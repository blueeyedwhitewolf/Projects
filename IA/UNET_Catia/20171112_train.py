 
#import numpy as np
#import matplotlib.pyplot as plt
#import sys
#from util.patch import Patches
#from util.unet_triclass import unet,dice_coef,dice_coef_loss,dice_coef_loss_r,dice_coef_mean,dice_coef
#from keras.utils.visualize_util import plot

import os
import time

from util.data import TwoImageIterator
from util.unet_triclass import unet,dice_coef_loss,dice_coef_mean,dice_coef

from keras.optimizers import Adam,SGD
from keras import callbacks

###
### tensorboard --logdir=//media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_ActiveBleeding_80_20/logs/
### tensorboard --logdir=///media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_BleedingPotencially_bleeding_80_20/logs/

#tensorboard --logdir=//media/acunha/Trabalhos/Vineyard_Datasets/20171117-Vineyard_Datasets/logs/
###

### tensorboard --logdir=//media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_PotenciallyBleeding_80_20/logs/



### set important paths
#BasePath ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_ActiveBleeding_80_20/'

#BasePath ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_BleedingPotencially_bleeding_80_20/'
BasePath ='/media/acunha/Trabalhos/VCE_Datasets/DatasetsPauloCoelho/20171207_Dataset_separado_gravidade_lesao/Dataset_PotenciallyBleeding_80_20/'

data_dir = BasePath + 'TRAINING/'
 
val_dir = BasePath + 'VALIDATION/'
 
path_model = BasePath + 'models/'

path_log = BasePath + 'logs/'


#=====================
try:
    os.stat(path_model)
except:
    os.mkdir(path_model)  

#=====================
try:
    os.stat(path_log)
except:
    os.mkdir(path_log)  
#=====================


from tensorflow.python.client import device_lib
print(device_lib.list_local_devices())

print path_model

def train(lr=0.001,load=0,opt='adam',loss='l',stop=5, model_version = 'A'):

    # Patch size
    ptch_sz = 512
    stride = -1
    batch_size = 4
    
    # Path for visualize data with tensor board
    str_name = str(time.time())+'_'+str(lr)+str(load)+opt+loss+str(stop)
    log_file = path_log + str_name
    
#    weights_val_loss_path = path_model + model_version +'_weights-{epoch:02d}-{val_loss:.3f}.hdf5'
#    weights_loss_path = path_model + str_name + '_weights-{epoch:02d}-{loss:.3f}.h5'
    
    # so estou intersado nos pesos quando ha melhoria na val loss
    weights_val_loss_path = path_model + model_version +'_weightsVal.hdf5'
    
    # Para ja nao estou a usar!
    weights_loss_path = path_model + str_name + '_weights.h5'     
    
#    model_png_path_name = path_model + str_name +'model.png' 
    
    # number of training epoch
    nb_epoch   = 128
    
    labels = [0,1]
    
    # Input RGB
    input_channels = 3

    # InputGrayScale
#    input_channels = 1
    
    # iteration in side a each epoch
    epoch_iterations = 100
    
    learning_rate = lr
    
    
#    # Define the Model
#    un = unet(input_channels, ptch_sz,n_channels=len(labels))
#    u = un.get_unet(nf=16) # u net using upsample

    print 'Input channels: ', input_channels, ' PatchSize: ',ptch_sz, ' N Labels', len(labels)
    un = unet(input_channels, ptch_sz,n_channels=len(labels))
    u = un.get_unet(nf=16) # u net using upsample
    
#   
    # Escolhe optimizacao
    
    print(opt,opt=='sgd')
    optim = Adam(lr=learning_rate)
    
    if(opt=='sgd'):
        optim = SGD(lr=learning_rate, momentum=0.99)
        print 'using sgd'

# Escolha da Metrica    
#    u.compile(optimizer=optim, loss=dice_coef_loss, metrics=[dice_coef])
    u.compile(optimizer=optim, loss=dice_coef_loss, metrics=[dice_coef,dice_coef_mean])
#    u.compile(optimizer='sgd', loss='categorical_crossentropy',metrics=['accuracy'])
    
    if(loss=='r'):
#        u.compile(optimizer=optim, loss=dice_coef_loss_r, metrics=[dice_coef,dice_coef_mean])

        u.compile(optimizer='sgd', loss='categorical_crossentropy',metrics=['accuracy'])
        print 'using r'

    #===================
    # Se load>0 Carrega pesos
    if(load>0):
        u.load_weights((weights_val_loss_path))
        print 'loading weights...'

    #=================== 
