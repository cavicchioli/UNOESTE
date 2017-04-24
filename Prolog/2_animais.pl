canario(tico).
peixe(nemo).
tubarao(tutu).
vaca(mimosa).
morcego(vamp).
avestruz(xica).
salmao(alfred).

%Todos os animais têm pele.
tem_pele(X):-animais(X).

%Peixe é um tipo de animal, pássaro é outro tipo e mamífero é um terceiro tipo.
animais(X):-aves(X);mamiferos(X);peixes(X).

aves(X):-canario(X);avestruz(X).
mamiferos(X):-vaca(X);morcego(X).
peixes(X):-peixe(X);tubarao(X);salmao(X).

%Normalmente, os peixes têm nadadeiras e podem nadar, enquanto os pássaros têm asas e podem voar.

tem_nadadeiras(X):-peixes(X).
pode_nadar(X):- nadadeiras(X).

tem_asas(X):-aves(X);morcego(X).
pode_voar(X):- asas(X).

%Se por um lado os pássaros e os peixes põem ovos, os mamíferos não põem. Embora tubaões sejam peixes, eles não põem ovos, seus filhotes nascem já formados.

poem_ovos(X):-aves(X);(peixes(X),not(tubarao(X))).

%Salmão é outro tipo de peixe e  ele é considerado uma delícia.
comestivel(X):-salmao(X).

%As vacas dão leite, mas também servem elas mesmas de comida (carne).
comestivel(X):-vaca(X).

%O canário é um pássaro amarelo.
cor(X,amarelo):-canario(X).

%Uma avestruz é um tipo de pássaro grande que não voa, apenas anda.
voa(X):-(aves(X),not(avestruz(X))).

%Contudo, nem todos os mamíferos andam para se mover. Por exemplo, o morcego voa.
voa(X):-morcego(X).

% Os mamíferos normalmente andam para se mover, como por exemplo, uma vaca.
anda(X):-avestruz(X);(mamiferos(X),not(morcego(X))).

nada(X):- peixes(X).





















