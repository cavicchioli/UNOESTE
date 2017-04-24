{==> Leitura dos elementos de um Vetor (de inteiros e positivos) - Tamanho
     L¢gico;
 ==> Exibir os elementos de um Vetor;
 ==> Consulta de um determinado elemento - informando a posi‡Æo que o mesmo
     se encontra no Vetor;
 ==> ExclusÆo de um determinado elemento.}
{--------------MODULARIZANDO-----------------------------------------------}

Program AULA3ABC;

Uses NewDelay, Crt;

Const TF=10;

Type TpVetor = Array [1..TF] of integer;

{==============================================================}

Procedure Moldura;
var k:integer;
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
end;

{==============================================================}
     {Leitura dos elementos de um vetor}
Procedure Leitura(Var Vetor: TpVetor; Var TL:integer);
var AuxNum, k: integer;
begin
     Moldura;
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
end;

{==============================================================}
     {Lista todos os elementos de um vetor}
Procedure Listar(Vetor: TpVetor; TL:integer);
var k, Indice: integer;
begin
     Moldura;
     k:=15; {k => Controle de linha}
     gotoxy(20,k); Write('# # #  ELEMENTOS DO VETOR  # # #');
     For Indice:=1 to TL do
     begin
          inc(k);
          gotoxy(10,k);
          Write('Vetor na posi‡Æo ',Indice,' ==> ', Vetor[Indice]);
     end;
     ReadKey;
end;

{==============================================================}
     {... Continuar posicionando... os "textos" na tela ...}

     {Consulta um determinado elemento e retorna a posi‡Æo que o mesmo
      se encontra}
Procedure Consulta(Vetor: TpVetor; TL:integer);
var AuxNum, Indice: integer;
begin
     Moldura;
     Write('Qual elemento procurar? ');  Readln(AuxNum);
     Indice:=1;
     While (Indice<=TL) and (AuxNum<>Vetor[Indice]) do
             INC(Indice);    {Indice:= Indice+1;}

     If (AuxNum=Vetor[Indice])
     then Write('O Elemento foi encontrado na posi‡Æo ',Indice)
     else Write('Elemento nÆo encontrado!');

     ReadKey;
end;

{==============================================================}
     {Excluir um determinado elemento}
Procedure Excluir(Var Vetor: TpVetor; Var TL:integer);
var AuxNum, Indice, k: integer;
begin
     Moldura;
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
end;

{==============================================================}

Function Menu: integer;
var Op: integer;
begin
    Moldura;
    Writeln('# # # Menu de Opções # # #');
    Writeln('[1] - Leitura');
    Writeln('[2] - Consulta');
    Writeln('[3] - Exclusão');
    Writeln('[4] - Listar Elementos');
    Writeln('[5] - Finalizar');
    Writeln('Op‡Æo Desejada: '); Readln(Op);
    Menu:= Op;
end;

{==============================================================}

Procedure Execucao;
var Opcao, Tam: integer;
    V:TpVetor;
begin
    TAM:=0;
    Repeat
        Opcao:= Menu;
        Case Opcao of
          1: Leitura(V,Tam);
          2: Consulta(V,Tam);
          3: Excluir(V,Tam);
          4: Listar(V,Tam);
        end;
    Until (Opcao=5);
end;

{Programa Principal}
Begin
     Execucao;
End.


