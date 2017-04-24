/*Obs na funcoes relacionadas ao tempo prof falou para passa os parametros com & para alterar registro direto
entretanto a outra ideia dada foi de executar o tempo star no comeco do jogar e o end time no fim 
do jogar e so gando o jogador sair desse modulo executar a diferenca entre os tempos */


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
    int acess,ativo,nivel,ponto;
    double tempo;
};

struct TpPalavra
{
  char pergunta[300],palavra[100],dica[100];
  int nivel,pontos,status,ativo;
};

struct TpRanking
{
    char nome[50];
    int pontos,ativo;
    double tempo;
};

struct TpCategoria  //tipo index oque faltava e o prof falou na aula de sexta...
{
  int codigo;
  char categoria[50];     
};

int Login(FILE *Arq);//modulo de login/cadastro de usuarios.
void Opcoes(void);
void Executar(FILE *Arq);
void RelatorioLogin(FILE *Arq);//imprime todos os logins do sistema.
void CadastroPalavras(FILE *Arq);//efetua o cadastro de  palavras dentro do jogo.
long BuscaJogo(FILE *Arq, char chave[100]);//busca palavras no arquivo Palavras.dat
void RelatorioPalavras(FILE *Arq);//imprime todas palavras disponiveis no arquivo.
long BuscaUsuario(FILE *Arq, char chave[50]);//busca usuarios no arquivo Usuarios.dat
void ExLogica(FILE *Arq);//Exclui logicamente todos os registros de >>>>>**** (acho que é palavra)<<<<
void ExFisPalavra(FILE *Arq);//Exclui fisicamente todos os registros marcados pela exclusão logica no arquivo Palavras.dat
void OrdenaPalavras(FILE *Arq);//Ordena Alfabeticamente todas as palavras do Arquivo Palavras.dat
void OrdenaUsuarios(FILE *Arq);//Ordena Alfabeticamente todos os Usuarios do Arquivo Usuarios.dat
void RelAdm(FILE *Arq);//Imprime todos administradores cadastrados no sistema.
void RelUsuario(FILE *Arq);//Imprime todos Usuarios/Jogadores cadastrados no sistema.
void ConsultarPalavra(FILE *Arq);//Executa uma consulta por palavra no Arquivo.
void ConsultarUsuario(FILE *Arq);//Executa uma consulta por Usuario no Arquivo.
void AltPalavra(FILE *Arq);//Altera todos os campos da palavra desejada.
void AltUsuario(FILE *Arq);//Altera todos os campos do Usuario desejado.
void Jogar(FILE *Arq);//Função Principal EXECUÇAO DO JOGO.
void ImpAchou(char resposta[100], int tam);//Modulo utilizado na impressao da palavra na tela.
void Tempo();//Modulo utilizado para pegar o tempo corrente da máquina.
void DifTempo ();//Modulo que retorna a diferença entre dois tempos.
void OrdenaRanking(FILE *Arq);//modulo que ordena o ranking;
void ExPorPalavra(FILE *Arq);//Exclusão Lógica por Palavra desejada.
void ExPorUsuario(FILE *Arq);//Exclusão Lógica por Usuario desejado.
void ExSelUsuario(FILE *Arq);//Exclusão Lógica por Usuarios selecionados.
void ExFisUsuario(FILE *Arq);//Exclusão Fisica de Usuarios
void AltCamPalavra(FILE *Arq);//Altera a palavra por campo.
void AltCamUsuario(FILE *Arq);//Altera o Usuario por campo.
long BuscaSenha(FILE *Arq, char chave[100]);
int func2();
void func1(FILE *Arq);
void forca2 (int erro);
int func4();
void MenuJogador (FILE *Arq);

void Inicia(FILE *Arq);
int CadastroUsuario(FILE *Arq);
void MenuUsu(FILE *Arq);
void MenuPal(FILE *Arq);
void Manutencao(FILE *Arq);
void MenuAdm(FILE *Arq);
void MenuRank(FILE *Arq);
void Regras();


int Login(FILE *Arq)
{
    TpUsuario reg;

    int i,c,p;
    char pass[50],login[50];

    Arq=fopen("Usuarios.dat","ab+");

    do
    {
    
     gotoxy(37,15);
     printf("                     ");
     gotoxy(30,15);
     printf("Login: ");
     gets(reg.login);
     strupr(reg.login);
     
    }while(BuscaUsuario(Arq,reg.login)==-1);

    
    do
    {
        gotoxy(40,16);
        printf("                     ");
        gotoxy(30,16);
        printf("Password: ");
        for(i=0;(reg.pass[i]=getch())!=13 && i<50-1;i++)
        {
            printf("*");
        }

         reg.pass[i]='\0';
     }while(BuscaSenha(Arq,reg.pass)==-1);

         
         p=BuscaUsuario(Arq,reg.login);
         fseek(Arq,p,0);
         fread(&reg,sizeof(TpUsuario),1,Arq);

        
       if(reg.acess==0)
       MenuJogador(Arq);
       
       if(reg.acess==1)
       MenuAdm(Arq);
        


    fclose(Arq);
    
     

}

void desenha(void) //Desenha Quadro
{
    int c,l,li=4,ci=4,lf=30,cf=70;
    textcolor(9);

        for(l=li+1;l<lf;l++)
     {  gotoxy(ci,l);printf("%c",179);
        gotoxy(cf,l);printf("%c",179);
     }

    for(c=ci+1;c<cf;c++)
     {  gotoxy(c,li);printf("%c",196);
        gotoxy(c,lf);printf("%c",196);
     }
     gotoxy(ci,li);printf("%c",218);
     gotoxy(cf,li);printf("%c",191);
     gotoxy(ci,lf);printf("%c",192);
     gotoxy(cf,lf);printf("%c",217);
}


