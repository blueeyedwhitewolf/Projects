"""Auxiliar methods to deal with loading the dataset."""
import os
import random
import numpy as np
from keras import backend as K
from keras.preprocessing.image import Iterator, load_img, img_to_array
from keras.preprocessing.image import apply_transform, flip_axis
from keras.preprocessing.image import transform_matrix_offset_center
from skimage import color
from util.patch import Patches
#import time


class TwoImageIterator(Iterator):
    """Class to iterate A and B images at the same time."""

    def __init__(self, 
                 directory, 
                 a_dir_name='A', 
                 b_dir_name='B',
                 fnames_are_same = True, 
                 load_to_memory=False,
                 is_a_binary=False, 
                 is_b_binary=False, 
                 is_a_grayscale=False,
                 is_b_grayscale=False,
                 is_b_categorical=False,
                 is_b_to_normalize=True, 
                 target_size=(512, 512),
                 rotation_range=0., 
                 height_shift_range=0., 
                 width_shift_range=0.,
                 shear_range = 0., 
                 zoom_range=0., 
                 fill_mode='constant', 
                 cval=0.,
                 horizontal_flip=False, 
                 vertical_flip=False,
                 dim_ordering=K.image_dim_ordering(),
                 N=-1, 
                 batch_size=32, 
                 shuffle=True, 
                 seed = None,
                 normalize_tanh=False, 
                 add_hsv=False,
                 patch_divide=False, 
                 ptch_sz=64, 
                 ptch_str = 32,
                 mode = 'triclass_intersect',
                 labels=[]):
  
                      
        """
        Iterate through two directories at the same time.

        Files under the directory A and B with the same name will be returned
        at the same time.
        Parameters:
        - directory: base directory of the dataset. Should contain two
        directories with name a_dir_name and b_dir_name;
        - a_dir_name: name of directory under directory that contains the A
        images;
        - b_dir_name: name of directory under directory that contains the B
        images;
        - load_to_memory: if true, loads the images to memory when creating the
        iterator;
        - is_a_binary: converts A images to binary images. Applies a threshold of 0.5.
        - is_b_binary: converts B images to binary images. Applies a threshold of 0.5.
        - is_a_grayscale: if True, A images will only have one channel.
        - is_b_grayscale: if True, B images will only have one channel.
        - N: if -1 uses the entire dataset. Otherwise only uses a subset;
        - batch_size: the size of the batches to create;
        - shuffle: if True the order of the images in X will be shuffled;
        - seed: seed for a random number generator;
        - normalize_tanh: set to True if using tanh activation function.
        - add_hsv:
        """
        self.directory = directory

        self.a_dir = os.path.join(directory, a_dir_name)
        self.b_dir = os.path.join(directory, b_dir_name)

        a_files = set(x for x in os.listdir(self.a_dir))
        b_files = set(x for x in os.listdir(self.b_dir))
        if fnames_are_same is True:
        # Files inside a and b should have the same name. Images without a pair
        # are discarded.
            self.filenames = list(a_files.intersection(b_files))
            
            # Copia nomes para ficheiros mascaras - b
            self.b_fnames  = self.filenames
            
