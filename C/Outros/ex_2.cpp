#include<stdio.h>
#include<conio.h>
#include "pilha2.h"

void Completa(Tppilha &va);
void Tirar(Tppilha &PA);

void Completa(Tppilha &va)
{
  int i=0,num;

  inicializa(va);
  do
    {
        printf("\nDigite um numero:");
        scanf("%d",&num);
        if(!cheia(va.topo)) 
          inserir(va, num);
          
    i++;
    }while(!cheia(va.topo)&& i!=5);
    printf("\n---------------- FINAL -------------------\n");
}

void Tirar(Tppilha &PA)
{
    Tppilha aux;
    int num;
    inicializa(aux);
    
    exibepilha(PA);
    printf("\nQual deseja retirar:");
    scanf("%d",&num);
        
    while(elementotopo(PA)!=num)
    inserir(aux,retira(PA));
    
    if(elementotopo(PA)==num);
     PA.topo--;
    
    while(!vazia(aux.topo))
    inserir(PA,retira(aux));
    
    exibepilha(PA); 
    
}

int main(void)
{
    Tppilha p1;

    Completa(p1);
    Tirar(p1);
    getch();
}
