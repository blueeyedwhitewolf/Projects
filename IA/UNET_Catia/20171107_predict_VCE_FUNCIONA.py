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
import sys
import numpy as np

from skimage.transform import resize
from skimage import measure
from skimage import io
from skimage.draw import polygon_perimeter

from util.unet_triclass import unet,dice_coef,dice_coef_loss
from keras.optimizers import Adam

# ------------------------------------------------------
# ------------------------------------------------------
# Dir list
# ------------------------------------------------------
def createList(foldername, suffix=".png"):
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
    
## =========================================

    ### set important paths

#    BasePath = 'C:/Trabalhos_local/VCE_Sets/20171027_302.272_CHP_SB3_1000_delgado/
    
# Este foi o set anotado pelo Paulo usando o tool por niveis           
#    BasePath ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171027_302.272_CHP_SB3_1000_delgado/Treino_com_IMGs_convetidas_512_512/'
#    weights_name= 'A_adam_weights.hdf5'    

# Este foi o set anotado pelo Paulo por observacao com imagens de sangramentos variadas treinado com 80 20 
#    BasePath ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20170925_SET_80_20/' 

# Este dataset tem os dois dataset juntos, o de 3000 e o de 1000 que utilizou a ferramenta de anotacao    
    BasePath = '/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171106_SET_1000_delgado_e_3000/'

    weights_name= 'A_adam_weights.hdf5'    
    
    
    BasePath_VCE ='/media/acunha/Trabalhos/VCE_Backup/VCE_CHP_SB3_ALL_Anonimizadas/SB3/001.001_CHP_SB3_IMGs/'
    
    predited_directory = 'PREDICTED_001.001_CHP_SB3_IMGs'  

    path_model = BasePath + 'models/'
    
# %% =========================================
#   Carrega parametro     
    if(len(sys.argv)>1):
        BasePath_VCE = (sys.argv[1])
    print '  BasePath_VCE: ',BasePath_VCE 

    
# %% =========================================
    
    dir_predicted_valSet = BasePath + predited_directory + "/"
    
    # Verifica se existe a directoria 
    try:
        os.stat(dir_predicted_valSet)
    except:
        os.mkdir(dir_predicted_valSet)  
    #===================== 
      
# %% Create Model
    # Model Parameters
    input_channels = 3 # RGB
    ptch_sz = 512
    labels = [0,1]
        
    # Define the Model
    un = unet(input_channels, ptch_sz,n_channels=len(labels))
    u = un.get_unet(nf=16) # u net using upsample
      
    # Optimizacao
    learning_rate=0.001
    optim = Adam(lr=learning_rate)
    print 'Using Adam'
     
    # Carrega pesos para modelo
    print 'loading weights...' 
    u.load_weights((path_model+weights_name))
     
    # Escolha da Metrica    
    u.compile(optimizer=optim, loss=dice_coef_loss, metrics=[dice_coef]) 

# %% ===================
    # obtem a lista de diretorias 
    listaFicheiros = os.listdir(BasePath_VCE)
    
    # Init areaCNT
    areaBleeding =np.array([["IMGname","Area"]])
    
    # Para cada pasta carrega ficheiros
    for name in listaFicheiros:
        dirPath = BasePath_VCE + name + "/"
        print "pasta = ", name, 
        
        
        # Cria pasta de destino
        dir_predicted_valSet_name = dir_predicted_valSet + name + "/"
    
        # Verifica se existe a directoria 
        try:
            os.stat(dir_predicted_valSet_name)
        except:
            os.mkdir(dir_predicted_valSet_name)  
    
    
        # Carrega lista de ficheiros
        fileNameList = createList(dirPath)
        
        print len(fileNameList), " com ficheiros" 
        
        # Adiciona path aos ficheiros
        fileNameListWithPath = [dirPath + s for s in fileNameList]     

