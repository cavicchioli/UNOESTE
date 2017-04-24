Program Matriz_Ex1;

Uses Newdelay, Crt;

Const  TC=3;
       TL=3;

Var  Matriz: Array[1..TL, 1..TC] of Real;
     l,c: integer;
     Maior: Real;

BEGIN
     ClrScr;

     For l:=1 to TL do
       For c:=1 to TC do
       begin
            Write('Matriz [',l, ',',c,']: ');
            Readln(Matriz[l,c]);
       end;

     Maior:=Matriz[1,1];

     Writeln;
     For l:=1 to TL do
       For c:=1 to TC do
       begin
            Writeln('Matriz [',l, ',',c,']: ',Matriz[l,c]:8:2);
            If (Maior<Matriz[l,c])
              then  Maior := Matriz[l,c];
       end;

      Writeln;
      Writeln('---------------------------------------------------');
      Write('O maior elemento da Matriz ‚: ', Maior:8:2);
      Readkey;
END.