void MiniForca (void)
{
    int c,l;

    textcolor(6);

     for(l=13;l<25;l++){
         gotoxy(15,l);printf("%c",186);}

     for(c=12;c<20;c++){
         gotoxy(c,24);printf("%c",220);}

     for(c=15;c<25;c++){
         gotoxy(c,13);printf("%c",205);}

     for(l=13;l<15;l++){
        gotoxy(25,l);printf("%c",186);}

                gotoxy(25,13);printf("%c",187);
                gotoxy(15,13);printf("%c",201);
                gotoxy(15,24);printf("%c",219);
}
void forca()
{
    int c,l;

        // FORCA (madeira)
     textcolor(6);
  
     for(l=10;l<25;l++){
         gotoxy(17,l);printf("%c",186);}

     for(c=12;c<23;c++){
         gotoxy(c,25);printf("%c",220);}

     for(c=17;c<30;c++){
         gotoxy(c,10);printf("%c",205);}

     for(l=10;l<13;l++){
        gotoxy(30,l);printf("%c",186);}

                gotoxy(30,10);printf("%c",187);
                gotoxy(17,10);printf("%c",201);
                gotoxy(17,25);printf("%c",219);


                     for(l=13;l<15;l++){
                         gotoxy(30,l);printf("|");}
}

void forca2 (int erro)
{
     int c,l;
                /////////////////////////////////corpo
            if(erro==1)
            {
                textcolor(14);
                textbackground(15);

                for(c=27;c<34;c++)
                  for(l=15;l<19;l++){
                        gotoxy(c,l);printf("%c",219);}

                    textbackground(14);
                    textcolor(15);
                    gotoxy(29,18);printf("%c",254); // dente
                    gotoxy(31,18);printf("%c",254); // dente

                    //textbackground(14);
                    textcolor(0);
                    gotoxy(30,17);printf("o");

                    textbackground(0);
            }
        
        else {
           if(erro==2)
           {
                        //short
                    textcolor(6);

                        for(c=27;c<34;c++)
                           for(l=19;l<20;l++){
                               gotoxy(c,l);printf("%c",219);}

                             //s
                                    for(c=27;c<29;c++){
                                            gotoxy(c,20);printf("%c",219);}

                                      for(c=32;c<34;c++){
                                            gotoxy(c,20);printf("%c",219);}
        
                                     //gravata
                                         textcolor(12);
                                         gotoxy(30,19);printf("%c",173);
        }
                                    
                             textcolor(14);
         if(erro==3){
            gotoxy(32,21);printf("%c",124);//perna
              gotoxy(32,22);printf("%c",248);}// pé
         if(erro==4){                            
            gotoxy(28,21);printf("%c",124);//perna
             gotoxy(28,22);printf("%c",248);}// pé
         if(erro==5){                                
            gotoxy(34,17);printf("%c",92); // braço direito
            gotoxy(35,18);printf("%c",248);}// mão
         if(erro==6){
            gotoxy(26,17);printf("%c",47); // esquerta
            gotoxy(25,18);printf("%c",248);}//mao
            
                                            
                 if(erro==7)
                 {
                                        textcolor(0);
                                        for(c=27;c<37;c++){
                                             gotoxy(c,16);printf("%c",219);}
                                        
                                          textbackground(14);
                                          textcolor(14);
                                         gotoxy(31,18);printf("%c",254); // dente
                                          gotoxy(29,18);printf("%c",254); // dente
                                          textcolor(7);
                                          gotoxy(30,18);printf("X"); // dente
                                          textbackground(0);
                                           
                 } 
        
          
    }

}




