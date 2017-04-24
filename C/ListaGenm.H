#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>

struct reg_lista
{
    struct listagem *cauda;
    struct listagem *cabeca;
};

union info_lista
{
    char info[8];
    struct reg_lista lista;
};

struct listagem
{
    char terminal;
    union info_lista no;
};
typedef struct listagem ListaGen;


//Verifica Nula
char Nula (ListaGen *L)
{
    return L == NULL;
}

//Verifica ATOMO
char Atomo (ListaGen *L)
{
    return !Nula(L) && L->terminal; 
}

// criar atomO

ListaGen *Criat (char info[])
{
    ListaGen *L = (ListaGen *)malloc(sizeof(ListaGen));
    
    L->terminal = 1;
    strcpy(L->no.info,info);
    
    return L;
}

// Funcao que retorna uma cabeça
ListaGen *Head(ListaGen *L)
{
    if(Nula(L) || Atomo(L))
    {
        printf("Head: L nao pode ser NULO ou ATOMO!");
        return NULL;
    }
    
    else
    {
        return L->no.lista.cabeca;
    }
}

//Funcao que retorna uma cauda
ListaGen *Tail(ListaGen *L)
{
    if(Nula(L) || Atomo (L))
    {
        printf("Tail nao pode ser NULO ou ATOMO");
        return NULL;
    }
    
    else
        return L->no.lista.cauda;
}

// EXIBE LISTA GENERALIZada
void exibeLista(ListaGen *L)
{
    if(Atomo(L))
        printf("%s",L->no.info);
    else
    {
        printf("[");
        while(!Nula(L))
        {
            exibeLista(Head(L));
            L = Tail(L);
            if(!Nula(L))
                printf(",");
        }
        printf("]");
    }
        
}
//Exibe ATOMO - RECURSIVo
void exibeAtomo (ListaGen *L)
{
    if(!Nula(L))
    {
        if(Atomo(L))
            printf("%s", L->no.info);
        
        else
        {
            exibeAtomo(Head(L));
            exibeAtomo(Tail(L));
        }
    }
}

// cria uma lista 

ListaGen *Cons (ListaGen *H, ListaGen *T)
{
    if(Atomo(T))
    {
        printf("Cons: O seg. arq. nao pode ser ATOMO!!");
        return NULL;
    }
    
    else
    {
        ListaGen *L = (ListaGen *)malloc(sizeof(ListaGen));
        L->terminal = 0;
        L->no.lista.cabeca = H;
        L->no.lista.cauda = T;
        return L;
    }
}


