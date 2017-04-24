#include<conio.h>
#include<stdio.h>
//#include<stdlib.h>
#include<conio2.h>
#include<time.h>

#define TMPMax 100

struct tptiro
{
    int col, lin, cor;
};

int main(void)
{
   char op;
   int i,tempo=0; 
   tptiro bicho;

    bicho.col= rand()%80+1;
    bicho.lin= rand()%25+1;
    bicho.cor= rand()%15+1;

   srand(time(0));
   do
   {
        _sleep(100);
        gotoxy(bicho.col, bicho.lin);  printf(" ");
        bicho.col= rand()%80+1;
        bicho.lin= rand()%25+1;
        bicho.cor= rand()%13+1; 
        
        gotoxy(bicho.col, bicho.lin);  
        textcolor(bicho.cor);
        printf("%c",2);
        
        gotoxy(1,1); 
        textcolor(15);
        printf(" Movimentações: %d",tempo); 

       // _sleep(1000);
        op=getch();
        if (op==-32)
            op=getch();
        if (op==32)
          for (i=bicho.col+1; i<80; i++)
          {
             gotoxy(i,bicho.lin);
             printf("*");
             _sleep(100);
             gotoxy(i,bicho.lin);
             printf(" ");
        }   
        
      
        tempo++;

   }while (op!=27 && tempo<=TMPMax);

    if (tempo>TMPMax)
    {
      gotoxy(40,12); textcolor(4);
      printf("Tempo esgotado!!");
      getch();
    }

   return 0;
}
