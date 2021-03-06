%movimentos v�lidos
podeir(1,1). %um canibal e um missionario
podeir(2,0). %dois missin�rios
podeir(0,2). %dois canibais
podeir(1,0). %um missionario
podeir(0,1). %um canibal

%estados v�lidos
valido(N,N).%numero de mission�rios e canibais iguais
valido(3,_).%todos os mission�rios est�o na margem esquerda do rio
valido(0,_).%todos os mission�rios est�o na margem direita do rio


%muda o missionario e/ou canibal da margem esquerda para a direita.
mudalado(estado(M1,C1,esq),estado(M2,C2,dir)) :- podeir(M,C),
	M =< M1, M2 is M1 - M, C =< C1,
	C2 is C1 - C,M1 =< 3, C1 =< 3, M2 =< 3,
        C2 =< 3,valido(M2,C2).

%muda o missionario e/ou canibal da margem direita para a esquerda.
mudalado(estado(M1,C1,dir),estado(M2,C2,esq)) :-  podeir(M,C),
	M =< 3 - M1, M2 is M1 + M, C =< 3 - C1,
	C2 is C1 + C,M1 =< 3,C1 =< 3, M2 =< 3,
	C2 =< 3,valido(M2,C2).
%a fun��o mudalado s� controla a margem esquerda do rio.


%resolve um determinado estado do jogo, essa fun��o tem uma lista de
%estados j� percorridos, que tem por intuito vefiricar se o estado,
%j� foi percorrido, a fun��o vai chamando recursivamente e concatenando
%o a lista de percorridos.
resolve(estado(0,0,dir),R, [estado(0,0,dir)|R]).
resolve(estado(M,C,L),V,R) :- mudalado(estado(M,C,L), estado(M1,C1,L1)),
 not(pertence(estado(M1,C1,L1),V)), resolve(estado(M1,C1,L1),[estado(M,C,L)|V],R).


%imprime um estado do jogo, seja indo um canibal/missionario indo para
%margem esquerda ou direira do rio.
percurso(estado(M1,C1,esq),estado(M2,C2,dir)):-
	      write('      '),N is M1-M2, write(N), write('              '),
              N2 is C1-C2, write(N2),write('	          '),
	      write(' Sai '),write('	         '),
	      write(' Vai \n').

percurso(estado(M1,C1,dir),estado(M2,C2,esq)):-
	      write('      '),N is M2-M1, write(N), write('              '),
              N2 is C2-C1, write(N2),write('	          '),
	      write(' Vai '),write('	         '),
	      write(' Sai \n').


% percorre a lista com as chamadas que foram feitas para resolver o jogo
% e vai imprimindo os movimentos necess�rios para concluir com sucesso.
imprime([_|[]]).
imprime([A,B|R]) :- percurso(A,B), imprime([B|R]).

%funcoes basicas.
pertence(X, [X|_]).
pertence(X, [_|Y]) :- pertence(X, Y).

conct([],L,L).
conct([X|L1],L2,[X|L3]) :- conct(L1,L2,L3).

inverte_lista([],[]).
inverte_lista([X|R],L) :-
        inverte_lista(R,T),
        conct(T,[X],L).

%resolve o jogo.
%solucao(3,3,esq).
solucao(M,C,L):- (resolve(estado(M,C,L),[],R),
        inverte_lista(R,R2),tabela(_), imprime(R2),linha(_)).

tabela(_):- nl,nl,write('     ------------**CANIBAIS & MISSION�RIO**-----------'),nl,
	    linha(_),nl,
	    write('MISSION�RIOS'),write('     '),write('CANIBAIS'),write('     '),
	    write('MRG. ESQUERDA'),write('    '),write('MRG. DIREITA'),nl,linha(_),nl,nl.
linha(_):-write('___________________________________________________________').
