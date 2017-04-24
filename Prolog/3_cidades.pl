cidade(são_mateus,pequena).
cidade(vitória,média).
cidade(são_paulo,grande).
cidade(maceió,média).
cidade(campos,pequena).
cidade(cariacica,pequena).
cidade(colatina,pequena).

capital(vitória).
capital(maceió).
capital(sãopaulo).

estado(es,sudeste).
estado(al,nordeste).
estado(sp,sudeste).

pertence(são_mateus,es).
pertence(vitória,es).
pertence(santos,sp).
pertence(maceió,al).
pertence(colatina,es).
pertence(cariacica,es).


cidade_pequena(X):-cidade(X,Tam), Tam = pequena.
cidade_na_região_norte(X):-pertence(X,Est), estado(Est,Y), Y = nordeste.
capital_região_sul(X):-pertence(X,Est), estado(Est,Y), capital(X), Y=sul.
cidade_pequena_região_sudeste(X):-pertence(X,Est), estado(Est,Y),cidade(X,W), Y = sudeste, W = pequena.
estado_com_capital_grande(X):-estado(X,_),pertence(Cid,X),cidade(Cid,T), capital(Cid), T = grande.
estado_região_nordeste_com_capital_média(X)
cidade_pequena_do_estado(X,Y)

