#include<stdio.h>
#include<conio2.h>
#include<ctype.h>
#include<string.h>
#include<dos.h>
#include <stdlib.h>
#include <time.h>


struct TpUsuario
{
    char login[50],pass[50];
    int acess,ativo,nivel;
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
void OrdenaUsuarios(FILE *Arq);
void RelAdm(FILE *Arq);
void RelUsuario(FILE *Arq);
void ConsultarPalavra(FILE *Arq);
void ConsultarUsuario(FILE *Arq);
void AltPalavra(FILE *Arq);
void AltUsuario(FILE *Arq);
void Jogar(FILE *Arq);
void ImpAchou(char resposta[100], int tam);


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


void OrdenaUsuarios(FILE *Arq)
{
    int qtde=0,i,j;
    
    TpUsuario regi,regj;
    
    Arq=fopen("Usuarios.dat","rb+");
    
    fseek(Arq,0,2);
    
    qtde=ftell(Arq)/sizeof(TpUsuario);
    
    for(i=0;i<qtde-1;i++)
    {
      for(j=i+1;j<qtde;j++)
      {
        fseek(Arq,i*sizeof(TpUsuario),0);
        fread(&regi,sizeof(TpUsuario),1,Arq);
        fseek(Arq,j*sizeof(TpUsuario),0);
        fread(&regj,sizeof(TpUsuario),1,Arq);
        
        if(strcmp(regi.login,regj.login)>0)
        {
            fseek(Arq,i*sizeof(TpUsuario),0);
            fwrite(&regj,sizeof(TpUsuario),1,Arq);
            fseek(Arq,j*sizeof(TpUsuario),0);
            fwrite(&regi,sizeof(TpUsuario),1,Arq);
        }
       }
    }
  printf("\nUsuarios Ordenados\n");
  getch();
  
  fclose(Arq);   
}

void RelAdm(FILE *Arq)
{
    TpUsuario r;
    Arq=fopen("Usuarios.dat","rb");
    clrscr();
    
    printf("\n*-*-*-RELATORIO DE ADMINISTRADORES-*-*-*\n");
    
    fread(&r,sizeof(TpUsuario),1,Arq);
    
    while(!feof(Arq))
    {
        if(r.acess==1)
        {
         printf("\nLogin: %s",r.login);
         printf("\nPassword: %s",r.pass);
         printf("\nNivel de Acesso: %d",r.acess);
         printf("\nConta Ativa: %d\n",r.ativo);
        }
        
        fread(&r,sizeof(TpUsuario),1,Arq);
    }
    fclose(Arq);
    getch(); 
}

void RelUsuario(FILE *Arq)
{
    TpUsuario r;
    Arq=fopen("Usuarios.dat","rb");
    clrscr();
    
    printf("\n*-*-*-RELATORIO DE USUARIOS-*-*-*\n");
    
    fread(&r,sizeof(TpUsuario),1,Arq);
    
    while(!feof(Arq))
    {
        if(r.acess==0)
        {
         printf("\nLogin: %s",r.login);
         printf("\nPassword: %s",r.pass);
         printf("\nNivel de Acesso: %d",r.acess);
         printf("\nConta Ativa: %d\n",r.ativo);
        }
        
        fread(&r,sizeof(TpUsuario),1,Arq);
    }
   fclose(Arq);
   getch();
}

void ConsultarPalavra(FILE *Arq)
{
    TpPalavra r;
    long p;
    char resp;
    
    Arq=fopen("Palavras.dat","rb");
    clrscr();
    printf("*-*-*-Busca Por Palavra-*-*-*\n");
    
    do
    {
     printf("\nProcurar Por: ");
     fflush(stdin);
     gets(r.palavra);
     strupr(r.palavra);
    
     p=BuscaJogo(Arq,r.palavra);
     if(p==-1)
        printf("\nPalavra Inexistente no Banco de Dados!\n");
        
     else
     {
        fseek(Arq,p,0);//<---- posicionou
        fread(&r,sizeof(TpPalavra),1,Arq);
        
        printf("\nPergunta: %s",r.pergunta);
        printf("\nResposta: %s",r.palavra);
        printf("\nDica: %s",r.dica);
        printf("\nPontos: %d",r.pontos);
        printf("\nNivel: %d",r.nivel);
        printf("\nStatus: %d",r.status);
        printf("\nPalavra Ativa: %d\n",r.ativo);
     }
    
     printf("\nConsultar Outra? <S/N>\n");
     scanf("%c",&resp);
     resp=toupper(resp);
     
    }while(resp=='S');
    
    fclose(Arq);
}

void ConsultarUsuario(FILE *Arq)
{
    TpUsuario r;
    long p;
    char resp;
    
    Arq=fopen("Usuarios.dat","rb");
    clrscr();
    printf("*-*-*-Buscar Por Usuario-*-*-*\n");
    
    do
    {
     printf("\nProcurar Por: ");
     fflush(stdin);
     gets(r.login);
     strupr(r.login);
    
     p=BuscaUsuario(Arq,r.login);
     if(p==-1)
        printf("\nUsuario Inexistente no Banco de Dados!\n");
        
     else
     {
        fseek(Arq,p,0);//<---- posicionou
        fread(&r,sizeof(TpUsuario),1,Arq);
        
        printf("\nLogin: %s",r.login);
        printf("\nPassword: %s",r.pass);
        printf("\nNivel de Acesso: %d",r.acess);
        printf("\nConta Ativa: %d\n",r.ativo);
     }
    
     printf("\nConsultar Outra? <S/N>\n");
     scanf("%c",&resp);
     resp=toupper(resp);
     
    }while(resp=='S');
    
    fclose(Arq);
}

void AltPalavra(FILE *Arq)
{
    long p;
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");
    
    clrscr();
    printf("\n*-*-*-ALTERAR PALAVRA-*-*-*");
    
    printf("\n\nAlterar: ");
    fflush(stdin);
    gets(regp.palavra);
    strupr(regp.palavra);
    
    p=BuscaJogo(Arq, regp.palavra);//BUSCA 
    if(p==-1)
        printf("\n Palavra Inexistente");
      else
      { 
         fseek(Arq,p,0); //posicionei
         fread(&regp,sizeof(TpPalavra),1,Arq);//leitura do arquivo
            
         printf("\nPergunta: %s",regp.pergunta);
         printf("\nResposta: %s",regp.palavra);
         printf("\nDica: %s",regp.dica);
         printf("\nPontos: %d",regp.pontos);
         printf("\nNivel: %d",regp.nivel);
         printf("\nStatus: %d",regp.status);
         printf("\nPalavra Ativa: %d\n",regp.ativo);   
         printf("\nDeseja Alterar? <S/N> :");  
                   
        if(toupper(getche())=='S')
        {
            clrscr();
            
            printf("Nova Pergunta:");
            fflush(stdin);
            gets(regp.pergunta);
            
            printf("Nova Resposta:");//<--colokar verificação de existencia da palavra alterda
            fflush(stdin);
            gets(regp.palavra);
            strupr(regp.palavra);
        
            printf("Nova Dica:");
            fflush(stdin);
            gets(regp.dica);
            strupr(regp.dica);

            printf("Novo Pontos:");
            fflush(stdin);
            scanf("%d",&regp.pontos);
        
            printf("Novo Nivel:");
            fflush(stdin);
            scanf("%d",&regp.nivel);

            regp.status=1;
            regp.ativo=1;
            
            printf("\nConfirmar Alteracao? <S/N>:");
            
            if(toupper(getche())=='S')
            {
             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpPalavra),1,Arq);
             clrscr();
             printf("Alteracao Realizada com Sucesso!!!");
            }
            
        }
     }
     
     fclose(Arq); 
}

