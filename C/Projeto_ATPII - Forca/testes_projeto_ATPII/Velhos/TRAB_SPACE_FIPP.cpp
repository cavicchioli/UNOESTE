#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <dos.h>
#include <time.h>
#include <conio2.h>

#define tf 100   
#define tf2 4


#define AMIGO 1   // Declaração de tipos para usos posterior, 
#define INIMIGO 2   //  facilitando a comparação dentro da struct.
#define OBSTACULO 3
#define VIDA 4
#define NAVE 5

            // Declaração das Structs usadas no JOGO !
struct vett                  
{
    int x,y;
    int tipo;
};
    
struct tptipo 
{
    int tiro,cor;
};


void final (int ci, int cf,int li, int lf);
void menu(void);
void regra(void);
int verifica (vett vet[tf], int x, int y, int tipo, int &posi,int tl);
 
 // -            -                -                          -                -
 
    //     Modulo utilizado para a construção da interface gráfica ( BOrdas do JOGO)

    
void construir(int ci,int cf,int li, int lf, int ci2, int cf2, int li2, int lf2)
{
    int c,l;
    textcolor(14);
    
    gotoxy(5,li-2);
    printf(" _ _ _ _  S  P  A  C  E  -  F  i  P  P  _ _ _ _");
     
    textcolor(9);
    for(l=li+1;l<lf;l++)
      {  gotoxy(ci,l);printf("%c",179);
         gotoxy(cf,l);printf("%c",179);
      }

     for(c=ci+1;c<cf;c++)
     {  gotoxy(c,li);printf("%c",45);
        gotoxy(c,lf);printf("%c",45);
     }
     gotoxy(ci,li);printf("%c",201);
     gotoxy(cf,li);printf("%c",187);
     gotoxy(ci,lf);printf("%c",200);
     gotoxy(cf,lf);printf("%c",188);
       
       // Tabela 2 //
    
        for(l=li2+1;l<lf2;l++)
     {  gotoxy(ci2,l);printf("%c",179);
        gotoxy(cf2,l);printf("%c",179);
     }
    for(c=ci2+1;c<cf2;c++)
     {  gotoxy(c,li2);printf("%c",45);
        gotoxy(c,lf2);printf("%c",45);
     }
     gotoxy(ci2,li2);printf("%c",201);
     gotoxy(cf2,li2);printf("%c",187);
     gotoxy(ci2,lf2);printf("%c",200);
     gotoxy(cf2,lf2);printf("%c",188);
 }

// 
                     // Este Modulo imprime e armazena os obstaculos Utilizado no JOGO
                     


void obstaculo2(vett v[tf], int ci,int cf, int li, int lf, int &tl)
{
    int i,o,h,j;
    textcolor(2);
    
    j=1;
    for(i=tl;i<5;i++)
    {
        v[i].x=10;
        v[i].y=j+6;
        v[i].tipo=OBSTACULO;
        gotoxy(v[i].x,v[i].y);
        printf("%c",5);
        tl++;
        j++;
    }
    
    j=1;
    for(i=tl;i<=9;i++)
    {
      v[i].x=45;
      v[i].y=j+23;
      v[i].tipo=OBSTACULO;
      gotoxy(v[i].x,v[i].y);
      printf("%c",5);
      tl++;
      j++;
    }
    
    j=1;
    for(i=tl;i<30;i++)
    {
      v[i].x=j+16;
      v[i].y=18;
      v[i].tipo=OBSTACULO;
      gotoxy(v[i].x,v[i].y);
      printf("%c",5);
      tl++;
      j++;
    }
    
      for(i=tl;i<50;i++)
    {
        o=rand()%((cf-1)-ci);
        h=rand()%((lf-1)-li);
        v[i].x=o+(ci+1);
        v[i].y=h+(li+1);
        v[i].tipo=OBSTACULO;
        gotoxy(v[i].x,v[i].y);
        printf("%c",5);
        
        tl++;
    }  
}

                  // Este Modulo imprime e armazena os AMigos Utilizado no JOGO

void amigos(vett v[tf], int ci,int cf, int li, int lf, int &tl)
{
    int i,o,h,am,pos;
    textcolor(13);
    
    am=tl;
      for(i=tl;i<60;i++)
    {
        do
        {     
        o=rand()%((cf-1)-ci);
        h=rand()%((lf-1)-li);
        }while(!verifica(v,o,h,OBSTACULO,pos,tl));
        v[i].x=o+(ci+1);
        v[i].y=h+(li+1);
        v[i].tipo=AMIGO;
        gotoxy(v[i].x,v[i].y);
        printf("%c",12);
        
        tl++;
    }
}
                   // Modulo que carrega e armazena os inimigos do jogo
                   
