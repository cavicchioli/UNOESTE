Program Lista_Dinamica;

Uses NewDelay, Crt;

Type TpInfo = String[20];
     TpPont = ^TpCaixa;
     TpCaixa = Record
                     Nome: TpInfo;
                     Prox: TpPont;
               end;

Function Conhece_Elemento: TpInfo;
Var AuxNome: TpInfo;
begin
     Write('Nome => ');
     Readln(AuxNome);
     Conhece_Elemento:= AuxNome;
end;

Procedure Inicializa(var Ponteiro: TpPont);
begin
     Ponteiro:= nil;
end;

Procedure Cria_Caixa(var Caixa: TpPont; Info: TpInfo);
begin
    New(Caixa);
    Caixa^.Nome:= Info;
    Caixa^.Prox:= nil;
end;

Procedure Insere(var L: TpPont; Elem: TpInfo);
var P: TpPont;
begin
    Cria_Caixa(P,Elem);
    If L = Nil
     then L:= P
     else begin
               P^.Prox := L;
               L := P;
          end;
end;

Procedure Exibe_Lista(L: TpPont);
begin
     While (L <> nil) do
     begin
          Writeln(L^.Nome);
          L:= L^.Prox;
     end;
     ReadKey;
end;

var Opcao: Char;
    Lista: TpPont;
Begin
    Inicializa(Lista);
    Repeat
          ClrScr;
          Writeln('[1] Insere');
          Writeln('[2] Exibe Lista');
          Writeln('[3] Finalizar');
          Write('Op‡Æo: ');
          Opcao := ReadKey;
          Writeln;
          Case Opcao of
            '1': Insere(Lista, Conhece_Elemento);
            '2': Exibe_Lista(Lista);
          End;
    Until (Opcao = '3');
End.