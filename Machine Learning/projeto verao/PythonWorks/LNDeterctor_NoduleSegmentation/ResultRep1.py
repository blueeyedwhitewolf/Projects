# -*- coding: utf-8 -*-
"""
Created on Wed Apr 25 09:55:47 2018

@author: Elham
"""

# -*- coding: utf-8 -*-
"""
Created on Tue Apr 24 09:24:01 2018

@author: Elham
"""

import numpy as np
from skimage import measure
from matplotlib import pyplot
from IPython import get_ipython
from tkinter import Label, StringVar, N, E, W
from PIL import Image, ImageTk
import PlotSolution1


def RR ( BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure, self ):
    
    get_ipython().run_line_magic('matplotlib', 'inline')  
    
    class BestSol:
          Position=[]
          Out=[]
          
    ResultsPath="C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/"
    
# %% Plot Derived BestCosts
          
    pyplot.figure(1,figsize=(4, 3.5)), pyplot.plot([BestCost[i][1] for i in range (len(BestCost))],linewidth=2)
    pyplot.xlabel('Iteration')
    pyplot.ylabel('OptimalCost', fontstyle='italic') 
       
    pyplot.savefig( ResultsPath + 'OptimalCost.png', format='png', dpi=300 ) 
    pyplot.close()   
    
    
# %% Plot the Last Obtained BestCost Solution (Clustered Pixels)
    
    BestSol.Position=BestCost[MaxIt-1][0]
    BestSol.Out=BestCost[MaxIt-1][2] 
    
    ImageEnhanced=np.zeros ( Size ).astype('int') 
    PlotSolution1.PltSol(FeatureMatrix, BestSol, ImageEnhanced, SliceM, ResultsPath) 
    
    
# %% Results Representation
    
    ImageSize = np.shape( GT3D[0] )  
    
    cmap = ['y','g','b','c','m','k','w','grey']  
    
    self.message5 = "Feature data clustering:           Segmented binary regions:               Overlaid contours:"
    self.label_text5 = StringVar()
    self.label_text5.set(self.message5)
    self.label5 = Label(self.frame2, textvariable=self.label_text5, bg="lightblue")        
    self.label5.grid(row=7, column=3, columnspan=2, sticky=(N, E, W), pady=2, padx=2)
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,5), pyplot.xticks([]), pyplot.yticks([])
    pyplot.imshow( SI[:,:,SliceM-2], cmap = 'gray', interpolation = 'none' )
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,8), pyplot.xticks([]), pyplot.yticks([])
    pyplot.imshow( SI[:,:,SliceM-1], cmap = 'gray', interpolation = 'none' ) 
    
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,2), pyplot.xticks([]), pyplot.yticks([])
    pyplot.imshow( SI[:,:,SliceM], cmap = 'gray', interpolation = 'none' ) 
          
        
    ###########################################################
    # Sagittal           
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,6) 
    for i in range ( len(GT3D) ):
 
        GT = np.zeros( [ImageSize[0],ImageSize[1]] ) 
        GT = GT3D[i][Slice,:,:] 
        
        contoursGT = measure.find_contours(GT, 0.9, fully_connected='low', positive_orientation='low')
        pyplot.xticks([]), pyplot.yticks([])
        pyplot.imshow( ImageM[Slice,:,:], cmap = 'gray', interpolation = 'none' )
        
        pyplot.hold(True)
        for n in range(len(contoursGT)):        
            contour = np.array(contoursGT[n])     
            pyplot.plot(contour[:, 1], contour[:, 0], color=cmap[i], linewidth=1)                   
        
        
    contoursSN = measure.find_contours(SegmentedNoduleLabel[:,:,SliceM-2], 0.1, fully_connected='low', positive_orientation='low') 
    pyplot.hold(True) 
    for n in range(len(contoursSN)):        
            contour = np.array(contoursSN[n]) 
            pyplot.plot(contour[:, 1], contour[:, 0], color='r',linewidth=1) 
    
    ###########################################################
    # Coronal 
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,9)        
    for i in range ( len(GT3D) ):
 
        GT = np.zeros( [ImageSize[0],ImageSize[1]] ) 
        GT = GT3D[i][:,Slice,:] 
        
        contoursGT = measure.find_contours(GT, 0.9, fully_connected='low', positive_orientation='low')
        pyplot.xticks([]), pyplot.yticks([])
        pyplot.imshow( ImageM[:,Slice,:], cmap = 'gray', interpolation = 'none' )
        
        pyplot.hold(True)
        for n in range(len(contoursGT)):        
            contour = np.array(contoursGT[n])     
            pyplot.plot(contour[:, 1], contour[:, 0], color=cmap[i], linewidth=1)                   
        
        
    contoursSN = measure.find_contours(SegmentedNoduleLabel[:,:,SliceM-1], 0.1, fully_connected='low', positive_orientation='low') 
    pyplot.hold(True)
    for n in range(len(contoursSN)):        
            contour = np.array(contoursSN[n]) 
            pyplot.plot(contour[:, 1], contour[:, 0], color='r',linewidth=1)
    
    ###########################################################
    # Axial
    pyplot.figure(2,figsize=(3, 3)), pyplot.subplot(3,3,3)
    for i in range ( len(GT3D) ):
 
        GT = np.zeros( [ImageSize[0],ImageSize[1]] ) 
        GT = GT3D[i][:,:,Slice] 
        
        contoursGT = measure.find_contours(GT, 0.9, fully_connected='low', positive_orientation='low')
        pyplot.xticks([]), pyplot.yticks([])
        pyplot.imshow( ImageM[:,:,Slice], cmap = 'gray', interpolation = 'none' )
        
        pyplot.hold(True)
        for n in range(len(contoursGT)):        
            contour = np.array(contoursGT[n])     
            pyplot.plot(contour[:, 1], contour[:, 0], color=cmap[i], linewidth=1)                   
        
        
    contoursSN = measure.find_contours(SegmentedNoduleLabel[:,:,SliceM], 0.1, fully_connected='low', positive_orientation='low') 
    pyplot.hold(True)
    for n in range(len(contoursSN)):        
            contour = np.array(contoursSN[n]) 
            pyplot.plot(contour[:, 1], contour[:, 0], color='r',linewidth=1)
            
            
    pyplot.savefig( ResultsPath + 'Figures.png', format='png', dpi=300 ) 
    pyplot.close() 
    
    
    Timage = Image.open(ResultsPath + 'Figures.png')
    Timage = Timage.resize([640, 476], Image.NEAREST)
    self.image2 = ImageTk.PhotoImage(Timage)
    self.label4 = Label(self.frame2, image=self.image2)   
    self.label4.grid(row=8, column=3, sticky=(N, E, W))  

    Timage = Image.open(ResultsPath + 'OptimalCost.png')
    Timage = Timage.resize([385, 230], Image.NEAREST)
    self.image3= ImageTk.PhotoImage(Timage)
    self.label4 = Label(self.frame4, image=self.image3)   
    self.label4.grid(row=11, column=0, sticky=(N, E, W))            
 
    
