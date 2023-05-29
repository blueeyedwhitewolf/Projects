# -*- coding: utf-8 -*-
"""
Created on Thu Nov 15 15:39:57 2018

@author: Admin
"""

import numpy as np
from sklearn.preprocessing import StandardScaler
from sklearn.neighbors import KNeighborsClassifier

inputx=np.loadtxt('cbr.txt',dtype='i',delimiter='\t')
x=inputx[...,0:2]
y=inputx[...,2]
#normalizar valores
scaler=StandardScaler()
scaler.fit(x)
x=scaler.transform(x)

#visualizar nova matriz
print(x)

model=KNeighborsClassifier(n_neighbors=1)
model.fit(x,y)
xx=np.array([[22,1]])
prever=model.predict(xx) #
print(prever) 
