'''
Created on 09/05/2015

@author: Aluno
'''

class Produto(object):
    __codigo=0
    __descr=''
    __quant=0
    __preco=0.0
    
    
    
    def __init__(self, cod=0, desc='', qt=0, preco=0.0):
        self.__codigo = cod
        self.__descr=desc
        self.__quant=qt
        self.__preco=preco
        
        
    def getDescr(self):
        return self.__descr
    
    def setDescr(self,desc):
        self.__descr = desc
        
        