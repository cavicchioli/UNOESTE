'''
Created on 09/05/2015

@author: Aluno
'''

class Termo(object):
    __palavra_en=''
    __palavra_pt=''

    def __init__(self, palavra_en, palavra_pt):
        self.__palavra_en = palavra_en
        self.__palavra_pt = palavra_pt

    def get_palavra_en(self):
        return self.__palavra_en

    def get_palavra_pt(self):
        return self.__palavra_pt

    def set_palavra_en(self, value):
        self.__palavra_en = value

    def set_palavra_pt(self, value):
        self.__palavra_pt = value
    
    def tostring(self):
        return self.__palavra_en+' '+self.__palavra_pt
    
    def compara(self, palavra_en):
        if self.__palavra_en == palavra_en:
            return True
        else:
            return False