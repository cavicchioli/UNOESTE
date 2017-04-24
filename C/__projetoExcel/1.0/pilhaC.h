#define MAXPILHA 30
#include <conio2.h>

struct TpPilhaC
{
    char Pilha[MAXPILHA];
    int Topo;
};

void InicializaC(TpPilhaC &P)
{
    P.Topo=-1;
}

void EmpilhaC(TpPilhaC &P,char elem)
{
    P.Pilha[++P.Topo] = elem;
}

char DesempilhaC(TpPilhaC &P)
{
    P.Topo--;
    return P.Pilha[P.Topo+1];
}

int VaziaC(int topo)
{
    if(topo==-1)
        return 1;
    else
        return 0;
}
    
char AcessaTopoC(TpPilhaC P)
{
    return P.Pilha[P.Topo];
}

int CheiaC(int Topo)
{
    if(Topo==MAXPILHA-1)
        return 1;
    else
        return 0;       
}
void ExibeC(TpPilhaC P)
{
    while(!VaziaC(P.Topo))
        printf("  %c",DesempilhaC(P));
}
