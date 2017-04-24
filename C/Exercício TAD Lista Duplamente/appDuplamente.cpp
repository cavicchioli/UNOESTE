#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include "duplamente.h"

main (void)
{
    Descritor desc;
    
    Init(&desc);
    
    int num;
    
    do
    {
        scanf("%d",&num);
        InserirInicio(&desc,num);

    }while(num!=0);
    Exibe(&desc);
    do
    {
        scanf("%d",&num);
        InserirFinal(&desc,num);

    }while(num!=0);
    
    Exibe(&desc);
}