void CadastroPalavras(FILE *Arq)
{
    TpPalavra reg;
    char tecla;


    Arq=fopen("Palavras.dat","ab+");

    clrscr();
    desenha();
    
    gotoxy(25,8);
    printf(" - Cadastro de Palavras - ");

    gotoxy(18,10);
    printf("Palavra:");
    fflush(stdin);
    gets(reg.palavra);
    strupr(reg.palavra);

    while(BuscaJogo(Arq,reg.palavra)==-1 && strcmp(reg.palavra,"\0")!=0)
    {
        gotoxy(18,13);
        printf("Pergunta:");
        gets(reg.pergunta);
        
        gotoxy(18,14);
        printf("Dica:");
        fflush(stdin);
        gets(reg.dica);
        strupr(reg.dica);
        
        gotoxy(18,15);
        printf("Pontos:");
        fflush(stdin);
        scanf("%d",&reg.pontos);
        
        gotoxy(18,16);
        printf("Nivel:");
        fflush(stdin);
        scanf("%d",&reg.nivel);

        reg.status=1;
        reg.ativo=1;

        fwrite(&reg,sizeof(TpPalavra),1,Arq);
        
        gotoxy(20,18);printf(" __________________________________________");
        getch();
        
        gotoxy(18,13);
        printf("Palavra:");
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

long BuscaSenha(FILE *Arq, char chave[50])
{
    TpUsuario reg;

    fseek(Arq,0,0); //Rewind(Arq); <~~~~~~~ FAZ MESMA COISA,JOGA O PONTEIRO PARA PRIMEIRA POSIÇAO;;;;

    fread(&reg,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq) && strcmp(chave,reg.pass)!=0)
        fread(&reg,sizeof(TpUsuario),1,Arq);

    if(strcmp(chave,reg.pass)!=0)
       return -1;
      else
       return ftell(Arq)-sizeof(TpUsuario); //sizeof(TpReg) menos um tamanho de uma estrutura!!!!
}


void RelatorioLogin(FILE *Arq)
{
    TpUsuario r;

    Arq=fopen("Usuarios.dat","rb");

    clrscr();
    desenha();
    
    gotoxy(20,8);
    printf("RELATORIO DE USUARIOS");

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
    
    int i=13;
    
    Arq=fopen("Palavras.dat","rb");

    clrscr();
    desenha();

    gotoxy(20,8);
    printf(" - PALAVRAS CADASTRADAS - ");

    fread(&r,sizeof(TpPalavra),1,Arq);
 
    while(!feof(Arq))
    {   
        gotoxy(15,i);
        printf("Pergunta: %s",r.pergunta); i++;
        gotoxy(15,i);
        printf("Resposta: %s",r.palavra);i++;
        gotoxy(15,i);
        printf("Dica: %s",r.dica);i++;
        gotoxy(15,i);
        printf("Pontos: %d",r.pontos);i++;
        gotoxy(15,i);
        printf("Nivel: %d",r.nivel);i++;
        gotoxy(15,i);
        printf("Status: %d",r.status);i++;
        gotoxy(15,i);
        printf("Palavra Ativa: %d",r.ativo);i+2;
        

        fread(&r,sizeof(TpPalavra),1,Arq);
    }
    fclose(Arq);

    getch();
}

void ExFisPalavra(FILE *Arq)
{
    TpPalavra r;
    
    clrscr();
    desenha();
    
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
    
    gotoxy(28,20);
    printf(" FUNCAO EXECUTADA COM SUCESSO ! ");
    getch();
}

void ExFisUsuario(FILE *Arq)
{
    TpUsuario r;
    FILE *Temp=fopen("Temp.dat","wb");
    Arq=fopen("Usuarios.dat","rb");

    while(!feof(Arq))
    {
        fread(&r,sizeof(TpUsuario),1,Arq);
        if(r.ativo==1)
         fwrite(&r, sizeof(TpUsuario),1,Temp);
    }
    fclose(Arq);
    fclose(Temp);

    remove("Usuarios.dat");
    rename("Temp.dat","Usuarios.dat");
}

void ExFisRanking(FILE *Arq)
{
    TpRanking r;
    FILE *Temp=fopen("Temp.dat","wb");
    Arq=fopen("Ranking.dat","rb");

    while(!feof(Arq))
    {
        fread(&r,sizeof(TpRanking),1,Arq);
        if(r.ativo==1)
         fwrite(&r, sizeof(TpRanking),1,Temp);
    }
    fclose(Arq);
    fclose(Temp);

    remove("Ranking.dat");
    rename("Temp.dat","Ranking.dat");
}

void ExLogica(FILE *Arq)//>>> ex logica de todos os registros
{
    TpPalavra r;
    int qt,i;
    Arq=fopen("Palavras.dat","rb+");
    fseek(Arq,0,2);
    qt= ftell(Arq) / sizeof(TpPalavra) - 1;
    
    for(i=0;i<qt;i++)
    {
        fseek(Arq,i*sizeof(TpPalavra),0);
        fread(&r,sizeof(TpPalavra),1,Arq);
        if(r.ativo!=0)
        {
            r.ativo=0;
            fseek(Arq,i*sizeof(TpPalavra),0);
            fwrite(&r,sizeof(TpPalavra),1,Arq);
        }
    }
    fclose(Arq);
}

void OrdenaPalavras(FILE *Arq)
{
    int qtde=0,i,j;

    TpPalavra regi,regj;

    Arq=fopen("Palavras.dat","rb+");

    clrscr();
    desenha();
    
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
  gotoxy(20,15);
  printf("Palavras Ordenadas!");
  getch();

  fclose(Arq);
}


void OrdenaUsuarios(FILE *Arq)
{
    int qtde=0,i,j;

    TpUsuario regi,regj;
    
    clrscr();
    desenha();

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
  gotoxy(20,8);
  printf("Usuarios Ordenados!");
  getch();

  fclose(Arq);
}

void RelAdm(FILE *Arq)
{
    TpUsuario r;
    Arq=fopen("Usuarios.dat","rb");
    
     clrscr();
     desenha();
    
    gotoxy(20,8);
    printf("  - RELATORIO DE ADMINISTRADORES - ");

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
  desenha();
  
    gotoxy(20,8);
    printf(" - RELATORIO DE USUARIOS - ");

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
    
    
     clrscr();
     desenha();
  
  
    Arq=fopen("Palavras.dat","rb");
    
    gotoxy(20,8);
    printf(" - Busca Por Palavra - ");

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
    
     clrscr();
     desenha();
  
    Arq=fopen("Usuarios.dat","rb");
   
    gotoxy(20,8);
    printf(" - Buscar Por Usuario - ");

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
    
     clrscr();
     desenha();
  
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");

    gotoxy(20,8);
    printf(" - ALTERAR PALAVRA - ");

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

void AltCamUsuario(FILE *Arq)
{
    int campo;
    char tecla;
    long p;
    
     clrscr();
  desenha();
  
  
    TpUsuario regp;
    Arq=fopen("Usuarios.dat","rb+");

    gotoxy(20,8);
    printf(" - ALTERAR USUARIOS POR CAMPO - ");

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

         printf("\n[1]Login: %s",regp.login);
         printf("\n[2]Password: %s",regp.pass);
         printf("\n[3]Nivel de Acesso: %d",regp.acess);
         printf("\n[-]Conta Ativa: %d\n",regp.ativo);
         printf("\nCampo a Alterar?:");
         scanf("%d",&campo);

        do
        {
         switch(campo)
         {
            case 1:{printf("Novo Login:");
                    fflush(stdin);
                    gets(regp.login);
                    strupr(regp.login);
                   }break;

            case 2:{printf("Novo Password:");//<--colokar verificação de existencia da palavra alterda
                    fflush(stdin);
                    gets(regp.pass);
                   }break;

            case 3:{printf("Novo Nivel de Acesso:");
                    fflush(stdin);
                    scanf("%d",&regp.acess);
                   }break;
         }
            regp.ativo=1;

            printf("\nConfirmar Alteracao? <S/N>:");

            if(toupper(getche())=='S')
            {
             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpUsuario),1,Arq);
             clrscr();
             printf("Alteracao Realizada com Sucesso!!!");
            }

         clrscr();

         printf("\n[1]Login: %s",regp.login);
         printf("\n[2]Password: %s",regp.pass);
         printf("\n[3]Nivel de Acesso: %d",regp.acess);
         printf("\n[-]Conta Ativa: %d\n",regp.ativo);
         printf("Deseja Alterar Outro Campo? <S/N>:");
         fflush(stdin);
         tecla=toupper(getch());

         if(tecla=='S')
         {
          printf("\nCampo a Alterar?:");
          scanf("%d",&campo);
         }

        }while(tecla=='S');
     }
     fclose(Arq);
}