void inimigos(vett v[tf], int ci,int cf, int li, int lf, int &tl)
{
    int i,o,h,pos;
    textcolor(15);
      for(i=tl;i<65;i++)
    {
        do
        {     
        o=rand()%((cf-1)-ci);
        h=rand()%((lf-1)-li);
        }while(!verifica(v,o,h,OBSTACULO,pos,tl));
        v[i].x=o+(ci+1);
        v[i].y=h+(li+1);
        v[i].tipo=INIMIGO;
        gotoxy(v[i].x,v[i].y);
        printf("%c",15);

        tl++;
    }
}
  
  
                    // Este Modulo carrega os tipos de tiro e as cores dos mesmos
void tp_tipo(tptipo v[4],int &tp)
{
    
    v[1].tiro=42;v[1].cor=10;
    v[2].tiro=21;v[2].cor=11;
    v[3].tiro=177;v[3].cor=14;
    
    
}
                    // Este modulo é utilizado como apoio , pois ele verifica a existencia e a inexistencia 
                         // de obstaculos, amigos, inimigos ,etc. dentro da struct

int verifica (vett vet[tf], int x, int y, int tipo, int &posi,int tl)
{
    int achou=0,i,inicio,fim;
    posi=0;
    
if(tipo==1)
{
    inicio=50;
    fim=59;
}
if(tipo==2)
{
    inicio=60;
    fim=64;
}
if(tipo==3)
{
    inicio=0;
    fim=49;
}

if(tipo==4)
{
    inicio=66;
    fim=tl;
}

if(tipo==5)
{
    inicio=65;
    fim=65;
}
   

  for(i=inicio;i<=fim;i++)
  {
        if (vet[i].x==x && vet[i].y==y && vet[i].tipo==tipo)
         {
           achou=1;
           posi=i;
         }  

   }
   return achou;
}
                    

               // Este Modulo faz com que os inimigos atirem e tambem verifique
                  // se estes tiros esta atingindo um amigo , uma vida ou um Obstaculo. 
                 
void atira_bixo(int ci,int cf,int li,int lf,int c,int l,int dir,vett v[tf],int TL,int x, int y,int &vida)
{
    int bala=223,tl,tc,h,i,pos;
    tl=l;
    tc=c;
    textcolor(14);
    switch(dir)
           {
                case 72://cima
                 {
                    for(h=tl-1;h>(tl+8) && h<li;h--)//montar vetor ++y
                    { 
                      if(!verifica(v,c,h,OBSTACULO,pos,TL))
                      {
                       if(!verifica(v,c,h,INIMIGO,pos,TL))
                       {
                        if(!verifica(v,c,h,AMIGO,pos,TL))
                       {
                        if(verifica(v,c,h,NAVE,pos,TL))
                            vida--;    
                        gotoxy(c,h);
                        printf("%c",bala);
                        _sleep(2); ////======================
                        gotoxy(c,h);
                        printf(" ");
                        
                       }
                       }
                      }
                    }
                    
                   }
                    break;
                    
                case 80://baixo
                    {
                    for(h=tl+1;h<(tl+8) && h<lf;h++)
                    {
                      if(!verifica(v,c,h,OBSTACULO,pos,TL))
                      {
                       if(!verifica(v,c,h,INIMIGO,pos,TL))
                       {
                        if(!verifica(v,c,h,AMIGO,pos,TL))
                       {
                        if(verifica(v,c,h,NAVE,pos,TL))
                            vida--;     
                        gotoxy(c,h);
                        printf("%c",bala);
                         _sleep(2);
                        gotoxy(c,h);
                        printf(" ");
                        
                        
                      
                       }
                      
                       }
                  
                      }
                    }
                    }
                    break;
                    
                case 75://esquerda
                  {
                    for(i=tc-1;i>(tc+8)&& i>ci;i--)
                    {
                     if(!verifica(v,i,l,OBSTACULO,pos,TL))
                     {
                      if(!verifica(v,i,l,INIMIGO,pos,TL))
                     {
                      if(!verifica(v,i,l,AMIGO,pos,TL))
                      {
                       if(verifica(v,c,h,NAVE,pos,TL))
                            vida--;        
                      gotoxy(i,l);
                      printf("%c",bala);
                       _sleep(2);
                      gotoxy(i,l);
                      printf(" ");
                      
                      
                      
                    }
                    }
                    }
                    }
                    }
                    break;
                    
                case 77://direita
                    {
                    for(i=tc+1;i<(tc+8)&& i<cf;i++)
                    {
                     if(!verifica(v,i,l,OBSTACULO,pos,TL))
                     {
                      if(!verifica(v,i,l,INIMIGO,pos,TL))
                      {
                       if(!verifica(v,i,l,AMIGO,pos,TL))
                      {
                        if(verifica(v,c,h,NAVE,pos,TL))
                            vida--;
                       gotoxy(i,l);
                       printf("%c",bala);
                        _sleep(2);
                       gotoxy(i,l);
                       printf(" ");
                       
                        
                       
                       }
                     }
                     }
                    }
                    }
                    break;
            }
            
         
}

               // Este modulo faz com que o inimigo ande pelo jogo randomizadamente,
                 // verificando a existencia de obstaculos , amigos e vidas. 
               
