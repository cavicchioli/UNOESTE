'''
Created on 09/05/2015

@author: Victor Hugo Cavichiolli Prado
'''
from fileinput import input
print('Alo Mundo')

frase1 = 'Primeiro programa em PYTHON'

print(frase1)

frase2 = '''Se voce precisar declarar uma frase
            que é muito grande e usa mais de uma linha use as aspas triplas!!'''
            
print(frase2)


''' Se os objetos forem diferentes de string usa a virgula para concatenar'''
print('Alo Mundo:',frase1,100)

''' Se é so string usa o +'''
print(frase1+' '+frase2)

print(frase1.__len__())

print(frase2[0:15])

valor = '1000'
'''CONVERSAO'''
num = int(valor) 

preco = 1.99

mpreco= 'Quantidade: %5d R$ %10.2f'%(2,preco)
print(mpreco)


'''preco = input('Informe o preco do produto')'''


imposto = 0

if preco > 1000:
    imposto = 7.5
elif preco > 700:
    imposto = 5.0
elif preco >200:
    imposto = 3.5
else:
    imposto = 1
    
    print('Imposto a ser pago: ',preco * (imposto/preco))
    









