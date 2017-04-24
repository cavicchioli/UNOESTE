Function Maior(Elem1, Elem2: integer): integer;
begin
     If (Elem1 > Elem2)
      then Maior:= Elem1
      else Maior:= Elem2;
end;


Function MaiorElemento(Vetor: TpVetor; TL: integer):integer;
begin
     If (TL = 1)
     then MaiorElemento:= Vetor[1]
     else MaiorElemento:= Maior(Vetor[TL],MaiorElemento(Vetor, TL-1));
end;