void  anda_inimigo (vett v[tf],int ci, int cf, int li, int lf,int tl,int t, int o,int &vida)//====================
  {
    int i,vetdir[5],x,y,dir,pos,j,c,l;
    
    for (i=0;i<5;i++) 
        vetdir[i]=(rand()%3)+1;
     
         j=0;
   for (i=60;i<65;i++)
   {
    if(verifica(v,v[i].x,v[i].y,INIMIGO,pos,tl))
    {   
     textcolor(15);
     
      if (vetdir[j]==1)
      {
          if (v[i].y-1!=li && !verifica(v,v[i].x,v[i].y-1,OBSTACULO,pos,tl))     
          {
           if (v[i].y-1!=li && !verifica(v,v[i].x,v[i].y-1,AMIGO,pos,tl))     
           {
            if (v[i].y-1!=li && !verifica(v,v[i].x,v[i].y-1,VIDA,pos,tl))     
            { 
            dir=72;//cima
                 
            gotoxy(v[i].x,v[i].y);
            printf(" "); 
            v[i].y--;
            gotoxy(v[i].x,v[i].y);
            printf("%c", 15);
            if(t==v[i].x && o==v[i].y)
              vida--;
            atira_bixo(ci,cf,li,lf,v[i].x,v[i].y,dir,v,tl,t,o,vida);
          }
          }
          }
          else
          {
           gotoxy(v[i].x,v[i].y);
           printf(" ");
           v[i].y=lf-1;
         }
        
      }
      if (vetdir[j]==2)
      {
        if (v[i].x-1!=ci && !verifica(v,v[i].x-1,v[i].y,OBSTACULO,pos,tl))               
        {
         if (v[i].x-1!=ci && !verifica(v,v[i].x-1,v[i].y,AMIGO,pos,tl))               
         {
          if (v[i].x-1!=ci && !verifica(v,v[i].x-1,v[i].y,VIDA,pos,tl))               
          {
           dir=75;//esquerda
            
           gotoxy(v[i].x,v[i].y);
           printf(" ");            
           v[i].x--;
           gotoxy(v[i].x,v[i].y);
           printf("%c", 15);
            if(t==v[i].x && o==v[i].y)
              vida--;
           
           atira_bixo(ci,cf,li,lf,v[i].x,v[i].y,dir,v,tl,t,o,vida);
        }
        }
        }
        else
        {
           gotoxy(v[i].x,v[i].y);
           printf(" ");
           v[i].x=cf-1;
        }  
      }    
      if (vetdir[j]==3)
      {
         if (v[i].x+1!=cf && !verifica(v,v[i].x+1,v[i].y,OBSTACULO,pos,tl))      
         {
          if (v[i].x+1!=cf && !verifica(v,v[i].x+1,v[i].y,AMIGO,pos,tl))      
          {
           if (v[i].x+1!=cf && !verifica(v,v[i].x+1,v[i].y,VIDA,pos,tl))      
           { 
           dir=77;//direita
              
           gotoxy(v[i].x,v[i].y);
           printf(" ");            
           v[i].x++;
           gotoxy(v[i].x,v[i].y);
           printf("%c", 15);
            if(t==v[i].x && o==v[i].y)
              vida--;
           
           atira_bixo(ci,cf,li,lf,v[i].x,v[i].y,dir,v,tl,t,o,vida);
          }
         }
        }
         else
         {
           gotoxy(v[i].x,v[i].y);
           printf(" ");
         v[i].x=ci+1;
        }
         
      } 
      if (vetdir[j]==4 ) 
      {
        if (v[i].y+1!=lf && !verifica(v,v[i].x,v[i].y+1,OBSTACULO,pos,tl))               
        {
         if (v[i].y+1!=lf && !verifica(v,v[i].x,v[i].y+1,AMIGO,pos,tl))               
         {
          if (v[i].y+1!=lf && !verifica(v,v[i].x,v[i].y+1,VIDA,pos,tl))               
          { 
          dir=80;//baixo
         
         gotoxy(v[i].x,v[i].y);
         printf(" ");
         v[i].y++;
         gotoxy(v[i].x,v[i].y);
         printf("%c", 15);
          if(t==v[i].x && o==v[i].y)
              vida--;
         
         atira_bixo(ci,cf,li,lf,v[i].x,v[i].y,dir,v,tl,t,o,vida);
        }
        }
        }
        else
        {
           gotoxy(v[i].x,v[i].y);
           printf(" ");
         v[i].y=li+1;
       }
      }
       
      j++;
    }  
   } 
  }        
                      //  Este modulo faz a interação do usuário com a maquina, pois é aqui
                        //  que são executados os comandos utilizados para o movimento da nave.
  
