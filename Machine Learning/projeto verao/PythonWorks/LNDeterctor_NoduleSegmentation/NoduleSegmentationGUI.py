# -*- coding: utf-8 -*-
"""
Created on Mon Apr 23 11:10:19 2018

@author: Elham
"""

import sys
import pickle
from tkinter import Tk, ttk, Label, Button, Entry, StringVar, DISABLED, NORMAL, END, N, S, E, W, HORIZONTAL 
from tkinter.filedialog import askopenfilename
from skimage.transform import resize
from PIL import Image, ImageTk
from matplotlib import pyplot
from IPython import get_ipython


pyplot.close("all")
get_ipython().run_line_magic('matplotlib', 'inline') 

ResultsPath="C:/TrabalhosAcunha/DropboxAtcunhaGmailCom/Dropbox/PythonWorks/LNDeterctor_NoduleSegmentation/"

# ########################## Segmentation Class ###############################

class Segmentation_Function:  
    
    def seg (self):   
        
        from DataReadingMain import DRM        
        [BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure] = DRM (self)
        return BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure
        
    def rep (BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure, self):
        
        from ResultRep1 import RR        
        RR (BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure, self)
        
        
# ############################## Main Class ###################################
        
class NoduleSegmentation:
    
    def __init__(self, master):        
        
        # Calls the constructor for the parent class.
        self.master = master
        
        self.master.title("Pulmonary Nodule Segmentation Application")         
        
        self.master.configure(bg="black")  
        
        # get screen width and height
