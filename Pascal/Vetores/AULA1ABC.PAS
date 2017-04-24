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
     {Moldura}
     TextColor(15);    {Cor de frente}
     TextBackGround(2);  {Cor de fundo}
     Gotoxy(1,1); Write(CHR(201));
     Gotoxy(79,1); Write(CHR(187));
     Gotoxy(1,25); Write(CHR(200));
     Gotoxy(79,25); Write(CHR(188));
     For k:=2 to 78 do
     begin
         gotoxy(k,1); write(CHR(205));
         gotoxy(k,25); write(CHR(205));
     end;
     For k:=2 to 24 do
     begin
         gotoxy(1,k); write(CHR(186));
         gotoxy(79,k); write(CHR(186));
     end;

     {Leitura dos elementos de um vetor}
     TL:=0;
     k:=3;       {k => Controle de linha}
     gotoxy(5,k); Write('Digite um valor (inteiro e posivito) - 0 para Sair: ');
     ReadLn(AuxNum);

     While (AuxNum>0) and (TL<TF) do
     begin
          TL:= TL+1;      { INC(TL); }
          Vetor[TL] := AuxNum;
          inc(k);
          gotoxy(5,k); Write('Digite um valor (inteiro e posivito) - 0 para Sair: ');
          ReadLn(AuxNum);
     end;

     {Lista todos os elementos de um vetor}
     Writeln;
     k:=15; {k => Controle de linha}
     gotoxy(20,k); Write('# # #  ELEMENTOS DO VETOR  # # #');
     For Indice:=1 to TL do
     begin
          inc(k);
          gotoxy(10,k);
          Write('Vetor na posiá∆o ',Indice,' ==> ', Vetor[Indice]);
     end;
     ReadKey;

     {... Continuar posicionando... os "textos" na tela ...}

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


