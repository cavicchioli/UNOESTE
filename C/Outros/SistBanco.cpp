#include<conio2.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<time.h>

#define CREDITO 1
#define DEBITO 2



struct TpBanco
{
    char conta[10];
    int ope,cat,dia,mes,ano;
    float val;
};


void Data(int &dia,int &mes,int &ano);
void CConta(FILE* Arq);
long BuscaConta(FILE *Arq, char chave[10]);
void Deposito(FILE *Arq);
void Saque(FILE *Arq);
void Cheque(FILE *Arq);
void Trans(FILE *Arq);
int Menu(FILE *B);
void Transacao(FILE *C);
void Relatorios(FILE *D);
void Rel(FILE *Arq);



int Menu(FILE *B)
{
 int op;
 clrscr();
 printf("------------SISTEMA BANCARIO------------");
 printf("\n\n [1] TRANSACOES");
 printf("\n [2] SALDO/EXTRATO");
 printf("\n [3] CADASTRO DE CONTAS");
 printf("\n [4] SAIR");
 printf("\n\n~:");
 scanf("%d",&op);
 
 switch(op)
 {
       case 1:Transacao(B); break;
       case 2:Relatorios(B); break;
       case 3:CConta(B); break;
       case 4:return 1;
       //default:Menu(B);
 }   
}

void Transacao(FILE *C)
{
    int op;
    clrscr();
    printf("------------MENU TRANSACOES------------");
    printf("\n\n CREDITO");
    printf("\n    [1]Deposito");
    printf("\n    [2]Transferencia");
    printf("\n\n DEBITO");
    printf("\n    [3]Saque");
    printf("\n    [4]Cheque");
    printf("\n    [5]D. Automatico");
    printf("\n\n~:");
    scanf("%d",&op);
    
     switch(op)
     {
       case 1:Deposito(C);break;
       case 2:Trans(C);break;
       case 3:Saque(C);break;
       case 4:Cheque(C);break;
       //default:Menu(C);
     }
}

void Relatorios(FILE *D)
{
 int op;
 clrscr();
 printf("------------SALDO / EXTRATOS------------");
 printf("\n\nSALDO");
 printf("\n     [1]Saldo Geral");
 printf("\n     [2]Saldo por Dia");
 printf("\n\nEXTRATO");
 printf("\n     [3]Extrato Geral");
 printf("\n     [4]Extrato por Transacao");
 printf("\n     [5]Extrato por Periodo");
 printf("\n\n~:");
 scanf("%d",&op);
 
 switch(op)
 {
       case 1:Rel(D);break;
       case 2:;break;
       default:Menu(D);
 }
    
}


//ABERTURA DE CONTA NO BANCO
void CConta(FILE *Arq)
{
    TpBanco reg;
    char conta[10];
    long pos;
    
    Arq=fopen("Banco.dat","ab+");
    
    clrscr();
    
    printf("* - * - * - * -CADASTRO DE CONTAS- * - * - * - *");//criaçao de contas
    
    printf("\n\nConta:");
    fflush(stdin);
    gets(conta);
    
    pos=BuscaConta(Arq,conta);
    
    if(pos==-1)
    {
      fseek(Arq,0,0);  
      strcpy(reg.conta,conta);
      
      reg.val=0;
      
      reg.ope=0;
      reg.cat=0;
      
      Data(reg.dia,reg.mes,reg.ano);
      
      fwrite(&reg,sizeof(TpBanco),1,Arq);
      
      printf("\n\nCONTA CRIADA COM SUCESSO!!");
      getch();
    }
   fclose(Arq);
}

long BuscaConta(FILE *Arq, char chave[10])//busca de conta!!
{
    TpBanco reg;

    fseek(Arq,0,0);

    fread(&reg,sizeof(TpBanco),1,Arq);

    while(!feof(Arq) && strcmp(chave,reg.conta)!=0)
        fread(&reg,sizeof(TpBanco),1,Arq);

    if(strcmp(chave,reg.conta)!=0)
       return -1;
      else
       return ftell(Arq)-sizeof(TpBanco);
}

void Data(int &dia,int &mes,int &ano)//modulo de data!!
{
  struct tm *local;
  time_t seg;
  seg=time(NULL);
  local=localtime(&seg);

  dia=local->tm_mday;
  mes=local->tm_mon+1;
  ano=local->tm_year+1900;      
}

void Deposito(FILE *Arq)
{
    TpBanco r;
    char conta[10];
    long pos;
    
    Arq=fopen("Banco.dat","ab+");
    clrscr();
    printf("*-*-*-*-*-DEPOSITO-*-*-*-*-*");
    
    printf("\n\nConta: ");
    fflush(stdin);
    gets(conta);
    
    pos=BuscaConta(Arq,conta);
    
      if(pos!=-1)
      {
        fseek(Arq,0,0);
        strcpy(r.conta,conta);
               
        printf("Valor do Deposito: ");
        scanf("%f",&r.val);
        
        r.ope=CREDITO;
        r.cat=11;//codigo de deposito
        
        Data(r.dia,r.mes,r.ano);


            fwrite(&r,sizeof(TpBanco),1,Arq);                    

        printf("\n\nDeposito realizado com sucesso!!!");
        getch();
       }
    fclose(Arq);
}

