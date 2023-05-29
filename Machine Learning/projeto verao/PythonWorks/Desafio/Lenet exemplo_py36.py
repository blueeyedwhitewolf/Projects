
# necessario apenas se criarmos o modelov

 
from keras.utils import np_utils
from keras.models import model_from_json

#import pandas as pd
import numpy as np

import os
import h5py
import matplotlib.pyplot as plt


from keras.models import  Model
from keras.layers import  Dense, Input
 
from keras.layers import normalization

from keras.layers.convolutional import Conv2D
from keras.layers.convolutional import MaxPooling2D
from keras.layers.core import Flatten, Dropout


#===========================
# Path - no windows, mudar barra par "/"
#pathDatasets = 'c:/Users/Public/Challenge_Fev23'
pathDatasets = '/home/python36/PythonWorks/CursoAtividadeProposta'
# Exemplo linux
#pathDatasets = '/home/acunha/Exemplo de Lenet'

# Pesos ja gravados
fileNameWeights = 'pesosCntAgua2_sozinhos.h5'
# se quizermos gravar novos pesos
fileNameWeights_save= 'pesosCntAgua2_sozinhos.h5'

# Dataset
#fileNameDataSet1 = "cntDataSet_CntAgua2_Total.h5" 
fileNameDataSet2 = "cntDataSet_CntAgua2_SoUnidades.h5" 

fileNameModel = "modeloCntAgua2_SoUnidades.json"

#===========================
#===========================
# Le Arrays do ficheio h5 com e sem compressao  
#===========================
def leDatasets(nome):
    
    with h5py.File(os.path.join(pathDatasets,nome),'r') as hf:
        ## Training set 
        g_train_set = hf.get('set')
        set_x = np.array(g_train_set.get('set_x'))
        set_y = np.array(g_train_set.get('set_y'))
        
    return set_x, set_y 
#===========================
#===========================
# Grava Arrays para ficheio h5 com_Compressao
#===========================
def gravaDatasets(nome):
    with h5py.File(os.path.join(pathDatasets,nome), 'w') as hf:
        # Training set
        g_set = hf.create_group('set')
        g_set.create_dataset('set_x', data = X, 
                          compression="gzip", compression_opts=9)
        g_set.create_dataset('set_y', data = y, 
                          compression="gzip", compression_opts=9)
       
#=========================
#=========================
# Shows image and label
#=========================
def digitPlot(img, label):
    img = np.int16(img.reshape(30, 20))
    
    plt.figure()

    plt.xticks(())
    plt.yticks(())
    plt.imshow(img, cmap='gray')

    plt.show()        
    
    # as unidades divide por 5 e as dezenas divide por 10
    print ("Label = ", label , "  Digit value = ", label/5)

#===============================
#===============================
# load json and create model
#===============================
def readModel(fileNameModel, fileNameWeights):
    json_file = open(os.path.join(pathDatasets,fileNameModel), 'r')
    loaded_model_json = json_file.read()
    json_file.close()
    model = model_from_json(loaded_model_json)
    
    # load weights into new model
    model.load_weights(os.path.join(pathDatasets,fileNameWeights))
    print("Loaded model and model weights from disk")

    return model

#===============================
#===============================
# serialize model to JSON
#===============================
def writeModel(filename):
    model_json = model.to_json()
    with open(filename, "w") as json_file:
        json_file.write(model_json)
      
