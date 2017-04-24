#include <conio2.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#define tf 100

struct cad
{
      int conta,contatrans[tf],contadep[tf],contsaque[tf];
      float saldo,valor[tf],dep[tf],vsaque[tf];
      
};

int trans(cad &c,int &tl)
{
    
    clrscr();
    printf("Digite o numero da conta para ser transferido ");
    scanf("%d", &c.contatrans[tl]);
    
    printf("Valor a ser transferido ");
    scanf("%f", &c.valor[tl]);
    
    tl++;
    
}

int deposito(cad &c,int &tl1)
{
    clrscr();
    printf("Numero de origem da conta para o deposito ");
    scanf("%d", &c.contadep[tl1]);
    
    printf("Valor do deposito ");
    scanf("%f", &c.dep[tl1]);
    
    tl1++;
    
}

int saque(cad &c,int &tl2)
{
    
    clrscr();
    printf("Data do dia de hoje do saque ");
    scanf("%d", &c.contsaque[tl2]);
    
    printf("Valor a ser transferido ");
    scanf("%f", &c.vsaque[tl2]);
    
    tl2++;
    
}    
    
int extrato(cad c,int tl,int tl1,int tl2)
{
    FILE * arq=fopen("relatorio.txt","wb+");
    fseek(arq,0,0);
     clrscr();
     int a=0,b=0,d=0;
     clrscr();
     printf("\n\n\n**************Transferencias******************");
      while(a<tl)
      {
                 
        printf("\n Conta %d   Valor Transferido - %.2f ",c.contatrans[a],c.valor[a]);
        c.saldo -=c.valor[a];
        a++;
      }
     printf("\n\n\n*****************Depositos******************");
     
     while(b<tl1) 
     {
                  printf("\n Conta %d   Valor depositado - %.2f ",c.contadep[b],c.dep[b]);
                  c.saldo+=c.dep[b];
                  b++;
     }
     
     printf("\n\n\n****************Saques**********************");
     while(d<tl2)
     {
                  printf("\nData do saque %d - Valor do Saque - %.2f",c.contsaque[d],c.vsaque[d]);
                  c.saldo-=c.vsaque[d];
                  d++;
     }                                                 
     printf("\n******************************************************************");             
     printf("\n\nConta %d   ",c.conta);
     printf("\nSaldo final = %.2f", c.saldo);
     fwrite(&c,sizeof(cad),1,arq);
     fclose(arq);
}    

void tela(cad &c)
{
     int op,tl=0,tl1=0,tl2=0;
     char tecla;
     
     
     do
     {
      clrscr();    
      printf(" 1 - Transferencias");
      printf("\n 2 - Depositos");
      printf("\n 3 - Saques");
      printf("\n 4 - Extrato");
     
      printf("\n\n\nOpcao desejada  ");
             
      scanf("%d",&op);

     
     
                     
      switch(op)
      {
               case 1:
                    clrscr();
                    trans(c,tl);
                    break;
               case 2:
                    deposito(c,tl1);
                    break;
               case 3:
                    saque(c,tl2);
                    break;
               case 4:
                    clrscr();
                    extrato(c,tl,tl1,tl2);
                    break;
               default:
                       printf("opcao invalida");
      }              
     
     printf("\n\n\n***** .... Pressione S para sair ... *****");
     fflush(stdin);
     scanf("%c", &tecla);
     }while(tecla!='S' || tecla != 's');
     
     getch();     
}


int main(void)
{
    
    cad c;
    int co,saldoini;
    
    clrscr();
    
    printf("Digite o numero da conta - ");
    scanf("%d", &co);
    
    c.conta=co;
    saldoini = 1000;
    c.saldo=saldoini;
    
    tela(c);
    getch();
}
     
