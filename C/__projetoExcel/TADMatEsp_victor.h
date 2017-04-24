//TAD MatEsp
#include<stdio.h>
#include <string.h>
#define NL 5
#define NC 5
#define TF 30
struct matrizEsp
{
    int lin,col;
    char valor[TF];
    struct matrizEsp *proxC,*proxL;
};
typedef struct matrizEsp MatEsp;

void inicializa(MatEsp*vetLin[],MatEsp*vetCol[])
{
    int i;
    for(i=0;i<NL;i++)
        vetLin[i] = NULL;
    for(i=0;i<NC;i++)
        vetCol[i] = NULL;
}
MatEsp *verificaOcupado(MatEsp *vetLin[],int linha,int coluna)
{
    MatEsp *aux = vetLin[linha];
    while(aux != NULL && coluna != aux->col)
        aux = aux->proxL;
    return aux;
}
void insereMatriz(MatEsp *vetLin[],MatEsp *vetCol[],int linha,int coluna,char elem[TF])
{
    MatEsp *aux,*nova,*ant;
    
    if(linha>=0 && linha<NL && coluna>=0 && coluna<NC)
    {
        aux = verificaOcupado(vetLin,linha,coluna);
        if(aux != NULL) //se houver algum elemento o valor será atualizado
            strcpy(aux->valor,elem);        
               
        else //senão será criado um novo elemento
        {
            nova = (MatEsp*)malloc(sizeof(MatEsp));
            nova->lin = linha;
            nova->col = coluna;
            strcpy(nova->valor,elem);
            
            //Ligação Horizontal
            if(vetLin[linha] == NULL)
            {
                nova->proxL = NULL;
                vetLin[linha] = nova;
            }
            else
            if(coluna<vetLin[linha]->col)
            {
                nova->proxL = vetLin[linha];
                vetLin[linha] = nova;
            }
            else
            {
                aux = vetLin[linha];
                while(aux != NULL && coluna > aux->col)
                {
                    ant = aux;
                    aux = aux->proxL;
                }
                nova->proxL = aux;
                ant->proxL = nova;
            }
            
            //Ligação Vertical
            if(vetCol[coluna] == NULL)
            {
                nova->proxC = NULL;
                vetCol[coluna] = nova;
            }
            else
            if(linha<vetCol[coluna]->lin)
            {
                nova->proxC = vetCol[coluna];
                vetCol[coluna] = nova;
            }
            else
            {
                aux = vetCol[coluna];
                while(aux != NULL && linha>aux->lin)
                {
                    ant = aux;
                    aux = aux->proxC;
                }
                nova->proxC = aux;
                ant->proxC = nova;
            } 
        }
    }
    else
        printf("\nCoordenadas Invalidas!\n");       
}

void exibeMatriz(MatEsp *vetLin[])
{
   int i,j;
   MatEsp *aux;
   for(i=0;i<NL;i++)
   {
        for(j=0;j<NC;j++)
        {
            aux = verificaOcupado(vetLin,i,j);
            if(aux == NULL)
                printf("%5d",0);
            else
                printf("%5s",aux->valor);
        }
        printf("\n\n");
    }   
}
/*
void somaMatriz(MatEsp *vetLinA[], MatEsp *vetLinB[], MatEsp *vetLinC[], MatEsp *vetColC[])
{
    int i,j;
    MatEsp *auxA,*auxB;
    int soma,a,b;
    char result[TF];
    
    for(i=0;i<NL;i++)
        for(j=0;j<NC;j++)
        {
            auxA = verificaOcupado(vetLinA,i,j);
            auxB = verificaOcupado(vetLinB,i,j);
            if(auxA == NULL)
                a = 0;
            else
              {
                itoa(a,auxA->valor,10);    
              }  
            if(auxB == NULL)
                b = 0;
            else
            {
                itoa(b,auxB->valor,10); 
            }
                
             
            soma = a+b;
            
            if(soma != 0){
             sprintf(result,"%c",soma);   
                insereMatriz(vetLinC,vetColC,i,j,result);    
            }
        }
}
*/

/*
void multiplicaMatriz(MatEsp *vetLinA[], MatEsp *vetLinB[], MatEsp *vetLinC[], MatEsp *vetColC[])
{
    int i,j,soma,k,va,conver;
    int C,L;
    char result[TF];
    MatEsp *aux;
    
    for(L=0;L<NL;L++)
    {
        for(C=0;C<NC;C++)
        {
            soma = 0;
            for(k=0;k<NC;k++)
            {
                aux = verificaOcupado(vetLinA, L, k);
                if(aux != NULL)
                {
                    itoa(va,aux->valor,10);
                    aux = verificaOcupado(vetLinB, k, C);
                    if(aux != NULL)
                    {
                        itoa(conver,aux->valor,10);
                        soma = soma + (va*conver);
                     }   
                    
                }
                if(soma != 0)
                {
                    sprintf(result,"%c",soma);
                    insereMatriz(vetLinC, vetColC, L, C, result);
                }
                    
            }
        }
    }   
}
*/