#            print"len(self.filenames):", (len(self.filenames))
#            print"self.filenames:", self.filenames
        else:
            self.filenames = sorted(os.listdir(self.a_dir))
            self.a_fnames = sorted(os.listdir(self.a_dir))
            self.b_fnames = sorted(os.listdir(self.b_dir))
        # Use only a subset of the files. Good to easily overfit the model
        if N > 0:
            random.shuffle(self.filenames)
            self.filenames = self.filenames[:N]
        self.N = len(self.filenames)
        
        
        
        self.dim_ordering = dim_ordering
       
       # Verfica se esta a  usar theano ou thensor flow
        if self.dim_ordering not in ('th', 'default', 'tf'):
            raise Exception('dim_ordering should be one of "th", "tf" or "default". '
                            'Got {0}'.format(self.dim_ordering))

        self.target_size = target_size

        self.is_a_binary = is_a_binary
        self.is_b_binary = is_b_binary
        self.is_a_grayscale = is_a_grayscale
        self.is_b_grayscale = is_b_grayscale
        self.is_b_to_normalize = is_b_to_normalize
        
        self.labels       = labels
        self.is_b_categorical = is_b_categorical
        if(self.labels==[]):
            self.is_b_categorical = False

        self.image_shape_a = self._get_image_shape(self.is_a_grayscale,False)
        self.image_shape_b = self._get_image_shape(self.is_b_grayscale,self.is_b_categorical)
        
        # movi esta flag para tras
        self.add_hsv = add_hsv
        self.load_to_memory = load_to_memory
        if self.load_to_memory:
            self._load_imgs_to_memory()

        if self.dim_ordering in ('th', 'default'):
            self.channel_index = 1
            self.row_index = 2
            self.col_index = 3
        if dim_ordering == 'tf':
            self.channel_index = 3
            self.row_index = 1
            self.col_index = 2

        self.rotation_range = rotation_range
        self.height_shift_range = height_shift_range
        self.width_shift_range = width_shift_range
        self.shear_range = shear_range
        self.fill_mode = fill_mode
        self.cval = cval
        self.horizontal_flip = horizontal_flip
        self.vertical_flip = vertical_flip

        self.normalize_tanh = normalize_tanh

        # Guarda nomes dos ficheiros de batch    
        self.batch_img_names = ["" for x in range(batch_size)] 
        
        self.patch_divide = patch_divide
        if self.patch_divide is True:
            self.ptch_sz = ptch_sz
            self.ptch_str = ptch_str
            self.ptch_shape_a = self._get_patch_shape(self.is_a_grayscale)
            self.ptch_shape_b = self._get_patch_shape(self.is_b_grayscale)
            self.mode = mode

        if np.isscalar(zoom_range):
            self.zoom_range = [1 - zoom_range, 1 + zoom_range]
        elif len(zoom_range) == 2:
            self.zoom_range = [zoom_range[0], zoom_range[1]]

        super(TwoImageIterator, self).__init__(len(self.filenames), batch_size,
                                               shuffle, seed)
        


                                               
        
        
    def _get_image_shape(self, is_grayscale,is_categorical):
        """Auxiliar method to get the image shape given the color mode."""
        if is_grayscale:
            if self.dim_ordering == 'tf':
                return self.target_size + (1,)
            else:
                return (1,) + self.target_size

        elif is_categorical:
            if self.dim_ordering == 'tf':
                return self.target_size + (len(self.labels),)
            else:
                return (len(self.labels),) + self.target_size
        else:
            if self.dim_ordering == 'tf':
                return self.target_size + (3,)
            else:
                return (3,) + self.target_size
                
                
                
                

    def _get_patch_shape(self, is_grayscale):
        """Auxiliar method to get the image shape given the color mode."""
        if is_grayscale:
            if self.dim_ordering == 'tf':
                return (self.ptch_sz,) + (self.ptch_sz,) + (1,)
            else:
                return (1,) + (self.ptch_sz,) + (self.ptch_sz,)

        else:
            if self.dim_ordering == 'tf':
#                return (self.ptch_sz,) + (self.ptch_sz,) + (len(self.labels),)
                return (self.ptch_sz,) + (self.ptch_sz,) + (3,)
            else:
                return (3,) + (self.ptch_sz,) + (self.ptch_sz,)
                
# ============================================================================
# ============================================================================
#  Devolve nome das imaches do batch
# ============================================================================
    def _get_batch_imgs_names(self):
        return self.batch_img_names
            
# ============================================================================
# ============================================================================
#  carrega set para a memoria
# ============================================================================
    def _load_imgs_to_memory(self):
        """Load images to memory."""
        if not self.load_to_memory:
            raise Exception('Can not load images to memory. Reason: load_to_memory = False')

        self.a = np.zeros((self.N,) + self.image_shape_a)
        self.b = np.zeros((self.N,) + self.image_shape_b)

        for idx in range(self.N):
            ai, bi = self._load_img_pair(idx, False)
            self.a[idx] = ai
            self.b[idx] = bi

    def _binarize(self, batch):
        """Make input binary images have 0 and 1 values only."""
        bin_batch = batch / 255.
        bin_batch[bin_batch >= 0.5] = 1
        bin_batch[bin_batch < 0.5] = 0
        return bin_batch

    def _normalize_for_tanh(self, batch):
        """Make input image values lie between -1 and 1."""
        tanh_batch = batch - 127.5
        tanh_batch /= 127.5
        return tanh_batch

