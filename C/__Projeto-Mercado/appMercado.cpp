#include <stdio.h>
#include <conio2.h>
#include <stdlib.h>
#include <string.h>
#include "mercado.h"

int main(void)
{
    int aux;
    TpDescritor L;
    char nome[50];
    
    printf("\nDigite o nome do mercado\n");
    printf("\nNOME: ");
    gets(nome);
    
    
    Inicializa(L,nome);
    
    printf("\n*-*-*-*-*-*-*-*-Insere-*-*-*-*-*-*-*-*\n");
    printf("\nNumero: ");
    scanf("%d",&aux);
    
    while(aux!=0)
    {
        if(ValidaCaixa(L,aux)==1)
         InsereCaixa(L,aux);
       
       printf("\nNovo Numero: "); 
       scanf("%d",&aux);
    }
    
    puts(L.Nome);
    printf("\n%d",L.CxAtivos);
    Exibe(L);
    
    
}
