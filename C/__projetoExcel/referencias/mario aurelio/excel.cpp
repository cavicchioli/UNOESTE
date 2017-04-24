#include "excel.h"

void iniciaExcel(MatEsp *vetlin[],MatEsp *vetcol[])
{
    MatEsp *aux;
    char key,elem[50],filename[25];
    char auxx[100],aux2[30],nova[100];
    int c,l,col,lin,num,pos;
    FILE *arq;
    textbackground(0);
    clrscr();
    
    desenhaTela(1,65);
    //coordenadas de tela
    c=l=1;
    //coordenadas da matriz
    col=65; //letra A
    lin=1;
    
    exibeConteudo(vetlin,l-1,col-65);
    textbackground(3);
    gotoxy(c*9-9+4,l+3);
    printf("         ");
    do
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
            case 60:gotoxy(1,1); //F2
                    textbackground(0);
                    textcolor(7);
                    printf("%c%d: \n",(c+col)-1,(l+lin)-1);
                    fflush(stdin);
                    gets(elem);
                    insereMatriz(vetlin,vetcol,(l+lin)-2,(c+col)-66,elem);
                    break;    
            case 61:gotoxy(1,1); //F3
                    textbackground(0);
                    textcolor(7);
                    printf("SALVAR>Digite o nome do arquivo: ");
                    fflush(stdin);
                    gets(filename);
                    gotoxy(1,2);printf("Salvando...");
                    if(save(arq,vetlin,filename))
                    {
                        gotoxy(1,2);printf("Arquivo gravado com sucesso!");

                    }
                    else
                    {
                        gotoxy(1,2);printf("Ocorreu um erro e o arquivo nao pode ser salvo!");

                    }
                    key=getch();
                    break;
            case 62:gotoxy(1,1); //F4
                    textbackground(0);
                    textcolor(7);
                    printf("CARREGAR>Digite o nome do arquivo: ");
                    fflush(stdin);
                    gets(filename);
                    gotoxy(1,2);printf("Carregando...");
                    if(open(arq,vetlin,vetcol,filename))
                    {
                        gotoxy(1,2);printf("Arquivo carregado com sucesso!");
                        exibeConteudo(vetlin,lin-1,col-65);
                        key=getch();
                    }
                    else
                    {
                        gotoxy(1,2);printf("Ocorreu um erro. A matriz nao foi carregada!");
                        key=getch();
                    }
                    break;
            case 83: //DEL
                    textbackground(0);
                    textcolor(7);                    
                    if(exclui(vetlin,vetcol,(l+lin)-2,(c+col)-66))
                    {  
                        gotoxy(c*9-9+4,l+3);
                        textbackground(3);
                        textcolor(0);
                        printf("         ");
                        exibeConteudo(vetlin,lin-1,col-65);
                    }
                    key=getch();
                    break;                                                                                                                                                                                              
        }
        desenhaTela(lin,col);
        textbackground(0);
        textcolor(7);
        exibeConteudo(vetlin,lin-1,col-65);//<--exibir todas as celulas na janela atual de lin até lin+19, col até col+8                     
        
        
        gotoxy(c*9-9+4,l+3);
        textbackground(3);
        textcolor(0);
        aux=verificaOcupado(vetlin,(l+lin)-2,(c+col)-66);
        if(aux!=NULL)
            printf("%s",aux->valor); //desenhar o conteudo da celula atual a partir da matriz esparsa
        else
            printf("         ");    
    }while (key!=27);
}

main(void)
{
    MatEsp *vetlin[NL],*vetcol[NC];
    init(vetlin,vetcol);
    
    iniciaExcel(vetlin,vetcol);//inicar
}
