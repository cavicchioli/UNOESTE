struct stringDin
{
    char letra;
    struct stringDin *prox;
};
typedef struct stringDin StrDin;

void init(StrDin **Str);//1
void copia(StrDin *str1,StrDin **str2);
void concatena(StrDin *str1,StrDin *str2,StrDin **str3);
void reinicia(StrDin **str);//2
void reiniciaR(StrDin **str);//2
void exibe(StrDin **str);//3
void exibeInvertida(StrDin **str);//4
int tamanho(StrDin **str);
void insere(StrDin **str, char letr);
char isEmpty (StrDin*str);
void delQtd(StrDin **Str,int start,int num);

void delQtd(StrDin **Str,int start,int num)
{
    
}

void init(StrDin **Str)//1
{
    *Str=NULL;
}

void copia(StrDin *str1,StrDin **str2)
{
    while(str1!=NULL)
    {
        insere(&*str2,str1->letra);
        str1=str1->prox;
    }
}

void concatena(StrDin *str1,StrDin *str2,StrDin **str3)
{
 copia(str1,&*str3);
 copia(str2,&*str3);   
}

void reinicia(StrDin **str)//2
{
    StrDin *aux;
    while(*str!=NULL)
    {
        aux=*str;
        *str=(*str)->prox;
        free(aux);
    }
} 

void reiniciaR(StrDin **str)//2
{
    if(*str!=NULL)
    {
        reiniciaR(&(*str)->prox);
        free(*str);
        *str=NULL;
    }
}

void exibe(StrDin **str)//3
{
    StrDin *aux;
    aux=*str;
    
    while(aux->prox!=NULL)
    {
        printf("%c",aux->letra);
        aux=aux->prox;
    }
}

void exibeInvertida(StrDin **str)//4
{
    if(*str!=NULL)
    {
        exibeInvertida(&(*str)->prox);
        printf("%c",(*str)->letra);
    }
}

int tamanho(StrDin **str)
{
    int cont=0;
    
    StrDin *aux;
    aux=*str;
    
    while(aux->prox!=NULL)
    {
        aux=aux->prox;
        cont++;
    }
    return cont;
}

char isEmpty (StrDin*str)
{
    return str==NULL;
}

void insere(StrDin **str, char letr)
{
    StrDin *nova=(StrDin*)malloc(sizeof(StrDin));
    StrDin *aux;
    
    nova->prox=NULL;
    nova->letra=letr;
    
    if(isEmpty(*str))
        *str=nova;
        else
        {
            aux=*str;
             while(aux->prox!=NULL)
              aux=aux->prox;

             aux->prox=nova;
        }
}
