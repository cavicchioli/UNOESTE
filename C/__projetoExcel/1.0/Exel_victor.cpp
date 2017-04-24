#include<conio2.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include "pilhaF.h"
#include "pilhaC.h"
#include "TADMatEsp2.h"

struct salvarPlanilha
{
    int lin,col;
    char conteudo[TF];
};
typedef struct salvarPlanilha tpSalvar;

void desenhaMatriz(MatEsp *VetLin[],int l,int lin,int c,int col);
void infoEsq(int n, int info, char s_info[]);
void infoCenter(int info, char s_info[]);
void desenhaTela(int lin, int col);
void iniciaExcel(MatEsp *VetLin[], MatEsp *VetCol[]);
char Salva(MatEsp *VetLin[], MatEsp *VetCol[]);
char Abrir(MatEsp *VetLin[], MatEsp *VetCol[]);
float polonesa(char expressao[]);
char numero(char elem);
char letra(char elem);
char operador(char elem);
void resolve(TpPilhaC &operadores,TpPilhaF &valores,int passo);
float polonesa(char expressao[]);

char numero(char elem)
{
    return (elem>='0' && elem<='9');
}

char letra(char elem)
{
    return (elem>='a' && elem<='z') || (elem>='A' && elem<='Z');
}

char operador(char elem)
{
    return (elem=='+' || elem=='-' || elem=='*' || elem=='/');
}

void resolve(TpPilhaC &operadores,TpPilhaF &valores,int passo)
{
    float num1,num2;
    char aux_operador;
    int i=0;
    
    while(i<passo){
        aux_operador=DesempilhaC(operadores);    
        num2=DesempilhaF(valores);
        num1=DesempilhaF(valores);
        
        switch(aux_operador)
        {
            case'+':EmpilhaF(valores,num1+num2);
                break;
            case'-':EmpilhaF(valores,num1-num2);
                break;
            case'*':EmpilhaF(valores,num1*num2);
                break;
            case'/':EmpilhaF(valores,num1/num2);
                break;
        }
        i++;
    }
}

float polonesa(char expressao[])
{
    
    TpPilhaC operador;//declaraçao e inicializaçao das pilhas utilizadas
    TpPilhaF valores;
    InicializaC(operador);
    InicializaF(valores);
    
    char aux_expressao[TF];//criei auxiliar para expressao e atribui o valor da expressao
    strcpy(aux_expressao,"");
    strcpy(aux_expressao,expressao);
    
    char aux_calculo[TF],oper;
    int tl=0,passo=1;
    //float aux_convercao;
    
    
    for(int i=0;i<strlen(aux_expressao);i++)
    {
        if(numero(aux_expressao[i]) || aux_expressao[i]=='.' || aux_expressao[i] == ',')
        {
            aux_calculo[tl++]=aux_expressao[i];
            //printf("%c")
        }
        else//se ele nao é mais numero nem . ou , é operador ou letra... portanto acabou o numero.
            {
                if(tl>0)//se o tl é maior quer dizer que foi pego um numero.. entao empilha na pilha de valores..
                {
                    aux_calculo[tl++]='\0';
                    EmpilhaF(valores,atof(aux_calculo));
                    strcpy(aux_calculo,"");
                    tl=0; //limpo o aux, e retorno o tl ao zero para contiar a captura dos números...
                }
                
                if(aux_calculo[i]==')' && !VaziaF(valores.Topo))//if(aux_calculo[i]==')' && !VaziaC(operador.Topo))
                {
                    while(AcessaTopoC(operador) != '(')
                    {
                        resolve(operador,valores,passo);//<====no resolve alterei uma condiçao de while rever depois!!
                    }
                    oper=DesempilhaC(operador);//retirar o ( que ficou na pilha!   
                }
                else
                    {
                     if(!VaziaC(operador.Topo) && ((aux_expressao[i]=='+' || aux_expressao[i]=='-') && (AcessaTopoC(operador)=='*' || AcessaTopoC(operador)=='/')))
                     {
                        resolve(operador,valores,passo);
                        EmpilhaC(operador,aux_expressao[i]);
                     }
                      else 
                         if(!VaziaC(operador.Topo) && aux_expressao[i]=='+' && AcessaTopoC(operador)=='-')
                         {
                            resolve(operador,valores,passo);
                            EmpilhaC(operador,aux_expressao[i]);
                         }
                         else 
                            if(!VaziaC(operador.Topo) && (aux_expressao[i]=='*' || aux_expressao[i]=='/') && (AcessaTopoC(operador)=='*' || AcessaTopoC(operador)=='/'))
                            {
                             resolve(operador,valores,passo);
                             EmpilhaC(operador,aux_expressao[i]);
                            }
                            else
                                {
                                 if(aux_expressao[i]=='+' || aux_expressao[i]=='-' || aux_expressao[i]=='*' || aux_expressao[i]=='/' || aux_expressao[i]=='(')                                    
                                   EmpilhaC(operador,aux_expressao[i]);
                                 
                                }
                        
                    }
                
            }
    }
    
  if(tl>0)//se o tl é maior quer dizer que foi pego um numero.. entao empilha na pilha de valores..
  {
   aux_calculo[tl++]='\0';
   EmpilhaF(valores,atof(aux_calculo));
   strcpy(aux_calculo,"");
   tl=0; //limpo o aux, e retorno o tl ao zero para contiar a captura dos números...
  }  
    

    passo=operador.Topo+1;
    resolve(operador,valores,passo);
    return DesempilhaF(valores);
}

