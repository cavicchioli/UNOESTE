#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <conio2.h>
#include <stdlib.h>
#include <ctype.h>

struct TpJogo
{
    char palavra[20], dica[100];
    int ponto, nivel, status, ativo;
};

void desenha(int li,int ci,int lf,int cf)
{
    int c,l;
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
     
     gotoxy(40,14);printf("KUCAS");


   /*  // FORCA

        textcolor(6);
     for(l=10;l<26;l++){
     gotoxy(20,l);printf("%c",186);
     }
     
     
      for(c=15;c<26;c++){
            gotoxy(c,25);printf("%c",220);
        }
        
     
        
            for(c=20;c<33;c++){
            gotoxy(c,10);printf("%c",205);}
            
             for(l=11;l<12;l++){
               gotoxy(33,l);printf("%c",186);
              }
             gotoxy(33,10);printf("%c",187);
                gotoxy(20,10);printf("%c",201);
                gotoxy(20,25);printf("%c",219);
                
                ///////////////////////////////////////////////
                
                for(c=32;c<35;c++){
                     gotoxy(c,16);printf("_");}
                     
                     for(l=12;l<16;l++){
                     gotoxy(33,l);printf("|");}
                
                
                /////////////////////////////////corpo

                textcolor(14);
                textbackground(15);
                for(c=31;c<38;c++)
                  for(l=16;l<20;l++)
                  {
                        gotoxy(c,l);printf("%c",219);
                    }
                    textcolor(15);
                    gotoxy(33,19);printf("%c",254);     
                    gotoxy(35,19);printf("%c",254);
                    textcolor(0);  
                    gotoxy(34,18);printf("o");   
                     textbackground(0);
                        //short
                        textcolor(6);
                        
                        for(c=31;c<38;c++)
                           for(l=20;l<21;l++){
                               gotoxy(c,l);printf("%c",219);}
                               
                             //s
                                    for(c=31;c<33;c++)
                                      {
                                            gotoxy(c,21);
                                            printf("%c",219);
                                      }
                                      
                                      for(c=36;c<38;c++)
                                      {
                                            gotoxy(c,21);
                                            printf("%c",219);
                                      }
                                     //gravata
                                         textcolor(12);
                                         gotoxy(34,20);printf("%c",173);
                                   
                                       //cinto
                               textcolor(3);
                               for(c=31;c<38;c++){
                                 gotoxy(c,23);printf("=");}
                                 
                                 // perna
                                 
                                   textcolor(14);
                                         gotoxy(37,22);printf("%c",124);
                                         gotoxy(31,22);printf("%c",124);
                                             gotoxy(38,18);printf("%c",92);
                                              gotoxy(39,19);printf("%c",248);
                                        gotoxy(30,18);printf("%c",47);
                                        gotoxy(29,19);printf("%c",248);
                                        
                                        for(c=31;c<38;c++){
                                              textcolor(0);
                                             gotoxy(c,17);printf("%c",219);}
                                             
                                        
                                        
getch();*/
                                   
}




void menu_adm()
{}

void menu_usu()
{}


void menu(FILE *buf)
{
    int c,l,li=4,ci=4,lf=30,cf=70, a,b;
    desenha(li,ci,lf,cf);

 getch();
}


int main ()
{
    FILE *B;
    
    
    menu(B);
}
