resolve:-
  estado_inicial(EA),
  resolve(EA,_,a,[]).

estado_inicial(s(esq,e(3,3),d(0,0))).
estado_final(s(dir,e(0,0),d(3,3))).

escreve([]).
escreve([s(B,e(NME,NCE),d(NMD,NCD))|R]):-
    write(B),
    write('        '),write(NME),write('      '),write(NCE),
    write('        '),write(NMD),write('      '),write(NCD),nl,
    escreve(R).


resolve(EA,_,_,Caminho):-
    estado_final(EA),
    write('Barco'),write('     '),write('Margem Esquerda'),
    write('    '),write('Margem Direita'),nl,
    write('           Mis   Can     '),write('Mis  Can'),nl,
    escreve(Caminho).  %,fail

resolve(EA,ES,EAnt, Caminho):-
  move(EA,ES),
  ES\=EAnt,
  naoviola(ES),
  append(Caminho,[ES],NovoCaminho),
  resolve(ES,_,EA,NovoCaminho).

naoviola(s(_,e(NME,NCE),d(NMD,NCD))):-
    naoviola(NME,NCE),
    naoviola(NMD,NCD).

naoviola(0,_).
naoviola(NM,NC):-
  NC=<NM.

n(1).
n(2).

%%Mover 1/Dois Canibais para a direita

move(s(esq,e(NME,NCE),d(NMD,NCD)),
    s(dir,e(NME,NNCE),d(NMD,NNCD))):-
      n(N), NCE > N - 1,
      NNCE is NCE - N, NNCD is NCD + N.


%%Mover 1/Dois Canibais para a esquerda
move(s(dir,e(NME,NCE),d(NMD,NCD)),
    s(esq,e(NME,NNCE),d(NMD,NNCD))):-
      n(N), NCD > N - 1,
      NNCD is NCD - N, NNCE is NCE + N.

%%Mover 1/Dois Missionários para a direita

move(s(esq,e(NME,NCE),d(NMD,NCD)),
    s(dir,e(NNME,NCE),d(NNMD,NCD))):-
      n(N), NME >= N ,
      NNME is NME - N, NNMD is NMD + N.

%%Mover 1 Missionário e um Canibal para a direita
move(s(esq,e(NME,NCE),d(NMD,NCD)),
    s(dir,e(NNME,NNCE),d(NNMD,NNCD))):-
      NME > 0 , NCE > 0,
      NNME is NME - 1, NNMD is NMD + 1,
      NNCE is NCE - 1, NNCD is NCD + 1.

%%Mover 1 Missionário e um Canibal para a esquerda
move(s(dir,e(NME,NCE),d(NMD,NCD)),
    s(esq,e(NNME,NNCE),d(NNMD,NNCD))):-
      NME > 0 , NCE > 0,
      NNME is NME + 1, NNMD is NMD - 1,
      NNCE is NCE + 1, NNCD is NCD - 1.
%%Mover 1/Dois Missionários para a esquerda
move(s(dir,e(NME,NCE),d(NMD,NCD)),
    s(esq,e(NNME,NCE),d(NNMD,NCD))):-
      n(N), NMD > N - 1,
      NNMD is NMD - N, NNME is NME + N.

