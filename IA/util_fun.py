# -*- coding: utf-8 -*-
"""
Created on Wed Dec 26 16:09:44 2018

@author: Admin
"""

'''
    Utility functions
'''

import array
import math
import cbr_tp
import similarity_fun

#
# Normalization
#
def minmax_normalize_case_vector(caso_base, vec_getter, nome_alvo='norm'):
    '''
    Itera sobre todos os casos no caso base e gera versoes normalizadas dos vetores numericos dados na descriçao do caso
    vec_getter - funçao que obtem o vetor numerico da descriçao do caso
    nome_alvo - nome desta entreda no dicionario de descriçao de caso
     
     Retorna vetores min,max 
    '''
    # iterates over case base cases, builds min-max array
    a_min = None
    a_max = None    
    for case in caso_base.get_all_cases():
        act = vec_getter(case.get_description()) 
        if not a_min:
            a_min = array.array('f', act)
            a_max = array.array('f', act)

        # update min and max
        for i in range(len(a_min)):
            a_min[i] = min(a_min[i], act[i])
            a_max[i] = max(a_max[i], act[i]) 

    # iterates again, generating a normalized array and saving back to case description
    for (id, case) in caso_base.get_all_case_tuples():
        desc = caso_base.get_description()
        cur = vec_getter(desc)
        n_vec = minmax_normalize(cur, a_min, a_max)
        if not desc.get('normalized'): desc['normalized'] = {}
        desc['normalized'][nome_alvo] = n_vec  #localizaçao do vetor normalizado na descriçao do caso
        case.set_description(desc)
        caso_base.update(id, case)

    # for this vector, enter min/max information onto casebase metadata
    m = caso_base.get_meta()
    if not m.get('minmax'): m['minmax'] = {}
    m['minmax'][nome_alvo] = {'min': [x for x in a_min],
                               'max': [x for x in a_max]}
    caso_base.set_meta(m)

    return (a_min, a_max)

def minmax_normalize(v, a_min, a_max):
    '''
     Normalization of a vector using given min and max vectors
    '''
    return [(v[i] - a_min[i])/(a_max[i] - a_min[i]) for i in range(len(v))]