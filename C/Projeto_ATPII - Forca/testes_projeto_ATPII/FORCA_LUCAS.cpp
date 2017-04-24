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


void desenha(void);
void desenha2(int li,int ci,int lf,int cf,int cr);
void CadastroPalavras(FILE *Arq);
long BuscaJogo(FILE *Arq, char chave[100]);
long BuscaUsuario(FILE *Arq, char chave[100]);
long BuscaSenha(FILE *Arq, char chave[50]);
void RelatorioLogin(FILE *Arq);
void RelatorioPalavras(FILE *Arq);
void ExFisPalavra(FILE *Arq);
void ExFisUsuario(FILE *Arq);
void ExFisRanking(FILE *Arq);
void ExLogica(FILE *Arq);//>>> ex logica de todos os registros;
void OrdenaPalavras(FILE *Arq);
void OrdenaUsuarios(FILE *Arq);
void RelAdm(FILE *Arq);
void RelUsuario(FILE *Arq);
void ConsultarPalavra(FILE *Arq);
void ConsultarUsuario(FILE *Arq);
void AltPalavra(FILE *Arq);
void AltCamUsuario(FILE *Arq);
void AltCamPalavra(FILE *Arq);
void AltUsuario(FILE *Arq);
void Jogar(FILE *Arq);
void ImpAchou(char resposta[100],int tam);
void OrdenaRanking(FILE *Arq);
void ExPorPalavra(FILE *Arq);
void ExPorUsuario(FILE *Arq);
void ExSelUsuario(FILE *Arq);
void MenuI(int li, int ci, int lf, int cf);
void func1(FILE *Arq);
int func3(int t);
int func4(int t);
void Inicia(FILE *Arq);
int CadastroUsuario(FILE *Arq);
void MenuJogador (FILE *Arq);
void MenuAdm(FILE *Arq);
void Manutencao(FILE *Arq);
void MenuRank(FILE *Arq);
void MenuPal(FILE *Arq);
void MenuUsu(FILE *Arq);
void Regras(FILE *Arq);


