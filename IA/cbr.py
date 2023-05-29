# -*- coding: utf-8 -*-
"""
Created on Thu Nov 15 14:55:28 2018

@author: Admin
"""

import numpy as np
import math
inputx=np.loadtxt('cbr.txt',dtype='i',delimiter='\t')

x1=inputx[...,0].tolist()
x2=inputx[...,1].tolist()
y=inputx[...,2].tolist() #representa a classe; se é frio ou se é agradável

while True:
    print('1-Novo caso')
    print('2-Guardar')
    print('0-Sair')
    opcao=int(input('Opcao:'))
    
    if opcao==0:
        break
    if opcao==1:
        x1alvo=int(input('Temperatura: '))
        x2alvo=int(input('Humidade: '))
        ji=0
        d=math.sqrt((x1alvo-x1[0])**2+(x2alvo-x2[0])**2)
        for i in range(1,len(x1)):
            di=math.sqrt((x1alvo-x1[i])**2+(x2alvo-x2[i])**2)
            if di<d:
                d=di
                ji=i
        if y[ji]==0:
            print('Leve o casaco')
        else:
            print('Tempo agradavel')
    if opcao==2:
        x1d=int(input('Temperatura: '))
        x2d=int(input('Humidade:'))
        yd=int(input('Sensacao: '))
        x1.append(x1d) #append adiciona um elemento no fim da lista
        x2.append(x2d)
        y.append(yd)

#guardar informacao(novas listas) em ficheiro
mat=np.array([x1,x2,y]).T #queremos uma lista por coluna
np.savetxt('cbr2.txt',mat,fmt='%i') #formato - queremos guardar numeros inteiros