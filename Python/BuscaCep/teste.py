from Conexao import *

meucep="19050590"

conexao = Conexao("localhost","cep","postgres","postgres123")
res = conexao.consultar("select * from tend_endereco e, tend_cidade c, tend_bairro b where e.id_cidade = c.id_cidade and e.id_bairro = b.id_bairro and e.cep like '"+meucep+"'")

for dados in res:
    print (dados)