# -*- coding: utf-8 -*-
"""
Created on Wed Apr 25 10:01:39 2018

@author: Elham
"""

# -*- coding: utf-8 -*-
"""
Created on Wed Jun 28 13:27:37 2017

@author: Elham
"""

import numpy as np
from matplotlib import pyplot
from IPython import get_ipython


def PltSol(FeatureMatrix, sol, SmoothDetectedNodules, Slice, ResultsPath): 
    
    get_ipython().run_line_magic('matplotlib', 'inline')
    
    Cmap=['spring','summer','autumn','winter', 'cool','Pastel1','Set1','Pastel2','tab10','Set3', \
          'tab20','Set2','hsv','jet','tab20b','Paired','Accent']
        
#    ###########################################################
    # Sagittal    
    X = FeatureMatrix[:,:,Slice-2]
    
    # Cluster Centers
    m = sol.Position[:,:,Slice-2]
    k = len(m)
    
    # Cluster Indices
    ind=sol.Out["ind"]
    ind=ind[:,:,Slice-2]
    
    Size = np.shape(SmoothDetectedNodules[:,:,Slice-2])   
    
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,4)
    pyplot.xticks([]), pyplot.yticks([])    
    pyplot.imshow( SmoothDetectedNodules[:,:,Slice-2], cmap = 'gray', interpolation = 'none' )  
    for j in range(k):
        
        SegmentedNoduleLabel = np.zeros ( Size ).astype('bool')        
        for i in range ( np.shape(X)[0] ):             
            if (ind[i]==j):                
                SegmentedNoduleLabel[int(X[i][0])][int(X[i][1])] = 1
                
        masked = np.ma.masked_where(SegmentedNoduleLabel == 0, SegmentedNoduleLabel)  
        
        pyplot.hold(True) 
        pyplot.imshow( masked, cmap = Cmap[j], interpolation = 'none', alpha = 1 ) 
    
    ###########################################################
    # Coronal
    X = FeatureMatrix[:,:,Slice-1]
    
    # Cluster Centers
    m = sol.Position[:,:,Slice-1]
    k = len(m)
    
    # Cluster Indices
    ind=sol.Out["ind"]
    ind=ind[:,:,Slice-1]
    
    Size = np.shape(SmoothDetectedNodules[:,:,Slice-1])   
    
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,7)
    pyplot.xticks([]), pyplot.yticks([]) 
    pyplot.imshow( SmoothDetectedNodules[:,:,Slice-1], cmap = 'gray', interpolation = 'none' )  
    for j in range(k):
        
        SegmentedNoduleLabel = np.zeros ( Size ).astype('bool')        
        for i in range ( np.shape(X)[0] ):             
            if (ind[i]==j):                
                SegmentedNoduleLabel[int(X[i][0])][int(X[i][1])] = 1
                
        masked = np.ma.masked_where(SegmentedNoduleLabel == 0, SegmentedNoduleLabel)  
        
        pyplot.hold(True)
        pyplot.imshow( masked, cmap = Cmap[j], interpolation = 'none', alpha = 1 ) 
    
    ###########################################################
    # Axial
    X = FeatureMatrix[:,:,Slice]
    
    # Cluster Centers
    m = sol.Position[:,:,Slice]
    k = len(m)
    
    # Cluster Indices
    ind=sol.Out["ind"]
    ind=ind[:,:,Slice]
    
    Size = np.shape(SmoothDetectedNodules[:,:,Slice])    
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,1)
    pyplot.xticks([]), pyplot.yticks([])    
    pyplot.imshow( SmoothDetectedNodules[:,:,Slice], cmap = 'gray', interpolation = 'none' )  
    for j in range(k):
        
        SegmentedNoduleLabel = np.zeros ( Size ).astype('bool')        
        for i in range ( np.shape(X)[0] ):             
            if (ind[i]==j):                
                SegmentedNoduleLabel[int(X[i][0])][int(X[i][1])] = 1
                
        masked = np.ma.masked_where(SegmentedNoduleLabel == 0, SegmentedNoduleLabel)  
        
        pyplot.hold(True)
        pyplot.imshow( masked, cmap = Cmap[j], interpolation = 'none', alpha = 1 ) 
    
    
    del X,sol,SmoothDetectedNodules,m,k,ind,Cmap,j,i,Size,masked,SegmentedNoduleLabel,ResultsPath
    