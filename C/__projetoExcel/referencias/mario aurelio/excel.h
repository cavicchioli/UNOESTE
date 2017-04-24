#include"pilha.h"
#include<conio2.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define NL 100
#define NC 26


struct MatrizEsp
{
    int lin,col;
    char valor[50];
    struct MatrizEsp *pc,*pl;
};
typedef struct MatrizEsp MatEsp;

struct Tpreg
{
    int lin,col;
    char valor[50];
};

MatEsp* verificaOcupado(MatEsp *vetlin[],int lin,int col)
{
    MatEsp *aux;
    aux=vetlin[lin];
    while(aux!=NULL && aux->col!=col)
        aux=aux->pc;
    return aux;
}

void infoCont(char elem[],int tipo)
{
    int tam,i,recebe; 
    char info[9],aux[50];
    float numero,num1,num2,resultado;
    strcpy(info,"");
    strcpy(aux,elem);
    
    if(tipo==1)
    {
        numero=atof(elem);
        num1=numero;
        recebe=(int)numero;
        num2=recebe;
        
        resultado=num1-num2;
        if(resultado==0)
        {
            sprintf(aux,"%.0f",numero);        
        }
        else
        {
            sprintf(aux,"%.2f",numero);            
        }
    }
    
    
    tam=strlen(aux);
    if(tam<=9)
    {
        for(i=0;i<(9-tam);i++)
            strcat(aux," ");
        printf("%s",aux);   
    }
    else
    {
        for(i=0;i<8;i++)
            info[i]=aux[i];
        info[i]='\0';
        printf("%s",info);
    }    
}

bool isNumber(char elem)
{
    return (elem>='0' && elem<='9');
}

bool isLetter(char elem)
{
    return (elem>='a' && elem<='z') || (elem>='A' && elem<='Z');
}

bool contemLetra(char exp[])
{
    int i;
    
    if(exp[0]=='=' && isLetter(exp[1]))
        i=4;
    else
        i=0;
    for(;i<strlen(exp);i++)
        if(isLetter(exp[i]))
            return true;
    return false;
}

bool isOperator(char elem)
{
    return (elem=='+' || elem=='-' || elem=='*' || elem=='/');
}

void formataForm(char forme[],char nova[],MatEsp *vetlin[])
{
    char aux3[2],form[30],lin[3];
    int linha,coluna,i,aux,tl,j,tl2,k,erro=0;
    MatEsp *aux2;
    
    tl=0;
    tl2=0;
    linha=0;
    coluna=0;
    strcpy(nova,"");
    strcpy(form,forme);
    
    for(i=0;i<strlen(form) && erro!=1;i++)
    {
        if(isLetter(form[i]) && isNumber(form[i+1]))
        {
            sprintf(aux3,"%d",form[i]);
            aux=atoi(aux3);
            coluna=aux-65;
            
            lin[tl2++]=form[i+1];
            if(isNumber(form[i+2]))
            {
                lin[tl2++]=form[i+2];
                if(isNumber(form[i+3]))
                    lin[tl2++]=form[i+3];
            }
            lin[tl2]='\0';
            tl2=0;
       

            linha=atoi(lin); 
            aux2=verificaOcupado(vetlin,linha-1,coluna);
            {
                if(aux2!=NULL)
                {          
                    for(j=0;j<strlen(aux2->valor);j++)
                    {                   
                        nova[tl++]=aux2->valor[j];
                    }
                }  
                else
                    erro=1;             
            }
            i+=strlen(lin);         
        }
        else
        {
            nova[tl++]=form[i];             
        }
        linha=0;
        coluna=0;
    }
    nova[tl]='\0';
    if(erro==1)
        strcpy(nova,"erro");
}

void exiveform(char f[])
{
    gotoxy(1,1);
    printf("%s",f);
}

int identCont(char conjunto[])
{
    char func[3];
    int i;
    
    if((conjunto[0]>='a' && conjunto[0]<='z') || (conjunto[0]>='A' && conjunto[0]<='Z'))
        return 1;
    else 
    {
        if(conjunto[0]== '=' && (conjunto[1]>='A' && conjunto[1]<='Z') && (conjunto[2]>='A' && conjunto[2]<='Z'))
        {
            for(i=0;i<3;i++)
                func[i]=conjunto[i+1];
            func[i]='\0';
            if(strcmp(func,"SUM")==0) return 4;
            else if(strcmp(func,"AVG")==0) return 5;
            else if(strcmp(func,"MAX")==0) return 6;
            else if(strcmp(func,"MIN")==0) return 7;
        }
        else if(conjunto[0]== '=')
            return 2;
        else return 3;
    }
}

