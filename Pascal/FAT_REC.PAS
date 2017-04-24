Program Fatorial;
Uses newdelay,crt;
Function Fat (x: integer): integer;
  Begin
     If (x=0) or (x=1) then
	Fat:=1
     else
	Fat:=x*Fat(x-1);
  End;

begin
     write(fat(5));
end.