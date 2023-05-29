# -*- coding: utf-8 -*-
"""
Created on Fri Jan 12 10:39:13 2018

@author: Elham
"""

import numpy as np
from skimage import measure
from skimage import morphology
from scipy import ndimage
from copy import deepcopy
import Measurements
import VolumeEstimation
import InterObserverAnalysis

def Seg ( BestCostMetaheuristic, NoduleDatabase, PatchFile ): 
    
    Measure = np.zeros( [1, 21] )
        
    BestSol = BestCostMetaheuristic
    
    BestSolLast = deepcopy(BestSol[len(BestSol)-1])     
    
    NoduleInformation = NoduleDatabase[0]
    
    Slice = NoduleDatabase[0]["Slice"]
    
    CenterPoint = [NoduleInformation["Centerpoint"][0], NoduleInformation["Centerpoint"][1]]

# %% Extracting te Results  
      
    SegmentedNoduleLast = np.zeros ( NoduleInformation["Size"] ).astype('int')           
                
    ClusterIndexLast = BestSolLast[2]["ind"].reshape(NoduleInformation["Size"] ).astype('int')
    
    SegmentedNoduleLast = deepcopy(ClusterIndexLast )
    
    for q in range ( np.shape(SegmentedNoduleLast)[2] ):  
        
        CenterIndex = ClusterIndexLast[NoduleInformation["Centerpoint"][0]][NoduleInformation["Centerpoint"][1]][q]
    
        for i in range ( np.shape(SegmentedNoduleLast)[0] ):        
            for j in range ( np.shape(SegmentedNoduleLast)[1] ):  
                if ( SegmentedNoduleLast[i][j][q] == CenterIndex ):
                    SegmentedNoduleLast[i][j][q] = 1
                else:
                    SegmentedNoduleLast[i][j][q] = 0
                

# %% Extract the Region having the Same Label as the Label of the CentroidPoint
    
    SegmentedNoduleLabel = np.zeros ( NoduleInformation["Size"] ).astype('int')
    
    for q in range ( np.shape(SegmentedNoduleLabel)[2] ): 
        
        SegmentedLabel = measure.label( SegmentedNoduleLast[:,:,q] ) 
        
        CenterLabel = SegmentedLabel[NoduleInformation["Centerpoint"][0]][NoduleInformation["Centerpoint"][1]]              
        
        for i in range ( np.shape(SegmentedLabel)[0] ):        
            for j in range ( np.shape(SegmentedLabel)[1] ):  
                if ( SegmentedLabel[i][j] == CenterLabel ):
                    SegmentedLabel[i][j] = 1
                else:
                    SegmentedLabel[i][j] = 0             
    
        SegmentedNoduleLabel[:,:,q] = SegmentedLabel
                
        
# %% Morphological Operations 
        
    for q in range ( np.shape(SegmentedNoduleLabel)[2] ): 
        
        SegmentedNoduleLabel[:,:,q] = ndimage.binary_fill_holes(SegmentedNoduleLabel[:,:,q])   
        
        SI = deepcopy(SegmentedNoduleLabel[:,:,q])
        SIC = np.logical_not(SI).astype('int')
        SICH=deepcopy(SIC)
        
        SIC=measure.label( SIC )
        Max=0
        for Index in range( 1,np.max(SIC)+1 ):
            count=len(np.where(SIC==Index)[0])
            if (count > Max):
                Max = count
                In = Index
        for i in range ( np.shape(SIC)[0] ):        
            for j in range ( np.shape(SIC)[1] ):  
                if ( SIC[i][j] == In ):
                    SIC[i][j] = 1
                    SICH[i][j] = 0
                else:
                    SIC[i][j] = 0
        
        SI = np.logical_or(SI,SICH).astype('int')
        
        SIC = np.logical_not(SI).astype('int')
        Convexhull = morphology.convex_hull_image(SIC == 1).astype('int')
        
        
        SI = np.logical_not( Convexhull - SI ).astype('int')
       
        SILabel = measure.regionprops( measure.label( SI ) ) 
        SIF = np.zeros([NoduleInformation["Size"][0],NoduleInformation["Size"][1]]).astype('int')
        for label in  SILabel: 
            coordinates = label.coords
            Flag = 0
            for i in range ( len(coordinates) ):
                if ( coordinates[i][0] ==CenterPoint[0] and coordinates[i][1] ==CenterPoint[1] ):
                    Flag = 1
                    break 
            if ( Flag ==1 ):                    
                for i in range ( np.shape(coordinates)[0] ):                             
                    SIF[coordinates[i][0]][coordinates[i][1]] = 1 
                        
                        
        SegmentedNoduleLabel[:,:,q] = deepcopy(SIF)
        
        
        if ( len(np.where( SegmentedNoduleLabel[:,:,q]==1 )[0]) ) >15:
            
            selem = morphology.square(1)    
            SegmentedNoduleLabel[:,:,q] = morphology.binary_dilation( SegmentedNoduleLabel[:,:,q], selem ) 
            
            selem = morphology.disk(1)    
            SegmentedNoduleLabel[:,:,q] = morphology.binary_dilation( SegmentedNoduleLabel[:,:,q], selem ) 
                    
        else: 
            
            selem = morphology.square(2)    
            SegmentedNoduleLabel[:,:,q] = morphology.binary_dilation( SegmentedNoduleLabel[:,:,q], selem ) 
            
            selem = morphology.disk(1)    
            SegmentedNoduleLabel[:,:,q] = morphology.binary_dilation( SegmentedNoduleLabel[:,:,q], selem ) 
    
    
# %% Removing the Small Regions after Morphological Operaions  

    SegmentedNoduleLabel1 = deepcopy(SegmentedNoduleLabel)
    SegmentedNoduleLabel = np.zeros ( NoduleInformation["Size"] ).astype('int')            
    
    for q in range ( np.shape(SegmentedNoduleLabel)[2] ): 
        
        SegmentedLabel = measure.label( SegmentedNoduleLabel1[:,:,q] )  
        
        RegionProps  =measure.regionprops( SegmentedLabel ) 
        
        coordinates = []
        
        for label in  RegionProps: 
            
            coordinates = label.coords
            
            Flag = 0
            for i in range ( len(coordinates) ):
                if ( coordinates[i][0] ==CenterPoint[0] and coordinates[i][1] ==CenterPoint[1] ):
                    Flag = 1
                    break                            
            
            if ( Flag ==1 ):                    
                for i in range ( np.shape(coordinates)[0] ):                             
                    SegmentedNoduleLabel[coordinates[i][0]][coordinates[i][1]][q] = 1
          

# %% Similarity Computation of Segmentation Results and the Groundtruth Images 
                
    SI = deepcopy( SegmentedNoduleLabel )

    Measure = Measurements.M ( SI, PatchFile[6], Measure, Slice )
                
    Measure = VolumeEstimation.Vol ( SI, PatchFile[6], Measure, Slice )

    Measure = InterObserverAnalysis.InO ( PatchFile[6], Measure, Slice )


# %%
    
    del BestSol,BestSolLast,NoduleInformation,SegmentedNoduleLast,SegmentedNoduleLabel1,\
        ClusterIndexLast,CenterIndex,CenterLabel,i,j,selem,coordinates, RegionProps,SegmentedLabel,q,CenterPoint,Flag, \
        Convexhull,Max,SILabel,count,Index, BestCostMetaheuristic,NoduleDatabase,Slice,SIC,SICH,SIF,In
    
    return SI, PatchFile[6], PatchFile[0], SegmentedNoduleLabel, Measure