# ============================================================================
# ============================================================================
#  Le um par de imagens para a memoria
# ============================================================================
    def _load_img_pair(self, idx, load_from_memory):
        """Get a pair of images with index idx."""
        if load_from_memory:
            a = self.a[idx]
            b = self.b[idx]
            return a, b

        a_fname = self.filenames[idx]
        b_fname = self.b_fnames[idx]

        a = load_img(os.path.join(self.a_dir, a_fname),
                     grayscale=self.is_a_grayscale,
                     target_size=self.target_size)
        b = load_img(os.path.join(self.b_dir, b_fname),
                     grayscale=True,
                     target_size=self.target_size)
                     
        
        a = np.array(a)
  
        if(len(a.shape)<3):
            a = a.reshape(self.image_shape_a)
            
        if(len(a.shape)<3):
            b = b.reshape(self.image_shape_a) 
        
        if self.add_hsv is True:

            a_hsv = color.convert_colorspace(a, 'RGB', 'HSV')

            a = np.concatenate((a, a_hsv), axis=2)

        if self.dim_ordering != 'tf':
            a = np.transpose(a, (2, 0, 1))
        b = img_to_array(b, self.dim_ordering)

        return a, b
        
       
        

    def _one_hot_enc(self, patch,input_is_grayscale = False,labels=[]):

        labels = np.array(labels)
        N_classes = labels.size
       
       
        if not input_is_grayscale:
            ptch_ohe = np.copy(patch)
            if np.max(patch) > 1:
                px = 255
            else:
                px = 1
            print "type(patch):", (type(patch))
            print "type(patch==[0,0,0]:", (type(patch==[0,0,0]))
            k = np.where((patch == [0,0,0]).all(axis=2))
            r = np.where((patch == [px,0,0]).all(axis=2))
            b = np.where((patch == [0,0,px]).all(axis=2))
            g = np.where((patch == [0,px,0]).all(axis=2))
            w = np.where((patch == [px,px,px]).all(axis=2))
        
            ptch_ohe[k] = [px, 0, 0]
            ptch_ohe[r] = [0, px, 0]
            ptch_ohe[b] = [0, 0, px]
            ptch_ohe[g] = [px, px, 0]
            ptch_ohe[w] = [px, px, px]
            
        else:
#            ptch_ohe = np.zeros(self.target_size+(3,))      
#                 
#            
#            
#            b = np.where((patch == 0).all(axis=2))
#            ll = np.where((patch == 3).all(axis=2))
#            rl = np.where((patch == 4).all(axis=2))
#          # g = np.where((patch == 5))
#           # w = np.where((patch == 6))
#        
#            
#            ptch_ohe[b] = [1, 0, 0]
#            ptch_ohe[ll] = [0, 1, 0]
#            ptch_ohe[rl] = [0, 0, 1]
#            #ptch_ohe[g] = [1, 1, 0]
#            #ptch_ohe[w] = [1, 1, 1]
         
         
         
          
          
         ptch_ohe = np.zeros(self.target_size+(N_classes,))
         for i,l in enumerate(labels):
            
            m = np.where((patch == l).all(axis=2))
            
            new_val = np.zeros(N_classes)
            new_val[i] = 1.
            
           

            ptch_ohe[m] = new_val           
        
         return ptch_ohe

    def _random_transform(self, a, b, is_batch = False):
        """
        Random dataset augmentation.

        Adapted from https://github.com/fchollet/keras/blob/master/keras/preprocessing/image.py
        """
       
        if is_batch is False:
        # a and b are single images, so they don't have image number at index 0
            img_row_index = self.row_index - 1
            img_col_index = self.col_index - 1
            img_channel_index = self.channel_index - 1
        else:
            img_row_index = self.row_index
            img_col_index = self.col_index
            img_channel_index = self.channel_index
        # use composition of homographies to generate final transform that needs to be applied
        if self.rotation_range:
            theta = np.pi / 180 * np.random.uniform(-self.rotation_range,
                                                    self.rotation_range)
        else:
            theta = 0
        rotation_matrix = np.array([[np.cos(theta), -np.sin(theta), 0],
                                    [np.sin(theta), np.cos(theta), 0],
                                    [0, 0, 1]])
        if self.height_shift_range:
            tx = np.random.uniform(-self.height_shift_range, self.height_shift_range) \
                 * a.shape[img_row_index]
        else:
            tx = 0

        if self.width_shift_range:
            ty = np.random.uniform(-self.width_shift_range, self.width_shift_range) \
                 * a.shape[img_col_index]
        else:
            ty = 0

        translation_matrix = np.array([[1, 0, tx],
                                       [0, 1, ty],
                                       [0, 0, 1]])

        if self.zoom_range[0] == 1 and self.zoom_range[1] == 1:
            zx, zy = 1, 1
        else:
            zx, zy = np.random.uniform(self.zoom_range[0], self.zoom_range[1], 2)
        zoom_matrix = np.array([[zx, 0, 0],
                                [0, zy, 0],
                                [0, 0, 1]])

        if self.shear_range:
            shear = np.random.uniform(-self.shear_range, self.shear_range)
        else:
            shear = 0
        shear_matrix = np.array([[1, -np.sin(shear), 0],
                                 [0, np.cos(shear), 0],
                                 [0, 0, 1]])

        transform_matrix = np.dot(np.dot(np.dot(rotation_matrix, translation_matrix), shear_matrix),
                                  zoom_matrix)

        h, w = a.shape[img_row_index], a.shape[img_col_index]
        transform_matrix = transform_matrix_offset_center(transform_matrix, h, w)
       
        a = apply_transform(a, transform_matrix, img_channel_index,
                            fill_mode=self.fill_mode, cval=self.cval)
        b = apply_transform(b, transform_matrix, img_channel_index,
                            fill_mode=self.fill_mode, cval=self.cval)

        if self.horizontal_flip:
            if np.random.random() < 0.5:
                a = flip_axis(a, img_col_index)
                b = flip_axis(b, img_col_index)

        if self.vertical_flip:
            if np.random.random() < 0.5:
                a = flip_axis(a, img_row_index)
                b = flip_axis(b, img_row_index)

        return a, b
