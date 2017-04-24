#define TF 30

struct matrizEsp
{
    int lin,col;
    char conteudo[TF];
    struct matrizEsp *proxC,*proxL;
};
typedef struct matrizEsp MatEsp;

void inicializa(MatEsp*vetLin[],MatEsp*vetCol[])//iniciar a matriz NL-numLinhas NC-numColunas
{
    int i;
    for(i=0;i<100;i++)
        vetLin[i] = NULL;//printf("%d\n",vetLin[i]);
    for(i=0;i<25;i++)
        vetCol[i] = NULL;
}
MatEsp *verificaOcupado(MatEsp *vetLin[],int linha,int coluna)//saber posição
{
    MatEsp *aux = vetLin[linha];
    while(aux != NULL && coluna != aux->col)
        aux = aux->proxL;
    return aux;
}
void insereMatriz(MatEsp *vetLin[],MatEsp *vetCol[],int linha,int coluna,char elem[30])//inserindo obs caso necessario elem vira int
{
    MatEsp *aux,*nova,*ant;
    
    if(linha>=0 && linha<100 && coluna>=0 && coluna<25)
    {
        aux = verificaOcupado(vetLin,linha,coluna);
        if(aux != NULL) //se emcontrar soh alterar o valor para o novo
            strcpy(aux->conteudo,elem);//aux->conteudo = elem;
        else //senão será criado um novo elemento
        {
            nova = (MatEsp*)malloc(sizeof(MatEsp));
            nova->lin = linha;
            nova->col = coluna;
            strcpy(nova->conteudo,elem);//aux->conteudo = elem;
            
            //Ligações Horizontal
            if(vetLin[linha] == NULL)//primeiro elemento da linha, estava vazia
            {
                nova->proxL = NULL;
                vetLin[linha] = nova;
            }
            else
            if(coluna<vetLin[linha]->col)//verificando se será o item q sera colocado na frente de todos ou o primeiro elemento da lista
            {
                nova->proxL = vetLin[linha];
                vetLin[linha] = nova;
            }
            else//entre elementos ou no final
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
            if(vetCol[coluna] == NULL)//coluna esta vazia, primeiro elemento inserido
            {
                nova->proxC = NULL;
                vetCol[coluna] = nova;
            }
            else
            if(linha<vetCol[coluna]->lin)//elemento q ser o primeiro ligado direto no vetor matriz
            {
                nova->proxC = vetCol[coluna];
                vetCol[coluna] = nova;
            }
            else//entre elementos ou final
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