void AltUsuario(FILE *Arq)
{
    long p;
    TpUsuario regp;
    Arq=fopen("Usuarios.dat","rb+");
    
    clrscr();
    printf("\n*-*-*-ALTERAR USUARIO-*-*-*");
    
    printf("\n\nAlterar: ");
    fflush(stdin);
    gets(regp.login);
    strupr(regp.login);
    
    p=BuscaUsuario(Arq, regp.login);//BUSCA 
    if(p==-1)
        printf("\n Usuario Inexistente");
      else
      { 
         fseek(Arq,p,0); //posicionei
         fread(&regp,sizeof(TpUsuario),1,Arq);//leitura do arquivo
            
         printf("\nLogin: %s",regp.login);
        printf("\nPassword: %s",regp.pass);
        printf("\nNivel de Acesso: %d",regp.acess);
        printf("\nConta Ativa: %d\n",regp.ativo); 
         printf("\nDeseja Alterar? <S/N> :");  
                   
        if(toupper(getche())=='S')
        {
            clrscr();
            
            printf("Novo Login:");//<--colokar verificação de existencia do login alterdo
            fflush(stdin);
            gets(regp.login);
            strupr(regp.login);
            
            printf("Novo Password:");
            fflush(stdin);
            gets(regp.pass);
            
        
            printf("Novo Nivel de Acesso: <ADMINISTRADOR 1 / JOGADOR 0>\n");
            fflush(stdin);
            scanf("%d",&regp.acess);

            regp.ativo=1;
            
            printf("\nConfirmar Alteracao? <S/N>:");
            
            if(toupper(getche())=='S')
            {
             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpUsuario),1,Arq);
             clrscr();
             printf("Alteracao Realizada com Sucesso!!!");
            }
            
        }
     }
     
     fclose(Arq); 
}

