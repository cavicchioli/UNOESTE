distancia(netuno,2800).
distancia(urano,1790).
distancia(saturno,886).
distancia(jupiter,484).
distancia(marte,141).
distancia(terra,93).
distancia(venus,67).
distancia(mercurio,36).

distancia_planetas(P1,P2,D):- distancia(P1,X), distancia(P2,Y), D is abs(X-Y).
