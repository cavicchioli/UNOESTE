#define nl 5
#define nc 5

struct matrizEsp
{
       int lin, col, valor;
       matrizEsp *pc, *pl;
};

typedef struct matrizEsp MatEsp;

void inicializaMatriz(MatEsp *vetlin[],MatEsp *vetcol[])
{
     for(int i=0;i<nl;i++)
        for(int j=0;j<nc;j++)
        {
                vetlin[i]=NULL;
                vetcol[j]=NULL;
        }
     
}

void verificaOcupado(MatEsp **vetlin, int i, int j)
{
     
}

void insereMatriz(MatEsp *vetlin[], MatEsp *vetcol[],int lin, int col, int elem)
{
     MatEsp *aux,*nova, *ant; //mexendo no PL
     
     if(lin>=0 && lin<nl && col>=0 && col<nc)
     {
             aux=verificaOcupado(vetlin,lin,col);
             if(aux!=NULL)//achou
                      aux->valor=elem;             
     
             else
             {
               nova = (MatEsp*)malloc(sizeof(MatEsp));
               nova->lin=lin;
               nova->col=col;
               nova->valor=elem;
               //ligação horizontal...
               if(vetlin[lin]==NULL)//primeira posi ... primeiro elemento do vetor ...
               {
                 nova -> pl = NULL;
                 vetlin[lin] = nova;             
               }
               else
               {
                 if(col < vetlin[lin]->col)//primeria posi ... com elemtos.. do vetor
                 {
                    nova -> pl = vetlin[lin];
                    vetlin[lin] = nova;
                 }
                 else
                 {
                    aux=vetlin[lin];
                    while(aux != NULL && col > aux -> col)
                    {
                              ant = aux;
                              aux = aux -> pl;
                    }
                    nova -> pl = aux;
                    ant -> pl = nova;
                 }
               }
             }
     }
     else
     {
         printf("Coord fora da matriz");
     }
     
}


void exibeMatriz(MatEsp *vetlin[])
{
     MatEsp *aux;
     int i,j;
     for(i=0;i<nl;i++)
     {
              for(j=0;j<nc;j++)
              {
                               aux=verificaOcupado(vetlin,i,j);
                               if(aux==NULL)
                                printf(" 0 ";)
                               else
                                printf(" %d ", aux->valor);
              }
              printf("\n");
     }        
}

void somaMatriz(MatEsp *vetlin[],MatEsp *vetlin2[])
{
     MatEsp *aux,*aux2;
     for(int i=0;i<nl;i++)
     {
             for(int j=0;j<nl;j++)
             {
                     aux=verificaOcupado(vetlin,i,j);
                     aux2=verificaOcupado(vetlin2,i,j);
                     int cont=0;
                     if(aux!=NULL || aux2!=NULL)
                     {
                                  cont = aux->valor + aux2 ->valor;
                                  if(cont == 0)
                                          
                     }
             }
     }
}


void multMatriz(MatEsp *vetlin[],MatEsp *vetlin2[],MatEsp *vetlin3[])
{
     int l,c, k;
     MatEsp *aux,*aux2;
     for(l=0;l<nl;l++)
     {
                      int S=0;
                      for(c=0;c<n;c++)
                      {
                                      for(k=0;k<6;k++)
                                      {
                                                      aux=verificaOcupado(vetlin,l,c);
                                                      aux2=verificaOcupado(vetlin2,l,c);
                                                      if(aux!=NULL && aux2!=NULL)
                                                        S= S+ aux->valor + aux2->valor;
                                      }                  
                                      if(S!=0)
                                          vetlin3[l,c]=S;    
                                                        
                                      
                      }
     }
}
