# -*- coding: utf-8 -*-
"""
Created on Mon Feb 26 18:13:42 2018

@author: Elham
"""

import numpy as np
from skimage import measure


def Vol ( SI, GT3D, Measure, Slice ):    
    
    radious=[]
    for i in range (3):
        RegionProps  = measure.regionprops( SI[:,:,i] )        
        for label in  RegionProps:         
            D = label.major_axis_length  
        radious.append(D/2) 
    SIVolume = (4/3) * np.pi * radious[0] * radious[1] * radious[2]
        
    
    GTV = []
    ImageSize = np.shape( GT3D[0] )    
    for j in range ( len(GT3D) ):
         
        GT = np.zeros( [ImageSize[0],ImageSize[1],3] ).astype('int') 
         
        GT[:,:,0] = GT3D[j][Slice,:,:]
        GT[:,:,1] = GT3D[j][:,Slice,:]
        GT[:,:,2] = GT3D[j][:,:,Slice]       
        
        radious=[]
        for i in range (3):
            RegionProps  = measure.regionprops( GT[:,:,i] )        
            for label in  RegionProps:         
                D = label.major_axis_length  
            radious.append(D/2)         
        GTV.append( (4/3) * np.pi * radious[0] * radious[1] * radious[2] )
    
    GTVolume = np.mean( GTV )

    
    GT3DV = [] 
    for j in range ( len(GT3D) ):
         
        GT = GT3D[j].astype('int')
        
        RegionProps  =measure.regionprops( GT )    
        for label in  RegionProps:         
            radious = (label.equivalent_diameter) / 2               
        GT3DV.append( (4/3) * np.pi * pow( radious, 3 ) )
 
    GT3DVolume = np.mean( GT3DV )

   
    GT3DVR = [] 
    for j in range ( len(GT3D) ):
         
        GT = GT3D[j]
        GT3DVR.append( len(np.where(GT)[0])  )
    
    GT3DVolumeR = np.mean( GT3DVR )
      
    
    Measure[0][9] = "{0:.3f}".format( SIVolume )
    Measure[0][10] = "{0:.3f}".format( GTVolume )
    Measure[0][11] = "{0:.3f}".format( GT3DVolume )    
    Measure[0][12] = "{0:.3f}".format( GT3DVolumeR )

    
    del SI,GT,GT3D,Slice,radious,i,label,D,SIVolume,GTVolume,GT3DVolume,GT3DVolumeR
    del GTV,GT3DV,GT3DVR
    
    return Measure  
    
