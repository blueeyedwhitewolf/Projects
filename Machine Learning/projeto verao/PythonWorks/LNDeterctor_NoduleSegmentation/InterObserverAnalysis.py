# -*- coding: utf-8 -*-
"""
Created on Wed Jan 10 11:08:57 2018

@author: Elham
"""

import numpy as np
import scipy.io
#import matlab.engine
#eng = matlab.engine.start_matlab()
from copy import deepcopy

def InO ( GT3D, Measure, Slice ):     

# %% InterObserver 2.5D
     
    Jaccard = []
    Dice = [] 
    Avgdis = []
    PositivePr = []
    
    for i in range ( len(GT3D) ):         
        GT3D[i] = GT3D[i].astype('int')
    
    ImageSize = np.shape( GT3D[0] )
    
    for i in range ( len(GT3D) ):
         
         GT = np.zeros([ImageSize[0],ImageSize[1],3]).astype('int') 
         
         GT[:,:,0] = GT3D[i][Slice,:,:]
         GT[:,:,1] = GT3D[i][:,Slice,:]
         GT[:,:,2] = GT3D[i][:,:,Slice]
         
         for j in range ( len(GT3D) ):
             
             if ( j != i ):
                
                GT2_5D = np.zeros([ImageSize[0],ImageSize[1],3]).astype('int')  
         
                GT2_5D[:,:,0] = GT3D[j][Slice,:,:]
                GT2_5D[:,:,1] = GT3D[j][:,Slice,:]
                GT2_5D[:,:,2] = GT3D[j][:,:,Slice]
         
                # Jaccard Index JI
                JI = np.sum(np.logical_and(GT, GT2_5D)) / \
                                        np.sum(np.logical_or(GT, GT2_5D))
                
                # Dice Coefficient DSC   
                DC = (2 * np.sum(np.logical_and(GT, GT2_5D))) / \
                                        ( np.sum(GT) + np.sum(GT2_5D) )
                
     
                # Positive Predictive Value PPV
                PPV = np.sum(np.logical_and(GT2_5D, GT)) / np.sum(GT) 
                              
                # Hausdorff and Average Boundary Distance HD
#                PathG = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/GroundtruthNodule.mat"
#                scipy.io.savemat( PathG, mdict={'arr': GT} ) 
                
#                PathS = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/SegmentedNodule.mat"
#                scipy.io.savemat( PathS, mdict={'arr': GT2_5D} ) 
                

                AD = 0 #eng.AverageDist()                                          
                       
                 
                Jaccard.append( JI ) 
                Dice.append( DC ) 
                Avgdis.append( AD )
                PositivePr.append( PPV )
                 
        
    Measure[0][13] = "{0:.3f}".format( np.mean( Jaccard ) )
     
    Measure[0][14] = "{0:.3f}".format( np.mean( Dice ) )
    
    Measure[0][15] = "{0:.3f}".format( np.mean( Avgdis ) )
    
    Measure[0][16] = "{0:.3f}".format( np.mean( PositivePr ) )
    
    
    del ImageSize,i,GT,GT2_5D,JI,DC,PPV,AD,Jaccard,Dice,Avgdis,PositivePr
    
    
# %% InterObserver 3D
     
    Jaccard = []
    Dice = []
    Avgdis = []
    PositivePr = []
   
    
    for i in range ( len(GT3D) ):
         
         GT = deepcopy(GT3D[i])
         
         for j in range ( len(GT3D) ):
             
             if ( j != i ):
                 
                # Jaccard Index JI
                JI = np.sum(np.logical_and(GT, GT3D[j])) / \
                                        np.sum(np.logical_or(GT, GT3D[j]))
                
                # Dice Coefficient DSC   
                DC = (2 * np.sum(np.logical_and(GT, GT3D[j]))) / \
                                        ( np.sum(GT) + np.sum(GT3D[j]) ) 
        
                # Positive Predictive Value PPV
                PPV = np.sum(np.logical_and(GT3D[j], GT)) / np.sum(GT) 
                              
                # Hausdorff and Average Boundary Distance HD
#                PathG = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/GroundtruthNodule.mat"
#                scipy.io.savemat( PathG, mdict={'arr': GT} ) 
                
#                PathS = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/SegmentedNodule.mat"
#                scipy.io.savemat( PathS, mdict={'arr': GT3D[j]} ) 
                
                AD = 0 #eng.AverageDist() 
                                      
                                        
                Jaccard.append( JI ) 
                Dice.append( DC ) 
                Avgdis.append( AD )
                PositivePr.append( PPV )                
                
        
    Measure[0][17] = "{0:.3f}".format( np.mean( Jaccard ) )
     
    Measure[0][18] = "{0:.3f}".format( np.mean( Dice ) )
    
    Measure[0][19] = "{0:.3f}".format( np.mean( Avgdis ) )
    
    Measure[0][20] = "{0:.3f}".format( np.mean( PositivePr ) )
    
    
    del i,GT,GT3D,JI,DC,PPV,AD,Jaccard,Dice,Avgdis,PositivePr    
    
    return Measure
    