#    # Grava modelo para PNG ,o disco
#    model_json = u.to_json()
#
#    with open((weights_loss_path), "w") as json_file:
#        json_file.write(model_json)
#        
#    plot(u, to_file=model_png_path_name)
    
   
    train_it   = TwoImageIterator(data_dir, 
                                  batch_size=batch_size,
                                  fnames_are_same=True,  
                                  target_size=(ptch_sz, ptch_sz),
                                  shuffle=True,
                                  is_a_grayscale=False, 
                                  is_b_grayscale=False, 
                                  is_b_categorical=True,
                                  rotation_range=0.15, 
                                  height_shift_range=0.15,
                                  width_shift_range=0.15, 
                                  zoom_range=0.15,
                                  horizontal_flip=True, 
                                  vertical_flip=True,
                                  fill_mode='constant', 
                                  cval=0.,
                                  patch_divide=False, 
                                  ptch_sz=ptch_sz, 
                                  ptch_str=stride,
                                  labels=labels)         

                          
    val_it   = TwoImageIterator(val_dir, 
                                batch_size=batch_size,
                                fnames_are_same=True,  
                                target_size=(ptch_sz, ptch_sz),
                                shuffle=True,
                                is_a_grayscale=False, 
                                is_b_grayscale=False, 
                                is_b_categorical=True,
                                rotation_range=0.0, 
                                height_shift_range=0.0,
                                width_shift_range=0.0, 
                                zoom_range=0.0,
                                horizontal_flip=False, 
                                vertical_flip=False,
                                fill_mode='constant', 
                                cval=0.,
                                patch_divide=False, 
                                ptch_sz=ptch_sz, 
                                ptch_str=stride,
                                labels=labels)
           
 
    if(stop<0):
        stop = nb_epoch
        
        
    # Grava pesos quando ha melhoria na "val_loss"
    checker = callbacks.ModelCheckpoint(weights_val_loss_path, monitor='val_loss',
                        verbose=1, save_best_only=True, save_weights_only=True,
                        mode='auto', period=1)
    
    # Grava pesos quando ha melhoria na "loss"    
    saver = callbacks.ModelCheckpoint(weights_loss_path, monitor='loss', 
                        verbose=1, save_best_only=True, save_weights_only=True, 
                        mode='auto', period=1)    
    
    #TensorBoard is a visualization tool provided with TensorFlow
    # ativar TensorBorad noutra consola com o comando: #tensorboard --logdir=.../logs/#
    # fica disponivel num website local 
    tb = callbacks.TensorBoard(log_dir=log_file, histogram_freq=0, 
                        write_graph=False, write_images=False)
    
    #EarlyStopping
    stopper = callbacks.EarlyStopping(monitor='val_loss', min_delta=0.001, 
                        patience=stop, verbose=0, mode='auto')
    
    
    #Treina com o TreiningSet e avalia rede com ValidationSet
    history= u.fit_generator(train_it.generator(),
                             epoch_iterations*batch_size,
                             nb_epoch=nb_epoch,
                             verbose=2,
                             validation_data=val_it.generator(),
#                             nb_val_samples=200,
                             nb_val_samples=20,
                             callbacks=[checker,tb,stopper,saver])
    
#    history= u.fit_generator(train_it.generator(),nb_epoch=nb_epoch,verbose=2, shuffle=True, validation_split=0.1, callbacks=[checker,tb,stopper,saver])
     
#    history= u.fit(train_it.generator(), nb_epoch=nb_epoch, batch_size=batch_size, verbose=2, shuffle=True, validation_split=0.1, callbacks=[checker,tb,stopper,saver])
     
    #%%

    print(history)   
    print 'finish train: ',str_name


if __name__ == '__main__':
     
#    # Default values
#    lr=0.0001  
#    load=0
#    opt='adam'  
#    loss='l' 
#    stop=-35 
#    model_version = 'A'
#    
#    if(len(sys.argv)>1):
#        lr = float(sys.argv[1])
#    print '  lr: ',lr
#    
#    if(len(sys.argv)>2):
#        load = float(sys.argv[2])
#    print '  load: ',load 
#    
#    if(len(sys.argv)>3):
#        opt = (sys.argv[3])
#    print '  opt: ',opt 
#    
#    if(len(sys.argv)>4):
#        loss = (sys.argv[4])
#    print '  loss: ',loss 
#    
#    if(len(sys.argv)>5):
#        stop = float(sys.argv[5])
#    print '  stop: ',stop 
#
#    if(len(sys.argv)>6):
#        model_version = (sys.argv[6])
#    print '  model_version: ', model_version 
    
#     train(lr,load,opt,loss,stop, model_version)  
    
#     model_version = "A_adam"
#     print '  model_version: ', model_version 
#     train(0.0001, 0, 'adam', 'l', -75,  model_version)
#     train(0.00001, 1, 'adam', 'l', -75,  model_version)
#     train(0.000001, 1, 'adam', 'l', -75,  model_version)
#     train(0.0000001, 1, 'adam', 'l', -75,  model_version)
#    
#     model_version = "B_adam"
#     print '  model_version: ', model_version 
#     train(0.0001, 0, 'adam', 'l', -75,  model_version)
#     train(0.00001, 1, 'adam', 'l', -75,  model_version)
#     train(0.000001, 1, 'adam', 'l', -75,  model_version)
#     train(0.0000001, 1, 'adam', 'l', -75,  model_version)
         
     model_version = "ZZ_adam"
     print '  model_version: ', model_version 
     
     train(0.0001, 0, 'adam', 'l', -75,  model_version)

     train(0.00001, 1, 'adam', 'l', -75,  model_version)

     train(0.000001, 1, 'adam', 'l', -75,  model_version)

     train(0.0000001, 1, 'adam', 'l', -75,  model_version)
    

    
