#define MAXPILHA 10

struct tppilha
{
       int topo;
       char pilha[MAXPILHA];
};



void inicializa(tppilha &p);
int cheia(int t);
int vazia(int t);
void inserir(tppilha &p, char elem);
char retira(tppilha &p);
char elementotopo(tppilha p);
void exibepilha(tppilha p);




void inicializa(tppilha &p)
{
     p.topo=-1;
}

int cheia(int t)
{
    if (t==MAXPILHA-1)
     return -1;
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


void inserir(tppilha &p, char elem)
{
     p.pilha[++p.topo]=elem;
     
}

char retira(tppilha &p)
{
     return p.pilha[p.topo--];
}   

char  elementotopo(tppilha p)
{
      return p.pilha[p.topo];

}

void exibepilha(tppilha p)
{
       while(!vazia(p.topo))
       {
         printf("\n %c ",retira(p));
       }
}
