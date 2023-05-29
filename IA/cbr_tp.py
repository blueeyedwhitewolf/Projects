# -*- coding: utf-8 -*-
"""
Created on Thu Dec 13 14:45:54 2018

@author: Admin
"""

import similarity_fun #fiheiro que criamos com a funçao de similaridade

import pickle #used to make serialization of objets

import json #used to encode and decode

class Caso(object):
    '''
    classe caso - representa um caso base
    cada caso contem os seguintes aspetos:
        -descriçao do caso: dados relevantes usados para a retrieval de casos
        -soluçao do caso
        -anotaçoes (metadados)
        estas devem traduzir-se num JSON valido
    '''
    def __init__(self,descricao=None,solucao=None):
        '''
        permite adicionar descriçao e soluçao ao caso
        '''
        self.solucao_caso={}
        self.descricao_caso={}
        self.anotacao_caso={}
        if descricao: self.set_descricao(descricao)
        if solucao: self.set_solucao(solucao)
        
    def set_descricao(self,descricao,p_etapa=1):
        '''
        Adicionar uma descricao a este caso. a descriçao é um dicionario json-encodable
        Um caso pode opcionalmente permitir multiplas descriçoes (para uma retrieval multifásica), especificando um ID_estado>1
        '''
        etapa=int(p_etapa)
        assert (type(etapa) is int) and (etapa>0)
        assert type(descricao) is dict
        
        #conversao para string para ser JSON compativel
        self.descricao_caso[str(etapa)]=descricao
        return True
        
    def get_descricao(self,p_etapa='1'):
        '''
        obtem a descriçao do problema para este caso com um estado especifico
        '''
        etapa=int(p_etapa)
        assert etapa>0
        assert str(etapa) in self.descricao_caso.keys()
        return self.descricao_caso[str(etapa)]
        
    def set_solucao(self, solucao):
        '''
        Adicionada uma soluçao para o caso. Tem que ser um dicionario JSON encodeable
        '''
        if self._is_json(solucao):
            self.solucao_caso=solucao
            return True
        else:
            return False
    
    def get_solucao(self):
        '''
        Obtem a soluçao para o caso.
        A soluçao é um dicionario especificado pelo utilizador de key-values
        '''
        return self.solucao_caso
    
    def set_anotacao(self,anotacao):
        '''
        casos de metadados. Em JSON
        '''
        if self._is_json(anotacao):
            self.anotacao_caso=anotacao
            return True
        else:
            return False
        
    def get_anotacao(self):
        '''
        obtem a anotacao
        '''
        return self.caso_anotacao
    
    def _validate(self):
        '''
        validar a estrutura de dados e converte-la no formato JSON
        '''
        return (self._is_json(self.descricao_caso) and self._is_json(self.solucao_caso) and self._is_json(self.anotacao_caso))
    
    def _is_json(self,data):
        try:
            final=json.loads(json.dumps(data))
        except Exception:
            return False
        return (type(final) is dict)
        
    def load_json(self,json_str):
        '''
        carregar um caso da string json pre-definida .
        formato:
            { "descricao": { "1": <dados>, "2": <dados> ... }
            "solucao": <dados>,
            "annotacao": <dados> (opcional)
            }
            
        o input so pode conter tipos primitivos
        '''
        seguro=json.loafs(json_str)
        return self.load_dict(seguro)
    
    def load_dict(self,seguro):
        '''
        Carregar um dicionario (ou JSON convertido em dicionario)
        ver load_json
        '''
        assert type(seguro) is dict
        if seguro.has_key('descricao'):
            for etapa in seguro['descricao'].keys():
                self.set_descricao(seguro['descricao'][etapa],etapa)
        
        if seguro.has_key('solucao'):
            self.set_solucao(seguro['solucao'])
        if seguro.has_key('anotacao'):
            self.set_anotacao(seguro['anotacao'])
            
        return self._validate()
                
        
