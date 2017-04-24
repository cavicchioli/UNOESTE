'''
Created on 09/05/2015

@author: Aluno
'''

dias=[5,10,20,30]
print(dias)

dias.append(21)
print(dias)

dias[0] = 9
print(dias)

outralista = [100, 200, 300, 400]

dias.append(outralista)
print(dias)

r =range(0,10)

for i in r:
    print(i)