Program Exemplo_Fibonacci;

Uses Newdelay, Crt;


Function Fibonacci (x: integer): integer;
begin
  if (x=1) or (x=0) then
  begin
   Fibonacci := 1
  end
  else
  begin
   Fibonacci := Fibonacci(x-1) + Fibonacci (x-2);
  end;
end;

begin
    Clrscr;
    Writeln('Resultado: ', Fibonacci(5));
    readkey;
end.