#include<stdio.h>
#include<time.h>
#include<stdlib.h>
#include<conio2.h>
int main()
{
   int i, j, tamanho, chave, trocas;
   int vetor[10];
   srand(time(0));
   tamanho=10;
   printf("Vetor desordenado...\n");
   for(i=0;i<tamanho;i++)
      {
      vetor[i]=rand()%100;
      printf("Vetor [%2d]: %3d\n",i+1,vetor[i]);
      }
   for (j=1;j<tamanho;j++)//insersao direta
      {
      chave = vetor[j];
      i = j - 1;
      while((i>=0) && (vetor[i]>chave))
         {
         vetor[i+1] = vetor[i];
         i = i - 1;
         trocas++;
         }
      vetor[i+1] = chave;
      }
   
   printf("Vetor ordenado...\n");
   for(i=0;i<tamanho;i++)
      printf("Vetor[%2d]: %3d\n",i+1,vetor[i]);
   printf("Trocas efetuadas: %3d\n\n",trocas);
   getch();
   return 0;
}
