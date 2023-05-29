"""
The U-Net
"""
from keras.layers import Input, merge 
from keras.layers.core import Activation, Reshape , Lambda
from keras.layers.convolutional import Convolution2D
from keras.layers.normalization import BatchNormalization
from keras.models import Model
from keras.layers import UpSampling2D
from keras import backend as K
import numpy as np


# funcoes dice

def dice_coef(y_true, y_pred):
    """ 
    Returns overall dice coefficient after supressing the background
    
    TODO : Choose channel(and axis) of background    
    """
    #flatten after select only foreground layers (lambda)
    y_true_f = K.flatten(Lambda(lambda y_true : y_true[:,:,1:])(y_true))
    y_pred_f = K.flatten(Lambda(lambda y_pred : y_pred[:,:,1:])(y_pred))

    
    smooth = 1
#    smooth = 0.5
       
    intersection = K.sum(y_true_f * y_pred_f)
    return (2. * intersection + smooth) / (K.sum(y_true_f) + K.sum(y_pred_f) + smooth)

def dice_coef_weight(y_true, y_pred):
    """
    Returns the product of dice coefficient for each class 
    it assumes channel 0 as background 
    
    TODO : Choose channel (and axis) of background 
           Choose other merge methods (sum,avg,etc)
    """
    
    y_true_f = (Lambda(lambda y_true : y_true[:,:,0:])(y_true))
    y_pred_f = (Lambda(lambda y_pred : y_pred[:,:,0:])(y_pred))
       
    product = merge([y_true_f,y_pred_f], mode= "mul")
    
   
    red_y_true = K.sum(y_true_f,axis=[0,1])
    red_y_pred = K.sum(y_pred_f,axis=[0,1])
    red_product= K.sum(product ,axis=[0,1])
    
    
    smooth = 1
#    smooth = 0.5
    dices = (2.*red_product+smooth)/(red_y_true+red_y_pred+smooth)
    
    
    ratio_y_pred = red_y_true/(K.sum(red_y_true)+smooth)
    
    
    ratio_y_pred = 1.0-ratio_y_pred
    
    ratio_y_pred = ratio_y_pred / K.sum(ratio_y_pred)
   
    
    return K.sum(merge([dices,ratio_y_pred],mode='mul'))
    
def dice_coef_weight_r(y_true, y_pred):
    """
    Returns the product of dice coefficient for each class 
    it assumes channel 0 as background 
    
    TODO : Choose channel (and axis) of background 
           Choose other merge methods (sum,avg,etc)
    """
    
    y_true_f = (Lambda(lambda y_true : y_true[:,:,0:])(y_true))
    y_pred_f = (Lambda(lambda y_pred : y_pred[:,:,0:])(y_pred))
       
    product = merge([y_true_f,y_pred_f], mode= "mul")
    
   
    red_y_true = K.sum(y_true_f,axis=[0,1])
    red_y_pred = K.sum(y_pred_f,axis=[0,1])
    red_product= K.sum(product ,axis=[0,1])
    
    smooth = 1
#    smooth = 0.5
    
    dices = (2.*red_product+smooth)/(red_y_true+red_y_pred+smooth)
    
    
    ratio_y_pred = red_y_true/(K.sum(red_y_true)+smooth)
    
    ratio_y_pred = K.pow(ratio_y_pred+0.1,-1.0)
   
   
    ratio_y_pred = ratio_y_pred / K.sum(ratio_y_pred)
 
    
    return K.sum(merge([dices,ratio_y_pred],mode='mul'))
    
    
def dice_coef_prod(y_true, y_pred):
    """
    Returns the product of dice coefficient for each class 
    it assumes channel 0 as background 
    
    TODO : Choose channel (and axis) of background 
           Choose other merge methods (sum,avg,etc)
    """
    
    y_true_f = (Lambda(lambda y_true : y_true[:,:,1:])(y_true))
    y_pred_f = (Lambda(lambda y_pred : y_pred[:,:,1:])(y_pred))
       
    product = merge([y_true_f,y_pred_f], mode= "mul")
    
   
    red_y_true = K.sum(y_true_f,axis=[0,1])
    red_y_pred = K.sum(y_pred_f,axis=[0,1])
    red_product= K.sum(product ,axis=[0,1])
    
    
    smooth = 1