void Trans(FILE *Arq)
{
    TpBanco r;
    char conta1[10],conta2[10];
    int pos;
    float valor;
    
    Arq=fopen("Banco.dat","ab+");
    
    clrscr();
    printf("*-*-*-*-*-TRANSFERENCIA-*-*-*-*-*");
    
    printf("\n\nDe (Conta): ");
    fflush(stdin);
    gets(conta1);
    
    pos=BuscaConta(Arq,conta1);
    
      if(pos!=-1)
      { 
         fseek(Arq,0,0);   
           
        printf("\nValor: ");
        scanf("%f",&valor);
        
        printf("\n\nPara (Conta): ");
        fflush(stdin);
        gets(conta2);
        
        pos=BuscaConta(Arq,conta2);
        
        if(pos!=-1)
        {
         fseek(Arq,0,0);  
            
         strcpy(r.conta,conta1);
         r.ope=CREDITO;
         r.cat=121;//saida de dinheiro por transferencia
         r.val=valor;
         Data(r.dia,r.mes,r.ano);
         fwrite(&r,sizeof(TpBanco),1,Arq);
         
         strcpy(r.conta,conta2);
         r.ope=CREDITO;
         r.cat=122;//entrada de dinheiro por transferencia
         r.val=valor;
         Data(r.dia,r.mes,r.ano);
         fwrite(&r,sizeof(TpBanco),1,Arq);
         printf("\n\nTransferencia realizada com sucesso!!!");
        }
        else
        printf("Conta de Destino Inexistente!!!");
       }
       else
       printf("Conta de Origem Inexistente!!!");
       
       getch();
       
    fclose(Arq);
}


void Saque(FILE *Arq)
{
    TpBanco r;
    char conta[10];
    long pos;
    
    Arq=fopen("Banco.dat","ab+");
    
    clrscr();
    printf("*-*-*-*-*-SAQUE-*-*-*-*-*");
    
    printf("\n\nConta: ");
    fflush(stdin);
    gets(conta);
    
    pos=BuscaConta(Arq,conta);
    
      if(pos!=-1)
      {
        fseek(Arq,0,0);  
        strcpy(r.conta,conta);
               
        printf("Valor do Saque: ");
        scanf("%f",&r.val);
        
        r.ope=DEBITO;
        r.cat=21;//codigo de saque
        
        Data(r.dia,r.mes,r.ano);
        fwrite(&r,sizeof(TpBanco),1,Arq);
        printf("\n\nSaque realizado com sucesso!!!");
        getch();
       }
    fclose(Arq);
}

void Cheque(FILE *Arq)
{
    TpBanco r;
    char conta[10];
    long pos;
    
    Arq=fopen("Banco.dat","ab+");
    
    clrscr();
    
    printf("*-*-*-*-*-CHEQUE-*-*-*-*-*");
    
    printf("\n\nConta: ");
    fflush(stdin);
    gets(conta);
    
    pos=BuscaConta(Arq,conta);
    
      if(pos!=-1)
      {
        fseek(Arq,0,0);      
        strcpy(r.conta,conta);
               
        printf("Valor do Cheque: ");
        scanf("%f",&r.val);
        
        r.ope=DEBITO;
        r.cat=22;//codigo de desconto de cheque!!
        
        Data(r.dia,r.mes,r.ano);
        fwrite(&r,sizeof(TpBanco),1,Arq);
        
        printf("\n\nOperacao realizada com sucesso!!!");
        getch();
       }
    fclose(Arq);
}

void Rel(FILE *Arq)
{
    TpBanco r;
   
    Arq=fopen("Banco.dat","rb+");
    
    fread(&r,sizeof(TpBanco),1,Arq);
    
    clrscr();
    printf("REALATORIO\n\n");
    printf("CONTA\tOPE\tCAT\tVALOR\t\t\tDIA\tMES\tANO\n");

    while(!feof(Arq))
    {
        printf("\n%s\t%d\t%d\t%.2f\t\t\t%d\t%d\t%d",r.conta,r.ope,r.cat,r.val,r.dia,r.mes,r.ano);

        fread(&r,sizeof(TpBanco),1,Arq);
    }
    fclose(Arq);

    getch();
}

float Saldo(FILE *Arq, char chave[10])
{
    TpBanco r;
    float saldo=0;
    
    Arq=fopen("Banco.dat","rb");
    
    clrscr();
    
    fread(&r,sizeof(TpBanco),1,Arq);
    
    while(!feof(Arq))
    {
        if(strcmp(r.conta,chave)==0)
        {
            switch(r.ope)
            {
                case 1:switch(r.cat);
                       {
                            case 11:saldo=saldo+r.val;break;//deposito
                            case 121:saldo=saldo-r.val;break;//trans Origem
                            case 122:saldo=saldo+r.val;break;//trans Destino
                        }
                case 2:switch(r.cat);
                       {
                            case 21:saldo=saldo-r.val;break;//saque
                            case 22:saldo=saldo-r.val;break;//cheque
                            case 23:;//d.automatico
                        }
            }
        }
        
        fread(&r,sizeof(TpBanco),1,Arq);
    }
     
   fclose(Arq); 
   
   return saldo;
}



int main()
{
    FILE *A;
    do
    {
     }while(Menu(A)!=1);
    return 1;
}
