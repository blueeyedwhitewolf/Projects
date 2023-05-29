# -*- coding: utf-8 -*-
"""
Created on Wed Dec 12 16:47:04 2018

@author: Admin
"""

import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

import seaborn as sns
dataset=pd.read_csv('mary.csv')
sns.set(style='ticks',color_codes=True)
sns.pairplot(dataset.iloc[:,0:3],hue='Sensacao',palette='husl')
plt.show()

#parte II
from keras.utils import to_categorical
from keras.models import Sequential
from keras.layers import Dense
from keras.optimizers import SGD,Adam

model=Sequential()
model.add(Dense(2,input_dim=2,activation='tanh'))
model.add(Dense(1,activation='tanh'))
model.compile(Adam(lr=0.04),'binary_crossentropy',metrics=['accuracy']) #lr - learning rate

X=dataset.iloc[:,0:2].values
Y=dataset.iloc[:,2].values
X1=[k/10-1 for k in X.T[0]]
X2=[k/10-1 for k in X.T[1]]
X=np.column_stack((X1,X2))
print(X)
print(Y)
model.fit(X,Y,epochs=100) #treinar a rede

#Verificar se a rede esta bem treinada
Y_pred=model.predict_classes(X)
print(Y_pred)
print(Y)

#ver pesos na rede
print(model.get_weights())