#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#define max 10

void Insercao(int vet[max],int tam);

void Insercao(int vet[max],int tam)
{   
 int aux; // Nossa variável auxiliar
 int j,i;
  for(i=1; i <= tam-1; i++)
  {
   aux=vet[i];
   j=i-1;
    while(j>=0 && aux<vet[j] ) // Puxa os valores até encontrar
    {                                  // a posição correta
     vet[j+1]=vet[j] ;
     j--;
    }
    vet[j+1]=aux; // Coloca o valor na posição correta
   }
}

int main (void)
{
  char tecla;
  int vetor[max],i=0,aux;
    do
    {
        tecla=getche();
        scanf("%d",&aux);
        vetor[i]=aux;
        i++;
        Insercao(vetor,i);
        
        tecla=getche();
    }while(tecla!=27);
    
    for(;i>0;i--)
    printf("%d\n",vetor[i]);
    getch();
}
