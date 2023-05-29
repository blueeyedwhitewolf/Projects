# -*- coding: utf-8 -*-
"""
Created on Fri Jan 12 09:33:35 2018

@author: Elham
"""

import numpy as np
import scipy.io
#import matlab.engine
#eng = matlab.engine.start_matlab()


def M ( SI, GT3D, Measure, Slice ):
    
    Jaccard = []
    Dice = [] 
    Underseg = []
    Overseg = []
    Absv = []
    Sensivity = []
    Pospred = []
    Hausdorff = []
    ADis = []
    
    ImageSize = np.shape( GT3D[0] )
    
    for i in range ( len(GT3D) ):
         
        GT = np.zeros([ImageSize[0],ImageSize[1],3]).astype('int')
         
        GT[:,:,0] = GT3D[i][Slice,:,:]
        GT[:,:,1] = GT3D[i][:,Slice,:]
        GT[:,:,2] = GT3D[i][:,:,Slice]   
         
        # Jaccard Index JI
        JI = np.sum(np.logical_and(GT, SI)) / np.sum(np.logical_or(GT, SI))
        
        # Dice Coefficient DSC   
        DC = (2 * np.sum(np.logical_and(GT, SI))) / ( np.sum(SI) + np.sum(GT) )
        
        # Under-segmentation Ratio UR
        UR = 1 - ( np.sum(np.logical_and(GT, SI)) / np.sum(GT) ) 
        
        # Over-segmentation Ratio OR
        OR = 1 - ( np.sum(np.logical_and(GT, SI)) / np.sum(SI) )
        
        # Absolute Volume Difference AVD
        AVD = np.abs( np.sum(SI) - np.sum(GT) ) 
        
        # Sensivity SEN
        SEN = np.sum(np.logical_and(GT, SI)) / np.sum(GT) 
        
        # Positive Predictive Value PPV
        PPV = np.sum(np.logical_and(GT, SI)) / np.sum(SI) 
        
        # Hausdorff and Average Boundary Distance HD
        PathG = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/GroundtruthNodule.mat"
        scipy.io.savemat( PathG, mdict={'arr': GT} ) 
        
        PathS = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/SegmentedNodule.mat"
        scipy.io.savemat( PathS, mdict={'arr': SI} ) 
        
        HD = 0 #eng.HausdorffDist()   
        
        AD = 0 #eng.AverageDist()  
                                
        Jaccard.append( JI ) 
        Dice.append( DC ) 
        Underseg.append ( UR )
        Overseg.append ( OR )
        Absv.append ( AVD )
        Sensivity.append ( SEN )
        Pospred.append ( PPV )
        Hausdorff.append ( HD )
        ADis.append ( AD )
        
    
    # Jaccard Index JI
    Measure[0][0] = "{0:.3f}".format( np.mean( Jaccard ) )
    
    # Dice Coefficient DSC   
    Measure[0][1] = "{0:.3f}".format( np.mean( Dice ) )
    
    # Under-segmentation Ratio UR
    Measure[0][2] = "{0:.3f}".format( np.mean( Underseg ) )
    
    # Over-segmentation Ratio OR
    Measure[0][3] = "{0:.3f}".format( np.mean( Overseg ) )
    
    # Absolute Volume Difference AVD
    Measure[0][4] = "{0:.3f}".format( np.mean( Absv ) )
    
    # Sensivity SEN
    Measure[0][5] = "{0:.3f}".format( np.mean( Sensivity ) )
    
    # Positive Predictive Value PPV
    Measure[0][6] = "{0:.3f}".format( np.mean( Pospred ) ) 
    
    # Hausdorff Distance
    Measure[0][7] = "{0:.3f}".format( np.mean( Hausdorff ) )   
    
    # Average Boundary Distance    
    Measure[0][8] = "{0:.3f}".format( np.mean( ADis ) )     
    

    del ImageSize,i,GT,GT3D,SI,PathG,PathS,JI,DC,UR,OR,AVD,SEN,PPV,HD,AD
    del Jaccard,Dice,Underseg,Overseg,Absv,Sensivity,Pospred,Hausdorff,ADis
    
        
    return Measure 