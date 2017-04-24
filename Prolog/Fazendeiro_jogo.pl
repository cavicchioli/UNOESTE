% [Fazendeiro,Carneiro,Lobo,Repolho]


%Kellen Ramos
%Victor Bertolino


%lados
oposto(esquerda,direita).
oposto(direita,esquerda).

% fazendeiro e o carneiro

pode_ir([FC,FC,L,R],
	[NFC,NFC,L,R]):-
	oposto(FC,NFC),
	write('Fazendeiro leva o Carneiro para o lado '+ NFC), nl.

% fazendeiro sozinho

pode_ir([F,C,L,R],
	[NF,C,L,R]):-
	oposto(F,NF),
	write('Fazendeiro vai sozinho para o lado '+ NF), nl.

% fazendeiro lobo

pode_ir([FL,C,FL,R],
	[NFL,C,NFL,R]):-
	oposto(FL,NFL),
	write('Fazendeiro leva o Lobo para o lado '+ NFL), nl.

% fazendeiro repolho

pode_ir([FR,C,L,FR],
	[NFR,C,L,NFR]):-
	oposto(FR,NFR),
	write('Fazendeiro leva o Repolho para o lado '+ NFR), nl.

permitido([Fc,Fc,_,_]).
permitido([Fl,_,Fl,_]).
permitido([FLR,C,FLR,FLR]):-
	oposto(C,FLR),
	white('Fazendeiro volta ').


pertence(Elem,[Elem|_]).
pertence(Elem,[_|Cauda]):-
	pertence(Elem,Cauda).

caminho(C,C,Cam,Cam).
caminho(C,D,Caux,Cam):-
	pode_ir(C,Aux), permitido(Aux),
	not(pertence(Aux,Caux)),
	caminho(Aux,D,[Aux|Caux],Cam).

solucao(Inicial,Final,Cam):-
	caminho(Final,Inicial,Final,Cam).



%para chamar =
% solucao([direita,direita,direita,direita],[esquerda,esquerda,esquerda,esquerda],cam).