void infoEsq(int n, int info, char s_info[])
{
    int i, tam;
    itoa(info,s_info,10);//converte do char para número no caso 10 >>> DECIMAL
    tam = strlen(s_info);
    for (i=0; i<n-tam; i++)
        strcat(s_info," ");
}

void infoCenter(int info, char s_info[])
{
    char s[9];
    strcpy(s,"    ");
    sprintf(s_info,"%c",info);//convertendo coloka oque está na tela numa string
    strcat(s,s_info);
    strcat(s,"    ");
    strcpy(s_info,s);
}

void desenhaMatriz(MatEsp *VetLin[],int l,int lin,int c,int col)//parte pedro
{
     int i,fimL,cont=1,coluna,fimC,iniC;
     MatEsp *aux;
     fimC = (col-65)+8;
     iniC = col-65;
     fimL=(lin+20)-1;
     
     for(i=lin;i<fimL;i++)
     {
        if(VetLin[i] != NULL)
        {
            aux = VetLin[i];                              
            while (aux != NULL)
            {
               if (aux->col > iniC && aux->col <= fimC)
               {
               coluna = 8-(fimC-aux->col);
               gotoxy(coluna*9-9+4,cont+3);
               textbackground(0);
               textcolor(15);
               //polonesa(aux->conteudo);
               printf ("%s",aux->conteudo);
               }
               aux=aux->proxL;
            }
        }
        cont++;
     }
}

