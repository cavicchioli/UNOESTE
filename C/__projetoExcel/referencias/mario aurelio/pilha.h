#include <stdio.h>
#include <conio2.h>
#include <string.h>
#define MAXPILHA 10

struct TpPilha
{
    int topo;
    char pilha[5][MAXPILHA];
    char pilha_c[MAXPILHA];
    float pilha_f[MAXPILHA];
};

void inicializa(TpPilha &P);

int cheia(int t);

int vazia(int t);

void insere(TpPilha &P,char elem[]);

void retira(TpPilha &P,char retorno[]);

char elemento_topo(TpPilha P);

void exibe_pilha(TpPilha P);


void inicializa(TpPilha &P)
{
    P.topo=-1;
}

int cheia(int t)
{
    if(t==MAXPILHA-1)
        return 1;
    else
        return 0;
}

int vazia(int t)
{
    if(t==-1)
        return 1;
    else
        return 0;
}

void insere(TpPilha &P,char elem[])
{
    strcpy(P.pilha[++P.topo],elem);
}

void insere_c(TpPilha &P,char elem)
{
    P.pilha_c[++P.topo]=elem;
}

void insere_f(TpPilha &P,float elem)
{
    P.pilha_f[++P.topo]=elem;
}

void retira(TpPilha &P,char retorno[])
{
    strcpy(retorno,P.pilha[P.topo]);
    P.topo--;
}

char retira_c(TpPilha &P)
{
    return P.pilha_c[P.topo--];
}

float retira_f(TpPilha &P)
{
    return P.pilha_f[P.topo--];
}

char elemTopo_c(TpPilha P)
{
    return P.pilha_c[P.topo];
}

/*char elemento_topo(TpPilha P)
{
    return P.pilha[P.topo];
}*/

void exibe_pilha(TpPilha P)
{
    char string[20];
    strcpy(string,"");

    while(!vazia(P.topo))
    {   retira(P,string);
        printf("%s\n",string);
        strcpy(string,"");
    }
}

void exibe_pilha_c(TpPilha P)
{
    while(!vazia(P.topo))
        printf("%c\n",retira_c(P));
}