int mover (vett v[tf], int ci,int cf, int li, int lf, int &x, int &y, char tc, int &p,int ci2,int lf2,int &amigo, int &ponto, int tl, int &vida,int &tp,tptipo ve[tf]) // MOVER * * * * * * * * * * * * * * * * *
{
    int pos,vet;
    
    textcolor(10);
    tc=getch();
    gotoxy(x,y);
    printf(" ");
    
    {
    
       switch(tc)
             {
                   case 80 : {  
                                  if(y!=lf-1)
                                  {
                                     if (!verifica(v,x,y+1,OBSTACULO,pos,tl))
                                       ++y;
                                     if (verifica(v,x,y,AMIGO,pos,tl))
                                       {
                                              // ++y;
                                             amigo++;
                                             ponto=ponto+100;
                                            
                                            gotoxy(v[pos].x,v[pos].y);
                                            printf(" ");  
                                             v[pos].tipo=0;
                                       }
                                       
                                     if (verifica(v,x,y+1,VIDA,pos,tl))
                                       {
                                             ++y;
                                             vida++;
                                             v[pos].tipo=0;
                                       }
                                       
                                     if (verifica(v,x,y+1,INIMIGO,pos,tl))
                                       {
                                             ++y;
                                             vida--;
                                             v[pos].tipo=0;
                                             
                                       }
                                   }
                                else
                                   y=li+1;
                                   p=31;
                               break;
                             }

                  case 72 : {
                                if(y!=li+1)
                                {
                                  if (!verifica(v,x,y-1,OBSTACULO,pos,tl))
                                   --y;
                                  if (verifica(v,x,y,AMIGO,pos,tl))
                                  {
                                    --y;
                                    amigo++;
                                    ponto=ponto+100;
                                    
                                    gotoxy(v[pos].x,v[pos].y);
                                    printf(" ");
                                    v[pos].tipo=0;
                                  }
                                  if (verifica(v,x,y-1,VIDA,pos,tl))
                                  {
                                    --y;
                                    vida++;
                                    v[pos].tipo=0;
                                  }
                                  
                                  if (verifica(v,x,y-1,INIMIGO,pos,tl))
                                  {
                                    --y;
                                    vida--;
                                    v[pos].tipo=0;
                                    
                                  }
                                 }
                                else
                                   y=lf-1;
                                p=30;
                                break;}

                    case 75 : { if(x!=ci+1)
                                {
                                 if (!verifica(v,x-1,y,OBSTACULO,pos,tl))
                                    --x;
                                 if (verifica(v,x,y,AMIGO,pos,tl))
                                  {
                                    --x;
                                    amigo++;
                                    ponto=ponto+100;
                                    gotoxy(v[pos].x,v[pos].y);
                                    printf(" ");
                                    v[pos].tipo=0;
                                  }
                                  if (verifica(v,x-1,y,VIDA,pos,tl))
                                  {
                                    --x;
                                    vida++;
                                    v[pos].tipo=0;
                                  }
                                  if (verifica(v,x-1,y,INIMIGO,pos,tl))
                                  {
                                    --x;
                                    vida--;
                                    v[pos].tipo=0;
                                    
                                  }
                                }
                                else
                                    x=cf-1;
                                p=17;
                                break;}

                    case 77 : { if(x!=cf-1)
                                {
                                 if (!verifica(v,x+1,y,OBSTACULO,pos,tl))
                                    ++x;
                                 if (verifica(v,x,y,AMIGO,pos,tl))
                                  {
                                    ++x;
                                    amigo++;
                                    ponto=ponto+100;
                                    gotoxy(v[pos].x,v[pos].y);
                                    printf(" ");
                                    v[pos].tipo=0;
                                  }
                                  if (verifica(v,x+1,y,VIDA,pos,tl))
                                  {
                                    ++x;
                                    vida++;
                                    v[pos].tipo=0;
                                  }
                                  
                                  if (verifica(v,x+1,y,INIMIGO,pos,tl))
                                  {
                                    ++x;
                                    vida--;
                                    v[pos].tipo=0;
                                    
                                  }
                                } 
                                else
                                   x=ci+1;
                                p=16;}
                                break;
                                
                case 59 :  tp_tipo(ve,tp);
                           if(tp<3)
                             tp++;
                           else
                             tp=1;
                        
                            break;
            }
           gotoxy(x,y);
           printf("%c",p);
           v[65].x=x;
           v[65].y=y;
           v[65].tipo=NAVE;
           
           gotoxy(ci2+1,lf2+3);
           printf("%d,%d",x,y);
    }
   
}
                      // Modulo que faz com que o usuario atire nos inimigos
                      
int  tiro (tptipo vet[4],int ci,int cf,int li,int lf,int x,int y,char tecla,int p,int tl,vett v[tf],int tp,int &ponto)    
{
    int l,c,pos,a,cor;
    c=x;
    l=y;
    
    
      textcolor(vet[tp].cor);
                switch(p)
                  {
                    case 31: {  a=l+1;
                                while(a<lf-1)
                                {
                                     if(!verifica(v,c,a+1,OBSTACULO,pos,tl) && !verifica(v,c,a+1,AMIGO,pos,tl))
                                     {
                                            if(verifica(v,c,a+1,INIMIGO,pos,tl) ) 
                                         {
                                              v[pos].tipo=0;
                                              ponto=ponto+50;
                                         }
                                        
                                             gotoxy(c,a+1);
                                             printf("%c",vet[tp].tiro);
                                             _sleep(4);
                                             gotoxy(c,a+1);
                                             printf(" ");
                                             a++;
                                            
                                        
                                     }
                                    else
                                      a=lf-1;
                                }
                                
                                 break;
                                }

                    case 30:{   a=l-1;

                                 while(a>li+1)
                                  {
                                      if(!verifica(v,c,a-1,OBSTACULO,pos,tl) && !verifica(v,c,a-1,AMIGO,pos,tl))
                                      {
                                            if(verifica(v,c,a-1,INIMIGO,pos,tl))  
                                            {
                                             v[pos].tipo=0;
                                             ponto=ponto+50;
                                            }
                                            
                                            gotoxy(c,a-1);
                                            printf("%c",vet[tp].tiro);
                                            _sleep(4);
                                            gotoxy(c,a-1);
                                            printf(" ");
                                            
                                            a--;
                                       }
                                      else
                                        a=li+1;
                                   }
                                
                                break;
                              }
                              
                    case 17:  { a=c-1;
   
                                   while(a>ci+1)
                                     {
                                       if(!verifica(v,a-1,l,OBSTACULO,pos,tl) && !verifica(v,a-1,l,AMIGO,pos,tl))
                                       {
                                           if(verifica(v,a-1,l,INIMIGO,pos,tl))
                                          {
                                            v[pos].tipo=0;   
                                            ponto=ponto+50;
                                          }
                                           
                                            gotoxy(a-1,l);
                                            printf("%c",vet[tp].tiro);
                                            _sleep(4);
                                            gotoxy(a-1,l);
                                            printf(" ");
                                            
                                            
                                            a--;
                                          
                                            
                                         
                                        }
                                        else
                                          a=ci+1;
                                    }
                                    gotoxy(c-1,l);
                                    printf(" ");
                                       
                                    break;
                             }

                    case 16:  { a=c+1;
                                   while(a<cf-1)
                                     {
                                             if(!verifica(v,a+1,l,OBSTACULO,pos,tl)&& !verifica(v,c+1,l,AMIGO,pos,tl))
                                             {
                                                    if(verifica(v,a+1,l,INIMIGO,pos,tl))
                                                {
                                                 v[pos].tipo=0;
                                                 ponto=ponto+50;
                                                 }
                                                 
                                                    gotoxy(a+1,l);
                                                    printf("%c",vet[tp].tiro);
                                                    _sleep(4);
                                                    gotoxy(a+1,l);
                                                    printf(" ");
                                                    a++;
                                                    
                                                
                                                    a++;
                                            }
                                            else
                                             a=cf-1;
                                    }
                 
                                break;
                              }
                    }
                
   
} 
                               // GAME OVER do jogo
                               
