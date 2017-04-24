#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

void executa(void)
{ 
    char tecla;
    
    FILE * ARQ;
    
    ARQ=fopen("tipo.txt","w+");
    
    do
    {
      tecla=getche();
      
      if(tecla!=27)
         fputc(tecla,ARQ);
    
       if(tecla==13)
         {
        fputc('\n',ARQ);
        printf("\n");
         }
         
    }while(tecla!=27);
    
    fclose(ARQ);
}

void ler()
{
    
    FILE *ARQ = fopen("tipo.txt","r");
    
    char tc[100];
        
    do
    {
        fgets(tc,100,ARQ);
        printf("%s",tc);
        
    }while(!feof(ARQ)-1);
    
    fclose(ARQ);
}
    
int main()
{
    executa();
    ler();
    getch();
    }
