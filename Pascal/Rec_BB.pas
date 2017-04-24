Function BB(Vetor: TpVetor; Inicio, Fim, Elemento: integer):integer;
var Meio: integer;
begin
     Meio:= (Inicio+Fim) div 2;
     If (Elemento=Vetor[Meio])
     then BB:= Meio
     else If (Inicio=Fim)
          then BB:= -1      {Elemento nao encontrado}
          else If (Elemento < Vetor[Meio])
               then BB:= BB(Vetor, Inicio, Meio-1, Elemento)
               else BB:= BB(Vetor, Meio+1, Fim, Elemento);
end;