void Jogar(FILE *Arq)
{
    TpPalavra r;
    TpUsuario reg;
    
    int pos, qtde,tam,i,k;
    char letra,test,achou[100],palavra[100];
    
    Arq=fopen("Palavras.dat","rb+");
    //Arq2=fopen("Usuario.dat","rb+");
    clrscr();
    fseek(Arq,0,2);
    qtde=ftell(Arq)/sizeof(TpPalavra);
    fread(&r,sizeof(TpPalavra),1,Arq);
    
    do
    {
     //imprime e randomiza as perguntas na tela;
     pos=rand()%(qtde+1);
     fseek(Arq,pos*sizeof(TpPalavra),0);
     puts(r.pergunta);
    
    
     tam=strlen(r.palavra);
    
     printf("\n");
    
     for(i=0;i<tam;i++)
       achou[i]='_';
    
     ImpAchou(achou,tam);
     
     printf("\n");
    
     do
     {
      //gotoxy(2,3);   
     
      printf("\nDigite Uma Letra:");
      fflush(stdin);
      scanf("%c",&letra);
      letra=toupper(letra);
     
      //printf("%s",r.palavra);
     
     strcpy(palavra,r.palavra);
     puts(palavra);
     printf("\n");
     
      for(i=0;i<tam;i++);
      {
            
       if(letra==palavra[i]);
       {
        textcolor(5);
        //gotoxy(i,3);
        
        achou[i]=letra;
        
        ImpAchou(achou,tam);
        
       }  
      
      }
     
     }while(getch()!=27); 
    
     fread(&r,sizeof(TpPalavra),1,Arq);
    
    }while(getch()!=27);
    
    fclose(Arq);
}

void ImpAchou(char resposta[100],int tam)
{
    int k;
    
    for(k=0;k<tam;k++)
        {
         printf("%c",resposta[k]);
         printf("%c",' '); 
        }
}

char Menu(void)
{
    char Opcao;
    clrscr();
    printf("\n**Opcoes**\n");
    printf("\n[A]Cadastrar Palavras");
    printf("\n[B]Relatorio de Todos os Logins");
    printf("\n[C]Login");
    printf("\n[D]Relatorio de Palavras");
    printf("\n[E]Exclusao Logica Palavras");
    printf("\n[F]Exclusao Fisica Palavras");
    printf("\n[G]Ordena Palavras Alfabeticamente");
    printf("\n[H]Ordena Usuarios Alfabeticamente");
    printf("\n[I]Relatorio de Administradores");
    printf("\n[J]Relatorio de Usuarios");
    printf("\n[K]Consultar Por Palavra");
    printf("\n[L]Consultar Por Usuario");
    printf("\n[M]Alterar Palavra (Registro Completo)");
    printf("\n[N]Alterar Usuario (Registro Completo)");
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
            case 'H': OrdenaUsuarios(Arq);
                      break;
            case 'I': RelAdm(Arq);
                      break;
            case 'J': RelUsuario(Arq);
                      break;
            case 'K': ConsultarPalavra(Arq);
                      break;
            case 'L': ConsultarUsuario(Arq);
                      break;
            case 'M': AltPalavra(Arq);
                      break;
            case 'N': AltUsuario(Arq);
                      break;
            case 'O': Jogar(Arq);
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

