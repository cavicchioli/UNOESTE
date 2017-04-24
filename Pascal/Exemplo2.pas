Program Exemplo2;

Uses NewDelay, Crt;

Type TipoRegistro = record
				Nome: String[50];
				Idade: integer;
			End;

Var     p, q: ^TipoRegistro;
	R: TipoRegistro;

Begin
        CLRSCR;
	New(p);
	R.Nome := 'Windislaisson Kauander';
	R.Idade := 50;
	Writeln(p^.nome);
	P^.nome := 'Mivanidia Lovegilda';
	P^.idade := 10;
	P := nil;
	New(q);
	Q^ := R;
	Writeln(q^.nome, '  ', q^.idade);
	Dispose(p);
	Dispose(q);
End.

