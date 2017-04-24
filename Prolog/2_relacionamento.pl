homem(pedro).
homem(marcos).
homem(ze).

mulher(maria).
mulher(joana).

idade(ze,30).
idade(maria,40).
idade(marcos,20).
idade(pedro,25).
idade(joana,28).

gosta(ze,aventura).
gosta(maria,comedia).
gosta(joana,romance).
gosta(marcos,terror).
gosta(marcos,romance).
gosta(pedro,romance).
gosta(maria,romance).

opcao(pedro,18,30).
opcao(marcos,17,28).
opcao(ze,20,40). % significa que o zé gostaria de se relacionar com pessoas 20 a 40 anos
opcao(joana,30,45).
opcao(maria,25,55).

afinidade_filme(X,Y):-gosta(X,Tipo), gosta(Y,Tipo).
casal(X,Y):-homem(X),mulher(Y).
casal(X,Y):-mulher(X),homem(Y).
casal_afinidade_filme(X,Y):-casal(X,Y),afinidade_filme(X,Y).
casal_afinidade_idade(X,Y):-opcao(X,D,A), idade(Y,Idd), Idd >= D, Idd =< A.
casal_afinidade_idade(X,Y):-opcao(Y,D,A), idade(X,Idd), Idd >= D, Idd =< A.
casal_total(X,Y):-casal_afinidade_filme(X,Y),casal_afinidade_idade(X,Y).





