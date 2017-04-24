from Termo import *

class TermoCompleto(Termo):
    __pronuncia=''
    __sinonimos=['']
    
    def __init__(self, palavra_en, palavra_pt, pronuncia, sinonimos):
        Termo.__init__(self, palavra_en, palavra_pt)
        self.__pronuncia = pronuncia
        self.__sinonimos = sinonimos

    def get_pronuncia(self):
        return self.__pronuncia

    def get_sinonimos(self):
        return self.__sinonimos

    def set_pronuncia(self, value):
        self.__pronuncia = value

    def set_sinonimos(self, value):
        self.__sinonimos = value
        
    def add_sinonimo(self, novo_sinonimo):
        self.__sinonimos.append(novo_sinonimo)
        
    def tostring(self):
        return Termo.tostring(self) + self.__pronuncia
    
    
    def compara(self, palavra_en):
        if Termo.compara(self, palavra_en):
            return True
        else:
            v=False
            for i in self.__sinonimos:
                if i == palavra_en:
                    v=True;
                    break;    
            return v 


    
        