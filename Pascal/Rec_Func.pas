Program Funcao;
Uses Newdelay, Crt;

Function G (n: integer): integer;  Forward;
Function H (n: integer): integer;  Forward;

Function F (n: integer): integer;
begin
         If (n=0)             {Caso base}
     then F:= 1
     else F:= G(n-1);    {Chama a Função G}
end;

Function G (n: integer): integer;
begin
    If (n=0)             {Caso base}
     then G:= 2
     else G:= H(n-1);    {Chama a Função H}
end;


Function H (n: integer): integer;
begin
    If (n=0)             {Caso base}
     then H:= 1
     else H:= F(n-1);    {Chama a Função F}
end;

Begin
    Clrscr;
    Writeln('F(x) = ', h(5));
    Readkey;
end.