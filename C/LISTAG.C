#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

#include "ListaGenm.h"

main(void)
{
    ListaGen *L;
    
    L = Cons(Cons(Criat("A"),Cons(Criat("B"),NULL)),Cons(Criat("C"),NULL));
    exibeLista(L);
    
    getch();
}
