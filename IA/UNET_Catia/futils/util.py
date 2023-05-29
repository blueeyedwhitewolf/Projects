# -*- coding: utf-8 -*-
"""
Created on Tue Apr  4 09:35:14 2017

@author: fferreira
"""
import os
import pickle
import numpy as np
import collections

import SimpleITK as sitk

from skimage.io import imsave
import nrrd


MIN_BOUND = -1000.0
MAX_BOUND = 400.0
#%%
def get_UID(file_name):
    print(file_name)
    if(os.path.isfile(file_name)):
        file = open(file_name,'rb')    
        try:        
            data = pickle.load(file)
            print(data)
            file.close()
            
            return data
        except Exception as inst:
            print type(inst)     # the exception instance
      
            print inst           # __str__ allows args to be printed directly

            print('no pickle here')
            return [],[],[]
    print 'nop'
    return[],[],[]
   
#%%    
def get_scan(file_name):
    if(os.path.isfile(file_name)):
        file = open(file_name,'rb')    
        data = pickle.load(file)
        file.close()
        return np.rollaxis(data,2)[::-1]
    else:
        return[],[],[]
#%%
def load_itk(filename,original=False):
    # Reads the image using SimpleITK
    if(os.path.isfile(filename) ):
        itkimage = sitk.ReadImage(filename)
    else:
        return [],[],[]

    # Convert the image to a  numpy array first ands then shuffle the dimensions to get axis in the order z,y,x
    ct_scan = sitk.GetArrayFromImage(itkimage)
        
    #ct_scan[ct_scan>4] = 0 #filter trachea (label 5)
    # Read the origin of the ct_scan, will be used to convert the coordinates from world to voxel and vice versa.
    origin = np.array(list(reversed(itkimage.GetOrigin())))

    # Read the spacing along each dimension
    spacing = np.array(list(reversed(itkimage.GetSpacing())))

    
    
    return ct_scan, origin, spacing
#%%
def save_itk(filename,scan,origin,spacing):
    
        
        stk = sitk.GetImageFromArray(scan.astype('uint8'))
        stk.SetOrigin(origin[::-1])
        stk.SetSpacing(spacing[::-1])
        
        
        writer = sitk.ImageFileWriter()
        writer.Execute(stk,filename,True)
#%%

def load_nrrd(filename):
        readdata, options = nrrd.read(filename)
        return np.transpose(np.array(readdata).astype(float))
                
#%% Save in _nii.gz format
def save_nii(dirname,savefilename,lung_mask):    
    
    array_img = nib.Nifti1Image(lung_mask, affine=None, header=None)
    nib.save(array_img, os.path.join(dirname,savefilename))
    
def save_slice_img(folder,scan,uid):
    print(uid,scan.shape[0])    
    for i,s in enumerate(scan):
        imsave(os.path.join(folder,uid+'sl_'+str(i)+'.png'),s)
#%%
def normalize(image,min_=MIN_BOUND,max_=MAX_BOUND):
    image = (image - min_) / (max_ - min_)
    image[image>1] = 1.
    image[image<0] = 0.
    return image
#%%
def dice(seg,gt):
    
    im1 = np.asarray(seg).astype(np.bool)
    im2 = np.asarray(gt).astype(np.bool)

    
    if im1.shape != im2.shape:
        raise ValueError("Shape mismatch: im1 and im2 must have the same shape.")

    
    intersection = np.logical_and(im1, im2).sum()
   
    return 2. * intersection / (im1.sum() + im2.sum())    
#%%
def dice_mc(seg,gt):
        
    labels= np.unique(seg)
    print(labels)
    dices = np.zeros(len(labels))    
    for i,l in enumerate(labels):
        im1 = seg==l
        im2 = gt ==l
        
        dices[i] = dice(im1,im2)
    
    return dices    
    
   

#%%
def recall(seg,gt):
    
    im1 = np.asarray(seg>0).astype(np.bool)
    im2 = np.asarray(gt>0).astype(np.bool)

    
    if im1.shape != im2.shape:
        raise ValueError("Shape mismatch: im1 and im2 must have the same shape.")

    intersection = np.logical_and(im1, im2).astype(float)

    
    if(im2.sum()>0):
        return intersection.sum() / ( im2.sum())    
    else:
        return 1.0    
    