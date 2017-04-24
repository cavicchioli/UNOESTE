//Matriz Esparsa

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include "TADMatEsp.h"

int main()
{
    int x,y;
    char valor[TF];
    
    MatEsp *vetLinA[NL],*vetColA[NC];
    MatEsp *vetLinB[NL],*vetColB[NC];
    //MatEsp *vetLinC[NL],*vetColC[NC];
    
    inicializa(vetLinA,vetColA);
    
    do
    {
     fflush(stdin);
     scanf("%d",&x);
     scanf("%d",&y);
     fflush(stdin);
     gets(valor); 
      
     insereMatriz( vetLinA,vetColA,x,y,valor);   
     exibeMatriz(vetLinA);
        
    }while(strcmp(valor,"exit")!=0);
}
