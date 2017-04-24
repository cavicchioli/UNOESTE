casou(joao, maria, dia(5, maio, 1980)).
casou(andre, fernanda, dia(11, agosto, 1950)).
casou(adriano, claudia, dia(15, outubro, 1973)).

%a) Qual a data do casamento de Maria?
%casou(_,maria,Data).
%
%b) Qual o mês do casamento de Andre?
%casou(andre,_,dia(_,Mes,_)).
%
% c) Quem casou antes de Adriano, considerando somente o ano de
% casamento?
% casou(adriano,_,dia(_,_,Ano1)) ; casou(Quem,_,dia(_,_,Ano2))
% ;Ano2 < Ano1.
%
%d) Quem casou a menos de 20 anos (considerando apenas o
% ano)?
%
