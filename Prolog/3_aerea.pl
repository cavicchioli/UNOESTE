origem(ba137, chicago).
origem(twa194, dallas).
origem(pa100, londres).
origem(az129, londres).

destino(ba137, londres).
destino(twa194, paris).
destino(pa100, roma).
destino(az129, pisa).

partida(ba137, 1040).
partida(twa194, 1900).
partida(pa100, 1330).

chegada(ba137,1250).
chegada(twa194,2200).
chegada(az129, 2200).


%Quais as respostas para as seguintes interrogações:
%a) ?-partida(Voo, 1900), chegada(Voo, 2200).
%Voo = twa194
%
%b) ?-partida(Minerva, 1900), chegada(Titian, 2200).
%Minerva = Titian, Titian = twa194
%
%c) ?-destino(pa100, R), origem(pa100, R).
%false
%
%d) ?-origem(Fred, Alf), destino(Fred, pisa).
%Fred = az129,
%Alf = londres.
%
%e) ?-destino(Iona, Mull), origem(Staffa, Mull), partida(Staffa, 1330).
%Iona = ba137,
%Mull = londres,
%Staffa = pa100.
