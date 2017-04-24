'''
Created on 09/05/2015

@author: Aluno
'''
def sdata(dia, mes, ano):
    lst = ["Janeiro", "Fevereiro",    "Março",    "Abril",    "Maio" , "Junho" ,"Julho","Agosto", "Setembro","Outubro","Novembro","Dezembro"]
    
    print(dia,' de ',lst[mes-1],' de ',ano)


data = (input("Digite a data:")).split('/')

dia = int(data[0])
mes = int(data[1])
ano = int(data[2])

sdata(dia, mes, ano)