void AltCamPalavra(FILE *Arq)
{
    int campo;
    
     clrscr();
     desenha();
  
    char tecla;
    long p;
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");

    gotoxy(20,8);
    printf(" - ALTERAR PALAVRA POR CAMPO - ");

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

         printf("\n[1]Pergunta: %s",regp.pergunta);
         printf("\n[2]Resposta: %s",regp.palavra);
         printf("\n[3]Dica: %s",regp.dica);
         printf("\n[4]Pontos: %d",regp.pontos);
         printf("\n[5]Nivel: %d",regp.nivel);
         printf("\n[-]Status: %d",regp.status);
         printf("\n[-]Palavra Ativa: %d\n",regp.ativo);
         printf("\nCampo a Alterar?:");
         scanf("%d",&campo);

        do
        {
         switch(campo)
         {
            case 1:{printf("Nova Pergunta:");
                    fflush(stdin);
                    gets(regp.pergunta);
                   }break;

            case 2:{printf("Nova Resposta:");//<--colokar verificação de existencia da palavra alterda
                    fflush(stdin);
                    gets(regp.palavra);
                    strupr(regp.palavra);
                   }break;

            case 3:{printf("Nova Dica:");
                    fflush(stdin);
                    gets(regp.dica);
                    strupr(regp.dica);
                   }break;

            case 4:{printf("Novo Pontos:");
                    fflush(stdin);
                    scanf("%d",&regp.pontos);
                   }break;

            case 5:{printf("Novo Nivel:");
                    fflush(stdin);
                    scanf("%d",&regp.nivel);
                   }break;
         }
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

         clrscr();

         printf("\n[1]Pergunta: %s",regp.pergunta);
         printf("\n[2]Resposta: %s",regp.palavra);
         printf("\n[3]Dica: %s",regp.dica);
         printf("\n[4]Pontos: %d",regp.pontos);
         printf("\n[5]Nivel: %d",regp.nivel);
         printf("\n[-]Status: %d",regp.status);
         printf("\n[-]Palavra Ativa: %d\n",regp.ativo);
         printf("Deseja Alterar Outro Campo? <S/N>:");
         fflush(stdin);
         tecla=toupper(getch());

         if(tecla=='S')
         {
          printf("\nCampo a Alterar?:");
          scanf("%d",&campo);
         }

        }while(tecla=='S');
     }


     fclose(Arq);
}

void AltUsuario(FILE *Arq)
{
    long p;
    TpUsuario regp;
    
     clrscr();
  desenha();
  
    Arq=fopen("Usuarios.dat","rb+");

    gotoxy(20,8);
    printf(" - ALTERAR USUARIO - ");

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
    TpRanking reg;
    time_t inicio,fim;
    
    int pos, qtde,tam,i,k,erro=0,t=0,nivel=1,p=0,niv=0;
    
    char letra,test,achou[100],palavra[100];

    Arq=fopen("Palavras.dat","rb+");
    FILE *Arq2=fopen("Ranking.dat","rb+");
    FILE *Arq3=fopen("Usuarios.dat","rb+");
    
    time(&inicio);

    clrscr();
    desenha();
    forca();

    fseek(Arq,0,2);
    qtde=ftell(Arq)/sizeof(TpPalavra);
    fseek(Arq,0,0);
    fread(&r,sizeof(TpPalavra),1,Arq);

    do
    {
         //imprime e randomiza as perguntas na tela;
         gotoxy(30,7);
         printf("                                    ");
         do
         {
          pos=rand()%qtde;
          fseek(Arq,pos*sizeof(TpPalavra),0);
          textcolor(2);
         }while(r.nivel!=nivel && r.ativo==0);
         
          gotoxy(30,7);
          puts(r.pergunta);

         tam=strlen(r.palavra);

         for(i=0;i<tam;i++)
              achou[i]='_';

         p=0;
         ImpAchou(achou,tam);
          
          
          gotoxy(10,28);
          printf(" NIVEL - %d",nivel);


          gotoxy(25,29);
            printf("Digite Uma Letra:");
            
         do
        {
            t=0;
            
            gotoxy(44,29);
            fflush(stdin);
            letra=toupper(getche());

            //printf("%s",r.palavra)
            int h;
            for(h=0;h<tam;h++)
            {
               if(letra==r.palavra[h])
                {
                     textcolor(5);
                     achou[h]=letra;
                     t=1;
                     p++;
                }
            }
            
            if(t==0)
              erro++;
            
            ImpAchou(achou,tam);
            forca2 (erro);
            

         }while(letra!=27 && erro<7 && tam!=p);
     
     niv++;
     fread(&r,sizeof(TpPalavra),1,Arq);
     if(niv==5 || niv==10 || niv==20)
       nivel=nivel++;
       
       
    }while(letra!=27 && erro<7);
    
    
     time(&fim);
     
     reg.tempo=difftime(fim,inicio);
     //fwrite();
     
    fclose(Arq);
    fclose(Arq2);
    fclose(Arq3);
    
}


