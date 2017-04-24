#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include "TADStringDin.h"

main (void)
{
    StrDin *str1,*str2,*str3;
    init(&str1);
    init(&str2);
    init(&str3);
    char letra;
    
    
    do
    {
        scanf("%c",&letra);
        insere(&str1,letra);
        
    }while(letra!='a');
    
    do
    {
        scanf("%c",&letra);
        insere(&str2,letra);

    }while(letra!='a');
    
    printf("\n---------------------------------------\n");
    printf("%d",tamanho(&str1));
    printf("\n---------------------------------------\n");
    exibe(&str1);
    printf("\n---------------------------------------\n");
    
    //copia(str1,&str2);
    exibe(&str2);
    printf("\n---------------------------------------\n");
    concatena(str1,str2,&str3);
    exibe(&str3);
    printf("\n---------------------------------------\n");
    exibeInvertida(&str1);
    getch();
    
    getch();
    
}
