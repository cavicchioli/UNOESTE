'''
Created on 09/05/2015

@author: Aluno
'''
path = input("Digite o caminho do arquivo: ")
arq = open(path,'r')

tam = int(input("Em partes de quantos bytes você quer dividir esse arquivo? "))

texto=""
texto = arq.read()

i=0
k=1
while i < texto.__len__():
    nome = path.split('.')[0]
    
    novo = open(nome+str(".%03d")%(k),'w')
    novo.write(texto[i:i+tam])
    
    novo.close()
    
    i+=tam
    k+=1
    
    
    