#include<stdio.h>
#include<time.h>
#include<stdlib.h>
#include<conio2.h>
#define tf 10

void Insercao_Direta(int vetor[tf],int elem,int tl);

int main(void)
{
   int i, j, chave, trocas;
   int vetor[tf];
   
   for(i=0;i<tf;i++)
      {
       printf("\nVetor desordenado...\n");    
       vetor[i]=rand()%100;
       printf("Vetor [%2d]: %3d\n",i+1,vetor[i]);
      
      printf("\n\nVetor ordenado...\n");
      Insercao_Direta(vetor,vetor[i],i);
      
      for(j=0;j<i;j++)
      printf("Vetor[%2d]: %3d\n",j+1,vetor[j]);
      }
      
   getch();
   return 0;
}


void Insercao_Direta(int vetor[tf],int elem,int tl)
{
 int PosAux;

  if (tl< tf)
  {   
	vetor[tl]= elem;
	 PosAux = tl-1;
	  while (vetor[PosAux] > elem && PosAux >= 0)
	  {
		vetor[PosAux+1] = vetor[PosAux];
		vetor[PosAux] = elem;
		PosAux--;
	  }
   }
   else printf("Lista Cheia!!!");
}
