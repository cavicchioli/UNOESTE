struct pilha
{
    int info
    struct  *pilha, *prox;
};

typedf struct pilha Pilha;

void init (Pilha **P)// segundo * significa que esta sendo passado um retorn de P
{
    *P = NULL;
}


char isEmpty (Pilha*P)
{
    return P==NULL;
}


int Top(Pilha *P)
{
    if(!isEmpty(P))
     return P->info;
    return -1; 
}


void Push(Pilha **P, int x)
{
    Pilha*nova=(Pilha*)malloc(sizeof(Pilha));
    nova->info=x;
    nova->prox=*P;
    *P=nova;
}

void Pop(Pilha **P, int *x)
{
    Pilha *morre;
    if(!isEmpty(P))
    {
        *x=(*P)->info;
        morre=P;     
        *P=(*P)-> prox;
        free(morre);
    }
    else
    {
        *x=-1;
    } 
    
}    

void enqueve(Fila **F, int x)
{
    Fila *nova, *aux;
    nova=(Fila*)malloc(sizeof(Fila));
    nova->info=x;
    nova->prox=NULL;
    if(isEmpty(*F))
        *F=nova;
        else
        {
            aux=*F;
             while(aux->prox!=NULL)
              aux=aux->prox;
             
             aux->prox=nova;
        }
}