# =================================
# =================================
# training 50   test 10  validation 10
# =================================
def TrainTestSplit(set_x, set_y,trainPercentage):
    
    # delets first row - used for initate array
    set_x = np.delete(set_x, 0,0)
    set_y = np.delete(set_y, 0,0)
    
    indice = np.arange(0,set_x.shape[0], 1)
    np.random.shuffle(indice)
    
    #--------
    # Variavel train set
    tamanhoTrain = int(set_x.shape[0]*trainPercentage)
    
    train_set_x = np.empty((tamanhoTrain,set_x.shape[1]), np.float32)
    train_set_y= np.empty((tamanhoTrain,set_y.shape[1]), np.int)
    
    for i in range(0,tamanhoTrain):
        train_set_y[i,:] = set_y[indice[i],:]
        train_set_x[i,:] = set_x[indice[i],:]
            
    #--------
    # Variavel test set
    tamanhoTest = set_x.shape[0] - tamanhoTrain 
    
    test_set_x = np.empty((tamanhoTest,set_x.shape[1]), np.float32)
    test_set_y= np.empty((tamanhoTest,set_y.shape[1]), np.int)
    
    for i in range(0, tamanhoTest):
        test_set_y[i,:] = set_y[indice[i+tamanhoTrain ],:]
        test_set_x[i,:] = set_x[indice[i+ tamanhoTrain ],:]
    
    return train_set_x,  train_set_y, test_set_x, test_set_y 


# =================================z
# =================================
def dataAugmentation( X , y ) :
  
    DataSet_X = X
    DataSet_y = y
        
    New_X = DataSet_X
    # Retira 2 clonuna pixels a esquera
    for j in range(1,2):
        i = 580
        while i>=0:
            New_X = np.delete(New_X,i,axis=1) 
            i -=20 
        
        idx = (19, 38, 57, 76, 95, 114, 133, 152, 171, 190, 209, 228, 247,\
               266, 285, 304, 323, 342, 361, 380, 399, 418, 437, 456, 475,\
               494, 513, 532, 551,570 )
        
        New_X  = np.insert(New_X, idx, 0, axis=1)
    
    DataSet_X = np.vstack([DataSet_X, New_X])
    DataSet_y = np.append(DataSet_y, y)
    print("shift2 <<")
                       
    # Retira 4 clonuna pixels a esquera
    for j in range(1,2):
        i = 580
        while i>=0:
            New_X = np.delete(New_X,i,axis=1) 
            i -=20 
        
        idx = (19, 38, 57, 76, 95, 114, 133, 152, 171, 190, 209, 228, 247,\
               266, 285, 304, 323, 342, 361, 380, 399, 418, 437, 456, 475,\
               494, 513, 532, 551,570 )
        
        New_X  = np.insert(New_X, idx, 0, axis=1)
    
    DataSet_X = np.vstack([DataSet_X, New_X])
    DataSet_y = np.append(DataSet_y, y)
    print("shift2 <<")
    
    
    New_X = X
    # Retira 2 clonuna pixels a direita
    for j in range(1,2):
        i = 599
        while i>=0:
            New_X = np.delete(New_X,i,axis=1) 
            i -=20 
        
        idx = (0, 19, 38, 57, 76, 95, 114, 133, 152, 171, 190, 209, 228, 247,\
               266, 285, 304, 323, 342, 361, 380, 399, 418, 437, 456, 475,\
               494, 513, 532, 551)
        
        New_X  = np.insert(New_X, idx, 0, axis=1)
    
    DataSet_X = np.vstack([DataSet_X, New_X])
    DataSet_y = np.append(DataSet_y, y)    
    print("shift2 >>")
    
    # Retira 4 clonuna pixels a direita
    for j in range(1,2):
        i = 599
        while i>=0:
            New_X = np.delete(New_X,i,axis=1) 
            i -=20 
        
        idx = (0, 19, 38, 57, 76, 95, 114, 133, 152, 171, 190, 209, 228, 247,\
               266, 285, 304, 323, 342, 361, 380, 399, 418, 437, 456, 475,\
               494, 513, 532, 551)
        
        New_X  = np.insert(New_X, idx, 0, axis=1)
    
    DataSet_X = np.vstack([DataSet_X, New_X])
    DataSet_y = np.append(DataSet_y, y)  
    print("shift2 >>")
    
    
    return DataSet_X, DataSet_y    
    
#===============================
#===============================
#===============================
#===============================
#===============================


# Le set de treino

X2, y2 = leDatasets(fileNameDataSet2)

# Remove primeira linha do array do datasets - e lixo
X2 = np.delete(X2,0,0)  
y2 = np.delete(y2,0,0)  

# Seleciona apenas o Digito das unidades

X_u = np.copy(X2[:,1800:2400])
y_u = y2[:,3]