void final (int ci, int cf,int li, int lf,int amigo)
{
    int a,b,l,c;
    
    a=(cf-ci)/2;
    b=(lf-li)/2;

    for(c=0;c<80;c++)
     for(l=li;l<lf+1;l++){
        textbackground(0);
        gotoxy(c,l);
        printf(" ");
        }
       
    textcolor(5);
   if(amigo==9)
   {
gotoxy(1,8);
printf("'##:::'##::'#######::'##::::'##::::'##:::::'##:'####:'##::: ##::::'####:'####:\n");
gotoxy(1,9);
printf(". ##:'##::'##.... ##: ##:::: ##:::: ##:'##: ##:. ##:: ###:: ##:::: ####: ####:\n");
gotoxy(1,10);
printf(":. ####::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ####: ##:::: ####: ####:\n");
gotoxy(1,11);
printf("::. ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ## ## ##::::: ##::: ##::\n");
gotoxy(1,12);
printf("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##. ####:::::..::::..:::\n");
gotoxy(1,13);
printf("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##:. ###::::'####:'####:\n");
gotoxy(1,14);
printf("::: ##::::. #######::. #######:::::. ###. ###::'####: ##::. ##:::: ####: ####:\n");
gotoxy(1,15);
printf(":::..::::::.......::::.......:::::::...::...:::....::..::::..:::::....::....::\n");

   _sleep(5000);}
   else
    {
gotoxy(14,4);
printf(":'######:::::::::'###:::::::'##::::'##::::'########:\n");
gotoxy(14,5);
printf("'##... ##:::::::'## ##:::::: ###::'###:::: ##.....::\n");
gotoxy(14,6);
printf(" ##:::..:::::::'##:. ##::::: ####'####:::: ##:::::::\n");
gotoxy(14,7);
printf(" ##::'####::::'##:::. ##:::: ## ### ##:::: ######:::\n");
gotoxy(14,8);
printf(" ##::: ##::::: #########:::: ##. #: ##:::: ##...::::\n");
gotoxy(14,9);
printf(" ##::: ##::::: ##.... ##:::: ##:.:: ##:::: ##:::::::\n");
gotoxy(14,10);
printf(". ######:::::: ##:::: ##:::: ##:::: ##:::: ########:\n");
gotoxy(14,11);
printf(":......:::::::..:::::..:::::..:::::..:::::........::\n");
gotoxy(14,12);
printf("                                                    \n");
gotoxy(14,13);
printf(":'#######:::::'##::::'##::::'########::::'########::\n");
gotoxy(14,14);
printf("'##.... ##:::: ##:::: ##:::: ##.....::::: ##.... ##:\n");
gotoxy(14,15);
printf(" ##:::: ##:::: ##:::: ##:::: ##:::::::::: ##:::: ##:\n");
gotoxy(14,16);
printf(" ##:::: ##:::: ##:::: ##:::: ######:::::: ########::\n");
gotoxy(14,17);
printf(" ##:::: ##::::. ##:: ##::::: ##...::::::: ##.. ##:::\n");
gotoxy(14,18);
printf(" ##:::: ##:::::. ## ##:::::: ##:::::::::: ##::. ##::\n");
gotoxy(14,19);
printf(". #######:::::::. ###::::::: ########:::: ##:::. ##:\n");
gotoxy(14,20);
printf(":.......:::::::::...::::::::........:::::..:::::..::\n");

_sleep(7000);
}
    
    
}

  void fim (int ci, int cf,int li,int lf)
 {
        int a, b;

        a=(cf-ci)/2;
          b=(lf-li)/2;

      
       textcolor(15);
gotoxy(10,2);        
printf("'########::'##:::::::'###::::'##::::'##::::'##:\n");
gotoxy(10,3);
printf(" ##.... ##:. ##:::::'## ##:::. ##::: ###::'###:\n");
gotoxy(10,4);
printf(" ##:::: ##::. ##:::'##:. ##:::. ##:: ####'####:\n");
gotoxy(10,5);
printf(" ########::::. ##:'##:::. ##:::. ##: ## ### ##:\n");
gotoxy(10,6);
printf(" ##.....::::: ##:: #########::: ##:: ##. #: ##:\n");
gotoxy(10,7);
printf(" ##::::::::: ##::: ##.... ##:: ##::: ##:.:: ##:\n");
gotoxy(10,8);
printf(" ##:::::::: ##:::: ##:::: ##: ##:::: ##:::: ##:\n");
gotoxy(10,9);
printf("..:::::::::..:::::..:::::..::..:::::..:::::..::\n");
  
         _sleep(1000);
       gotoxy(a,b+2);
         textcolor(2);
            printf("_____________________________");
       gotoxy(a,b+4);
          textcolor(14);
             printf(" VICTOR PRADO ");
                _sleep(900);
        gotoxy(a+14,b+4);
           textcolor(3);
              printf(" LUCAS FONSECA ");
                _sleep(5000);
    }

                  // Este modulo é o responsavel pela a execução do programa em geral,
                    // pois é aqui que são chamadas as funções premordiais 
