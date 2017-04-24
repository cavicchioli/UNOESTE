#include<stdio.h>
#include<conio2.h>
#include<ctype.h>
#include<string.h>
#include<dos.h>

struct TpUsuario
{
    char login[50],pass[50];
    int acess,ativo;
};

struct TpPalavra
{
  char pergunta[300],palavra[100],dica[100];
  int nivel,pontos,status,ativo;
};

void Login(FILE *Arq);
char Menu(void);
void Executar(FILE *Arq);
void RelatorioLogin(FILE *Arq);
void CadastroPalavras(FILE *Arq);
long BuscaJogo(FILE *Arq, char chave[100]);
void RelatorioPalavras(FILE *Arq);
long BuscaUsuario(FILE *Arq, char chave[50]);
void ExLogica(FILE *Arq);
void ExclusaoFisica(FILE *Arq);
void OrdenaPalavras(FILE *Arq);


void Login(FILE *Arq)
{
    TpUsuario reg;
    
    int i;
    char pass[50],login[50];
    
    Arq=fopen("Usuarios.dat","ab+");

    do
    {   
     printf("\nLogin: ");
     gets(reg.login);
     strupr(reg.login); 
    }
    while(BuscaUsuario(Arq,reg.login)!=-1);

    printf("\nPassword: ");
    for(i=0;(reg.pass[i]=getch())!=13 && i<50-1;i++)
    {
        printf("*");
    }
    reg.pass[i]='\0';
    
    reg.acess=0;
    reg.ativo=1;
    
        fwrite(&reg,sizeof(TpUsuario),1,Arq);
        
        
    fclose(Arq);

}

void CadastroPalavras(FILE *Arq)
{
    TpPalavra reg;
    char tecla;

    Arq=fopen("Palavras.dat","ab+");
    
    clrscr();
    printf("*-*-*-Cadastro de Palavras-*-*-*");
    
    printf("\n\nPalavra:");
    fflush(stdin);
    gets(reg.palavra);
    strupr(reg.palavra);
    
    while(BuscaJogo(Arq,reg.palavra)==-1 && strcmp(reg.palavra,"\0")!=0)
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

        fwrite(&reg,sizeof(TpPalavra),1,Arq);
        
        printf("\nPalavra:");
        fflush(stdin);
        gets(reg.palavra);
        strupr(reg.palavra);
        

    }
    fclose(Arq);

}

long BuscaJogo(FILE *Arq, char chave[100])         
{
    TpPalavra reg;
    
    fseek(Arq,0,0); //Rewind(Arq); <~~~~~~~ FAZ MESMA COISA,JOGA O PONTEIRO PARA PRIMEIRA POSIÇAO;;;;
    
    fread(&reg,sizeof(TpPalavra),1,Arq);
    
    while(!feof(Arq) && strcmp(chave,reg.palavra)!=0)
        fread(&reg,sizeof(TpPalavra),1,Arq);
        
    if(strcmp(chave,reg.palavra)!=0)
       return -1;
      else
       return ftell(Arq)-sizeof(TpPalavra); //sizeof(TpReg) menos um tamanho de uma estrutura!!!!
}

long BuscaUsuario(FILE *Arq, char chave[100])
{
    TpUsuario reg;

    fseek(Arq,0,0); //Rewind(Arq); <~~~~~~~ FAZ MESMA COISA,JOGA O PONTEIRO PARA PRIMEIRA POSIÇAO;;;;

    fread(&reg,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq) && strcmp(chave,reg.login)!=0)
        fread(&reg,sizeof(TpUsuario),1,Arq);

    if(strcmp(chave,reg.login)!=0)
       return -1;
      else
       return ftell(Arq)-sizeof(TpUsuario); //sizeof(TpReg) menos um tamanho de uma estrutura!!!!
}

void RelatorioLogin(FILE *Arq)
{
    TpUsuario r;

    Arq=fopen("Usuarios.dat","rb");

    clrscr();

    printf("\n\t\tRELATORIO DE USUARIOS\n");
    
    fread(&r,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq))
    {
        printf("\nLogin: %s",r.login);
        printf("\nPassword: %s",r.pass);
        printf("\nNivel de Acesso: %d",r.acess);
        printf("\nConta Ativa: %d\n",r.ativo);

        fread(&r,sizeof(TpUsuario),1,Arq);
    }
    fclose(Arq);

    getch();
}