int Login(FILE *Arq)  ////////////////////////////////////////////////////////////////////////////////////////////////////
{
    TpUsuario reg;

    int i,c,p,li=12,ci=15,lf=22,cf=60,cor=5;
    char pass[50],login[50];

    desenha2(li,ci,lf,cf,cor);

    Arq=fopen("Usuarios.dat","ab+");
    textbackground(cor);

    do
    {

     gotoxy(33,15);
     printf("                     ");
     gotoxy(26,15);
     printf("Login: ");
     gets(reg.login);
     strupr(reg.login);

    }while(BuscaUsuario(Arq,reg.login)==-1);

    do
    {
        gotoxy(36,17);
        printf("                     ");
        gotoxy(26,17);
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

       textbackground(0); ///////////////ALTERADO

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

void desenha2(int li,int ci,int lf,int cf,int cr) //Desenha Quadro ////////ACRESCENTADO
{
    int c,l;
    textcolor(10);
    textbackground(cr);

     for(l=li;l<lf;l++)
        for(c=ci;c<cf;c++){
          gotoxy(c,l);
          printf(" ");}


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
     textbackground(0);
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
    MenuPal(Arq);
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

     int i=13;

    Arq=fopen("Usuarios.dat","rb");

    clrscr();
    desenha();

    gotoxy(20,8);
    printf("RELATORIO DE USUARIOS");

    fread(&r,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq))
    {
        gotoxy(15,i);
        printf("Login: %s",r.login);
        gotoxy(15,i);
        printf("Password: %s",r.pass);
        gotoxy(15,i);
        printf("Nivel de Acesso: %d",r.acess);
        gotoxy(15,i);
        printf("Conta Ativa: %d\n",r.ativo);

        fread(&r,sizeof(TpUsuario),1,Arq);
        getch();
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
    textcolor(14);
    printf(" - PALAVRAS CADASTRADAS - ");

    fread(&r,sizeof(TpPalavra),1,Arq);

    while(!feof(Arq))
    {
        textcolor(15);
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
        printf("Palavra Ativa: %d",r.ativo);i=i+2;

        textcolor(14);
        printf(" __________________________________________");i+2;


        fread(&r,sizeof(TpPalavra),1,Arq);
        getch();
    }
    fclose(Arq);

    getch();
    MenuPal(Arq);
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

    clrscr();
    desenha();

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

    gotoxy(28,20);
    textcolor(14);
    printf(" EXCLUSAO EXECUTADA COM SUCESSO ! ");
    getch();
    MenuUsu(Arq);
}

void ExFisRanking(FILE *Arq)
{
    TpRanking r;

    clrscr();
    desenha();

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

    gotoxy(28,20);
    textcolor(14);
    printf(" EXCLUSAO EXECUTADA COM SUCESSO ! ");
    getch();

    MenuRank(Arq);
}

void ExLogica(FILE *Arq)//>>> ex logica de todos os registros
{
    TpPalavra r;
    int qt,i;

    clrscr();
    desenha();

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

    gotoxy(28,20);
    textcolor(14);
    printf(" EXCLUSAO EXECUTADA COM SUCESSO ! ");
    getch();

    fclose(Arq);

    MenuPal(Arq);
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
  textcolor(14);
  printf("Palavras Ordenadas!");
  getch();

  fclose(Arq);

  MenuPal(Arq);
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
  textcolor(14);
  printf("Usuarios Ordenados!");
  getch();

  fclose(Arq);
  MenuUsu(Arq);
}

void RelAdm(FILE *Arq)
{
    TpUsuario r;
    int i=13,li=4,ci=4,lf=30,cf=70,cor=0;

    Arq=fopen("Usuarios.dat","rb");

     desenha2(li,ci,lf,cf,cor);
     desenha();

    gotoxy(20,8);
    printf("  - RELATORIO DE ADMINISTRADORES - ");

    fread(&r,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq))
    {
        if(r.acess==1)
        {
             gotoxy(15,i);
             printf("Login: %s",r.login);i++;
             gotoxy(15,i);
             printf("Password: %s",r.pass);i++;
             gotoxy(15,i);
             printf("Nivel de Acesso: %d",r.acess);i++;
             gotoxy(15,i);
             printf("Conta Ativa: %d\n",r.ativo);i=i+2;
        }

        fread(&r,sizeof(TpUsuario),1,Arq);
    }
    fclose(Arq);
    getch();
    MenuUsu(Arq);
}

void RelUsuario(FILE *Arq)
{
    TpUsuario r;
    int i=13,li=4,ci=4,lf=30,cf=70,cor=0;

    Arq=fopen("Usuarios.dat","rb");

    desenha2(li,ci,lf,cf,cor);
    desenha();

    gotoxy(20,8);
    printf(" - RELATORIO DE USUARIOS - ");

    fread(&r,sizeof(TpUsuario),1,Arq);

    while(!feof(Arq))
    {
        if(r.acess==0)
        {
             gotoxy(15,i);
             printf("Login: %s",r.login);i++;
             gotoxy(15,i);
             printf("Password: %s",r.pass);i++;
             gotoxy(15,i);
             printf("Nivel de Acesso: %d",r.acess);i++;
             gotoxy(15,i);
             printf("Conta Ativa: %d",r.ativo);i=i+2;
        }

        fread(&r,sizeof(TpUsuario),1,Arq);
    }
   fclose(Arq);
   getch();
   MenuUsu(Arq);
}

void ConsultarPalavra(FILE *Arq)
{
    TpPalavra r;
    long p;
    char resp;

    clrscr();
    desenha();

    Arq=fopen("Palavras.dat","rb");


    do
    {
     textcolor(14);
     gotoxy(20,8);
     printf(" - Busca Por Palavra - ");

     textcolor(15);
     gotoxy(7,10);
     printf("Procurar Por: ");
     fflush(stdin);
     gets(r.palavra);
     strupr(r.palavra);

     p=BuscaJogo(Arq,r.palavra);

     if(p==-1)
       {
        clrscr();
        desenha();
        gotoxy(20,8);
        textcolor(14);
        printf(" - Busca Por Palavra - ");
        gotoxy(7,14);
        textcolor(15);
        printf("Palavra Inexistente no Banco de Dados!");
       }
     else
     {
        fseek(Arq,p,0);//<---- posicionou
        fread(&r,sizeof(TpPalavra),1,Arq);

        clrscr();
        desenha();
        gotoxy(20,8);
        textcolor(14);
        printf(" - Busca Por Palavra - ");

        textcolor(15);
        gotoxy(7,10);
        printf("Pergunta: %s",r.pergunta);
        gotoxy(7,11);
        printf("Resposta: %s",r.palavra);
        gotoxy(7,12);
        printf("Dica: %s",r.dica);
        gotoxy(7,13);
        printf("Pontos: %d",r.pontos);
        gotoxy(7,14);
        printf("Nivel: %d",r.nivel);
        gotoxy(7,15);
        printf("Status: %d",r.status);
        gotoxy(7,16);
        printf("Palavra Ativa: %d\n",r.ativo);
     }
     gotoxy(7,18);
     textcolor(14);
     printf("Consultar Outra? <S/N>: ");
     textcolor(15);
     scanf("%c",&resp);
     resp=toupper(resp);

     clrscr();
     desenha();


    }while(resp=='S');

    fclose(Arq);
    MenuPal(Arq);
}


void ConsultarUsuario(FILE *Arq)
{
    TpUsuario r;
    long p;
    char resp;

    clrscr();
    desenha();

    Arq=fopen("Usuarios.dat","rb");

    do
    {
     gotoxy(20,8);
     textcolor(14);
     printf(" - Buscar Por Usuario - ");

     textcolor(15);
     gotoxy(7,10);
     printf("Procurar Por: ");
     fflush(stdin);
     gets(r.login);
     strupr(r.login);

     p=BuscaUsuario(Arq,r.login);

     if(p==-1)
     {
        clrscr();
        desenha();
        gotoxy(20,8);
        textcolor(14);
        printf(" - Buscar Por Usuario - ");
        gotoxy(7,14);
        textcolor(15);
        printf("\nUsuario Inexistente no Banco de Dados!\n");
     }
     else
     {
        fseek(Arq,p,0);//<---- posicionou
        fread(&r,sizeof(TpUsuario),1,Arq);

        textcolor(14);
        gotoxy(7,10);
        printf("\nLogin: %s",r.login);
        gotoxy(7,11);
        printf("\nPassword: %s",r.pass);
        gotoxy(7,12);
        printf("\nNivel de Acesso: %d",r.acess);
        gotoxy(7,13);
        printf("\nConta Ativa: %d\n",r.ativo);
     }

     gotoxy(7,16);
     textcolor(14);
     printf("Consultar Outra? <S/N>: ");
     textcolor(15);
     scanf("%c",&resp);
     resp=toupper(resp);

    }while(resp=='S');

    fclose(Arq);
    MenuUsu(Arq);
}


void AltPalavra(FILE *Arq)
{
    long p;
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");

    clrscr();
    desenha();

    gotoxy(20,8);
    textcolor(14);
    printf(" - ALTERAR PALAVRA - ");

    gotoxy(7,10);
    textcolor(15);
    printf("Alterar: ");
    fflush(stdin);
    gets(regp.palavra);
    strupr(regp.palavra);

    p=BuscaJogo(Arq, regp.palavra);//BUSCA
    if(p==-1)
       {
        clrscr();
        desenha();
        gotoxy(20,8);
        textcolor(14);
        printf(" - ALTERAR PALAVRA - ");
        gotoxy(7,10);
        textcolor(15);
        printf("Palavra Inexistente");
        getch();
       }
      else
      {
         fseek(Arq,p,0); //posicionei
         fread(&regp,sizeof(TpPalavra),1,Arq);//leitura do arquivo

         clrscr();
         desenha();
         gotoxy(20,8);
         textcolor(14);
         printf(" - ALTERAR PALAVRA - ");

         textcolor(15);

         gotoxy(7,10);
         printf("Pergunta: %s",regp.pergunta);
         gotoxy(7,11);
         printf("Resposta: %s",regp.palavra);
         gotoxy(7,12);
         printf("Dica: %s",regp.dica);
         gotoxy(7,13);
         printf("Pontos: %d",regp.pontos);
         gotoxy(7,14);
         printf("Nivel: %d",regp.nivel);
         gotoxy(7,15);
         printf("Status: %d",regp.status);
         gotoxy(7,16);
         printf("Palavra Ativa: %d\n",regp.ativo);
         gotoxy(7,18);
         textcolor(14);
         printf("Deseja Alterar? <S/N> :");
         textcolor(15);

        if(toupper(getche())=='S')
        {
            clrscr();
            desenha();
            gotoxy(20,8);
            textcolor(14);
            printf(" - ALTERAR PALAVRA - ");

            textcolor(15);

            gotoxy(7,10);
            printf("Nova Pergunta:");
            fflush(stdin);
            gets(regp.pergunta);

            gotoxy(7,11);
            printf("Nova Resposta:");
            fflush(stdin);
            gets(regp.palavra);
            strupr(regp.palavra);

            gotoxy(7,12);
            printf("Nova Dica:");
            fflush(stdin);
            gets(regp.dica);
            strupr(regp.dica);

            gotoxy(7,13);
            printf("Novo Pontos:");
            fflush(stdin);
            scanf("%d",&regp.pontos);

            gotoxy(7,14);
            printf("Novo Nivel:");
            fflush(stdin);
            scanf("%d",&regp.nivel);

            regp.status=1;
            regp.ativo=1;

            textcolor(14);
            gotoxy(7,16);
            printf("Confirmar Alteracao? <S/N>:");
            textcolor(15);
            if(toupper(getche())=='S')
            {
             fseek(Arq,p,0); //posicionei
             fwrite(&regp,sizeof(TpPalavra),1,Arq);
             clrscr();
             textcolor(15);
             gotoxy(7,10);
             printf("Alteracao Realizada com Sucesso!!!");
            }

        }
     }

     fclose(Arq);
     MenuPal(Arq);
}


void AltCamUsuario(FILE *Arq)//////////////////////////////////////////////////////////////////////fsdfsfsdfsfsdfsdsfdfds
{
    int campo;
    char tecla;
    long p;
    TpUsuario regp;
    Arq=fopen("Usuarios.dat","rb+");

    clrscr();
    desenha();

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
     MenuUsu(Arq);
}


void AltCamPalavra(FILE *Arq)
{
    int campo;
    char tecla;
    long p;
    TpPalavra regp;

    Arq=fopen("Palavras.dat","rb+");

    clrscr();
    desenha();

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
     MenuPal(Arq);
}

void AltUsuario(FILE *Arq)
{
    long p;
    TpUsuario regp;

    Arq=fopen("Usuarios.dat","rb+");

    clrscr();
    desenha();

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
     MenuUsu(Arq);
}


void Jogar(FILE *Arq)
{
    TpPalavra r;
    TpRanking reg;
    time_t inicio,fim;

    int pos,c,l, qtde,tam,i,k,erro=0,t=0,nivel=1,p=0,niv=0;

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

     if(niv==2 || niv==10 || niv==20)
       nivel++;


    }while(letra!=27 && erro<7);

     time(&fim);

     reg.tempo=difftime(fim,inicio);

    fclose(Arq);
    fclose(Arq2);
    fclose(Arq3);
}


