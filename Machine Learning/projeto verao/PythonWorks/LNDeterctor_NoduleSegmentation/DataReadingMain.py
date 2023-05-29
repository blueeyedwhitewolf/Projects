# -*- coding: utf-8 -*-
"""
Created on Mon Aug  7 17:05:03 2017

@author: Elham
"""

import pickle
import numpy as np
from matplotlib import pyplot
from skimage import feature
from copy import deepcopy
#import matlab.engine
import TLBO
import SegmentedNodule3D


pyplot.close("all")

#eng = matlab.engine.start_matlab()

def DRM ( self ):       
    
    NodulePath = self.NodulePath
    
    with open ( NodulePath, 'rb' ) as PKFile:
         PatchFile = pickle.load(PKFile) 
    
    
    PathI = "C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/Image.mat"
    
    Slice = 26
    SliceM = 2  
    
    NoduleDatabase = {k: {} for k in range(1) }   
    BestCostMetaheuristic = []  
    
            
    ImageSize = np.shape(PatchFile[0])
    DetectedNodules = np.zeros([ImageSize[0],ImageSize[1],3]) 
    GTDetectedNodules = np.zeros([ImageSize[0],ImageSize[1],3])  
    GTDetectedNodules1 = np.zeros([ImageSize[0],ImageSize[1],3])
    GTDetectedNodules2 = np.zeros([ImageSize[0],ImageSize[1],3])
    
    
    # Main Cube Detected Nodule Images
    DetectedNodules[:,:,0] =  PatchFile[0][Slice,:,:]
    DetectedNodules[:,:,1] =  PatchFile[0][:,Slice,:]
    DetectedNodules[:,:,2] =  PatchFile[0][:,:,Slice]
    
    
    # Cube the Groundtruth Boundaries of Nodule Images 
    GTDetectedNodules[:,:,0] =  PatchFile[2][Slice,:,:]
    GTDetectedNodules[:,:,1] =  PatchFile[2][:,Slice,:]
    GTDetectedNodules[:,:,2] =  PatchFile[2][:,:,Slice]         
    
    
    GTDetectedNodules1[:,:,0] =  PatchFile[1][Slice,:,:]
    GTDetectedNodules1[:,:,1] =  PatchFile[1][:,Slice,:]
    GTDetectedNodules1[:,:,2] =  PatchFile[1][:,:,Slice]            
    
       
    for i in range ( len(PatchFile[6]) ):
        GTDetectedNodules2[:,:,0] =  GTDetectedNodules2[:,:,0] + PatchFile[6][i][Slice,:,:]
        GTDetectedNodules2[:,:,1] =  GTDetectedNodules2[:,:,1] + PatchFile[6][i][:,Slice,:]
        GTDetectedNodules2[:,:,2] =  GTDetectedNodules2[:,:,2] + PatchFile[6][i][:,:,Slice]
    
       
    # Find the Size and the Centerpoint of the Nodule        
    # DetectedNodules1 =  PatchFile[imgcounter][0]
    
    Size = np.shape(DetectedNodules)
    Centerpoint = list( (int(Size[0]/2)+1, int(Size[1]/2)+1, int(Size[2]/2)+1) )
    
    
    # %% Image Enhancement            
    
    ImageEnhanced = deepcopy( DetectedNodules )            
    
#    for q in range(Size[2]):  
#        Image = ImageEnhanced[:,:,q]
#        scipy.io.savemat( PathI, mdict={'arr': Image} ) 
#        ImageEnhanced[:,:,q] = eng.GaborFiltering()        
    
    
    # %% Image Feature Extraction              
    
    # Hessian Matrix and Eigen Values Computation 
    
    H = feature.hessian_matrix(ImageEnhanced, sigma=1, mode='constant', cval=0.0, order=None) 
    
    Eigon1 = np.zeros(Size)
    Eigon2 = np.zeros(Size)
    Eigon3 = np.zeros(Size)
    
    for i in range(Size[0]):  
        for j in range(Size[1]): 
            for q in range(Size[2]):  
                
                Hessian = np.matrix ( [ [ H[0][i][j][q], H[1][i][j][q], H[2][i][j][q] ], \
                                        [ H[1][i][j][q], H[3][i][j][q], H[4][i][j][q] ], \
                                        [ H[2][i][j][q], H[4][i][j][q], H[5][i][j][q] ] ] )
    
                Eig = np.linalg.eig( Hessian)
                
                Eigon1[i][j][q] = Eig[0][0]
                Eigon2[i][j][q] = Eig[0][1]
                Eigon3[i][j][q] = Eig[0][2]
                
    
    # Image Curvedness    
    CV = np.sqrt(Eigon1**2 + Eigon3**2) 
                            
    # %% Feature Matrix Creation
    
    FeatureMatrix = np.zeros( [ ( Size[0]*Size[1] ), 7, Size[2] ] )
        
    for q in range(Size[2]):          
        
        row = 0 
        
        for i in range (Size[0]): 
            for j in range (Size[1]):
            
                FeatureMatrix[row][0][q] = i
                FeatureMatrix[row][1][q] = j
                FeatureMatrix[row][2][q] = q
                
                FeatureMatrix[row][3][q] = ImageEnhanced[i][j][q]
                
                FeatureMatrix[row][4][q] = H[0][i][j][q]  
                FeatureMatrix[row][5][q] = H[3][i][j][q] 
                
                FeatureMatrix[row][6][q] = CV[i][j][q]
                
                                        
                row+= 1 
    
    # %% Nodule Segmentation  
    
    # Locate the Optimized Points of the Nodules using TLBO Algorithm 
    MaxIt = 100
    nPop = 50
    BestCostMetaheuristic = TLBO.Tl ( MaxIt, nPop, ImageEnhanced, GTDetectedNodules1, FeatureMatrix, SliceM, self )    
    
    
    # %% Nodule Database Information Storing
    
    NoduleDatabase[0]["filename"] = PatchFile[4]
    NoduleDatabase[0]["DetectedNodules"] = DetectedNodules
    NoduleDatabase[0]["SmoothDetectedNodules"] = ImageEnhanced
    NoduleDatabase[0]["GTDetectedNodulesIntersection"] = GTDetectedNodules
    NoduleDatabase[0]["GTDetectedNodulesUnion"] = GTDetectedNodules1
    NoduleDatabase[0]["GTDetectedNodulesCombine"] = GTDetectedNodules2
    NoduleDatabase[0]["DataFeaturesMatrix"] = FeatureMatrix
    NoduleDatabase[0]["Centerpoint"] = Centerpoint
    NoduleDatabase[0]["Size"] = Size
    NoduleDatabase[0]["Slice"] = Slice
    NoduleDatabase[0]["SliceM"] = SliceM
    
    
    del DetectedNodules,ImageEnhanced,GTDetectedNodules,GTDetectedNodules1,GTDetectedNodules2,Centerpoint, \
        ImageSize,nPop,H,Eig,Eigon1,Eigon2,Eigon3,CV,i,j,q,row,Hessian,PathI  
    
    
    #%% Nodule Segmentation
     
    [SI, GT3D, ImageM, SegmentedNoduleLabel, Measure] = SegmentedNodule3D.Seg ( BestCostMetaheuristic, NoduleDatabase, PatchFile )    
    
    
    return BestCostMetaheuristic, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure
