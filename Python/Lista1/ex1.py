'''
Created on 09/05/2015

@author: Aluno
'''
import math
from math import sqrt

p1 = (input("Informe o valor do 1º ponto da reta (x,y): ")).split(',')
p2 = (input("Informe o valor do 2º ponto da reta (x,y): ")).split(',')

x1 = float(p1[0])
y1 = float(p1[1])

x2 = float(p2[0])
y2 = float(p2[1])

dist = sqrt((x2-x1)**2 + (y2-y1)**2)

print('A distância entre os pontos p1 e p2 é: ',dist);
