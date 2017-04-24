'''
Created on 09/05/2015

@author: Aluno
'''
from math import sqrt
vet = input(" Digite uma sequência de valores ordenados: ").split(',')

amp = round((float(vet[vet.__len__()-1])-float(vet[0]))/sqrt(vet.__len__()))

i=0
linf = float(vet[0])
lsup = float(vet[0])+amp
count=0

print("---Tabela de Frequencia---")

while i < vet.__len__():
    while float(vet[i]) >= linf and float(vet[i]) < lsup:
        count+=1
        i+=1
        
        if(i>=vet.__len__()):
            break
       
    
    print('%d %d %d'%(linf,lsup,count))   
    linf=lsup
    lsup = linf+amp
    count=0