class CasoBase(object):
    '''
    nao é usado diretamente.
    define metodos e implementa funçoes utilitarias
    '''
    def __init__(self):
        self.default_retriever=None;

    def adicionar(self, newcase):
        raise NotImplementedError

    def eliminar(self, caseid):
        raise NotImplementedError

    def atualizar(self, id, newcase):
        raise NotImplementedError

    def get_by_id(self, id):
        raise NotImplementedError

    def get_all_cases(self):
        raise NotImplementedError

    def get_all_case_tuples(self):
        raise NotImplementedError

    def get_meta(self):
        raise NotImplementedError

    def set_meta(self):
        raise NotImplementedError
        
        
    #CASE RETRIEVAL
                
    def set_default_retriever(self, retriever):
        self.default_retriever=retriever;
    
    def retrieve_similar(self, caso_act, p_retriever=None, etapa=1):
        '''
        faz retrieval baseada na similaridade ao caso atual e retriever object
        '''
        assert int(etapa)>0
        retriever=set.default_retriever
        if p_retriever:
            retriever=p_retriever
        assert retriever #no retriever and no default retriever specified
    
class MemoriaCasoBase(CasoBase):
    '''
    classe que implementa uma memoria. dados podem ser salvos ou carregados mas
    caso contratio todo a manipulaçao dos casos é éfemera
    '''
    def __init__(self):
        super(MemoriaCasoBase,self).__init__()
        #sets up data structures
        self.casos={}
        self.id_act=1
        self.meta={}
        
    def _next_id(self):
        while self.casos.has_key(self.id_act):
            self.id_act+=1
        return self.id_act
         
    #METADADOS
    def get_meta(self):
        return self.meta
    
    def set_meta(self,novo_caso):
        assert type(novo_caso) is dict
        self.meta=novo_caso
    
    def adicionar(self,novo_caso):
        '''
        Adicionar um novo caso base; retorna o ID_caso
        '''
        assert isinstance(novo_caso, Caso)
        self.casos[self._next_id()]=novo_caso
        
    def eliminar(self,ID_caso):
        '''
        Remove o caso do dicionario em memoria
        '''
        assert type(ID_caso) is int
        if self.casos.has_key(ID_caso):
            self.casos.pop(ID_caso)
            return True
        return False
        
    def atualizar(self,ID_caso,novo_caso):
        '''
        Atualizar consiste em apagar o caso antigo e inserir o novo caso
        '''
        assert type(ID_caso) is int
        assert isinstance(novo_caso,Caso)
        self.eliminar(ID_caso)
        #Assim garante-se que o ID esta vazio
        self.casos[ID_caso]=novo_caso
        return True
        
    def get_by_id(self,ID_caso):
        '''
        faz retrieval do caso pelo seu ID
        '''
        assert type(ID_caso) is int
        return self.casos.get(ID_caso)
        
    def get_all_cases(self):
        '''
        Faz retrieval de todos os casos do CBR
        '''
        for ID_caso in self.Caso.keys():
            yield self.casos[ID_caso]
    
    def get_all_case_tuples(self):
        '''
        retorna uma tuple que contem o id do caso (id,caso)
        '''
        for ID_caso in self.Casos.keys():
            yield (ID_caso,self.casos[ID_caso])
        
    def salvar_caso_base(self,file):
        '''
        Salva o caso base atualmente em memoria num ficheiro pickle
        '''
        #construir dicionario
        alvo={'id_act':self.id_act,
              'casos':self.to_dicts(),
              'meta':self.meta}
        
        try:
            pickle.dump(alvo,open(file,'w'))
        except Exception:
            print ('Falha ao salvar a Base de Casos')
            raise
            
        return True
        
    def carregar_caso_base(self,file):
        '''
        Carregar casos base pickled de volta na memoria
        '''
        try:
            fonte=pickle.load(open(file))
        except Exception:
            print ('Falha ao carregar %s' % file)
            raise
        
        assert type(fonte) is dict and fonte.has_key('id_act')
        self.id_act=fonte['id_act']
        self.casos=self.from_dicts(fonte['casos'])
        self.meta=fonte['meta']
        return True
    
    def to_dicts(self):
        '''
        retorna uma representaçao do tipo dicionario de todos os casos no caso base
        '''
        d={}
        for caso in self.casos.keys:
            d[caso]=self.casos[caso].get_dict()
        
    def from_dicts(self,fonte):
        '''
        constroi mapeamento do dicionario de volta em self.casos
        '''
        d={}
        for caso in fonte.keys():
            novo_caso=Caso()
            if novo_caso.load_dict(fonte[caso]):
                d[caso]=novo_caso