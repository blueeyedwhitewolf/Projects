########################################################################
########################################################################
# Este ficheiro faz a previsao de um set 
# as imagens sao convertidas para 512x512
#
# Caminho das imagens: BasePath_VCE
#
# Caminho dos pesos: BasePath
#
########################################################################

import os
#import sys
import numpy as np

from skimage.transform import resize
from skimage import measure
from skimage import io
from skimage.draw import polygon_perimeter


# ------------------------------------------------------
# ------------------------------------------------------
# Dir list
# ------------------------------------------------------
def createList(foldername, suffix="_mask_pred.png"):
    file_list_tmp = os.listdir(foldername)

    file_list = []

    for item in file_list_tmp:
        if item.endswith(suffix):
            file_list.append(item)

    return file_list
# ------------------------------------------------------
# ------------------------------------------------------
# Le grupo de patch_size IMGs
# ------------------------------------------------------
def leIMGs_batch(IMGsFileNames, batch_size):
    
    cnt = 0
    
    for nome in IMGsFileNames:  
        img320x320 = io.imread(nome)
        img = resize(img320x320, (512, 512))
        
        if cnt ==0:
            IMGsBatchFile =np.expand_dims(img, axis=0)
        else:
            newImg = np.expand_dims(img, axis=0)
            IMGsBatchFile = np.vstack((IMGsBatchFile, newImg))
        
        cnt = cnt + 1    
    
    return IMGsBatchFile

# ------------------------------------------------------
# ------------------------------------------------------
def categorical_to_gray(img,labels):
    
    new_img = np.zeros((int(np.sqrt(img.shape[0])),int(np.sqrt(img.shape[0]))))
    
    r_img   = img.reshape(int(np.sqrt(img.shape[0])),int(np.sqrt(img.shape[0])),-1)
    
    for i,l in enumerate(labels[1::]):
        new_img[r_img[:,:,i+1]>0.5]=l
#        print(np.sum(r_img[:,:,i+1]>0.5))
    
    new_img[0,0] = labels[-1]
    
#    print(np.unique(new_img))
    
    return new_img



# ------------------------------------------------------
# ------------------------------------------------------

# Source - poligon area:
#https://stackoverflow.com/questions/24467972/calculate-area-of-polygon-given-x-y-coordinates
#https://www.mathsisfun.com/geometry/area-irregular-polygons.html

def AreaIrregularPolygon(coords):
    t=0
    for count in range(len(coords)-1):
        y = coords[count+1][1] + coords[count][1]
        x = coords[count+1][0] - coords[count][0]
        z = y * x
        t += z
    return abs(t/2.0)

#a=[(5.09,5.8), (1.68,4.9), (1.48,1.38), (4.76,0.1), (7.0,2.83), (5.09,5.8)]
#print _area_(a)
#


if __name__ == '__main__':
    
 
    BasePath_VCE ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_ActiveBleeding_80_20/PREDICTED_081.076_CHP_SB3_IMGs_ActiveBleeding/'


# %% ===================
    # obtem a lista de diretorias 
    listaFicheiros = os.listdir(BasePath_VCE)
    
    # Init areaCNT
    areaBleeding =np.array([["IMGname","Area"]])
    
    # Para cada pasta carrega ficheiros
    for name in listaFicheiros:
        dirPath = BasePath_VCE + name + "/"
        print "pasta = ", name, 
           
    
        # Carrega lista de ficheiros
        fileNameList = createList(dirPath)
        
        print len(fileNameList), " com ficheiros" 
        
        # Adiciona path aos ficheiros
        fileNameListWithPath = [dirPath + s for s in fileNameList]     

# %%   Preve a mascara das imagens em grupos de batch_size
         
    
        cnt_imgs_print = 0
        cnt = 1

        while cnt < 1000 : 
#        while cnt < len(fileNameList) : 
            #===================
            # Obtem primeiro set com tamanho batch - para previsao     
            batch_imgs_names = fileNameList[cnt]
            
            batch_imgs_names_and_paths = fileNameListWithPath[cnt]
#            x_batch = leIMGs_batch(batch_imgs_names_and_paths, batch_size)
            
            
            
           
            # para cada imagem previstas
#            for ind,p in enumerate(pred):
             
        
            # contador 
            print "pasta: ", name, " IMG: ", cnt, " - Areas: ",

            
            # Obtem imagem original
            img = io.imread(batch_imgs_names_and_paths)
              
            # Polygon area
            area = np.count_nonzero(img)
            
            
            print str(area), " ",
            this_areaBleeding = np.asarray([[batch_imgs_names,str(area)]])
            areaBleeding = np.vstack((areaBleeding, this_areaBleeding))
            
            print "#"
 

                
            cnt = cnt+1 
            
        # Grava areas detetadas por imagem
#        AreaFileName = BasePath_VCE+'RedLesionsAreas.csv'
#        print "AreaFileName ", AreaFileName 
#        np.savetxt(AreaFileName, areaBleeding, delimiter=";", fmt="%s")
            
    # Grava areas detetadas por imagem
    AreaFileName = BasePath_VCE+'RedLesionsAreas.csv'
    print "AreaFileName ", AreaFileName 
    np.savetxt(AreaFileName, areaBleeding, delimiter=";", fmt="%s")
        


 