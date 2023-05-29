# -*- coding: utf-8 -*-
"""
Created on Mon Aug  7 11:36:39 2017

@author: Elham
"""

from copy import deepcopy
import numpy as np
import ClusteringCost


def Tl ( MaxIt, nPop, ImageEnhanced, GTDetectedNodules, FeatureMatrix, Slice, self ): 
    
# %% Teaching Learning Based Optimization Algorithm Parameters and Problem Definition
    
# Create Initial Solutions   
    
    k=15                                                                          # Number of Clusters    
            
# Problem Definition

    VarSize=[ k,np.shape(FeatureMatrix)[1],np.shape(FeatureMatrix)[2] ]           # Decision Variables Matrix Size
    
    VarMin=np.zeros( VarSize )   
    for q in range ( VarSize[2] ):                                                # Lower Bound of Variables
        for i in range( VarSize[0] ):
            for j in range( VarSize[1] ):        
                VarMin[i][j][q] = np.min( FeatureMatrix[:,j,q] )                 
    
        
    VarMax=np.zeros( VarSize )
    for q in range ( VarSize[2] ):                                                # Upper Bound of Variables
        for i in range( VarSize[0] ):
            for j in range( VarSize[1] ):        
                VarMax[i][j][q] = np.max( FeatureMatrix[:,j,q] )   
    
                
# %% Initialization

# Empty Structure for Individuals
    class empty_individual:
          Position=[]
          Cost=[]
          Out=[]
    
# Initialize Nodule Points
    pop=list()    
    for i in range(nPop):
        pop.append([]) 
        pop[i].append(empty_individual.Position) 
        pop[i].append(empty_individual.Cost) 
        pop[i].append(empty_individual.Out)
        
# Initialize Best Solution Ever Found
    class BestSol:
          Position=[]
          Cost=np.inf
          Out=[]
          
# Create Initial Population
    for i in range (nPop):
        
        pop[i][0]=np.random.uniform(VarMin,VarMax,VarSize)  
        [pop[i][1],pop[i][2]]=ClusteringCost.ClC(pop[i][0],FeatureMatrix) 
        
        if (pop[i][1]<BestSol.Cost):
            BestSol.Position=pop[i][0]
            BestSol.Cost=pop[i][1]
            BestSol.Out=pop[i][2]   


# Array to Hold Best Cost Values    
    BestCost=list()    
    for i in range(MaxIt):
        BestCost.append( [[],[],[]] )      

    
# %% TLBO Algorithm Main Loop
    
    for it in range (MaxIt):         
        
# Calculate Population Mean
        Mean = 0
        for i in range (nPop):
            Mean = Mean + pop[i][0]
        
        Mean = Mean/nPop  
       
# Select Teacher
        Teacher = deepcopy(pop[0])
        for i in range (1,nPop):
            if pop[i][1] < Teacher[1]:
               Teacher = deepcopy(pop[i])
        
        
# Teacher Phase
        for i in range(nPop):
            
            # Create Empty Solution            
            newsol = deepcopy(empty_individual)
            
            # Teaching Factor
            TF = np.random.randint(1,3)
            
            # Teaching (moving towards teacher)
            newsol.Position = pop[i][0] + np.random.rand(VarSize[0],VarSize[1],VarSize[2])*(Teacher[0] - TF*Mean)
            
            # Clipping
            # Apply Position Limits
            for q1 in range (VarSize[2]):
                for i1 in range (VarSize[0]):
                    for j1 in range (VarSize[1]):
                        if ( newsol.Position[i1][j1][q1] < VarMin[i1][j1][q1] ):  
                            newsol.Position[i1][j1][q1] = VarMin[i1][j1][q1]
                        elif ( newsol.Position[i1][j1][q1] > VarMax[i1][j1][q1] ):  
                            newsol.Position[i1][j1][q1] = VarMax[i1][j1][q1]  
            
            
            # Evaluation
            [newsol.Cost, newsol.Out]=ClusteringCost.ClC(newsol.Position,FeatureMatrix)
            
            # Comparision
            if newsol.Cost<pop[i][1]:
                
                pop[i][0] = newsol.Position
                pop[i][1] = newsol.Cost
                pop[i][2] = newsol.Out
                
                if pop[i][1] < BestSol.Cost:
                   BestSol.Position=pop[i][0]
                   BestSol.Cost=pop[i][1]
                   BestSol.Out=pop[i][2]
                   
                   
# Learner Phase
        for i in range (nPop):
            
            A = np.arange(0,nPop)
            A = np.delete(A, A[i])
            j = A[np.random.randint(nPop-1)]
            
            Step = pop[i][0] - pop[j][0]
            if pop[j][1] < pop[i][1]:
                Step = -Step            
            
            # Create Empty Solution
            newsol = deepcopy(empty_individual)
            
            # Teaching (moving towards teacher)
            newsol.Position = pop[i][0] + np.random.rand(VarSize[0],VarSize[1],VarSize[2])*Step
            
            # Clipping
            # Apply Position Limits
            for q1 in range (VarSize[2]):
                for i1 in range (VarSize[0]):
                    for j1 in range (VarSize[1]):
                        if ( newsol.Position[i1][j1][q1] < VarMin[i1][j1][q1] ):  
                            newsol.Position[i1][j1][q1] = VarMin[i1][j1][q1]
                        elif ( newsol.Position[i1][j1][q1] > VarMax[i1][j1][q1] ):  
                            newsol.Position[i1][j1][q1] = VarMax[i1][j1][q1]  
            
            # Evaluation
            [newsol.Cost, newsol.Out]=ClusteringCost.ClC(newsol.Position,FeatureMatrix)
            
            # Comparision
            if newsol.Cost<pop[i][1]:
                
                pop[i][0] = newsol.Position
                pop[i][1] = newsol.Cost
                pop[i][2] = newsol.Out
                
                if pop[i][1] < BestSol.Cost:
                   BestSol.Position=pop[i][0]
                   BestSol.Cost=pop[i][1]
                   BestSol.Out=pop[i][2]
              
# Store Best Cost Ever Found
        BestCost[it][0]=BestSol.Position
        BestCost[it][1]=BestSol.Cost
        BestCost[it][2]=BestSol.Out 
        
        percentage = it * 100 / MaxIt
        
# Display Iteration Information 
        self.progress.start()
        self.progress.config(mode='determinate', maximum=100, value=it)
        self.progress.update() 
        self.style.configure('text.Horizontal.TProgressbar', text='{:g} %'.format(percentage))
        
        
        
        del i,i1,j1,q1,Mean,Teacher,A,j,TF,newsol 
     
    
    self.progress.stop()  
    self.progress.config(mode='determinate', maximum=1, value=1)
    self.progress.update()
    self.style.configure('text.Horizontal.TProgressbar', text='{:g} %'.format(percentage))
    
    
    del empty_individual,BestSol,pop,VarSize,VarMin,VarMax,it,k, MaxIt,nPop,ImageEnhanced,GTDetectedNodules,FeatureMatrix,percentage       
    
    return BestCost