float CALC(char expressao[])
{
    char exp[30],test[30],oper;
    float valor,num1,num2;
    int i,tl=0;
    TpPilha pilha,pilha2;
    inicializa(pilha);
    inicializa(pilha2);
    strcpy(test,"");
    strcpy(exp,expressao);

    for(i=0;i<strlen(exp);i++)
    {
        if((exp[i]>='0' && exp[i]<='9') || exp[i]=='.')
        {
            test[tl++]=exp[i];
        }
        else
        {
            if(tl>0)
            {
                test[tl++]='\0';
                insere_f(pilha,atof(test));
                strcpy(test,"");
                tl=0;
            }
            if(exp[i]=='+' || exp[i]=='-' || exp[i]=='*' || exp[i]=='/')
                insere_c(pilha2,exp[i]);
        }
    }
    if(tl>0)
    {
        test[tl++]='\0';
        insere_f(pilha,atof(test));
        strcpy(test,"");
    }
    while(!vazia(pilha2.topo))//calcula
    {
        num2=retira_f(pilha);
        num1=retira_f(pilha);
        oper=retira_c(pilha2);

        switch(oper)
        {
            case'+':insere_f(pilha,num1+num2);
                break;
            case'-':insere_f(pilha,num1-num2);
                break;
            case'*':insere_f(pilha,num1*num2);
                break;
            case'/':insere_f(pilha,num1/num2);
                break;
        }
    }
    return retira_f(pilha);
}

float AVG(char valores[])
{
    float numeros[20],somatorio=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
        somatorio+=numeros[i];
    return somatorio/tl2;
}

float SUM(char valores[])
{
    float numeros[20],somatorio=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
        somatorio+=numeros[i];
    return somatorio;
}

float MAX(char valores[])
{
    float numeros[20],maior=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
    {
        if(numeros[i]>maior)
            maior=numeros[i];
    }
    return maior;
}

float MIN(char valores[])
{
    float numeros[20],menor=99999;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
    {
        if(numeros[i]<menor)
            menor=numeros[i];
    }
    return menor;
}

int verificaCoord(char exp[])
{
    int i,tam,cont=0;

    tam=strlen(exp);
    i=0;
    while(i<tam)
    {
        if((isLetter(exp[i]) && isNumber(exp[i+1])) || (isLetter(exp[i]) && isNumber(exp[i+1]) && isNumber(exp[i+2])) ||(isLetter(exp[i]) && isNumber(exp[i+1]) && isNumber(exp[i+2]) && isNumber(exp[i+3])))
        {
            cont++;
        }
        i++;
    }
    return cont;
}

void calculo(TpPilha &pilha1,TpPilha &pilha2,int cond)
{
    float num1,num2;
    char oper;
    int i;

    i=0;
    while(i<cond)//calcula
    {
        num2=retira_f(pilha1);
        num1=retira_f(pilha1);
        oper=retira_c(pilha2);
        

        switch(oper)
        {
            case'+':insere_f(pilha1,num1+num2);
                break;
            case'-':insere_f(pilha1,num1-num2);
                break;
            case'*':insere_f(pilha1,num1*num2);
                break;
            case'/':insere_f(pilha1,num1/num2);
                break;
        }
        i++;
    }
}

float polonesa(char expressao[])
{
    char exp[50],test[50],oper;
    float valor,num1,num2;
    int i,tl=0;
    TpPilha pilha,pilha2;
    inicializa(pilha);
    inicializa(pilha2);
    strcpy(test,"");
    strcpy(exp,expressao);   


    for(i=0;i<strlen(exp);i++)
    {
        if(isNumber(exp[i]) || exp[i]=='.')
        {          
            test[tl++]=exp[i];
        }
        else
        {
            if(tl>0)
            {
                test[tl++]='\0';
                
                insere_f(pilha,atof(test));
                strcpy(test,"");
                tl=0;
            }
            if(exp[i]==')' && !vazia(pilha2.topo))
            {
                while(elemTopo_c(pilha2) != '(')
                    calculo(pilha,pilha2,1);
                oper=retira_c(pilha2);

            }
            else
            {
                if(!vazia(pilha2.topo) && ((exp[i]=='+' || exp[i]=='-') && (elemTopo_c(pilha2)=='*' || elemTopo_c(pilha2)=='/')))
                {
                    calculo(pilha,pilha2,1);
                    insere_c(pilha2,exp[i]);
                }
                else if(!vazia(pilha2.topo) && exp[i]=='+' && elemTopo_c(pilha2)=='-')
                {
                    calculo(pilha,pilha2,1);
                    insere_c(pilha2,exp[i]);
                }
                else if(!vazia(pilha2.topo) && (exp[i]=='*' || exp[i]=='/') && (elemTopo_c(pilha2)=='*' || elemTopo_c(pilha2)=='/'))
                {
                    calculo(pilha,pilha2,1);
                    insere_c(pilha2,exp[i]);
                }
                else
                {
                    if(exp[i]=='+' || exp[i]=='-' || exp[i]=='*' || exp[i]=='/' || exp[i]=='(')
                        insere_c(pilha2,exp[i]);
                }
            }
        }
    }
    if(tl>0)
    {
        test[tl++]='\0';
        insere_f(pilha,atof(test));
        strcpy(test,"");
    }
    calculo(pilha,pilha2,pilha2.topo+1);
    return retira_f(pilha);
}