# %% Evaluation Metrics 
    labelfont = ('times', 12, 'bold')
    
    Metric_value = "Dice similarity coefficient:   " + str ( Measure[0][1] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=9, column=5, sticky=(N, E, W), pady=5, padx=5)  
    
    Metric_value = "Sensivity:   " + str ( Measure[0][5] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=11, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Positive predictive value:   " + str ( Measure[0][6] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=13, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Average boundary distance:   " + str ( Measure[0][8] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=15, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "  " 
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4)
    self.label4.grid(row=17, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "  " 
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4)
    self.label4.grid(row=19, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Dice similarity coefficient (inter-observers):   " + str ( Measure[0][14] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=21, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Sensivity/Positive predictive value (inter-observers):   " + str ( Measure[0][16] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=23, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Average boundary distance (inter-observers):   " + str ( Measure[0][15] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=25, column=5, sticky=(N, E, W), pady=5, padx=5) 
    
    Metric_value = "  " 
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4)
    self.label4.grid(row=27, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "  " 
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4)
    self.label4.grid(row=29, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Automatic nodule volume:   " + str ( Measure[0][9] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=31, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Manual nodule volume (2.5D):   " + str ( Measure[0][10] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=33, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "Manual nodule volume (3D):   " + str ( Measure[0][12] )
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4, bg="lightblue")
    self.label4.config(font=labelfont)
    self.label4.grid(row=35, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    Metric_value = "  " 
    self.message4 = Metric_value
    self.label_text4 = StringVar()
    self.label_text4.set(self.message4)
    self.label4 = Label(self.frame3, textvariable=self.label_text4)
    self.label4.grid(row=37, column=5, sticky=(N, E, W), pady=5, padx=5)
    
    
    del BestCost, FeatureMatrix,Size,Slice,SliceM,MaxIt,SI,GT3D,ImageM,SegmentedNoduleLabel,Measure, \
        BestSol,ImageEnhanced,ImageSize,cmap,GT,i,n,contoursGT,contoursSN