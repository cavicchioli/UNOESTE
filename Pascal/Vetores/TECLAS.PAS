Program tecla_;

Uses Newdelay, Crt;

var tecla, tecla2: char;

begin
     clrscr;
     repeat
          write('Tecla => ');
          tecla:= readkey;
          If (ORD(tecla) = 0)
          then begin
                    tecla2:= readkey;
                    writeln('Tecla pressionada [',tecla2,'] N§ => #',ORD(tecla2));
               end
          else writeln('Tecla pressionada [',tecla,'] N§ => #',ORD(tecla));

     until (tecla=#27);
end.