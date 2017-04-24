Program x;
Uses Newdelay,crt;


Function FAT (X: integer): integer;
    var
       i, ResFat: integer;
 Begin
    ResFat:=1;
    For i:=1 to X do
       ResFat:=ResFat*I;
    FAT:=ResFat;
 End;


 begin
    write(fat(5));
 end.