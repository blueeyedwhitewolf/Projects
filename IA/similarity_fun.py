# -*- coding: utf-8 -*-
"""
Created on Sat Dec 22 21:56:59 2018

@author: Admin
"""

'''
A funcao de similaridade recebe duas descricoes de problemas e retorna uma pontuacao
indicativa da similaridade dos casos
A funcao de ranking recebe uma lista ordenada de pontuaçoes de similaridade e retorna um rank de casos relevante
---> Vamos utilizar k-NearestNeighbors

Estas duas funçoes sao combinadas num 'Retriever' que representa uma estrategia de recuperaçao(retrieval)
a ser usada num caso base arbitrario (). Objetos recuperados sao passados como parametros para o objeto CasoBAse para efetuar a recuperacao no caso base

'''

import math
import cbr_tp

def similaridade_euclediana(vetor1,vetor2):
    '''
    Distancia euclediana para similaridade numerica
    '''
    assert len(vetor1)==len(vetor2)
    squares=sum([pow((vetor1[i]-vetor2[i]),2) for i in range(len(vetor1))])
    return math.sqrt(squares)

def similaridade_manhattan(vetor1,vetor2):
    '''
    distancia de manhattan do vetor1 e vetor 2
    manhattan distance= sum of  |xi-yi| for all i in vec
    '''
    assert len(vetor1)==len(vetor2)
    return sum([abs(vetor1[i]-vetor2[i]) for i in range(len(vetor1))])

#Ranking
def KNN(lista_casos,K=5):
    '''
    rating de K-NN - faz retrieval do top K de casos de uma lista de casos ordenados
    '''
    assert type(K) is int and K>0
    return lista_casos[:K]

class Retriever(object):
    '''
    Um objeto retriever comina o metodo de similaridade e metodo de ranking numa estrategia de recuperaçao de um caso
    temos que:
            -ordenar o caso base de acordo com a metrica de similaridade
            -rank resulta do ordenamento de acordo com uma funcao de rank (KNN)
    '''
    
    def __init__(self,f_simil=None,f_rank=None):
        self.similarity_function=f_simil
        self.rank_function=f_rank
        #getter por defaulr
        self.vector_gettter=lambda x:x
    
    def set_similaridade(self, f_simil):
        self.similarity_function = f_simil

    def set_ranking(self, f_rank):
        self.rank_function = f_rank

    def set_vector_getter(self, f_getter):
        '''
          The vector getter knows how to retrieve a feature vector for comparison from the case description
        '''
        self.vector_getter = f_getter

    def similar(self, cproblem1, cproblem2):
        '''
         Returns similarity of 2 case problems
        '''
        return self.similarity_function(self.vector_getter(cproblem1), self.vector_getter(cproblem2))

    def rank(self, lista_casos):
        '''
         Returns ranking based on similarity.
         caselist is of the form [ (score, Case) ...]
        '''
        lista_casos_ordenada = sorted(lista_casos, key=lambda x:x[0])
        return self.rank_function(lista_casos_ordenada)


#
# Common retrieval strageties based upon sumeric vector similarity
#

# k-NN Euclidean retriever
class K_NN_Euclidean_Retriever(Retriever):
    '''
     A subclass of Retriever object that implements k-NN retrieval with euclidean
     distance as the similarity metric.
    '''
    def __init__(self,K):
        super(K_NN_Euclidean_Retriever,self).__init__(similaridade_euclediana, lambda x: KNN(x,K))


class K_NN_Manhattan_Retriever(Retriever):
    '''
      This subclass implements k-nn case retrieval using the manhatan distance
    '''
    def __init__(self,K):
        super(K_NN_Manhattan_Retriever,self).__init__(similaridade_manhattan, lambda x: KNN(x,K))
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    