program passagem_onibus;
uses newdelay,crt;

type
    TpData = Record
                   dia, mes, ano: byte;
             end;
    TpHorario = Record
                      h, m: byte;
                end;
    TpReg = record
               num_pas:word;
               origem,destino:string[20];
               data: TpData;
               horario:TpHorario;
               poltrona:byte;
               distancia:single;
               fumante:boolean;
             end;

    TpArq = File of TpReg;


      "46 lugares"
=> Compra de passagens;
=> Consulta de passagens;
=> Cancelamento de passagens;
=> Mostrar a situa‡Æo do “nibus em rela‡Æo aos lugares ocupados e dispon¡veis.

begin
     clrscr;

     readkey;
end.