void ImpAchou(char resposta[100],int tam) // exibir A letra (AchOU)
{
    int k;

    textcolor(15);
    gotoxy(35,25);
    printf("                           ");

   gotoxy(35,25);
    for(k=0;k<tam;k++)
        {
         printf("%c",resposta[k]);
         printf("%c",' ');
        }
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
  MenuRank(Arq);
}


void ExPorPalavra(FILE *Arq)
{
    long p;
    TpPalavra regp;
    Arq=fopen("Palavras.dat","rb+");

    clrscr();
    desenha();

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
     MenuPal(Arq);
}


void ExPorUsuario(FILE *Arq)
{
    long p;
    TpUsuario regp;
    Arq=fopen("Usuarios.dat","rb+");

    clrscr();
    desenha();

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
     MenuUsu(Arq);
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
    MenuUsu(Arq);
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
        case 2:Regras(Arq);
               break;

    }

}


int func3(int t)
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
             case 72: { a=a-2;
                        if(a==-1)
                           a=0;
                      }break;

             case 80: { a=a+2;
                        if(a==t)
                           a=t-2;
                      }break;
            }
            textcolor(14);
            gotoxy(10,(16+a));printf(">");
        }
    }while(tecla!=13);
 return a;
}

int func4(int t)
{
    int a=0;
    char tecla;
    gotoxy(27,(11+a));printf(">");

 do{    tecla=getch();
        textcolor(2);

        gotoxy(27,11+a);printf(" ");

        if(tecla==-32||tecla==0)
        {
          tecla=getch();
            switch(tecla)
            {
             case 72: { a=a-2;
                        if(a<=-1)
                           a=0;
                      }break;

             case 80: { a=a+2;
                        if(a>=t)
                           a=t-2;
                      }break;
            }
            textcolor(14);
            gotoxy(27,(11+a));printf(">");
        }
    }while(tecla!=13);
 return a;
}

