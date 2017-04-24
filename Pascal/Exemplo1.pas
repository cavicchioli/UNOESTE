Program Exemplo1;

Uses NewDelay, Crt;

Var X: integer;
    P, Q: ^integer;
Begin
        CLRSCR;
	X :=10;
	P := @X;
	Q^ := 30;
	Q := P;
	Q^ := P^ + 10;
	Writeln(P^);
        readkey;
End.