# ========================================================================
# ========================================================================
#
# ========================================================================
    def next(self):
        """Get the next pair of the sequence."""

        # Lock the iterator when the index is changed.
        with self.lock:
            index_array, _, current_batch_size = next(self.index_generator)

        if self.add_hsv is True:
            if self.dim_ordering == 'tf':
                self.image_shape_a = self.target_size + (6,)
            else:
                self.image_shape_a = (6,) + self.target_size

        if self.patch_divide is True:

            ptch = Patches(sz_patch=[self.ptch_sz,self.ptch_sz],
                           stride=self.ptch_str, inFov=True,
                           mode=self.mode)

            batch_a = np.zeros((0,) + self.ptch_shape_a)
            batch_b = np.zeros((0,) + self.ptch_shape_b)
        else:
            batch_a = np.zeros((current_batch_size,) + self.image_shape_a)
            batch_b = np.zeros((current_batch_size,) + self.image_shape_b)
#            batch_filename = ["","","",""]

        cnt_batch_names = 0 
        for i, j in enumerate(index_array):
            a_img, b_img = self._load_img_pair(j, self.load_to_memory)
            
            # Image_names
            self.batch_img_names[cnt_batch_names] = self.filenames[j]
            cnt_batch_names = cnt_batch_names +1
            
            a_img, b_img = self._random_transform(a_img, b_img)
            
#            
            
            if self.is_b_to_normalize:
                b_img = self._normalize_for_tanh(b_img)
                
            
            if not self.is_b_binary and self.is_b_categorical:
                b_img = self._one_hot_enc(b_img,True,self.labels)
           

            if self.patch_divide is True:
                aux_a, _, aux_b = ptch.create_patches(a_img, gdt=b_img)
                a = np.zeros(aux_a.shape)
                b = np.zeros(aux_b.shape)
                for l in range(0, aux_a.shape[0]):
                    a[l], b[l] = self._random_transform(aux_a[l], aux_b[l])
                    ##print np.any(b[l]!=0)
                    if self.mode is 'triclass' or self.mode is 'triclass_intersect':
                        if np.max(a[l]) > 1:
                            px = 255
                        else:
                            px = 1
                        k = np.where((b[l] == [0,0,0]).all(axis=2))
                        ##print k
                        b[l][k] = [px, 0, 0]

                ##print aux_a.shape
                batch_a = np.concatenate((batch_a, a), axis=0)
                batch_b = np.concatenate((batch_b, b), axis=0)
            else:
                #a_img, b_img = self._random_transform(a_img, b_img)
                ##print a_img.shape
                batch_a[i] = a_img
                batch_b[i] = b_img
#                batch_filename[i]= self.filenames[j]
                
#             
                

        if self.is_a_binary:
            batch_a = self._binarize(batch_a)

        if self.add_hsv is True:
            if self.dim_ordering == 'tf':
                batch_a[:, :, :, :3] = batch_a[:, :3, :, :] / 255.
            else:
                batch_a[:, :3, :, :] = batch_a[:, :3, :, :] / 255.

        if self.normalize_tanh is True:
            batch_a = self._normalize_for_tanh(batch_a)
        else:
            batch_a = batch_a / 255.

        sh = batch_b.shape
        if self.is_b_binary and not self.is_b_categorical:
            batch_b = self._binarize(batch_b)
        elif not self.is_b_binary and self.patch_divide is True:
            if self.dim_ordering == 'tf':
                batch_b = np.reshape(batch_b, (sh[0], self.ptch_sz**2,
                                               sh[self.channel_index]))
            else:
                batch_b = np.reshape(batch_b, (sh[0], sh[self.channel_index],
                                               self.ptch_sz**2))
        elif not self.is_b_binary and self.patch_divide is False:
            if self.dim_ordering == 'tf':
                batch_b = np.reshape(batch_b, (sh[0], self.target_size[0]**2,
                                               sh[self.channel_index]))
            else:
                batch_b = np.reshape(batch_b, (sh[0], sh[self.channel_index],
                                               self.target_size[0]**2))

        if self.normalize_tanh is True:
            batch_b = self._normalize_for_tanh(batch_b)
        elif np.max(batch_b) > 1.:
            batch_b = batch_b / 255.
#
#        return [batch_a, batch_b,batch_filename]
#
        return [batch_a, batch_b]

    def generator(self):
        while 1:
            x,y = self.next()
            #print x.shape,y.shape
            yield x,y
