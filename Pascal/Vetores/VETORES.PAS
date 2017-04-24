{==> Leitura dos elementos de um Vetor (de inteiros e positivos) - Tamanho
     L¢gico;
 ==> Exibir os elementos de um Vetor;
 ==> Consulta de um determinado elemento - informando a posiá∆o que o mesmo
     se encontra no Vetor;
 ==> Exclus∆o de um determinado elemento.}
{----------------------------------------------------------------------------}

Program Vetores;

Uses NewDelay, Crt;

Const TF=10;

Var Vetor: Array[1..TF] of integer;
    TL, Indice, AuxNum, k: integer;


{Programa Principal}
Begin
     ClrScr;
     TL:=0;
     {Leitura dos elementos de um vetor}
     Write('Digite um valor (inteiro e posivito) - 0 para Sair: ');
     ReadLn(AuxNum);

     While (AuxNum>0) and (TL<TF) do
     begin
          TL:= TL+1;      { INC(TL); }
          Vetor[TL] := AuxNum;

          Write('Digite um valor (inteiro e posivito) - 0 para Sair: ');
          ReadLn(AuxNum);
     end;

     {Lista todos os elementos de um vetor}
     Writeln;
     Writeln('# # #  ELEMENTOS DO VETOR  # # #');
     For Indice:=1 to TL do
          Writeln('Vetor na posiá∆o ',Indice,' ==> ', Vetor[Indice]);
     ReadKey;

     {Consulta um determinado elemento e retorna a posiá∆o que o mesmo
      se encontra}
     Writeln;
     Write('Qual elemento procurar? ');  Readln(AuxNum);
     Indice:=1;
     While (Indice<=TL) and (AuxNum<>Vetor[Indice]) do
             INC(Indice);    {Indice:= Indice+1;}

     If (AuxNum=Vetor[Indice])
     then Write('O Elemento foi encontrado na posiá∆o ',Indice)
     else Write('Elemento n∆o encontrado!');

     ReadKey;

     {Excluir um determinado elemento}
     Writeln;
Write('Qual elemento excluir? ');  Readln(AuxNum);
     Indice:=1;
     While (Indice<=TL) and (AuxNum<>Vetor[Indice]) do
             INC(Indice);    {Indice:= Indice+1;}

     If (AuxNum=Vetor[Indice])
     then  Begin
                For k:=Indice to TL-1 do
                    Vetor[k]:= Vetor[k+1];

                TL:=TL-1;     {DEC(TL);}
           End;

     {Lista todos os elementos de um vetor}
     Writeln;
     Writeln('# # #  ELEMENTOS DO VETOR  # # #');
     For Indice:=1 to TL do
          Writeln('Vetor na posiá∆o ',Indice,' ==> ', Vetor[Indice]);
     ReadKey;
End.