void ImpAchou(char resposta[100],int tam) // exibir A letra (AchOU)
{
    int k;
    
    textcolor(15);
    gotoxy(40,27);
    printf("                           ");

   gotoxy(35,25);
    for(k=0;k<tam;k++)
        {
         printf("%c",resposta[k]);
         printf("%c",' ');
        }
}

//cplusplus
void Tempo()
{
  time_t tempo;
  struct tm * timeinfo;

  time ( &tempo );
  timeinfo = localtime ( &tempo );
  printf ( "A Data e a Hora Corrente: %s", asctime (timeinfo) );
  getch();
}
//cplusplus
void DifTempo ()
{
  time_t start,end;
  char szInput [256];
  double dif;

  time (&start);
  printf ("Digite seu Nome: ");
  gets (szInput);
  time (&end);
  dif = difftime (end,start);
  printf ("Oi %s.\n", szInput);
  printf ("Voce demorou %.2lf segundos para escrever seu nome.\n", dif );
  getch();
}

void OrdenaRanking(FILE *Arq)//por pontuação >>> acrescentar a condição de se os pontos são iguais o que tem menor tempo é o maior.....
{
    int qtde=0,i,j;

    TpRanking regi,regj;

    Arq=fopen("Ranking.dat","rb+");

    fseek(Arq,0,2);

    qtde=ftell(Arq)/sizeof(TpRanking);

    for(i=0;i<qtde-1;i++)
    {
      for(j=i+1;j<qtde;j++)
      {
        fseek(Arq,i*sizeof(TpRanking),0);
        fread(&regi,sizeof(TpRanking),1,Arq);
        fseek(Arq,j*sizeof(TpRanking),0);
        fread(&regj,sizeof(TpRanking),1,Arq);

        if(regi.pontos>regj.pontos)
        {
            fseek(Arq,i*sizeof(TpRanking),0);
            fwrite(&regj,sizeof(TpRanking),1,Arq);
            fseek(Arq,j*sizeof(TpRanking),0);
            fwrite(&regi,sizeof(TpRanking),1,Arq);
        }
       }
    }
  printf("\nRanking Ordenado\n");
  getch();

  fclose(Arq);
}

void ExPorPalavra(FILE *Arq)
{
      clrscr();
  desenha();
  
  
    long p;
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");

    gotoxy(20,8);
    printf(" - EXCLUSAO POR PALAVRA - ");

    printf("\n\nExcluir: ");
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
         printf("\nDeseja Excluir? <S/N> :");

        if(toupper(getche())=='S')
        {
            clrscr();

            regp.ativo=0;

             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpPalavra),1,Arq);
             clrscr();
             printf("Exclusao Realizada com Sucesso!!!");
        }

     }


     fclose(Arq);
}

void ExPorUsuario(FILE *Arq)
{
    long p;
    
     clrscr();
    desenha();
  
    TpUsuario regp;
    Arq=fopen("Usuarios.dat","rb+");

    gotoxy(20,8);
    printf(" - EXCLUSAO POR USUARIO - ");

    printf("\n\nExcluir: ");
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
         printf("\nDeseja Excluir? <S/N> :");

        if(toupper(getche())=='S')
        {
            clrscr();

            regp.ativo=0;

             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpUsuario),1,Arq);
             clrscr();
             printf("Exclusao Realizada com Sucesso!!!");
        }

     }


     fclose(Arq);
}

void ExSelUsuario(FILE *Arq)//Exclusão Por seleção >> escolha quais deseja deletar..   /// dando erro igual a exclusão logia com while!!!
{
    TpUsuario regp;
    int i, qt;
    
    Arq=fopen("Usuarios.dat","rb+");
    
    fseek(Arq,0,2);
    qt=ftell(Arq)/sizeof(TpUsuario)-1;
    
    clrscr();
    desenha();
    
    gotoxy(20,8);
    printf(" - EXCLUSAO POR SELECAO EM USUARIOS - ");
    
    for(i=0;i<qt;i++)
    {
        fseek(Arq,i*sizeof(TpUsuario),0);
        fread(&regp,sizeof(TpUsuario),1,Arq);
        
        
         printf("\nLogin: %s",regp.login);
         printf("\nPassword: %s",regp.pass);
         printf("\nNivel de Acesso: %d",regp.acess);
         printf("\nConta Ativa: %d\n",regp.ativo);
         printf("\nDeseja Excluir? <S/N> :");
        
        if(toupper(getche())=='S')
        {
            regp.ativo=0;

             fseek(Arq,i*sizeof(TpUsuario),0); //posicionei
             fwrite(&regp,sizeof(TpUsuario),1,Arq);
             clrscr();
             printf("Exclusao Realizada com Sucesso!!!");
        }
        clrscr();       
    }
    
    fclose(Arq);
}