void Inicia(FILE *Arq)
{
  int op , tam = 6;

  clrscr();
  desenha();

  textcolor(14);
  gotoxy(25,8);
  printf(" < < < BOB - FORCA < < < ");
  textcolor(15);

  gotoxy(10,16);
  printf("  Logar");
  gotoxy(10,18);
  printf("  Cadastrar");
  gotoxy(10,20);
  printf("  SAIR");



  op=func3(tam);

  switch(op)
  {
        case 0:{Login(Arq);
               }break;
        case 2:{CadastroUsuario(Arq);
               }break;
   }


}


int CadastroUsuario(FILE *Arq)
{
    TpUsuario reg;

    int li=12,ci=15,lf=22,cf=60,cor=2;
    char tecla;

     desenha2(li,ci,lf,cf,cor);
     desenha();

    int i,c;
    char pass[50],login[50];

    Arq=fopen("Usuarios.dat","ab+");

    textcolor(11);
    textbackground(2);

    do
    {

     gotoxy(37,15);
     printf("                     ");
     gotoxy(30,15);
     printf("Login: ");
     gets(reg.login);
     strupr(reg.login);
     tecla=getch();

    }while(BuscaUsuario(Arq,reg.login)!=-1 && tecla!=27);


        gotoxy(40,16);
        printf("                     ");
        gotoxy(30,16);
        printf("Password: ");
       while(tecla!=27 && tecla!=13){
        for(i=0;(reg.pass[i]=getch())!=13 && i<50-1;i++)
        {
            printf("*");
        }

         reg.pass[i]='\0';
         tecla=getch();
        }

         reg.acess=0;
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
  int op,tam=6;

   clrscr();
  desenha();

  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - ADMINISTRADOR - - - - - ");
  textcolor(15);

  textcolor(14);
  gotoxy(10,16);
  printf("  Jogar");
  gotoxy(10,18);
  printf("  Manutençao");
  gotoxy(10,20);
  printf("  SAIR");

  op=func3(tam);

  switch(op)
  {
        case 0:{Jogar(Arq);
               }break;
        case 2:{Manutencao(Arq);
               }break;
   }

}