int verificaLista(char string[30],int &pos)
{
    int i;

    i=0;
    while(string[i]!=':' && string[i]!='\0')
        i++;
    if(i==strlen(string))
    {
        pos=0;
        return 0;
    }
    else
    {
        pos=i;
        return 1;
    }
}

void formaLista(char string[30],char nova[315])
{
    char aux2[50],letraI,letraF,cnumI[3],cnumF[3],lista[315],aux[3];
    int i,tl,tl2,pos=0,numI,numF,erro,tam,j;

    i=0;
    tl=0;
    while(string[i]!=':')//pega letras e numeros a esquerda
    {
        i++;
    }
    while(string[i]!='(' && i>0)
    {
        if(isLetter(string[i]))
            letraI=string[i];
        else if(isNumber(string[i]))
            cnumI[tl++]=string[i]; 
        i--;       
    }
    cnumI[tl]='\0';

    verificaLista(string,pos);

    i=pos+1;
    tl2=0;
    while(string[i]!=')' && string[i]!='\0')//pega letras e numeros a direita - alterado de '(' para ')'
    {
        if(isLetter(string[i]))
            letraF=string[i];
        else if(isNumber(string[i]))
            cnumF[tl2++]=string[i];
        i++;
    }
    cnumF[tl2]='\0';

    numI=atoi(cnumI);
    numF=atoi(cnumF);


    

    if((numI>=0 && numI<=100) && (numF>=0 && numF<=100))
        erro=0;
    else
        erro=1;

    /*printf("\n\nLETRA INICIAL: %c\tNUMERO INICIAL %d",letraI,numI);
    printf("\n\nLETRA FINAL: %c\tNUMERO FINAL %d",letraF,numF);
    printf("\nERRO: %d",erro);
    getch();*/


    if(letraI==letraF)
    {
        tl=0;
        while(numI<=numF)//VERTICAL
        {
            lista[tl++]=letraI;
            lista[tl]='\0';
            itoa(numI,aux,10);
            strcat(lista,aux);
            tl=strlen(lista);
            lista[tl++]=',';
            numI++;
        }
        lista[tl-1]='\0';
    }
    else//HORIZONTAL
    {
        tl=0;
        while(letraI<=letraF)
        {
            lista[tl++]=letraI;
            lista[tl]='\0';
            strcat(lista,cnumI);
            tl=strlen(lista);
            lista[tl++]=',';
            letraI++;
        }
        lista[tl-1]='\0';
    }


    i=0;
    tl=0;
    while(string[i]!='(')
    {
        nova[tl++]=string[i];
        i++;
    }
    nova[tl++]=string[i];
    nova[tl]='\0';

    strcat(nova,lista);
    tl=strlen(nova);
    nova[tl++]=')';
    nova[tl]='\0';
}

void geraLista(char string[],char nova[])
{
    char aux2[50],letraI,letraF,cnumI[3],cnumF[3],lista[315],aux[3];
    int i,tl,tl2,pos=0,numI,numF,erro,tam,j;

    if(verificaLista(string,pos))
    {
        nova[0]='\0';
        i=0;
        tam=strlen(string);
        tl=tl2=0;
        while(i<tam)
        {
            if(string[i]=='=' && isLetter(string[i+1]))//função SUM AVG MAX
            {
                for(j=i;string[j]!=')';j++)
                {
                    aux2[tl2++]=string[j];
                }
                aux2[tl2++]=string[j];
                aux2[tl2]='\0';


                i+=strlen(aux2)-1;

                if(verificaLista(aux2,pos))
                {
                    formaLista(aux2,lista);
                    strcat(nova,lista);
                    tl+=strlen(lista);
                }
                else
                {
                    strcat(nova,aux2);
                    tl+=strlen(aux2);
                }
                strcpy(aux2,"");
                tl2=0;
            }
            else
            {
                nova[tl++]=string[i];
                nova[tl]='\0';
            }
            i++;
        }
    }
}

