move(JarraA, CapacA, JarraB, CapacB, NovoA, NovoB) :- NovoA is CapacA, NovoB is JarraB, JarraA\=CapacA.

move(JarraA, CapacA, JarraB, CapacB, NovoA, NovoB) :- NovoA is 0, NovoB is JarraB, JarraA\=0.

move(JarraA, CapacA, JarraB, CapacB, NovoA, NovoB) :- NovoA is 0, NovoB is JarraA+JarraB, NovoB<CapacB, JarraA\=0.

move(JarraA, CapacA, JarraB, CapacB, NovoA, NovoB) :- NovoA is JarraA-(CapacB-JarraB), NovoB is CapacB,
	                                              CapacB-JarraB=<JarraA, JarraB\=CapacB.

altera([Cabeca|Calda], 0, Valor, [Valor|Calda]).

altera([Cabeca|Calda], Posicao, Valor, [Cabeca|NovaCalda]) :- NovaPosicao is Posicao-1,altera(Calda, NovaPosicao, Valor, NovaCalda).

pegaItem([Cabeca|Calda], Cabeca, 0).

pegaItem([_|Calda], Elemento, NovoContador) :- pegaItem(Calda, Elemento, Contador),
                                               NovoContador is Contador+1.
pegaJarra(Configuracao, Jarra, Posicao) :- pegaItem(Configuracao, Jarra, Posicao).

pegaCapacidade(Capacidades, Capac, Posicao) :- pegaItem(Capacidades, Capac, Posicao).

    pertence(X, [X|_]) :- !.
    pertence(X, [_|Z]) :- pertence(X, Z).

transicao(ConfFinal, ConfFinal, Capacidades, Lista, Contador)
                         :- reverse(Lista, NovaLista), write(NovaLista), !.

transicao(ConfInicial, ConfFinal, Capacidades, Lista,
          Contador) :- Contador>0, NovoContador is Contador-1,
          pegaJarra(ConfInicial, JarraA, PosicaoA),
          pegaCapacidade(Capacidades, CapacA, PosicaoA),
          pegaJarra(ConfInicial, JarraB, PosicaoB),
          pegaCapacidade(Capacidades, CapacB, PosicaoB),
          PosicaoA\=PosicaoB,
          move(JarraA, CapacA, JarraB, CapacB, NovoA, NovoB),
          altera(ConfInicial, PosicaoA, NovoA, ConfTemp),
          altera(ConfTemp, PosicaoB, NovoB, NovaConf),
          not(pertence(NovaConf, Lista)),
          transicao(NovaConf, ConfFinal, Capacidades,
                                            [NovaConf|Lista], NovoContador), !.

resolve(Inicial, Final, Capacidade, Contador) :-
                   caminho(Inicial, Final, Capacidade, [Inicial], Contador).