void Manutencao(FILE *Arq)
{
  int op,li=4,ci=4,lf=30,cf=70,cor=0,tam=6;


  desenha2(li,ci,lf,cf,cor);
  desenha();

  textcolor(14);
  gotoxy(25,8);
  printf("- - - - - MANUTENCAO - - - - - ");
  textcolor(15);

  gotoxy(10,16);
  printf("  Palavras");
  gotoxy(10,18);
  printf("  Usuarios");
  gotoxy(10,20);
  printf("  Ranking");

  op=func3(tam);

  switch(op)
  {
        case 0:{MenuPal(Arq);
               }break;
        case 2:{MenuUsu(Arq);
               }break;
        case 4:{MenuRank(Arq);
               }break;
   }

}

void MenuRank(FILE *Arq)
{
  int op,tam=6;

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

  op=func3(tam);

  switch(op)
  {
        case 0:{OrdenaRanking(Arq);
               }break;
        case 2:{
               }break;
        case 4:{Manutencao(Arq);
               }break;
   }

}


void MenuPal(FILE *Arq)
{
  int op,li=6,ci=19,lf=28,cf=56,cor=5,tam=18;
  clrscr();
  desenha();
  desenha2(li,ci,lf,cf,cor);
  textbackground(cor);

  textcolor(14);
  gotoxy(18,8);
  printf("- - - - - MANUTENCAO PALAVRAS - - - - - ");
  textcolor(15);

  gotoxy(29,11);
  printf("  Cadastrar");
  gotoxy(29,13);
  printf("  Relatorio");
  gotoxy(29,15);
  printf("  Exclusao Fisica");
  gotoxy(29,17);
  printf("  Ordenar");
  gotoxy(29,19);
  printf("  Consultar");
  gotoxy(29,21);
  printf("  Alterar Palavra");
  gotoxy(29,23);
  printf("  Excluir Por Palavra");
  gotoxy(29,25);
  printf("  Alterar Por Campo");
  gotoxy(29,27);
  printf(" _VOLTAR_");

  op=func4(tam);
  textbackground(0);
  switch(op)
  {
        case 0:{CadastroPalavras(Arq);
               }break;
        case 2:{RelatorioPalavras(Arq);
               }break;
        case 4:{ExFisPalavra(Arq);
               }break;
        case 6:{OrdenaPalavras(Arq);
               }break;
        case 8:{ConsultarPalavra(Arq);
               }break;
        case 10:{AltPalavra(Arq);
               }break;
        case 12:{ExPorPalavra(Arq);
               }break;
        case 14:{AltCamPalavra(Arq);
               }break;
        case 16:{Manutencao(Arq);
               }break;
   }

}

