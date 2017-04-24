cidade(s�o_mateus,pequena).
cidade(vit�ria,m�dia).
cidade(s�o_paulo,grande).
cidade(macei�,m�dia).
cidade(campos,pequena).
cidade(cariacica,pequena).
cidade(colatina,pequena).

capital(vit�ria).
capital(macei�).
capital(s�opaulo).

estado(es,sudeste).
estado(al,nordeste).
estado(sp,sudeste).

pertence(s�o_mateus,es).
pertence(vit�ria,es).
pertence(santos,sp).
pertence(macei�,al).
pertence(colatina,es).
pertence(cariacica,es).


cidade_pequena(X):-cidade(X,Tam), Tam = pequena.
cidade_na_regi�o_norte(X):-pertence(X,Est), estado(Est,Y), Y = nordeste.
capital_regi�o_sul(X):-pertence(X,Est), estado(Est,Y), capital(X), Y=sul.
cidade_pequena_regi�o_sudeste(X):-pertence(X,Est), estado(Est,Y),cidade(X,W), Y = sudeste, W = pequena.
estado_com_capital_grande(X):-estado(X,_),pertence(Cid,X),cidade(Cid,T), capital(Cid), T = grande.
estado_regi�o_nordeste_com_capital_m�dia(X)
cidade_pequena_do_estado(X,Y)

