struct lista
{
    struct lista *ant,*prox;
    int info;
};
typedef struct lista Lista;

struct descritor
{
    Lista *Inicio,*Fim;
};
typedef struct descritor Descritor;


int isEmpty (Descritor lis);
void Init(Descritor *Desc);
void InserirInicio(Descritor *Desc, int elem);

Lista* Busca(Descritor LD, int x)
{
    Lista *aux=LD.Inicio;
    
    while(aux!=NULL && x!=aux->info)
        aux=aux->prox;

    return aux;
}

void Exclui(Descritor *LD, int x)
{
    Lista *aux;
    
    aux=busca(*LD,x);
    
    if(aux!=NULL)//Achou
    {
        if((*LD).Inicio==(*LD).Fim)
            init(&*LD);
        else
        {
            if((*LD).Inicio==aux)
            {
                (*LD).Inicio=aux->prox;
                (*LD).Inicio->ant=NULL;
            }
            else
            {
                if((*LD).Fim==aux)
                {
                    (*LD).Fim=aux->ant;
                    (*LD).Fim->prox=NULL;
                }
                else
                {
                    aux->ant->prox=aux->prox;
                    aux->prox->ant=aux->ant;
                }
                free(aux);
            }
        }
    }
}


void Init(Descritor *Desc)
{
    (*Desc).Inicio=NULL;
    (*Desc).Fim=NULL;
}

int isEmpty (Descritor lis)
{
    return lis.Inicio==NULL;
}

void InserirInicio(Descritor *Desc, int elem)
{
    Lista *nova=(Lista*)malloc(sizeof(Lista));
    
    nova->info=elem;
    nova->ant=NULL;
    
    if(isEmpty(*Desc))
    {
      nova->prox=NULL;
     (*Desc).Inicio=nova;
     (*Desc).Fim=nova; 
    }
    else
        {
            nova->prox=(*Desc).Inicio;
            (*Desc).Inicio->ant=nova;
            (*Desc).Inicio=nova;
        }
}

void InserirFinal(Descritor *Desc, int elem)
{
    Lista *nova=(Lista*)malloc(sizeof(Lista));

    nova->info=elem;
    nova->ant=NULL;
    

    if(isEmpty(*Desc))
    {
     nova->prox=NULL;
     (*Desc).Inicio=nova;
     (*Desc).Fim=nova;
    }
    else
        {
            nova->ant=(*Desc).Fim;
            (*Desc).Fim->prox=nova;S
            (*Desc).Fim=nova;
        }
}

void Exibe(Descritor *Desc)
{
    Lista *list;

    printf("\n*-*-*-*-*-*-*-*-Exibe-*-*-*-*-*-*-*-*\n\n");
    
    if(Desc.Inicio==NULL)
     printf("\nLista Vazia\n");
     else
     {
       list=Desc.Inicio;

       while(list!=NULL)
       {
         printf("%d \t",list->info);
         list=list->prox;
       }
    }
    getch();
}