void MenuUsu(FILE *Arq)
{
  int op,tam=18,li=6,ci=19,lf=28,cf=56,cor=5;
  clrscr();
  desenha();
  desenha2(li,ci,lf,cf,cor);
  textbackground(cor);

  textcolor(14);
  gotoxy(18,8);
  printf("- - - - - MANUTENCAO USUARIOS - - - - - ");
  textcolor(15);
  //colokar mais um modulo para usar o mesmo op de manutencao palavras
  gotoxy(29,11);
  printf("  Relatorio");
  gotoxy(29,13);
  printf("  Ordenar");
  gotoxy(29,15);
  printf("  Relatorio de Adm");
  gotoxy(29,17);
  printf("  Relatorio de Jogadores");
  gotoxy(29,19);
  printf("  Consultar");
  gotoxy(29,21);
  printf("  Alterar");
  gotoxy(29,23);
  printf("  Excluir Por Usuario");
  gotoxy(29,25);
  printf("_VOLTAR_");

  op=func4(tam);
  textbackground(0);
  switch(op)
  {
        case 0:{RelatorioLogin(Arq);
               }break;
        case 2:{OrdenaUsuarios(Arq);
               }break;
        case 4:{RelAdm(Arq);
               }break;
        case 6:{RelUsuario(Arq);
               }break;
        case 8:{ConsultarUsuario(Arq);
               }break;
        case 10:{AltUsuario(Arq);
               }break;
        case 12:{ExPorUsuario(Arq);
               }break;
        case 14:{Manutencao(Arq);
               }break;

   }

}


void Regras(FILE *Arq)
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

  MenuJogador(Arq);
}


void MenuPrincipal (FILE *Arq)
{
      int c,l,li=4,ci=4,lf=30,cf=70, a,b ,x=0;

      clrscr();
      desenha();

      Inicia(Arq);
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