void executa ()
{
    
    int li=5,lf=30,ci=5,cf=50,migo=0,pont=0,num=150,vid=5;
    int ci2=52,cf2=60,li2=5,lf2=30,o,h,tl=0,c=54,pos;
    char tecla,jogador[20];
    int x,y,p=0,v=0,tp=1,cc,ll,fim,tot=0;
           
            x=(cf+ci)/2;
            y=(lf+li)/2;
     
    vett vet[tf];
    tptipo ve[tf2];
    
    textcolor(15);
    printf("\nDIGITE O NOME: ");
    gets(jogador);
    clrscr();
     
            
    construir(ci,cf,li,lf,ci2,cf2,li2,lf2);
    obstaculo2(vet,ci,cf,li,lf,tl);
    amigos(vet,ci,cf,li,lf,tl);
    inimigos(vet,ci,cf,li,lf,tl);
   
    
    
     do
      {
         textcolor(15);//mostrar pontos
         gotoxy(ci2+1,li+6);printf("SCORE");
         gotoxy(ci2+3,li+7);printf("%d",pont);
    
         textcolor(13);//mostrar amigo
         gotoxy(ci2+1,li+4);printf("%c",12);
         textcolor(15);
         gotoxy(ci2+2,li+4);printf("  %d",migo);
    
         textcolor(12);//mostrar a vida
         gotoxy(ci2+1,li+12);printf("%c",3);
         textcolor(15);
         gotoxy(ci2+3,li+12);printf("%d",vid);
         
         
         gotoxy(ci2+2,li+9);//mostrar o tipo do tiro no canto superior
         textcolor(ve[tp].cor);
         printf(" %c",ve[tp].tiro);
         //tempo();
         
           textcolor(15);
           gotoxy(ci+1,lf+2);
           printf("Jogador: ");
           puts(jogador);
      
    
    
         if(pont>num)//vida
          {
           do
           {     
           o=rand()%((cf-1)-ci);
           h=rand()%((lf-1)-li);
           }while(!verifica(vet,o,h,OBSTACULO,pos,tl));
           vet[tl].x=o+(ci+1);
           vet[tl].y=h+(li+1);
           vet[tl].tipo=VIDA;
           gotoxy(vet[tl].x,vet[tl].y);
           textcolor(12);
           printf("%c",3);
           num=num+400;
           tl++;
          }
         
          anda_inimigo(vet,ci,cf,li,lf,tl,x,y,vid);
          _sleep(80);    
          
        
        if(kbhit())
        {      
           tecla=getch();
        
          if(tecla==-32||tecla==0)
          {
            
              mover(vet,ci,cf,li,lf,x,y,tecla,p,ci2,lf2,migo,pont,tl,vid,tp,ve);
             
          }      
          else
          if(tecla==32)
              tiro(ve,ci,cf,li,lf,x,y,tecla,p,tl,vet,tp,pont);
       }      
      
      if(vid==0 || migo==9 || pont>1000)
         tot=1;
    
    
    
    } while(tot!=1 && tecla!=27);
          
          
        _sleep(10);
          for(cc=0;cc<80;cc++)
           for(ll=li;ll<lf+1;ll++){
            textbackground(0);
             gotoxy(cc,ll);
             printf(" "); }
             
     final(ci,cf,li,lf,migo);
     clrscr();
     menu();
   
   
};



void menu(void)
  {
     int c,l,x,y,i,a,b,v[tf2],t=1;
     int ci3=2, cf3=40, li3=2, lf3=20;
     char tecla;
    
     textcolor(9);
     for(c=ci3+1;c<cf3;c++)
     {  gotoxy(c,li3);printf("%c",45);
        gotoxy(c,lf3);printf("%c",45);
     }

       for(l=li3+1;l<lf3;l++)
     {  gotoxy(ci3,l);printf("%c",179);
        gotoxy(cf3,l);printf("%c",179);
     }

     gotoxy(ci3,li3);printf("%c",201);
     gotoxy(cf3,li3);printf("%c",187);
     gotoxy(ci3,lf3);printf("%c",200);
     gotoxy(cf3,lf3);printf("%c",188);

     
     textcolor(14);
     gotoxy(ci3+1,li3+1);
     printf(" \t  S P A C E  -  F i P P  ");
     gotoxy(ci3+3,li3+3);
     printf(" ________________________");
      
     for(i=2;i<35;i++)
     {
      gotoxy(ci3+i,li3+3);
      printf(" ");
      _sleep(20);
      a=(ci3+i)-1;
      b=(li3+3)-1;
      gotoxy(a,b);
      printf("_");
      _sleep(20);
      }
      
      v[1]=li3+5;
      v[2]=li3+8;
      v[3]=li3+11;
      
      
      
      gotoxy(ci3+3,li3+5);
      printf(" JOGAR  ");
      gotoxy(ci3+3,li3+8);
      printf(" REGRAS do JOGO  ");
      gotoxy(ci3+3,li3+11);
      printf(" SAIR  ");
     
     gotoxy(ci3+26,v[t]);
     textcolor(12);
     printf("<");
      
      do{  
         tecla=getch();
          if(tecla==-32||tecla==0)
          {
            tecla=getch();
             
            gotoxy(ci3+26,v[t]);
            printf("  ");
      
            switch(tecla)
            {
             case 80: {  
                        t++;
                        if(t==4)
                          t=3;}
                        break;
                
             case 72:{   
                        t--;
                        if(t==0)
                          t=1;}
                        break;
             
            } 
                    
                    
                        gotoxy(ci3+26,v[t]);
                        textcolor(12);
                        printf("<");
                    
           }
            
    }while(tecla!=13);
    
    printf("\a");
    clrscr();
    
    if(t==1)
      executa();
    
    else
      if(t==2)
        regra();
      if(t==3);
      //ranking();  
      if(t==4);
         fim(ci3,cf3,li3,lf3);
}

