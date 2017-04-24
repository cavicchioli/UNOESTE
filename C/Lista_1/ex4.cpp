#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>



int compara(FILE *Arq,FILE* Arq2)
{
    Arq=fopen("ex_4.txt","r+");
    Arq2=fopen("ex_4a.txt","r+");
    
    char chave[100],chave2[100];
    int ret;
    
    fgets(chave,100,Arq);
    fgets(chave2,100,Arq2);
    
    while(!feof(Arq) && strcmp(chave,chave2)==0)
    {
     fgets(chave,100,Arq);
     fgets(chave2,100,Arq2);
     
     if(strcmp(chave,chave2)!=0)
      ret=1;
    }
    if(ret==1)
    printf("Arquivos Diferentes");
    else
    printf("Arquivos Identicos");
    
    getch();
}

int main()
{
    FILE *A;
    FILE *B;
    compara(A,B);
    
    return 1;
}