void Opcoes(void)
{
    
    clrscr();

    printf("\n  Cadastrar Palavras");
    printf("\n  Relatorio de Todos os Logins");
    printf("\n  Login");
    printf("\n  Relatorio de Palavras");
    printf("\n  Exclusao Logica Palavras");//error
    printf("\n  Exclusao Fisica Palavras");
    printf("\n  Ordena Palavras Alfabeticamente");
    printf("\n  Ordena Usuarios Alfabeticamente");
    printf("\n  Relatorio de Administradores");
    printf("\n  Relatorio de Usuarios");
    printf("\n  Consultar Por Palavra");
    printf("\n  Consultar Por Usuario");
    printf("\n  Alterar Palavra (Registro Completo)");
    printf("\n  Alterar Usuario (Registro Completo)");
    printf("\n  Testes --->MODULO Jogar");
    printf("\n  Tempo Corrente");
    printf("\n  Diferenca entre Tempos");
    printf("\n  Exclusao Por Palavra");
    printf("\n  Exclusao Por Usuario");
    printf("\n  Exclusao Selecionada, Por Usuario");//error
    printf("\n  Exclusao Fisica Usuarios");
    printf("\n  Exclusao Fisica Ranking");
    printf("\n  Altera Palavra por Campo");

    printf("\n[ESC] Sair");
   


  
}

void Executar(FILE *Arq)
{
    int op;
    char tecla; 
    
    do
    {
  
        //Opcoes();
        op=func2();
        
        switch(op)
        {
            case 0: CadastroPalavras(Arq);
                      break;
            case 1: RelatorioLogin(Arq);
                      break;
            case 2: Login(Arq);
                      break;
            case 3: {RelatorioPalavras(Arq);
                      break;}
            case 4: ExLogica(Arq);
                      break;
            case 5: ExFisPalavra(Arq);
                      break;
            case 6: OrdenaPalavras(Arq);
                      break;
            case 7: OrdenaUsuarios(Arq);
                      break;
            case 8: RelAdm(Arq);
                      break;
            case 9: RelUsuario(Arq);
                      break;
            case 10: ConsultarPalavra(Arq);
                      break;
            case 11: ConsultarUsuario(Arq);
                      break;
            case 12: AltPalavra(Arq);
                      break;
            case 13: AltUsuario(Arq);
                      break;
            case 14: Jogar(Arq);
                      break;
            case 15: Tempo();
                      break;
            case 16: DifTempo ();
                      break;
            case 17: ExPorPalavra(Arq);
                      break;
            case 18: ExPorUsuario(Arq);
                      break;
            case 19: ExSelUsuario(Arq);
                      break;
            case 20: ExFisUsuario(Arq);
                      break;
            case 21: ExFisRanking(Arq);
                      break;
            case 22: AltCamPalavra(Arq);
                      break;
        }
        tecla=getch();
        
   }while(tecla!=27);
    
}

void MenuI(int li, int ci, int lf, int cf)
{
    int x=0;

    clrscr();
    desenha();
    
    MiniForca();
     gotoxy(40,16);
    printf("                     ");
     gotoxy(37,15);
    printf("                     ");

    textcolor(14);
    gotoxy(25,8);
    printf(" < < < BOB - FORCA < < < ");
    //MiniForca();
    textcolor(15);
    gotoxy(27,24);printf("______");
      gotoxy(35,24);printf("______");
        gotoxy(43,24);printf("______");
             gotoxy(27,23);printf("JOGAR");
             gotoxy(35,23);printf("REGRAS");
             gotoxy(43,23);printf("RANKING");

getch();

}

void func1(FILE *Arq)
{
    int a=0 , v[3];
    char tecla;

    v[1]=27;
    v[2]=35;
    v[3]=43;
 
    do{
           tecla=getch();
            textcolor(0);
             gotoxy(v[a],24);
             printf("_____");
             
             
           if(tecla==-32||tecla==0)
           {
                tecla=getch();
                 switch(tecla)
                {
                         case 75: { a--;
                                    if(a==0||a==-1)
                                        a=1;
                                  }
                                    break;

                         case 77: { a++;
                                    if(a==4)
                                       a=3;
                                  }
                                   break;
                 }
            }
                     textcolor(14);
                     gotoxy(v[a],24);
                     printf("_____");
                     
    }while(tecla!=13);
    
    switch (a)
    { 
        case 1 :Jogar(Arq);
                break;
        case 2:Regras();
               break;
        
    }
    
}

int func2()
{
    int a=0;
    char tecla;
    
    gotoxy(1,(2+a));printf(">");
    do{

           tecla=getch();
            textcolor(0);
             gotoxy(1,2+a);printf(" ");
           if(tecla==-32||tecla==0)
           {
                tecla=getch();
                 switch(tecla)
                {
                         case 72: { a--;
                                    if(a==-1)
                                        a=0;
                                  }
                                    break;

                         case 80: { a++;
                                    if(a==23)
                                       a=22;
                                  }
                                   break;
                }
                     textcolor(14);
                     gotoxy(1,(2+a));printf(">");
            }
    }while(tecla!=13);
    
    return a;
    
}

