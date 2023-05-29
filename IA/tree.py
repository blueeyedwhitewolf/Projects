# -*- coding: utf-8 -*-
"""
Created on Thu Jan 10 14:53:00 2019

@author: Admin
"""

import numpy as np
from sklearn import tree

x=[[2,2,1,1],
   [2,2,1,0],
   [0,1,1,0],
   [1,2,1,0],
   [0,0,0,0],
   [0,0,0,1],
   [1,0,0,1],
   [2,1,1,0],
   [2,0,0,0],
   [0,1,0,0],
   [2,1,0,1],
   [1,1,1,1],
   [1,2,0,0],
   [0,0,1,1]]

y=['NAO','NAO','SIM','SIM','SIM','NAO','SIM','NAO','SIM','SIM','SIM','SIM','SIM','NAO']

clf=tree.DecisionTreeClassifier()

clf.fit(x,y)

xnew=[[0,0,1,1],
      [1,2,0,0],
      [1,2,1,1]]

ynew=clf.predict(xnew)

print(ynew)