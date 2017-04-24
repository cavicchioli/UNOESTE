from Termo import Termo

class Dicionario(object):
    
    __palavras=[]

    def __init__(self, palavras):
        self.__palavras = palavras

    def get_palavras(self):
        return self.__palavras

    def set_palavras(self, value):
        self.__palavras = value

    def insere(self, termo):
        self.__palavras.append(termo)
    
    def traduz(self, palavra_en):
        for p in self.__palavras:
            if p.compara(palavra_en):
                return p.get_palavra_pt()
        return 'Não há tradução'
           
    def contem(self, palavra_en):
        v=False
        for p in self.__palavras:
            v =p.compara(palavra_en)
            
        return v
    
    def remove(self, palavra_en):
        for i in range(self.__palavras.__len__()):
            if self.__palavras[i].compara(palavra_en):
                self.__palavras[i].remove()
                
    def get_total(self):
        return self.__palavras.__len__()