void RelatorioPalavras(FILE *Arq)
{
    TpPalavra r;

    Arq=fopen("Palavras.dat","rb");

    clrscr();

    printf("\n\t\tPALAVRAS CADASTRADAS\n");
   
    fread(&r,sizeof(TpPalavra),1,Arq);

    while(!feof(Arq))
    {
        printf("\nPergunta: %s",r.pergunta);
        printf("\nResposta: %s",r.palavra);
        printf("\nDica: %s",r.dica);
        printf("\nPontos: %d",r.pontos);
        printf("\nNivel: %d",r.nivel);
        printf("\nStatus: %d",r.status);
        printf("\nPalavra Ativa: %d\n",r.ativo);
    
        fread(&r,sizeof(TpPalavra),1,Arq);
    }
    fclose(Arq);

    getch();
}

void ExclusaoFisica(FILE *Arq)
{
    TpPalavra r;
    FILE *Temp=fopen("Temp.dat","wb");
    Arq=fopen("Palavras.dat","rb");
    
    while(!feof(Arq))
    {
        fread(&r,sizeof(TpPalavra),1,Arq);
        if(r.ativo==1)
         fwrite(&r, sizeof(TpPalavra),1,Temp);
    }
    fclose(Arq);
    fclose(Temp);

    remove("Palavras.dat");
    rename("Temp.dat","Palavras.dat");
}

void ExLogica(FILE *Arq)
{
    TpPalavra r;
    Arq=fopen("Palavras.dat","rb+");
    
    while(!feof(Arq))
    {
        fread(&r,sizeof(TpPalavra),1,Arq);
        r.ativo=0;
        //fseek(Arq,ftell(Arq)-sizeof(TpPalavra),0);
        //fwrite(&r,sizeof(TpPalavra),1,Arq);
        
       
       
    }
    fclose(Arq);
    
    printf("sssss");
    getch();
}

void OrdenaPalavras(FILE *Arq)
{
    int qtde=0,i,j;
    
    TpPalavra regi,regj;
    
    Arq=fopen("Palavras.dat","rb+");
    
    fseek(Arq,0,2);
    
    qtde=ftell(Arq)/sizeof(TpPalavra);
    
    for(i=0;i<qtde-1;i++)
    {
      for(j=i+1;j<qtde;j++)
      {
        fseek(Arq,i*sizeof(TpPalavra),0);
        fread(&regi,sizeof(TpPalavra),1,Arq);
        fseek(Arq,j*sizeof(TpPalavra),0);
        fread(&regj,sizeof(TpPalavra),1,Arq);
        
        if(strcmp(regi.palavra,regj.palavra)>0)
        {
            fseek(Arq,i*sizeof(TpPalavra),0);
            fwrite(&regj,sizeof(TpPalavra),1,Arq);
            fseek(Arq,j*sizeof(TpPalavra),0);
            fwrite(&regi,sizeof(TpPalavra),1,Arq);
        }
       }
    }
  printf("\nPalavras Ordenadas\n");
  getch();
  
  fclose(Arq);   
}





char Menu(void)
{
    char Opcao;
    clrscr();
    printf("\n**Opcoes**\n");
    printf("\n[A]Cadastrar Palavras");
    printf("\n[B]Relatorio Login");
    printf("\n[C]Login");
    printf("\n[D]Relatorio de Palavras");
    printf("\n[E]Exclusao Logica Palavras");
    printf("\n[F]Exclusao Fisica Palavras");
    printf("\n[G]Ordena Palavras Alfabeticamente");
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
            case 'B': RelatorioLogin(Arq);
                      break;
            case 'C': Login(Arq);
                      break;
            case 'D': RelatorioPalavras(Arq);
                      break;
            case 'E': ExLogica(Arq);
                      break;
            case 'F': ExclusaoFisica(Arq);
                      break;
            case 'G': OrdenaPalavras(Arq);
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

