# -*- coding: utf-8 -*-
"""
Created on Wed Jun 28 13:11:25 2017

@author: Elham
"""

import numpy as np
from scipy.spatial import distance


def ClC(m,X):  
    
    X = X[:, 3:, :]
    
    m = m[:, 3:, :]
    
    dmin = np.zeros( [np.shape(X)[0], 1, np.shape(X)[2]] )
    ind = np.zeros( [np.shape(X)[0], 1, np.shape(X)[2]] )
    
    
    # Calculate Distance Matrix  
    for q in range ( np.shape(X)[2] ):
        
        d = distance.cdist(X[:,:,q], m[:,:,q], 'euclidean')
    
        # Assign Clusters and Find Closest Distances
        dmin[:,0,q], ind[:,0,q] = d.min(axis=1), d.argmin(axis=1)
    
    
    # Sum of Within-Cluster Distance
    WCD = np.sum(dmin)
    
    z=WCD

    # Empty dict
    out={}       
        
    out["d"] = d
    out["dmin"] = dmin
    out["ind"] = ind
    out["WCD"] = WCD  
    
    del d,X,m,dmin,ind,WCD    
    
    return z,out
