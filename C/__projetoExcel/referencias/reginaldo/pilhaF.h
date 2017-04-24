#define MAXPILHA 30

struct TpPilhaF
{
    float Pilha[MAXPILHA];
    int Topo;
};

void InicializaF(TpPilhaF &P)
{
    P.Topo=-1;
}

void EmpilhaF(TpPilhaF &P,float elem)
{
    P.Pilha[++P.Topo] = elem;
}

float DesempilhaF(TpPilhaF &P)
{
    P.Topo--;
    return P.Pilha[P.Topo+1];
}

int VaziaF(int topo)
{
    if(topo==-1)
        return 1;
    else
        return 0;
}

float AcessaTopoF(TpPilhaF P)
{
    return P.Pilha[P.Topo];
}

int CheiaF(int Topo)
{
    if(Topo==MAXPILHA-1)
        return 1;
    else
        return 0;
}
void ExibeF(TpPilhaF P)
{
    while(!VaziaF(P.Topo))
        printf(" %0.2f",DesempilhaF(P));
}
