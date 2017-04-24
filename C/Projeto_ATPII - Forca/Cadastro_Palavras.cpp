#include<stdio.h>
#include<conio2.h>
#include<ctype.h>
#include<string.h>
#include<dos.h>

struct TpJogo
{
  char pergunta[300],palavra[100],dica[100];
  int nivel,pontos,status,ativo;
};

void Executar(FILE *Arq);
void CadastroPalavras(FILE *Arq);
char Menu(void);
void Executar(FILE *Arq);
long Busca(FILE *Arq, char chave[100]);

void CadastroPalavras(FILE *Arq)
{
    TpJogo reg;
    char tecla;
    

    Arq=fopen("Palavras.dat","ab+");
    
    clrscr();
    printf("*-*-*-Cadastro de Palavras-*-*-*");
    
    printf("\n\nPalavra:");
    fflush(stdin);
    gets(reg.palavra);
    strupr(reg.palavra);
    
    while(Busca(Arq,reg.palavra))
    {
        printf("Pergunta:");
        gets(reg.pergunta);
        
        printf("Dica:");
        fflush(stdin);
        gets(reg.dica);
        strupr(reg.dica);

        printf("Pontos:");
        fflush(stdin);
        scanf("%d",&reg.pontos);
        
        printf("Nivel:");
        fflush(stdin);
        scanf("%d",&reg.nivel);

        reg.status=1;
        reg.ativo=1;

        fwrite(&reg,sizeof(TpJogo),1,Arq);
        
        printf("\nPalavra:");
        fflush(stdin);
        gets(reg.palavra);
        strupr(reg.palavra);

    }
    fclose(Arq);

}

long Busca(FILE *Arq, char chave[100])         
{
    TpJogo reg;
    
    fseek(Arq,0,0); //Rewind(Arq); <~~~~~~~ FAZ MESMA COISA,JOGA O PONTEIRO PARA PRIMEIRA POSIÇAO;;;;
    
    fread(&reg,sizeof(TpJogo),1,Arq);
    
    while(!feof(Arq) && strcmp(chave,reg.palavra)!=0)
        fread(&reg,sizeof(TpJogo),1,Arq);
        
    if(strcmp(chave,reg.palavra)!=0)
       return -1;
      else
       return ftell(Arq)-sizeof(TpJogo); //sizeof(TpReg) menos um tamanho de uma estrutura!!!!
}


char Menu(void)
{
    char Opcao;
    clrscr();
    printf("\n**Opcoes**\n");
    printf("\n[A]Cadastrar Palavras");
    printf("\n[B]Relatorio");
    printf("\n[C]Consultar");
    printf("\n[D]Alterar");
    printf("\n[E]Ordena Bolha");
    printf("\n[ESC] Sair");
    printf("\n\nOpcao=>");

    return toupper(getche());
}

void Executar(FILE *Arq)
{
    char op;

    do
    {
        op=Menu();

        switch(op)
        {
            case 'A': CadastroPalavras(Arq);
                      break;
           
        }
        clrscr();
    }
    while(op!=27);
}

int main(int)
{
    FILE *A;

    Executar(A);

    return 1;
}
