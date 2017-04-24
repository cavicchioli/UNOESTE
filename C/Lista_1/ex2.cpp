#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

void cria(FILE *Arq);
void conta(FILE *Arq);

void cria(FILE *Arq)
{
    Arq=fopen("Ex_2.txt","w+");

    char tecla;

    printf("Digite o seu TEXTO:");

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

void conta(FILE *Arq)
{
    Arq=fopen("Ex_2.txt","r");

    char palavra;
    int letr=0,esp=0,lin=0;
    
    palavra=fgetc(Arq);
    
    while(!feof(Arq))
    {
      if(palavra==' ')
       esp++;
       
      if(palavra>=65 && palavra<=123)
       letr++;
        
      if(palavra=='\n')
      lin++;
        
     palavra=fgetc(Arq);
    }
    printf("%d espacos -%d letra -%d linhas",esp,letr,lin);
    getch();
fclose(Arq);
}

int main()
{
    FILE *A;
    cria(A);
    conta(A);
}
