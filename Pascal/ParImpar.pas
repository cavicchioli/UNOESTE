Program Par_Impar;
Uses Newdelay, Crt;

Function Impar(Numero: integer): boolean; Forward;

Function Par(Numero: integer): boolean;
begin
    If (Numero=0)                            {Caso Base}
     then Par:= true
     else Par:= Impar(Numero-1);   {Chama a Fun��o �mpar}
end;


Function Impar(Numero: integer): boolean;
begin
    If (Numero=0)                            {Caso Base}
     then Impar:= false
     else Impar:= Par(Numero-1);   {Chama a Fun��o Par}
end;


begin
    Clrscr;
    Writeln('� par? ', Par(6));
    readkey;
end.