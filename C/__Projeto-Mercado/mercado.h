struct TpFila //Estrutura -> Fila do Mercado (Carrinhos que estão na FILA)
{
       TpFila *Prox; //Ponteiro da LDDE
       int Prioridade; //Prioridade do Usuário [1-IDOSO,2-GESTANTE,3-DEFICIENTE,4-OUTROS]
       int Itens;//Quantidade de Itens no Carrinho
};

struct TpCaixa //Estrutura -> Caixas do Mercado
{
    //INFORMAÇÕES CAIXA   
    int Numero; //Numero do Caixa
    TpCaixa *Prox; //Ponteiro da LDDE
    
    //INFORMAÇÕES FILA
    int TotalFila; //Total de pessoas na Fila
    TpFila *Inicio,*Fim; //Descritor da Fila
    
};

struct TpDescritor //Estrutura -> Descritor dos Caixas
{
    TpCaixa *Inicio,*Fim; //Inicio e Fim dos Caixas Ativos;
    char Nome[50]; //Nome do Mercado
    int  CxAtivos; //Quantidade de Caixas em Funcionamento
};

void Inicializa(TpDescritor &Desc,char Nome[50]);
void InsereCaixa(TpDescritor &Desc, int elem);
void Exibe(TpDescritor Desc);
int ValidaCaixa(TpDescritor Desc,int elem);
void InsereFila(TpCaixa &Caixa, int compras, int prio);

void Inicializa(TpDescritor &Desc,char merc[50])
{
    Desc.Inicio=NULL;
    Desc.Fim=NULL;
    Desc.CxAtivos=0;
    strcpy(Desc.Nome,merc);
}

void InsereFila(TpCaixa &Caixa, int produtos, int prio)//Insere Ordenado // OK
{
    TpFila *NovoCarrinho=new(TpFila);
    TpFila *Ant;
    TpFila *Atual;
    
 
    NovoCarrinho->Itens=produtos;
    NovoCarrinho->Prioridade=prio;
    NovoCarrinho->Prox=NULL;
    
    if(Caixa.Inicio==NULL)//primeira inserçao
    {
        Caixa.Inicio=NovoCarrinho;
        Caixa.Fim=NovoCarrinho;
    }
  
    if(prio <= Caixa.Inicio->Prioridade)
    {
      NovoCarrinho->Prox=Caixa.Inicio;
      Caixa.Inicio=NovoCarrinho;
    }
    
    if(prio >= Caixa.Fim->Prioridade)
    {
      Caixa.Fim->Prox=NovoCarrinho;
      Caixa.Fim=NovoCarrinho;
    }
    
    if(prio > Caixa.Inicio->Prioridade && prio < Caixa.Fim->Prioridade)
    {
     Ant=Caixa.Inicio;
     Atual=Caixa.Inicio;

      while(Atual!=NULL && Atual->Prioridade<=prio)
      {
       Ant=Atual;
       Atual=Atual->Prox;
      }

      NovoCarrinho->Prox=Atual;
      Ant->Prox=NovoCarrinho;
    }
    Caixa.TotalFila++;
}

void InsereCaixa(TpDescritor &Desc, int elem)//Insere Ordenado // OK
{
    TpCaixa *NovaCaixa=new(TpCaixa);
    TpCaixa *Ant;
    TpCaixa *Atual;
    
 
    NovaCaixa->Numero=elem;
    NovaCaixa->TotalFila=0;
    NovaCaixa->Inicio=NULL;
    NovaCaixa->Fim=NULL;
    NovaCaixa->Prox=NULL;
    
    if(Desc.Inicio==NULL)//primeira inserçao
    {
        Desc.Inicio=NovaCaixa;
        Desc.Fim=NovaCaixa;
    }
  
    if(elem <= Desc.Inicio->Numero)
    {
      NovaCaixa->Prox=Desc.Inicio;
      Desc.Inicio=NovaCaixa;
    }
    
    if(elem >= Desc.Fim->Numero)
    {
      Desc.Fim->Prox=NovaCaixa;
      Desc.Fim=NovaCaixa;
    }
    
    if(elem > Desc.Inicio->Numero && elem < Desc.Fim->Numero)
    {
     Ant=Desc.Inicio;
     Atual=Desc.Inicio;

      while(Atual!=NULL && Atual->Numero<=elem)
      {
       Ant=Atual;
       Atual=Atual->Prox;
      }

      NovaCaixa->Prox=Atual;
      Ant->Prox=NovaCaixa;
    }
    Desc.CxAtivos++;
}

void BuscaCaixa(TpDescritor Desc)//CAIXA COM MENOR NUMERO DE PESSOAS NA LISTA;
{
    TpCaixa *Ant,*Atual;
    TpCaixa *Aux;
    
     Aux->TotalFila=999999999999999999;
     Ant=Desc.Inicio;
     Atual=Desc.Inicio;

      while(Atual!=NULL)
      {
            
        if(Ant->TotalFila<Atual->TotalFila)
         if(Ant->TotalFila<Aux-TotalFila)
          Aux=Ant;   
      
       Ant=Atual;
       Atual=Atual->Prox;
      }
}


/*
int ValidaCaixa(TpDescritor Desc,int elem)
{   
    TpCaixa *ant,*atual;
    
       ant=Desc.Inicio;
       atual=Desc.Inicio;
       
       if(elem>20)
        return 0;
       
        while(atual!=NULL)
        {
         if(atual->Numero==elem)
          return 0;
          
          ant=atual;
          atual=atual->Prox;
        }
        return 1;
}
*/

void Exibe(TpDescritor Desc)
{   
    TpCaixa *caixa;
    
    printf("\n*-*-*-*-*-*-*-*-Exibe-*-*-*-*-*-*-*-*\n\n");
    if(Desc.Inicio==NULL)
     printf("\nLista Vazia\n");
     else
     {
       caixa=Desc.Inicio;
       
       while(caixa!=NULL)
       {
         printf("%d \t",caixa->Numero);
         caixa=caixa->Prox;
       }     
    }
    getch();
}
