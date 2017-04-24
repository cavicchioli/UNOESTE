#define MAXPILHA 100

struct Tppilha
{
       int topo;
       int pilha[MAXPILHA];
};


void inicializa(Tppilha &p);
int cheia(int t);
int vazia(int t);
void inserir(Tppilha &p, int elem);
int retira(Tppilha &p);
int elementotopo(Tppilha p);
void exibepilha(Tppilha p);


void inicializa(Tppilha &p)
{
     p.topo=-1;
}

int cheia(int t)
{
    if (t==MAXPILHA-1)
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


void inserir(Tppilha &p, int elem)
{
     p.pilha[++p.topo]=elem;

}

int retira(Tppilha &p)
{
     return p.pilha[p.topo--];
}

int  elementotopo(Tppilha p)
{
      return p.pilha[p.topo];

}

void exibepilha(Tppilha p)
{
       while(!vazia(p.topo))
       {
         printf("\n %d  ", retira(p));
       }
}