void desenhaTela(int lin, int col)
{
    int i,j;
    char slin[4],scol[9];
    textbackground(0);
    clrscr();
    textbackground(3);//3
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

void iniciaExcel(MatEsp *VetLin[], MatEsp *VetCol[])
{
    char key,f2[TF];
    int coluna,linha;//posicao na matriz esp
    int c,l,col,lin;
    
    

    textbackground(0);
    clrscr();
    desenhaTela(1,65);
    //coordenadas de tela
    c=l=1;
    //coordenadas da matriz
    col=65; //letra A
    lin=1;
    gotoxy(c*9-9+4,l+3);
    printf("         ");

    do
    {
        key=getch();
        if (key==-32 || key==0)
        {
            key=getch();
            switch(key) 
            {                       //linhas   linhas-1
                case 80:if (l==20 && lin<100    -    19) //seta p/ cima
                            lin++;
                        if (l<20)
                            l++;
                        break;
                case 72:if (l==1 && lin>1) //seta p/ baixo
                            lin--;
                        if (l>1) 
                            l--;
                        break;
                                     //'A' alfabeto  colunas-1
                case 77:if (c==8 && col<65 +   26    -    8) //seta p/ direita
                            col++;
                        if (c<8)
                            c++;
                        break;
                case 75:if (c==1 && col>65) //seta p/ esquerda
                            col--;
                        if (c>1) 
                            c--;
                        break;
                        
                case 60: //quando preciona F2
                        gotoxy(1,1); //vai para linha destinada a inserir as coisas
                        textbackground(0);//pinta tela de preto
                        textcolor(15);
                        printf("TEXTO: ");
                        gets(f2);
                        
                        linha = (l+lin)-1;//achando a linha para inserir
                        
                        coluna = (col-65)+c;//achando coluna para inserir
                        insereMatriz(VetLin,VetCol,linha,coluna,f2);
                        
                        break;
                        
                case 61:if(!Salva(VetLin,VetCol))
                        {
                            gotoxy(1,1);
                            textbackground(0);
                            textcolor(15);
                            printf("Arquivo com problema!!!");
                        }
                        else
                            {
                                gotoxy(1,1); 
                                textbackground(0);
                                textcolor(15);
                                printf("Arquivo salvo com sucesso!!!");   
                            }     
                        break;
                case 62:if(!Abrir(VetLin,VetCol))
                        {
                            gotoxy(1,1);
                            textbackground(0);
                            textcolor(15);
                            printf("Arquivo com problema!!!");
                        }
                        else
                            {
                                gotoxy(1,1); 
                                textbackground(0);
                                textcolor(15);
                                printf("Arquivo carregado com sucesso!!!");   
                            } 
                        break;
            }
            desenhaTela(lin,col);
            textbackground(0);
            textcolor(7);//7
            //<--------------------exibir todas as celulas na janela atual 
            //                     de lin até lin+19, col até col+8
            gotoxy(c*9-9+4,l+3);
            textbackground(3);
            textcolor(0);
            printf("%d %d %d %d         ",l,lin,c,col); //desenhar o conteudo da celula atual a partir da matriz esparsa
            desenhaMatriz(VetLin,l,lin,c,col);
        }
    }while (key!=27);
}

char Salva(MatEsp *VetLin[], MatEsp *VetCol[])
{
    tpSalvar reg;
    FILE *Arq;
    MatEsp *aux,*ant;
    char tecla,nome[50];
    int i;
    
    gotoxy(1,1);
    textbackground(0);
    textcolor(15);
    printf("Nome do Arquivo: ");
    fflush(stdin);
    gets(nome);
    strcat(nome,".dat");
    
    if(Arq=fopen(nome,"ab+"))
    {
    
        for(i=0;i<25;i++)//linhas
        {  
            aux = VetCol[i];
               
            while(aux != NULL)          
            {
                reg.col=aux->col;
                reg.lin=aux->lin;
                strcpy(reg.conteudo,aux->conteudo);
            
        
                fwrite(&reg,sizeof(tpSalvar),1,Arq);
        
                ant = aux;
                aux = aux->proxC;
            }
        }
    
     fclose(Arq);
     return 1;
    }
    else
        return 0;
}

char Abrir(MatEsp *VetLin[], MatEsp *VetCol[])
{
    tpSalvar reg;
    FILE *Arq;
    MatEsp *aux,*ant;
    char tecla,nome[50];
    int i;
    
    gotoxy(1,1);
    textbackground(0);
    textcolor(15);
    printf("Nome do Arquivo: ");
    fflush(stdin);
    gets(nome);
    strcat(nome,".dat");
    
    if(Arq=fopen(nome,"rb"))
    {
        fseek(Arq,0,0);
        fread(&reg,sizeof(tpSalvar),1,Arq);
    
        while(!feof(Arq))
        {
            insereMatriz(VetLin,VetCol,reg.lin,reg.col,reg.conteudo);   
            fread(&reg,sizeof(tpSalvar),1,Arq);
        }
    
    fclose(Arq);
        return 1;
    }
    else
        return 0;
}

main(void)
{
    MatEsp *VetLin[100], *VetCol[26];
    inicializa(VetLin,VetCol);
    
    iniciaExcel(VetLin,VetCol);
}
