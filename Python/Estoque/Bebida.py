'''
Created on 09/05/2015

@author: Aluno
'''
from Produto import *

class Bebida(Produto):
    __volume=0.0
    __graduacao=0.0

    def __init__(self,  cod=0, desc='', qt=0, preco=0.0, grau=0.0, vol=0.0):
        Produto.__init__(self, cod, desc, qt, preco)
        self.__graduacao= grau
        self.__volume  =vol

    def get_volume(self):
        return self.__volume


    def get_graduacao(self):
        return self.__graduacao


    def set_volume(self, value):
        self.__volume = value


    def set_graduacao(self, value):
        self.__graduacao = value

    
        
        