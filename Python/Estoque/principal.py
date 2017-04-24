'''
Created on 09/05/2015

@author: Aluno
'''
from Produto import *
from Bebida import *

if __name__=='__main__':
    #cafe = Produto(desc='Café')
    cafe = Produto(1,'Café',10,5.5)
    print(cafe.getDescr())
    cafe.setDescr('Café Cruzeiro do Sul')
    print(cafe.getDescr())

skol = Bebida(2,'Cerveja',36,1.5,5.5,550)

print(skol.getDescr())


estoque = [];
estoque.append(skol)
estoque.append(cafe)
estoque.append(Produto(9,'Fandangos',1,4))

for prod in estoque:
    print(prod.getDescr())
    if isinstance(prod, Bebida):
        print(prod.get_graduacao())
    
    