float preparaExp(char expressao[],MatEsp *vetlin[],char resultado[])
{
    char exp[50],aux[50],nova[100];
    int i,j,k,tl=0,tl2=0,tam,pos;
    float result;

    strcpy(aux,expressao);
    //formataForm(aux->valor,auxx,vetlin);

    while(verificaCoord(aux))
    {
        if(verificaLista(aux,pos))
        {
            geraLista(aux,nova);
            strcpy(aux,nova);
        }
        else
        {
            formataForm(aux,nova,vetlin);
            strcpy(aux,nova);
        }
    }
    strcpy(expressao,aux);
    if(contemLetra(expressao))
        strcpy(expressao,"erro");
    
    if(strcmp(expressao,"erro")!=0)
    {
        //separar preparar
        tam=strlen(expressao);
        i=0;
        while(i<tam)
        {
            if(expressao[i]=='=' && isLetter(expressao[i+1]))//função SUM AVG MAX
            {
                for(j=i;expressao[j]!=')';j++)
                {
                    aux[tl2++]=expressao[j];
                }
                aux[tl2++]=expressao[j];
                aux[tl2]='\0';
    
                i+=strlen(aux)-1;
                switch(identCont(aux))
                {
                    case 4: result=SUM(aux);
                            sprintf(aux,"%.2f",result);
                        break;
                    case 5: result=AVG(aux);
                            sprintf(aux,"%.2f",result);
                        break;
                    case 6: result=MAX(aux);
                            sprintf(aux,"%.2f",result);
                        break;
                    case 7: result=MIN(aux);
                            sprintf(aux,"%.2f",result);
                        break;
                }
                for(k=0;k<strlen(aux);k++)
                    exp[tl++]=aux[k];
                tl2=0;
            }
            else
            {
                if(isNumber(expressao[i]) || isOperator(expressao[i]) || expressao[i]=='(' || expressao[i]==')' || expressao[i]=='.')//numeros
                    exp[tl++]=expressao[i];
            }
            i++;
        }
        exp[tl]='\0';
        sprintf(resultado,"%f",polonesa(exp));
        //result=polonesa(exp);
        //return result;
    }
    else
        strcpy(resultado,"erro");
}

void exibeConteudo(MatEsp *vetlin[],int lin, int col)
{
    int i,j,c=4,l=4,pl=lin,pc=col;
    char result[35],resultado[50],copia[50];
    MatEsp *aux2;
    strcpy(result,"");
    textbackground(0);
    textcolor(7);
    
    for(j=4;j<=23;j++)//linhas
    {
        for(i=1;i<=8;i++)//colunas
        {
            aux2=verificaOcupado(vetlin,pl,pc);
            if(aux2!=NULL)
            {
                //EXIBE NUMEROS E TEXTOS
                gotoxy(c,l);
                if(identCont(aux2->valor)==1 || identCont(aux2->valor)==3)
                    infoCont(aux2->valor,0);
                else
                {   
                    //EXIBE RESULTADO DE FORMULAS, É FEITA UMA COPIA DA STRING
                    strcpy(copia,aux2->valor);
                    gotoxy(c,l);     
                    preparaExp(copia,vetlin,resultado);  
                    if(strcmp(resultado,"erro")==0)  
                        infoCont(resultado,0);  
                    else
                        infoCont(resultado,1);        
                    //printf("%.2f",preparaExp(copia,vetlin));                 
                }
            }
            c+=9;
            pc++;
        }
        l++;        
        pl++;
        pc=col;
        
        c=4;
    }
}

void infoEsq(int n, int info, char s_info[])
{
    int i, tam;
    itoa(info,s_info,10);
    tam = strlen(s_info);
    for (i=0; i<n-tam; i++)
        strcat(s_info," ");
}

void infoCenter(int info, char s_info[])
{
    char s[9];
    strcpy(s,"    ");
    sprintf(s_info,"%c",info);
    strcat(s,s_info);
    strcat(s,"    ");
    strcpy(s_info,s);
}

