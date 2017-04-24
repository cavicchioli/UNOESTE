canario(tico).
peixe(nemo).
tubarao(tutu).
vaca(mimosa).
morcego(vamp).
avestruz(xica).
salmao(alfred).

%Todos os animais t�m pele.
tem_pele(X):-animais(X).

%Peixe � um tipo de animal, p�ssaro � outro tipo e mam�fero � um terceiro tipo.
animais(X):-aves(X);mamiferos(X);peixes(X).

aves(X):-canario(X);avestruz(X).
mamiferos(X):-vaca(X);morcego(X).
peixes(X):-peixe(X);tubarao(X);salmao(X).

%Normalmente, os peixes t�m nadadeiras e podem nadar, enquanto os p�ssaros t�m asas e podem voar.

tem_nadadeiras(X):-peixes(X).
pode_nadar(X):- nadadeiras(X).

tem_asas(X):-aves(X);morcego(X).
pode_voar(X):- asas(X).

%Se por um lado os p�ssaros e os peixes p�em ovos, os mam�feros n�o p�em. Embora tuba�es sejam peixes, eles n�o p�em ovos, seus filhotes nascem j� formados.

poem_ovos(X):-aves(X);(peixes(X),not(tubarao(X))).

%Salm�o � outro tipo de peixe e  ele � considerado uma del�cia.
comestivel(X):-salmao(X).

%As vacas d�o leite, mas tamb�m servem elas mesmas de comida (carne).
comestivel(X):-vaca(X).

%O can�rio � um p�ssaro amarelo.
cor(X,amarelo):-canario(X).

%Uma avestruz � um tipo de p�ssaro grande que n�o voa, apenas anda.
voa(X):-(aves(X),not(avestruz(X))).

%Contudo, nem todos os mam�feros andam para se mover. Por exemplo, o morcego voa.
voa(X):-morcego(X).

% Os mam�feros normalmente andam para se mover, como por exemplo, uma vaca.
anda(X):-avestruz(X);(mamiferos(X),not(morcego(X))).

nada(X):- peixes(X).





















