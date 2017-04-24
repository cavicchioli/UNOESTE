{Imagine uma passagem de “nibus, que ‚ formada por um conjunto de informa‡äes
 logicamente relacionadas, por‚m, de tipos diferentes, tais como n£mero de
 passagem (inteiro), origem e destino (caracteres), data (caracteres), hor rio
 (caracteres), poltrona (inteiro), distƒncia (real), fumante (l¢gico), que sÆo
 subdivisäes do registro (elementos do conjunto), tamb‚m chamadas de campos.
 Logo, um registro ‚ composto por campos que sÆo partes que especificam cada
 uma das informa‡äes.}

program exemplo1;
uses newdelay, crt;
type str30=string[30];
     str10=string[10];
     str8=string[8];
     TpData = Record
                    d, m: byte;
                    a: integer;
              end;
     TpHorario = record                       "46 lugares"
                       h,m:byte;           ==> Venda de passagens;
                 end;                      ==> Cancelamento de passagens;
                                           ==> Consulta de uma determinada
     tpreg=record                                               poltrona;
                 num:LONGINT;              ==> Mostrar o layout do “nibus,
                 origem:str30;                 considerando os lugares
                 destino:str30;                ocupados e dispon¡veis;
                 data:TpData;
                 horario:TpHorario;
                 poltrona:byte;
                 distacia:single;
                 fumante:boolean;
           end;
     tparq = file of tpreg;
