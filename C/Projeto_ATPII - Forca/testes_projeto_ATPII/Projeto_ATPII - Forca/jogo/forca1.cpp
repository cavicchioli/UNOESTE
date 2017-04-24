#include <stdio.h>
#include <conio2.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <dos.h>

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


void desenha(int li,int ci,int lf,int cf) //Desenha Quadro
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
void forca (void)
{
    int c,l;
       
        // FORCA (madeira)
     textcolor(6);
     
     for(l=10;l<26;l++){
         gotoxy(20,l);printf("%c",186);}

     for(c=15;c<26;c++){
         gotoxy(c,25);printf("%c",220);}

     for(c=20;c<33;c++){
         gotoxy(c,10);printf("%c",205);}
         
     for(l=11;l<12;l++){
        gotoxy(33,l);printf("%c",186);}
             
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
                  for(l=16;l<20;l++){
                        gotoxy(c,l);printf("%c",219);}
                    
                    
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
                                    for(c=31;c<33;c++){
                                            gotoxy(c,21);printf("%c",219);}
                                      
                                      for(c=36;c<38;c++){
                                            gotoxy(c,21);printf("%c",219);}

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

                                        textcolor(0);
                                        for(c=31;c<38;c++){
                                             gotoxy(c,17);printf("%c",219);}
getch();
}

void menu(int li, int ci, int lf, int cf)
{
    int c, l;
    
    l=(li+lf)/2;
    c=(ci+cf)/2;
    textcolor(14);
    gotoxy(25,8);
    printf(" < < < BOB - FORCA < < < ");
    MiniForca();
    textcolor(15);
    gotoxy(27,24);printf("______");
      gotoxy(35,24);printf("______");
        gotoxy(43,24);printf("______");
             gotoxy(27,23);printf("JOGAR");
             gotoxy(35,23);printf("REGRAS");
             gotoxy(43,23);printf("CADASTRO");
             
getch();

}


void menu2()
{
    int a=0 , v[3];
    char tecla;
    
    v[1]=27;
    v[2]=35;
    v[3]=43;
    
    do{
         
           tecla=getch();
            textcolor(0);
             gotoxy(v[a],24);printf("______");
           if(tecla==-32||tecla==0)
           {
                tecla=getch();
                 switch(tecla)
                {
                         case 75: { a--;
                                    if(a==0)
                                        a=1;
                                  }
                                    break;
                   
                         case 77: { a++;
                                    if(a==4)
                                       a=3;
                                  }
                                   break;  
                }
                     textcolor(14);
                     gotoxy(v[a],24);printf("______");
            }            
    }while(tecla!=13);
}          

int main(void)
{
    int c,l,li=4,ci=4,lf=30,cf=70, a,b;
    
    desenha(li,ci,lf,cf);
    menu(li,ci,lf,cf);
    menu2();
    //forca();
}