//////////////////////////////////////////////////////////////////////////
int func3()
{
    int a=0;
    char tecla;
 
 gotoxy(10,(16+a));printf(">");
 
 do{    tecla=getch();
        textcolor(2);
        
        gotoxy(10,16+a);printf(" ");
        
        if(tecla==-32||tecla==0)
        {
          tecla=getch();
            switch(tecla)
            {
             case 72: { a--;
                        if(a==-1)
                        a=0;
                      }break;

             case 80: { a++;
                        if(a==3)
                           a=2;
                      }break;
            }
            textcolor(14);
            gotoxy(10,(16+a));printf(">");
        }
    }while(tecla!=13);   
 return a;     
}

int func4()
{
    int a=0;
    char tecla;
    gotoxy(10,(16+a));printf(">");

 do{    tecla=getch();
        textcolor(2);

        gotoxy(10,16+a);printf(" ");

        if(tecla==-32||tecla==0)
        {
          tecla=getch();
            switch(tecla)
            {
             case 72: { a--;
                        if(a==-1)
                        a=0;
                      }break;

             case 80: { a++;
                        if(a==10)
                           a=9;
                      }break;
            }
            textcolor(14);
            gotoxy(10,(16+a));printf(">");
        }
    }while(tecla!=13);
 return a;
}

void Inicia(FILE *Arq)
{
  int op;  
  
   clrscr();
  desenha();
  
  textcolor(14);
  gotoxy(25,8);
  printf(" < < < BOB - FORCA < < < "); 
  textcolor(15);
  
  gotoxy(10,16);
  printf("  Logar");
  gotoxy(10,17);
  printf("  Cadastrar");
  gotoxy(10,18);
  printf("  SAIR");
  
  op=func3();
  
  switch(op)
  {
        case 0:{Login(Arq);
               }break;
        case 1:{CadastroUsuario(Arq);
               }break;
   }
   
}

int CadastroUsuario(FILE *Arq)
{
    TpUsuario reg;

     clrscr();
     desenha();
  
    int i,c;
    char pass[50],login[50];

    Arq=fopen("Usuarios.dat","ab+");

    do
    {
    
     gotoxy(37,15);
     printf("                     ");
     gotoxy(30,15);
     printf("Login: ");
     gets(reg.login);
     strupr(reg.login);
     
    }while(BuscaUsuario(Arq,reg.login)!=-1);


        gotoxy(40,16);
        printf("                     ");
        gotoxy(30,16);
        printf("Password: ");
        for(i=0;(reg.pass[i]=getch())!=13 && i<50-1;i++)
        {
            printf("*");
        }

         reg.pass[i]='\0';
     
        
         reg.acess=1;
         reg.ativo=1;

        fwrite(&reg,sizeof(TpUsuario),1,Arq);
        
       // MenuJogador(Arq);

    fclose(Arq);

}


void MenuJogador (FILE *Arq)
{
      clrscr();
      desenha();
      
      MiniForca();
      
      textcolor(14);
      gotoxy(25,8);
      printf(" < < < BOB - FORCA < < < ");



      textcolor(15);
      gotoxy(27,23);printf("JOGAR");
      gotoxy(35,23);printf("REGRAS");
      gotoxy(43,23);printf("RANKING");
      func1(Arq);
}

void MenuAdm(FILE *Arq)
{
  int op; 
  
   clrscr();
  desenha();
   
  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - ADMINISTRADOR - - - - - "); 
  textcolor(15);
  
  textcolor(14);
  gotoxy(10,16);
  printf("  Jogar");
  gotoxy(10,17);
  printf("  Manutençao");
  gotoxy(10,18);
  printf("  SAIR");
  
  op=func3();
  
  switch(op)
  {
        case 0:{Jogar(Arq);
               }break;
        case 1:{Manutencao(Arq);
               }break;
   }
   
}

void Manutencao(FILE *Arq)
{
  int op;  
  
   clrscr();
  desenha();
  
  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - MANUTENCAO - - - - - "); 
  textcolor(15);
  
  gotoxy(10,16);
  printf("  Palavras");
  gotoxy(10,17);
  printf("  Usuarios");
  gotoxy(10,18);
  printf("  Ranking");
  
  op=func3();
  
  switch(op)
  {
        case 0:{MenuPal(Arq);
               }break;
        case 1:{MenuUsu(Arq);
               }break;
        case 2:{MenuRank(Arq);
               }break;
   }
   
}

void MenuRank(FILE *Arq)
{
  int op;  
  
   clrscr();
  desenha();
  
  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - MANUTENCAO RANKING - - - - - "); 
  textcolor(15);
  
  gotoxy(10,16);
  printf("  Ordena");
  gotoxy(10,17);
  printf("  Visualizar");
  gotoxy(10,18);
  printf("  _VOLTAR_");
  
  op=func3();
  
  switch(op)
  {
        case 0:{OrdenaRanking(Arq);
               }break;
        case 1:{
               }break;
        case 2:{Manutencao(Arq);
               }break;
   }
   
}