void desenhaTela(int lin, int col)
{
    int i,j;
    char slin[4],scol[9];
    textbackground(0);
    clrscr();
    textbackground(3);
    textcolor(0);
    //desenha a coluna esq 1..20
    for (i=4; i<=23; i++)
    {
        gotoxy(1,i);
        infoEsq(3,lin,slin);
        printf("%s",slin);
        lin=lin+1;
    }
    //desenha a linha sup A..H
    j=4;
    for (i=1; i<=8; i++)
    {
        gotoxy(j,3);
        infoCenter(col,scol);
        printf("%s",scol);
        j=j+9;
        col=col+1;
    }
}

void init(MatEsp *vetlin[NL],MatEsp *vetcol[NC])
{
    int i;
    for(i=0;i<NL;i++)
    {
        vetlin[i]=NULL;
    }
    for(i=0;i<NC;i++)
    {
        vetcol[i]=NULL;
    }
}

void insereMatriz(MatEsp *vetlin[],MatEsp *vetcol[],int lin,int col,char elem[])
{
    MatEsp *nova,*aux,*ant;

    aux=verificaOcupado(vetlin,lin,col);
    if(aux!=NULL)
    {
        strcpy(aux->valor,elem);
    }
    else
    {
        nova=(MatEsp*)malloc(sizeof(MatEsp));
        nova->lin=lin;
        nova->col=col;
        strcpy(nova->valor,elem);
        //ligação horizontal

        if(vetlin[lin]==NULL)
        {
            vetlin[lin]=nova;
            nova->pc=NULL;
        }
        else
        {
            if(vetlin[lin]->col>col)
            {
                nova->pc=vetlin[lin];
                vetlin[lin]=nova;
            }
            else
            {
               ant=aux=vetlin[lin];
               while(aux!=NULL && col>aux->col)
               {
                    ant=aux;
                    aux=aux->pc;
               }
               ant->pc=nova;
               nova->pc=aux;

            }
        }
        //ligação vertical;
        if(vetcol[col]==NULL)
        {
            vetcol[col]=nova;
            nova->pl=NULL;
        }
        else
        {
            if(vetcol[col]->lin>lin)
            {
                nova->pl=vetcol[col];
                vetcol[col]=nova;
            }
            else
            {
                ant=aux=vetcol[col];
                while(aux!=NULL && lin>aux->lin)
                {
                    ant=aux;
                    aux=aux->pl;
                }
                ant->pl=nova;
                nova->pl=aux;
            }
        }
    }
}

bool exclui(MatEsp *vetlin[], MatEsp *vetcol[],int lin,int col)
{
    MatEsp *aux,*ant;

    aux=verificaOcupado(vetlin,lin,col);
    if(aux!=NULL)
    {
        //ligação horizontal
        if(vetlin[lin]->col == col)
        {
           vetlin[lin]=vetlin[lin]->pc;
        }
        else
        {
            ant=aux=vetlin[lin];
            while(aux!=NULL && col>aux->col)
            {
                ant=aux;
                aux=aux->pc;
            }
            ant->pc=aux->pc;
        }
        //ligação vertical
        if(vetcol[col]->lin == lin)
        {
           vetcol[col]=vetcol[col]->pl;
        }
        else
        {
            ant=aux=vetcol[col];
            while(aux!=NULL && lin>aux->lin)
            {
                ant=aux;
                aux=aux->pl;
            }
            ant->pl=aux->pl;
        }
        free(aux);
        return true;
    }
    else
        return false;
}

bool save(FILE *arq,MatEsp *vetlin[],char filename[])
{
    int i,j;
    MatEsp *aux;
    Tpreg R;
    
    if(arq=fopen(filename,"wb"))
    {
        for(i=0;i<NL;i++)//linhas
        {
            for(j=0;j<NC;j++)//colunas
            {    
                aux=verificaOcupado(vetlin,i,j); 
                if(aux!=NULL)
                {
                    R.lin=aux->lin;
                    R.col=aux->col;
                    strcpy(R.valor,aux->valor);
                    fwrite(&R,sizeof(R),1,arq);
                }           
            }
        }
        fclose(arq);
        return true;
    }
    else
        return false;  
}

bool open(FILE *arq,MatEsp *vetlin[],MatEsp *vetcol[],char filename[])
{
    Tpreg R;

    if(arq=fopen(filename,"rb"))
    {
        fread(&R,sizeof(Tpreg),1,arq);
        while(!feof(arq))
        {
            insereMatriz(vetlin,vetcol,R.lin,R.col,R.valor);
            fread(&R,sizeof(Tpreg),1,arq);
        }
        fclose(arq);
        return true;
    }
    else
        return false;
}