# %%   Preve a mascara das imagens em grupos de batch_size
        
        batch_size = 4
    
        cnt_imgs_print = 0
        cnt = 1

        while cnt < len(fileNameList)/batch_size+1: 
            #===================
            # Obtem primeiro set com tamanho batch - para previsao     
            batch_imgs_names = fileNameList[(cnt-1)*batch_size:cnt*batch_size]
            
            batch_imgs_names_and_paths = fileNameListWithPath[(cnt-1)*batch_size:cnt*batch_size]
            x_batch = leIMGs_batch(batch_imgs_names_and_paths, batch_size)
            
            
        #    print "Nome imgs:", batch_imgs_names
            
            #===================
            # Faz previsao e calcula tempo de processamento
        #        print "Previsao: "
        #        t1=time.time()
            pred = u.predict(x_batch)
        #        t2=time.time()
            
        #        print "Tempo batch:",t2-t1, "  Tempo imagem:", (t2-t1)/batch_size
            
            
           
            # para cada imagem previstas
            for ind,p in enumerate(pred):
             
        
                # contador
                cnt_imgs_print = cnt_imgs_print + 1
                print "pasta: ", name, " IMG: ", cnt_imgs_print, " - ", batch_imgs_names[ind], " Areas: ",

                # Converte em imagem 
                mask_pred = categorical_to_gray(pred[ind],labels)
                
                # Obtem imagem original
                img = x_batch[ind]
                 
                # Calcula o contorno:  constant value of 0.8
                contours_pred = measure.find_contours(mask_pred, 0.8) 
                
                gravarContour = "nao"
                
                # Para cada contorno encontrado
                for n, contour in enumerate(contours_pred):
                    
                    if len(contour[:, 1])>2:
                        #obtem os pontos entre os vertices do contorno
                        rr, cc = polygon_perimeter(contour[:, 1], contour[:, 0], shape=mask_pred.shape, clip=True)
                        
                        # desenha contorno na imagem original
                        img[cc, rr,0 ] = 0    # Red
                        img[cc, rr,1 ] = 1  # Green
                        img[cc, rr,2 ] = 0    # Blue 
                        
                        # Polygon area
                        area = AreaIrregularPolygon(contour)
                        
                        
   # <--------------- confirmar queo STR nao da problema aqui!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        print str(area), " ",
                        this_areaBleeding = np.asarray([[batch_imgs_names[ind],str(area)]])
                        areaBleeding = np.vstack((areaBleeding, this_areaBleeding))
                        gravarContour = "sim"

        
                # Grava mascara prevista
                # Nota retirei 5 carcteres e coloqui o ponto - pois ha ficheiros JPRG com 4 char e outro PNG com 3!!!
        #            save_mask_prediction = dir_predicted_valSet_name+batch_imgs_names[ind][ 0:len(batch_imgs_names[ind] )-5]+ "_mask_pred.png"
        #            io.imsave(save_mask_prediction, mask_pred)
        #            print " M",
        
                print "#"
                
                # Grava imagem CVS com contronos deteteados e a Pesos usados         
                if gravarContour == "sim":
                    save_IMG_contour = dir_predicted_valSet_name+batch_imgs_names[ind][ 0:len(batch_imgs_names[ind] )-4]+"_"+weights_name+ ".csv"
                    np.savetxt(save_IMG_contour, contours_pred, delimiter=";", fmt="%s")
                
                # Grava imagem com mascara em RGB
                save_IMG_mask_prediction_RGB = dir_predicted_valSet_name+batch_imgs_names[ind][ 0:len(batch_imgs_names[ind] )-4]+ "_IMG_RGB_pred.png"
                io.imsave(save_IMG_mask_prediction_RGB, img)

                
            cnt = cnt+1 
    # Grava areas detetadas por imagem
    AreaFileName = BasePath+predited_directory[10:]+'RedLesionsAreas.csv'
    np.savetxt(AreaFileName, areaBleeding, delimiter=";", fmt="%s")
        


 