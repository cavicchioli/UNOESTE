'''
Created on 09/05/2015

@author: Aluno
'''
from random import randint

resp = randint(0,100)

v=-1

while v != resp:
    v = int(input("Digite sua resposta: "))
    if v < resp:
        print("Seu chute é menor que a resposta!")
    elif v > resp:
        print("Seu chute é maior que a resposta!")
    else:
        break

print("Parabéns você acertou:", resp)   

