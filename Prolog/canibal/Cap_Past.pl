%Kellen Ramos --- Victor Bertolino

pode_ir(1,1).    
pode_ir(0,1).   
pode_ir(0,2).   
pode_ir(2,0).    
pode_ir(1,0).  

valido(X,X).   
valido(3,_).   
valido(0,_).   

pertence(X, [X|_]).   
pertence(X, [_|Y]) :- pertence(X, Y).


passagem(estado(M1,C1,esq),estado(M2,C2,dir)) :- pode_ir(M,C), %direita
	M =< M1,        
        M2 is M1 - M,   
        C =< C1,       
        C2 is C1 - C,  
        M1 =< 3,       
        C1 =< 3,     
        M2 =< 3,
        C2 =< 3,
        valido(M2,C2).

passagem(estado(M1,C1,dir),estado(M2,C2,esq)) :-  pode_ir(M,C),%esquerda
        M =< 3 - M1,   
                       
        M2 is M1 + M,   
        C =< 3 - C1,    
        C2 is C1 + C,
        M1 =< 3,
        C1 =< 3,
        M2 =< 3,
        C2 =< 3,
        valido(M2,C2).



resolve(estado(0,0,dir),R, [estado(0,0,dir)|R]).  
resolve(estado(M,C,L),V,R) :- passagem(estado(M,C,L), estado(M1,C1,L1)),
 not(pertence(estado(M1,C1,L1),V)), resolve(estado(M1,C1,L1),[estado(M,C,L)|V],R).
 

imprime_lado(estado(M1,C1,esq),estado(M2,C2,dir)):-
              write('Levar '),N is M1-M2, write(N), write(' Pastor e '),
              N2 is C1-C2, write(N2), write(' Capeta da ESQUERDA para a DIREITA \n').

imprime_lado(estado(M1,C1,dir),estado(M2,C2,esq)):-
              write('Levar '),N is M2-M1, write(N), write(' Pastor e '),
              N2 is C2-C1, write(N2), write(' Capeta da DIREITA para a ESQUERDA \n').

imprime([_|[]]).
imprime([A,B|R]) :- imprime_lado(A,B), imprime([B|R]).

conc([],L,L).
conc([X|L1],L2,[X|L3]) :- conc(L1,L2,L3).

inverte_lista([],[]).
inverte_lista([X|R],L) :-
        inverte_lista(R,T),
        conc(T,[X],L).

solucao(M,C,L):- (resolve(estado(M,C,L),[],R),
        inverte_lista(R,R2), imprime(R2)).