#  retirei data augmentaion
#X, y = dataAugmentation( X_u , y_u)
X = X_u
y = y_u



X = X.reshape(X.shape[0],30, 20)

# Previous
#X = X[:,np.newaxis,:,:]

X = X[:,:,:,np.newaxis]

#digitPlot(X_u[0,:],y_u[0])


# Caso nao queria fazer dataAugmentation
#X=X_u
#y=y_u

N_img_prever = 256


digitPlot(X[N_img_prever,:],y[N_img_prever])

# convert list of labels to binary class matrix

# ---->>>> Vou usar apenas o contador das unidades <<<<-----
y_train = np_utils.to_categorical(y) 
#y_test = np_utils.to_categorical(test_set_y[:,3]) 
#y_valid = np_utils.to_categorical(valid_set_y) 

#===============================
# pre-processing: divide by max and substract mean
#-------------
X_train  = np.copy(X)
scale = np.max(X_train)
X_train /= scale

#X_test = test_set_x
#X_test /= scale

mean = np.std(X_train)
X_train -= mean
#X_test -= mean


#input_dim = X_train.shape[1]
nb_classes = y_train.shape[1]

#=============================== Relu
#===============================
# Cria o modelo - alternativa a le-lo ja gravado
#===============================
 
width=20
height=30
depth=1 

classes_U = 50 
 
# Dozen Digit =================================================================
inputs_U = Input(shape=(height, width, depth), name = "Digit_U")

conv1_U = Conv2D(20, (5, 5), padding="same", activation='relu', name = "conv1_U")(inputs_U) 
maxpool1_U = MaxPooling2D(pool_size=(2, 2), strides=(2, 2), name = "MaxPooling1_U")(conv1_U) 

conv2_U = Conv2D(50, (5, 5), padding="same", activation='relu', name = "conv2_U")(maxpool1_U) 
maxpool2_U = MaxPooling2D(pool_size=(2, 2), strides=(2, 2), name = "MaxPooling2_U")(conv2_U) 

flatten_U = Flatten(name = "flatten1_U")(maxpool2_U)
DenseU = Dense(500, activation='relu', name = "dense1_U")(flatten_U) 

output_U = Dense(50, activation='softmax', name = "output_U")(DenseU) 
 
 
model = Model(inputs=[inputs_U], outputs=output_U)
  

#model.compile(loss="categorical_crossentropy", optimizer='adam', metrics=['accuracy']) 


#Grava modelo em formato json
#writeModel(fileNameModel)
 

# Le modelo e pesos ja gravado - alternativa a cria-lo
#model = readModel(fileNameModel, fileNameWeights)


# we'll use MSE (mean squared error) for the loss, and RMSprop as the optimizer
model.compile(loss='mse', optimizer='rmsprop',metrics=['accuracy'])


#===============================
#===============================
# Training....
#===============================

print("Training...")
#model.fit(X_train, y_train, nb_epoch=15, batch_size = none, verbose=1)
model.fit(X_train, y_train, epochs=1, batch_size = 32, shuffle=True, verbose=1)


#===============================
#===============================
#score = model.evaluate(X_test, test_set_y, batch_size = none), 
#===============================

#score = model.evaluate(X_test, y_test, verbose=1) 
#print("\n\n Beste Score = \n [0.00033908228409012078, 0.99531250000000004] \nn Score = \n", score)

#===============================
#===============================
# serialize weights to HDF5 - Grava novos pesos
#===============================

model.save_weights(os.path.join(pathDatasets,fileNameWeights_save))
#print("Saved model weights to disk")



#===============================
#===============================
# Exemplo de previsoes
#===============================
#Digito que vai prever
N_img_prever = 149

#Mostra o digito que vamos prever
digitPlot(X[N_img_prever,:],y[N_img_prever])

X_aux = X_train[np.newaxis, N_img_prever,:]
 

valor_previsto_digito = model.predict(X_aux, verbose=1)

print ("Resltado previsao = ", valor_previsto_digito/5, " resultado GT = ", y[N_img_prever]/5)




