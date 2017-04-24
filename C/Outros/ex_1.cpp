#include<stdio.h>
#include<conio.h>
#include "pilha2.h"

void Concatena(Tppilha &PA, Tppilha &PB);
void Completa(Tppilha &va);

void Completa(Tppilha &va)
{
  int i=0,num;
  
  inicializa(va);
  do
    {
        printf("\nDigite um numero:");
        scanf("%d",&num);
        if(!cheia(va.topo)) inserir(va, num);
        
    i++;
    
    }while(!cheia(va.topo)&& i!=5);
    printf("---------------------------------------");
    
}


void Concatena(Tppilha &PA, Tppilha &PB)
{
    Tppilha Paux;
    
    
    
    inicializa(Paux);
    
    while(!vazia(PB.topo))
     inserir(Paux,retira(PB));
      
    while(!vazia(Paux.topo))
     inserir(PA,retira(Paux));
     
     exibepilha(PA);
}

int main(void)
{
    Tppilha p1,p2;
    
    Completa(p1);
    Completa(p2);
    Concatena(p1,p2);
    getch();
}
