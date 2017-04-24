#include <conio2.h>
#include <stdio.h>
#include <stdlib.h>
#define TF 10

//1° MODULO
void Levetor(int vetor[TF], int &TL)
{
    int aux;
    printf("\n**Conhecer Vetor**\n");
    printf("vetor[%d]:",TL);
    scanf("%d",&aux);
    while(TL<TF && aux!=0)
    {
        vetor[TL++]=aux;
        if(TL<TF)
        {
         printf("Vetor[%d]:",TL);
         scanf("%d",&aux);
        }
        else
         printf("\n**Vetor Cheio!!**\n");
         getch();
    }  
}

//2° MODULO
void Exibevetor(int vet[TF], int TL)
{
    int i;
     clrscr();
     printf("**Conteudo do Vetor**\n");
    if(TL==0)
     printf("Vetor Vazio");
    else
    for(i=0;i<TL;i++)
     printf("\nVetor[%d]:%d",i,vet[i]);
}

void Interseccao(int vet1[TF],int tam1,int vet2[TF],int tam2,int vet3[TF],int &TL3)
{
  int i,j,k,t,cont;
  TL3=0;
  for(i=0;i<tam1;i++)
  {
    for(k=0;k<tam2;k++)
    {
        if(vet1[i]==vet2[k])
        {cont=0;
         for(t=0;t<TL3;t++)
         {  
           if (vet1[i]==vet3[t])
           cont++;
         }
         if (cont==0)
         vet3[TL3]=vet1[i];
         TL3++;
        }
     }
   }  
}

//FUNÇAO PRINCIPAL
int main(void)
{
    int V1[TF],V2[TF],V3[TF],TL1=0,TL2=0,TL3=0;
    Levetor(V1,TL1);
    clrscr();
    Exibevetor(V1,TL1);
        clrscr();
    Levetor(V2,TL2);
        clrscr();
    Exibevetor(V2,TL2);
        clrscr();
    Interseccao(V1,TL1,V2,TL2,V3,TL3);
        clrscr();
    Exibevetor(V3,TL3);
    
    getch();
    
    
    
    return 0;
}

