Program Lista_Dinamica;

Uses NewDelay, Crt;

Type TpInfo = String[20];
     TpPont = ^TpCaixa;
     TpCaixa = Record
                     Info: TpInfo;
                     Prox: TpPont;
                end;

Procedure Inicializa(var L: TpPont);
begin
     L:= Nil;
end;

Procedure Cria_Caixa(Var Caixa: TpPont; Elemento: TpInfo);
begin
     New(Caixa);
     Caixa^.Info:= Elemento;
     Caixa^.Prox:= Nil;
end;

Function Conhece_Elemento: TpInfo;
var AuxInfo: Tpinfo;
Begin
     Write('Informa‡Æo: ');
     Readln(AuxInfo);
     Conhece_Elemento:= AuxInfo;
end;

Procedure Insere(var L: TpPont; Elemento:TpInfo);
Var AuxCaixa: TpPont;
Begin
     Cria_Caixa(AuxCaixa, Elemento);
     AuxCaixa^.Prox:= L;
     L:= AuxCaixa;
end;

Procedure Exibe(L: TpPont);
begin
     If (L=Nil)
     then Write('Lista Vazia!!!')
     else While (L <> Nil) do
          Begin
               Writeln(L^.Info);
               L:= L^.Prox;
          End;
    ReadKey;
end;

{Principal}
Var Lista: TpPont;
Begin
     Inicializa(Lista);
     Insere(Lista, Conhece_Elemento);
     Exibe(Lista);

End.
{===============================================================================
Implementar os módulos para:
a) Exibir o primeiro elemento da lista;
b) Exibir o último elemento da lista;
c) Inserir após o último elemento;
d) Inserir entre dois elementos previamente conhecidos via usuário;
e) Consultar um determinado elemento;
f) Exibir todos os elementos da lista recursivamente;
g) Excluir um determinado elemento;
h) Excluir todos os elementos da lista (não recursivamente e recursivamente);
i) Inserir os elementos ordenados alfabeticamente.

===============================================================================}