#    smooth = 0.5
    dices = (2.*red_product+smooth)/(red_y_true+red_y_pred+smooth)
    
    
  
    
    
    return K.prod(dices)

def dice_coef_mean(y_true, y_pred):
    """
    Returns the product of dice coefficient for each class 
    it assumes channel 0 as background 
    
    TODO : Choose channel (and axis) of background 
           Choose other merge methods (sum,avg,etc)
    """
    
    y_true_f = (Lambda(lambda y_true : y_true[:,:,1:])(y_true))
    y_pred_f = (Lambda(lambda y_pred : y_pred[:,:,1:])(y_pred))
       
    product = merge([y_true_f,y_pred_f], mode= "mul")
    
   
    red_y_true = K.sum(y_true_f,axis=[0,1])
    red_y_pred = K.sum(y_pred_f,axis=[0,1])
    red_product= K.sum(product ,axis=[0,1])
    
    
    smooth = 1
#    smooth = 0.5
    dices = (2.*red_product+smooth)/(red_y_true+red_y_pred+smooth)
    
    
  
    
    
    return K.mean(dices)
    
    
    
def dice_coef_loss(y_true, y_pred):
    return -dice_coef(y_true, y_pred)
#    return -dice_coef_weight(y_true, y_pred)
    
def dice_coef_loss_r(y_true, y_pred):
    return -dice_coef_weight_r(y_true, y_pred)
    
    
##################################################################
    #################################################################
    #########################################################################################333
    
    
class unet():
    """ class that defines a u shaped network (U-Net). """
    def __init__(self, nch, sz,n_channels=3):

        self.sz = sz
        self.nch = nch
        self.nlayers = int(np.floor(np.log(sz)/np.log(2)))+1
        self.n_channels = n_channels

        if K.image_dim_ordering() == 'th':
            self.ch_indx = 1
        elif K.image_dim_ordering() == 'tf':
            self.ch_indx = 3

    # Define the neural network
    def get_unet(self, nf):
        if K.image_dim_ordering() == 'th':
            inputs = Input((self.nch, self.sz, self.sz))
        elif K.image_dim_ordering() == 'tf':
            inputs = Input((self.sz, self.sz, self.nch))

        conv1 = []
        # nch x sz x sz
        conv = Convolution2D(nf, 3, 3, border_mode='same')(inputs)
        conv = BatchNormalization()(conv)
        conv1.append(Activation('relu')(conv))
        # nfxnch x sz x sz

        for ii in range(1, self.nlayers):

            if ii < 8:
                nnf = nf * ii
            else:
                nnf = nf * 8
            if ii == self.nlayers-1:
                conv = Convolution2D(nnf, 2, 2, border_mode='valid')(conv1[ii-1])
            else:
                conv = Convolution2D(nnf, 3, 3, border_mode='same',
                                     subsample=(2, 2))(conv1[ii-1])
            conv = BatchNormalization()(conv)
            conv = Activation('relu')(conv)
            conv1.append(conv)

        upconv1 = conv1[-1]
        ind = 0
        for xx in range(self.nlayers-2, -1, -1):

            if xx < 8 and xx > 0:
                nnf = nf * xx
            elif xx <= 0:
                nnf = 1
            else:
                nnf = nf * 8

            up = merge([UpSampling2D(size=(2, 2))(upconv1), conv1[xx]],
                       mode='concat', concat_axis=self.ch_indx)
            upconv = Convolution2D(nnf * 8, 3, 3, border_mode='same')(up)
            upconv = BatchNormalization()(upconv)
            upconv = Activation('relu')(upconv)
            # conv7 = Dropout(0.2)(conv7)
            if xx > 0:
                upconv = Convolution2D(nnf * 8, 3, 3, border_mode='same')(upconv)
                upconv = BatchNormalization()(upconv)
                upconv1 = Activation('relu')(upconv)
                ind += 1
                # nf*8 x 2 x 2
            else:
                pass

        upconv = Convolution2D(self.n_channels, 3, 3, border_mode='same')(upconv) #3 classes

        resh = Reshape((self.sz * self.sz, self.n_channels))(upconv)

        act = 'softmax'
        out = Activation(act)(resh)


        model = Model(input=inputs, output=out)
        
        #alteracao para obter precisao e sensibilidade
        
        model.compile(optimizer='sgd', loss='categorical_crossentropy',metrics=['accuracy'])
      

        return model

    