void MenuPal(FILE *Arq)
{
  int op;  
  clrscr();
  desenha();
  
  textcolor(14);
  gotoxy(20,8);
  printf("- - - - - MANUTENCAO PALAVRAS - - - - - "); 
  textcolor(15);
  
  gotoxy(10,16);
  printf("  Cadastrar");
  gotoxy(10,17);
  printf("  Relatorio");
  gotoxy(10,18);
  printf("  Exclusao Fisica");
  gotoxy(10,19);
  printf("  Ordenar");
  gotoxy(10,20);
  printf("  Consultar");
  gotoxy(10,21);
  printf("  Alterar Palavra");
  gotoxy(10,22);
  printf("  Excluir Por Palavra");
  gotoxy(10,23);
  printf("  Alterar Por Campo");
  gotoxy(10,24);
  printf(" _VOLTAR_");
  
  op=func4();
  
  switch(op)
  {
        case 0:{CadastroPalavras(Arq);
               }break;
        case 1:{RelatorioPalavras(Arq);
               }break;
        case 2:{ExFisPalavra(Arq);
               }break;
        case 3:{OrdenaPalavras(Arq);
               }break;
        case 4:{ConsultarPalavra(Arq);
               }break;
        case 5:{AltPalavra(Arq);
               }break;
        case 6:{ExPorPalavra(Arq);
               }break;
        case 7:{AltCamPalavra(Arq);
               }break;
        case 8:{Manutencao(Arq);
               }break;
   }
   
}

void MenuUsu(FILE *Arq)
{
  int op;  
  clrscr();
  desenha();
  
  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - MANUTENCAO USUARIOS - - - - - "); 
  textcolor(15);
  //colokar mais um modulo para usar o mesmo op de manutencao palavras
  gotoxy(10,16);
  printf("  Relatorio");
  gotoxy(10,17);
  printf("  Ordenar");
  gotoxy(10,18);
  printf("  Relatorio de Administradores");
  gotoxy(10,19);
  printf("  Relatorio de Jogadores");
  gotoxy(10,20);
  printf("  Consultar");
  gotoxy(10,21);
  printf("  Alterar");
  gotoxy(10,22);
  printf("  Excluir Por Usuario");
  gotoxy(10,23);
  printf("_VOLTAR_");
  
  op=func4();
  
  switch(op)
  {
        case 0:{RelatorioLogin(Arq);
               }break;
        case 1:{OrdenaUsuarios(Arq);
               }break;
        case 2:{RelAdm(Arq);
               }break;
        case 3:{RelUsuario(Arq);
               }break;
        case 4:{ConsultarUsuario(Arq);
               }break;
        case 5:{AltUsuario(Arq);
               }break;
        case 6:{ExPorUsuario(Arq);
               }break;
        case 7:{Manutencao(Arq);
               }break;
        
   }
   
}

void Regras()
{
  clrscr();
  desenha();  
  
  gotoxy(25,8);
  printf("- - - - - REGRAS - - - - - ");
  
  gotoxy(10,16);
  printf("Responda as questoes utilizando o alfabeto,");
  gotoxy(10,17);
  printf("seu objetivo e acertar todas as respostas");
  gotoxy(10,18);
  printf("e  ganhar  %d MILHAO  DE REAIS. ",1);
  gotoxy(10,19); 
  printf("Fique  atento  pois  cada  questao  vale uma");
  gotoxy(10,20);
  printf("quantidade  de  dinheiro  se  voce  parar");
  gotoxy(10,21);
  printf("ganhara  a  metade  do  que  tem,");
  gotoxy(10,22);
  printf("se  errar  perdera  tudo.");
  getch();
}


void MenuPrincipal (FILE *Arq)
{
      int c,l,li=4,ci=4,lf=30,cf=70, a,b ,x=0;
      clrscr();
      desenha();
      
      Inicia(Arq);
      //MiniForca();
      //Login(Arq);
      //MenuJogador(Arq);
     // Menu(li,ci,lf,cf);
      //Executar(Arq);
      getch();
}


int main()
{
    FILE *A;
    textcolor(5);
    clrscr();
    MenuPrincipal(A);

    return 1;
}




/*
ALUNOS: LUCAS FONSECA RA: 0261029835
        VICTOR PRADO  RA: 0261030370
*/


/*

PPPPPPPPPPPPPPPPP        AAA               MMMMMMMM               MMMMMMMM
P::::::::::::::::P      A:::A              M:::::::M             M:::::::M
P::::::PPPPPP:::::P    A:::::A             M::::::::M           M::::::::M
PP:::::P     P:::::P  A:::::::A            M:::::::::M         M:::::::::M
  P :::P     P:::::P A:::::::::A           M::::::::::M       M::::::::::M
  P::::P     P:::::PA:::::A:::::A          M:::::::::::M     M:::::::::::M
  P::::PPPPPP:::::PA:::::A A:::::A         M:::::::M::::M   M::::M:::::::M
  P:::::::::::::PPA:::::A   A:::::A        M::::::M M::::M M::::M M::::::M
  P::::PPPPPPPPP A:::::A     A:::::A       M::::::M  M::::M::::M  M::::::M
  P::::P        A:::::AAAAAAAAA:::::A      M::::::M   M:::::::M   M::::::M
  P::::P       A:::::::::::::::::::::A     M::::::M    M:::::M    M::::::M
  P::::P      A:::::AAAAAAAAAAAAA:::::A    M::::::M     MMMMM     M::::::M
PP::::::PP   A:::::A             A:::::A   M::::::M               M::::::M
P::::::::P  A:::::A               A:::::A  M::::::M               M::::::M
P::::::::P A:::::A                 A:::::A M::::::M               M::::::M
PPPPPPPPPPAAAAAAA                   AAAAAAAMMMMMMMM               MMMMMMMM

*/
