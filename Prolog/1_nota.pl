nota(joao,5.0).
nota(maria,6.0).
nota(joana,8.0).
nota(mariana,9.0).
nota(cleuza,8.5).
nota(jose,6.5).
nota(joaquim,4.5).
nota(mara,-1).
nota(mary,11).

situacao(Aluno):-nota(Aluno,X), resp(X, Mens),nl,write(Mens),nl.

resp(Valor,Mensagem):- Valor >= 7.0, Valor =< 10.0,  Mensagem = 'APROVADO'.
resp(Valor,Mensagem):- Valor >= 5.0, Valor < 7.0, Mensagem = 'RECUPERACAO'.
resp(Valor,Mensagem):- Valor >= 0.0, Valor < 5.0, Mensagem = 'REPROVADO'.
resp(Valor,Mensagem):- Valor < 0 ; Valor > 10.0, Mensagem = 'ERRO'.
