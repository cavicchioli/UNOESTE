'''
Created on 09/05/2015

@author: Aluno
'''

def media(vet):
    soma=0
    for i in vet:
        soma+=int(i)
    return soma/vet.__len__()
    
