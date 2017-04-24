#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

void cria(FILE *Arq);
void converte(FILE *Arq);

void cria(FILE *Arq)
{
    Arq=fopen("Ex_3.txt","ab+");

    char tecla;

    printf("Digite o texto para convercao:");

    do
    {
        tecla=getche();

        if(tecla!=27)
         fputc(tecla,Arq);

         if(tecla==13)
         {
            fputc('\n',Arq);
            printf("\n");
         }

    }while(tecla!=27);
    fclose(Arq);
}

void converte(FILE *Arq)
{
    Arq=fopen("Ex_3.txt","r+");
    
    char palavra[100];
    
    fgets(palavra,100,Arq);
    while(!feof(Arq))
    {
      
      strupr(palavra);
      fputs(palavra,Arq);
      printf("%s",palavra);
      fgets(palavra,100,Arq);
    }
    fclose(Arq);
    
}

int main()
{
 FILE *A;
 cria(A);
 converte(A);
 getch();
}