#        ws = self.master.winfo_screenwidth() # width of the screen
#        hs = self.master.winfo_screenheight() # height of the screen
#        self.master.geometry('%dx%d+%d+%d' % (ws, hs, 0, 0))
        
        self.master.geometry('+10+10')
        
        
        self.NodulePath = ""   


        self.message = "Enter the path of the nodule to be segmented:"
        self.label_text = StringVar()
        self.label_text.set(self.message)
        self.label = Label(self.master, textvariable=self.label_text, bg="lightblue")
        self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        

        vcmd = self.master.register(self.validate) # we have to wrap the command        
        self.entry = Entry(self.master, validate="key", validatecommand=(vcmd, '%P'))
        self.entry.grid(row=1, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        

        self.browse_button = Button(self.master, text="Browse", command=self.browse, state=NORMAL)
        self.browse_button.grid(row=1, column=3, sticky=(N, W), pady=5, padx=5)
        self.browse_button.config(width=20)
        
        
        self.segmentation_button = Button(self.master, text="Segmentation", command=self.segmentation, state=NORMAL)
        self.segmentation_button.grid(row=3, column=0, sticky=(N, W), pady=5, padx=5)
        self.segmentation_button.config(width=20)
        
        
        self.reset_button = Button(self.master, text="Reset", command=self.reset, state=DISABLED)
        self.reset_button.grid(row=3, column=0, sticky=(N, E), pady=5, padx=5)
        self.reset_button.config(width=20)
        
        
        self.exit_button = Button(self.master, text="Exit", command=self.exit, state=NORMAL)
        self.exit_button.grid(row=11, column=5, sticky=(S, E), pady=5, padx=5) 
        self.exit_button.config(width=20)
        
        
        self.message1 = "Pulmonary Nodule Images (Axial, Sagittal and Coronal Views):"
        self.label_text1 = StringVar()
        self.label_text1.set(self.message1)
        self.label1 = Label(self.master, textvariable=self.label_text1, bg="lightblue")        
        self.label1.grid(row=5, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        
        self.content1 = ttk.Frame(self.master, padding=(3,3,12,12))        
        self.frame1 = ttk.Frame(self.content1, borderwidth=10, relief="sunken", width=410, height=530) 
        self.content1.grid(row=7, column=0, sticky=(N, E, W))        
        self.frame1.grid(row=7, column=0, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        
        self.message2 = "Segmentation Representation (Axial, Sagittal and Coronal Views):"
        self.label_text2 = StringVar()
        self.label_text2.set(self.message2)
        self.label2 = Label(self.master, textvariable=self.label_text2, bg="lightblue")        
        self.label2.grid(row=5, column=3, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        
        self.content2 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame2 = ttk.Frame(self.content2, borderwidth=10, relief="sunken", width=665, height=530) 
        self.content2.grid(row=7, column=3, sticky=(N, E, W))
        self.frame2.grid(row=7, column=3, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        
        self.message3 = "Measures:"
        self.label_text3 = StringVar()
        self.label_text3.set(self.message3)
        self.label3 = Label(self.master, textvariable=self.label_text3, bg="lightblue")        
        self.label3.grid(row=5, column=5, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        
        self.content3 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame3 = ttk.Frame(self.content3, borderwidth=10, relief="sunken", width=435, height=530)  
        self.content3.grid(row=7, column=5, sticky=(N, E, W))
        self.frame3.grid(row=7, column=5, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        
        self.content4 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame4 = ttk.Frame(self.content4, borderwidth=10, relief="sunken", width=410, height=260)  
        self.content4.grid(row=11, column=0, sticky=(N, E, W))
        self.frame4.grid(row=11, column=0, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        
        self.style = ttk.Style(self.master)
        # add label in the layout
        self.style.layout('text.Horizontal.TProgressbar', 
                     [('Horizontal.Progressbar.trough',
                       {'children': [('Horizontal.Progressbar.pbar',
                                      {'side': 'left', 'sticky': 'ns'})],
                        'sticky': 'nswe'}), 
                      ('Horizontal.Progressbar.label', {'sticky': ''})])
        # set initial text
        self.style.configure('text.Horizontal.TProgressbar', text='0 %')
        
        self.progress = ttk.Progressbar(self.master, orient=HORIZONTAL, length=425, style='text.Horizontal.TProgressbar')
        self.progress.config(mode='determinate', maximum=100, value=1)
        self.progress.grid(row=9, column=0, sticky=(N, E, W))        
        
        
    def validate(self,path):
        
        if not path: # the field is being cleared
            
            self.NodulePath = ""
            self.message = "Enter the path of the nodule to be segmented:"
            self.label_text.set(self.message)
            self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
            return True

        try: 
            
            FileExt = path[ (len(path)-4):len(path) ]
            
            if path == "" or FileExt != ".pkl":   
                
                self.message = "Wrong Path!"
                self.label_text.set(self.message)
                self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
                self.NodulePath = ""  
                self.entry.delete(0, END)
            
            else: 
                
                self.NodulePath = path 
                self.message = "Correct Path!"
                self.label_text.set(self.message) 
                self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
                
                with open ( self.NodulePath, 'rb' ) as PKFile:
                     ImageM = pickle.load(PKFile)
                
                Slice = 26
                
                ImageM1 = resize(ImageM[0][Slice,:,:], (385, 500))
                ImageM2 = resize(ImageM[0][:,Slice,:], (385, 500))
                ImageM3 = resize(ImageM[0][:,:,Slice], (385, 500))
                
                pyplot.figure(1,figsize=(3, 3)), pyplot.subplot(3,1,2), pyplot.xticks([]), pyplot.yticks([])
                pyplot.imshow( ImageM1 , cmap = 'gray' )
    
                pyplot.figure(1,figsize=(3, 3)), pyplot.subplot(3,1,3), pyplot.xticks([]), pyplot.yticks([])
                pyplot.imshow( ImageM2, cmap = 'gray' )
    
                pyplot.figure(1,figsize=(3, 3)), pyplot.subplot(3,1,1), pyplot.xticks([]), pyplot.yticks([])
                pyplot.imshow( ImageM3, cmap = 'gray' )
                
                pyplot.savefig( ResultsPath + 'Figures.png', format='png', dpi=300 ) 
                pyplot.close() 
                 
                Timage = Image.open(ResultsPath + 'Figures.png')
                Timage = Timage.resize([385, 500], Image.NEAREST)
                self.image1 = ImageTk.PhotoImage(Timage)
                self.label6 = Label(self.frame1, image=self.image1)   
                self.label6.grid(row=7, column=0, sticky=(N, E, W))  
                
            return True
            
        except ValueError:
            
            return False
        
        
    def OpenFile(self):
        
            name = askopenfilename(
                           filetypes =(("Python File", "*.pkl"),("All Files","*.pkl")),
                           title = "Choose a file."
                           )    
    
            #Using try in case user types in unknown file or closes without choosing a file.
            try:
                
                with open(name,'r') as UseFile:                    
                    self.message = UseFile.read()
                    self.label_text.set(self.message)                    
                    self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)  
                    
            except:
                
                self.message = "Wrong Path!"
                self.label_text.set(self.message)
                self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
                self.NodulePath = ""  
                self.entry.delete(0, END)
        
            self.entry.insert(0, str(name))
            
            self.validate(name)

    def browse(self):
        
        self.message = "Enter the path of the nodule to be segmented:"
        self.label_text.set(self.message)
        self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        
        self.NodulePath = ""
        
        self.entry.delete(0, END)
        
        self.content1 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame1 = ttk.Frame(self.content1, borderwidth=10, relief="sunken", width=410, height=535)  
        self.content1.grid(row=7, column=0, sticky=(N, E, W))
        self.frame1.grid(row=7, column=0, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        self.OpenFile()
        
        self.browse_button.configure(state=NORMAL)
        self.segmentation_button.configure(state=NORMAL)
        self.reset_button.configure(state=DISABLED)
        

    def segmentation(self):
        
        if self.NodulePath == "":
            
           self.message = "Wrong Path!"
           self.label_text.set(self.message)
           self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
           
           self.entry.delete(0, END)
           
           self.browse_button.configure(state=NORMAL)
           self.segmentation_button.configure(state=NORMAL)
           self.reset_button.configure(state=DISABLED)

        else:
            
            [BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure] = Segmentation_Function.seg(self)  
            
            Segmentation_Function.rep(BestCost, FeatureMatrix, Size, Slice, SliceM, MaxIt, SI, GT3D, ImageM, SegmentedNoduleLabel, Measure,self)  
            
            self.browse_button.configure(state=DISABLED)
            self.segmentation_button.configure(state=DISABLED)
            self.reset_button.configure(state=NORMAL) 
        
    
    def reset(self):        

        self.message = "Enter the path of the nodule to be segmented:"
        self.label_text.set(self.message)
        self.label.grid(row=0, column=0, columnspan=2, sticky=(N, E, W), pady=5, padx=5)
        
        self.NodulePath = ""
        
        self.entry.delete(0, END)

        self.browse_button.configure(state=NORMAL)
        self.segmentation_button.configure(state=NORMAL)
        self.reset_button.configure(state=DISABLED)         
        
        self.content1 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame1 = ttk.Frame(self.content1, borderwidth=10, relief="sunken", width=410, height=530)  
        self.content1.grid(row=7, column=0, sticky=(N, E, W))
        self.frame1.grid(row=7, column=0, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        self.content2 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame2 = ttk.Frame(self.content2, borderwidth=10, relief="sunken", width=665, height=530)        
        self.content2.grid(row=7, column=3, sticky=(N, E, W))
        self.frame2.grid(row=7, column=3, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        self.content3 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame3 = ttk.Frame(self.content3, borderwidth=10, relief="sunken", width=435, height=530)  
        self.content3.grid(row=7, column=5, sticky=(N, E, W))
        self.frame3.grid(row=7, column=5, columnspan=3, rowspan=2, sticky=(N, E, W))
        
        self.content4 = ttk.Frame(self.master, padding=(3,3,12,12))
        self.frame4 = ttk.Frame(self.content4, borderwidth=10, relief="sunken", width=410, height=260)  
        self.content4.grid(row=11, column=0, sticky=(N, E, W))
        self.frame4.grid(row=11, column=0, columnspan=3, rowspan=2, sticky=(N, E, W)) 
        
        self.style.configure('text.Horizontal.TProgressbar', text='0 %')
        self.progress = ttk.Progressbar(self.master, orient=HORIZONTAL,length=425, style='text.Horizontal.TProgressbar')
        self.progress.config(mode='determinate', maximum=100, value=1)
        self.progress.grid(row=9, column=0, sticky=(N, E, W))
        
        
    def exit(self):
        
        self.master.destroy()            
        sys.exit()
        
# ########################### End of Main Class ###############################
   
     
root = Tk()
# The main program starts here by instantiating the NoduleSegmentation class.
my_gui = NoduleSegmentation(root)
# Starts the application's main loop, waiting for mouse and keyboard events.
root.mainloop()