void regra(void)
{
    int ci3=2, cf3=44, li3=2, lf3=20;
    int i,c,l,tecla,a,b,cc,ll;

    textcolor(9);
     for(c=ci3+1;c<cf3;c++)
     {  gotoxy(c,li3);printf("%c",45);
        gotoxy(c,lf3);printf("%c",45);
     }

       for(l=li3+1;l<lf3;l++)
     {  gotoxy(ci3,l);printf("%c",179);
        gotoxy(cf3,l);printf("%c",179);
     }

     gotoxy(ci3,li3);printf("%c",201);
     gotoxy(cf3,li3);printf("%c",187);
     gotoxy(ci3,lf3);printf("%c",200);
     gotoxy(cf3,lf3);printf("%c",188);


     textcolor(14);
     gotoxy(ci3+1,li3+1);
     printf(" \REGRAS DO JOGO  ");
      gotoxy(ci3+3,li3+3);
      printf(" ________________________");

     for(i=2;i<35;i++){
      gotoxy(ci3+i,li3+3);
      printf(" ");
      _sleep(40);
      a=(ci3+i)-1;
      b=(li3+3)-1;
      gotoxy(a,b);
       printf("_");
       _sleep(20);

      }

      do{
          gotoxy(ci3+2,li3+5);
          printf("Mate os seus Inimigos ");textcolor(15);printf("%c",15);textcolor(14);printf(" e capture");
          gotoxy(ci3+2,li3+6);
          printf("a Muierada ");textcolor(13);printf("%c ",12);textcolor(14);printf("tenha cuidado com os");
          gotoxy(ci3+2,li3+7);
          printf("tiros dos viloes eles pondem matar.");
          gotoxy(ci3+2,li3+8);
          printf("Use as teclas cima,baixo,esquerda");
          gotoxy(ci3+2,li3+9);
          printf("e direita para andar e o espaco para");
          gotoxy(ci3+2,li3+10);
          printf("dar um tiro. Voce pode Escolher o ");
          gotoxy(ci3+2,li3+11);
          printf("tipo de tiro apertando a tecla");textcolor(15);printf(" F1");textcolor(14);printf(" e");
          gotoxy(ci3+2,li3+12);
          printf("utilizar os Obstaculos ");textcolor(2);printf("%c",5);textcolor(14);printf(",com escudos,");
          gotoxy(ci3+2,li3+13);
          printf("para isso e so encostar neles.");
          gotoxy(ci3+2,li3+14);
          printf("Passe por cima das vidas ");textcolor(12);printf("%c",3);textcolor(14);printf(" para");
          gotoxy(ci3+2,li3+15);
          printf("pega-las.");


         tecla=getch();

      }while(tecla!=27);
      clrscr();
      menu();
}

void load(void)
{
    int i;
    
 gotoxy(20,2);                                     
 textcolor(14);printf(" ## ##   #   ## ###     ");printf("### ### ##  ##  \n");
 gotoxy(20,3);    
 textcolor(14);printf("#   # # # # #   #       ");printf("#    #  # # # # \n");
 gotoxy(20,4);    
 textcolor(14);printf(" #  ##  ### #   ##      ");printf("##   #  ##  ##  \n");
 gotoxy(20,5);    
 textcolor(14);printf("  # #   # # #   #       ");printf("#    #  #   #   \n");
 gotoxy(20,6);   
 textcolor(14);printf("##  #   # #  ## ###     ");printf("#   ### #   #   \n");
 gotoxy(20,7);
 printf("                                        \n");
 gotoxy(20,8);                
 textcolor(2);printf("     # # ###  #  ###  ## ### ### \n");
 gotoxy(20,9);
 textcolor(2);printf("     # # # # # # #   #    #  #   \n");
 gotoxy(20,10);
 textcolor(2);printf("     # # # # # # ##   #   #  ##  \n");
 gotoxy(20,11);
 textcolor(2);printf("     # # # # # # #     #  #  #   \n");
 gotoxy(20,12);
 textcolor(2);printf("     ### # #  #  ### ##   #  ### \n");
    
    
    for(i=26;i<47;i++)
    {
        gotoxy(i+2,16);
        textcolor(9);
        printf("%c",219);
        
        textcolor(10);
        gotoxy(32,18);
        switch(i-25)
        {

            case 1:printf("L");break;
            case 2:printf("LO");break;
            case 3:printf("LOA");break;
            case 4:printf("LOAD");break;
            case 5:printf("LOADIN");break;
            case 6:printf("LOADING");break;
            case 7:printf("LOADING.");break;
            case 8:printf("LOADING..");break;
            case 9:printf("LOADING...");break;
            case 10:printf("LOADING....");break;
            case 11:printf("LOADING.....");break;
            case 12:printf("LOADING......");break;
            case 13:printf("LOADING.......");
        
        }
        _sleep(80);
    }
    gotoxy(28,24);
    textcolor(7);
    printf("PRECIONE UMA TECLA!!!\a");
    getch();
}

                              // Modulo Principal 

int main (void)
{
    
    load();
    clrscr();
    menu();
  
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














