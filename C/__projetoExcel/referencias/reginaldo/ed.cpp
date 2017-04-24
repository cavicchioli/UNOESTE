#include <allegro.h>
#include <stdio.h>
#include <string.h>
#include <conio2.h>
#include <ctype.h>
#include <stdlib.h>
#include "pilhaF.h"
#include "pilhaC.h"

// protótipos
void inicia(void);
void finaliza(void);
void lestring(char string[50]);
int arquivo_existe(char nome[50]);
void nao_existe(void);
void retira_espacos(char texto[30]);
int verifica_funcao(char texto[30]);
void calcula_expressao (char texto[30], float valores[26]);
void atribui_valores (char texto[30], float valor[26]);
void executa(char nome_arq[50]);
void exibe(char texto[30], float valor[26], int y, BITMAP *buffer);
void exibenl(char texto[30], float valor[26], int y, BITMAP *buffer);
void erro(int linha);
void InicializaVetor(float valor[26]);

int main() 
{
    BITMAP *fundo, *buffer;
    SAMPLE *musica;
    char nome_arq[50];
    
    inicia();
	
	fundo = load_bitmap("principal.bmp", NULL);
    buffer = create_bitmap(800, 600);
    musica = load_sample("panamericano.wav");
	
	
	play_sample(musica, 50, 128, 1000, 1);
	show_mouse(screen);
	
	do
	{
        draw_sprite(buffer,fundo,0,0);
        
        if(key[KEY_ENTER])
        {
            lestring(nome_arq);
            clear_keybuf();
            if(arquivo_existe(nome_arq) == 1)
            {
                stop_sample(musica); 
                executa(nome_arq);    
                play_sample(musica, 50, 128, 1000, 1);     
            }
            else
            {
               stop_sample(musica); 
               nao_existe();
               play_sample(musica, 50, 128, 1000, 1);
            }
        }
        
      	draw_sprite(screen,buffer,0,0);
    	clear(buffer);
    	readkey();
    	
    }while(!key[KEY_ESC]);
	stop_sample(musica);
	clear(fundo);
	destroy_bitmap(buffer);
	destroy_sample(musica);
	destroy_bitmap(fundo);
	
	finaliza();
	
	return 0;
}
END_OF_MAIN();

void executa(char nome_arq[50])
{
    char texto[30];
    int x, linha=1, y = 20;
    float valor[26];
    FILE *arq;
    BITMAP *fundo, *buffer;
    char aux[2], abrir[8];
    
    InicializaVetor(valor);
    fundo = load_bitmap("tela_preta.bmp", NULL);
    buffer = create_bitmap(800,600);    
    arq = fopen(nome_arq,"r");
    
    do
    {
        fgets(texto, 30, arq);             
        retira_espacos(texto);
        x = verifica_funcao(texto);
        switch (x)
        {
           case 1:
             //   if(valida_expressao(texto, valor) == 1)
                   calcula_expressao(texto, valor);
              //  else
               //    printf("\nA expressao da linha %d esta incorreta !!", linha);
                break;
           case 2:
                atribui_valores(texto, valor);
                break;
           case 3:
                fundo = load_bitmap("tela_preta.bmp", NULL);
                y = 20;
                break;
           case 4:
	            exibe(texto, valor, y, fundo);
                break;
           case 5:
                y += 20;
                exibenl(texto, valor, y, fundo);
                break;
           case -1:
		   		readkey();
                erro(linha);
                break;
        }
        
        if(y > 570) // vai estourar a tela
        {
		 	 textout_centre_ex(fundo, font, "Pressione algo para continuar", 0, y+20, makecol(255,0,0), -1);
			 draw_sprite(screen,fundo,0,0);
			 readkey(); 
			 fundo = load_bitmap("tela_preta.bmp", NULL);
			 y = 20;	 
		}
        
        linha++;
        draw_sprite(buffer,fundo, 0, 0);
        draw_sprite(screen,buffer,0,0);
        clear(buffer);
    }while(!feof(arq));
    draw_sprite(screen,fundo, 0, 0);
    readkey();
    fclose(arq);  
    clear(fundo);
    destroy_bitmap(fundo);
    destroy_bitmap(buffer);
}

void InicializaVetor(float valor[26])
{
   int i;
   for(i=0;i<26;i++)
      valor[i] = 0;
}

void erro(int linha)
{
     BITMAP *fundo;
     SAMPLE *musica;
     
     fundo = load_bitmap("erro.bmp", NULL);
     musica = load_sample("chaves.wav");
     
     draw_sprite(screen,fundo,0,0);
     play_sample(musica, 255, 128, 1000, 0);
     
     textprintf_ex(screen,font, 650, 350, makecol(255,255,255), -1, "%d", linha);
     readkey();
     destroy_sample(musica);
     destroy_bitmap(fundo);
}

void exibe(char texto[30], float valor[26], int y, BITMAP *buffer) // COLOCAR AQUI OS SONS DE EXIBINDO
{
     SAMPLE *exibe, *letra;
     char aux[2], abrir[8];
    
	 strcpy(abrir,"");
     aux[0] = texto[6];
     aux[1] = '\0';
     strcat(abrir,aux);
     strcat(abrir,".wav");
     
     exibe = load_sample("exibindo.wav");
     play_sample(exibe, 255, 128, 1000, 0);
     readkey();
     letra = load_sample(abrir);
     play_sample(letra, 255, 128, 1000, 0);
     readkey();
  
     textprintf_ex(buffer, font, 50, y, makecol(0,0,255), -1,"%0.2f", valor[texto[6] - 65]);  
     destroy_sample(exibe); 
     destroy_sample(letra);
}

void exibenl(char texto[30], float valor[26], int y, BITMAP *buffer)
{
     SAMPLE *exibe, *letra;
     char aux[2], abrir[8];
     
     strcpy(abrir,"");
     aux[0] = texto[8];
     aux[1] = '\0';
     strcat(abrir,aux);
     strcat(abrir,".wav");
     
     exibe = load_sample("exibindo.wav");
     play_sample(exibe, 255, 128, 1000, 0);
     readkey();
     letra = load_sample(abrir);
     play_sample(letra, 255, 128, 1000, 0);
     readkey();
  
     textprintf_ex(buffer, font, 50, y, makecol(0,0,255), -1,"%0.2f", valor[texto[8] - 65]);  
     destroy_sample(exibe); 
     destroy_sample(letra);
}

void inicia(void)
{
	allegro_init();
	install_keyboard();
	install_timer();
	install_mouse();
	install_sound(DIGI_AUTODETECT, MIDI_AUTODETECT, NULL);
    set_uformat(U_ASCII); // acentuação
    set_volume(128, 255);
	
	set_color_depth(32);
	set_gfx_mode(GFX_AUTODETECT_FULLSCREEN, 800, 600, 0, 0);
}

void finaliza(void)
{
	clear_keybuf();
	remove_keyboard(); 
	remove_mouse(); 
	allegro_exit();
}

void nao_existe(void)
{
    BITMAP *fundo;
    SAMPLE *perdeu;
    
    fundo = load_bitmap("nao_existe.bmp", NULL);
    perdeu = load_sample("nao_existe.wav");
    
    draw_sprite(screen, fundo, 0, 0);
    play_sample(perdeu, 255, 128, 1000, 0);
    
    readkey();
    
    clear(fundo);
    destroy_bitmap(fundo);
    destroy_sample(perdeu);
}

void lestring(char string[50])
{ 
    BITMAP* buffer4, *fundo;
    int     i=0;

    install_keyboard();
    buffer4 = create_bitmap(800,600);
    fundo = load_bitmap("digite.bmp", NULL);
    strcpy(string,"  ");
    
    draw_sprite(screen, fundo, 0 ,0); 
    
    readkey();
    do 
    {  
            draw_sprite(buffer4, fundo, 0 ,0);       
            if(keypressed())
            {
                    int  newkey   = readkey(); //Cria o tipo newkey que retorna sempre um unico numero inteiro,que contem varias informacoes sobre a tecla pressionada
                    char ASCII    = newkey & 0xff; //declara a variavel ASCII que pega o codigo ASCII retornado pelo numero inteiro de NEWKEY
                    char scancode = newkey >> 8; //declara a variavel SCANCODE que pega o SCANCODE retornado pelo NEWKEY para verificar teclas pressionadas como no caso do BACKSPACE ABAIXO
             
                    if(ASCII >= 32 && ASCII <= 126)//verifica se a tecla ASCII eh entre 32 a 126
                    {
                            if(i < 100 - 1) //se o numero de caracteres for menor q 100
                            {
                                    string[i] = ASCII;//joga a letra correspondente da posicao asc2 na posicao i da string edittext
                                    i++;
                                    string[i] = '\0';//apos jogar a letra correspondente na posicao a frente coloca \0 para indicar fim da string
                            }
                    }
                    else 
                      if(scancode == KEY_BACKSPACE)//se o scancode for a tecla SPACE fecha a string com \0
                      {
                         if (i > 0) //se ja tiver algum caractere na string coloca \0 que seria o backspace
                           i--;
                           string[i] = '\0';
                      }
            }
      
                
                textprintf_ex(buffer4, font, 50, 150, makecol(255,255,255), makecol(0, 0, 0),string);//mostra a string a cada caractere pressionado
                draw_sprite(screen, buffer4 ,0 , 0);
                clear(buffer4);
                              
  }while(!key[KEY_ENTER]); 
 
  clear(fundo);
  clear(buffer4);
  destroy_bitmap(buffer4);
  destroy_bitmap(fundo);
}

void retira_espacos(char texto[30]) // ver se precisa colocar o '\0' no final
{
   int i, j;
   for(i=0;i<strlen(texto);i++)
      if(texto[i] == ' ')
          for(j=i;j<strlen(texto) - 1;j++)
             texto[j] = texto[j+1];
   i=strlen(texto)-1;
   while(texto[i] == '\n') // tira os pula linha
      i--;
   texto[i+1] = '\0';
}

int verifica_funcao(char texto[30])
{
   int i; 
   char aux[5];
   if(texto[0] >= 'A' && texto[0] <= 'Z' && texto[1] == '=') // é uma atribuição ou expressão
   {
       if((texto[2] >= 'A' && texto[2] <= 'Z') || texto[2] == '(')
         return 1; // expressao
       else
         return 2; // atribuição            
   }
   else if(strcmp(texto,"limpa") == 0)
       return 3; // limpa
   for(i=0;i<5;i++)
       aux[i] = texto[i];
   aux[5] = '\0';
   if(strcmp(aux,"exibe") == 0)
   {
       if(texto[5] == '(' && texto[6] >= 'A' && texto[6] <= 'Z' && texto[7] == ')')
          return 4; // exibe()
       else if (texto[5] == 'n' && texto[6] == 'l' && texto[7] == '(' && texto[8] >= 'A' && texto[8] <= 'Z' && texto[9] == ')')
          return 5; // exibenl()
       else if (texto[6] == 'n' && texto[5] == 'l' && texto[7] == '(' && texto[8] >= 'A' && texto[8] <= 'Z' && texto[9] == ')') 
          return 5; // exibeLN()
   }
   return -1;
}

void calcula_expressao (char texto[30], float valores[26])
{
    TpPilhaC saida, operador; // var é onde guarda os nomes das variaveis , A, B, C
    TpPilhaF polonesa;
    InicializaC(saida);
    InicializaC(operador);
    InicializaF(polonesa);
    int i;
    char aux, variavel;
    float aux1,aux2;
    for(i=0;i<strlen(texto);i++)
    {
            if(texto[i] != '/' && texto[i] != '*' && texto[i] != '+' && texto[i] != '-' && texto[i] != '=' && texto[i] != '(' && texto[i] != ')') // quer dizer que é operando
              EmpilhaC(saida, texto[i]);
            else
            {
                if (texto[i] == '*' || texto[i] == '/')
                {
				  aux = AcessaTopoC(operador);
				  while(aux == '*' || aux == '/')
				  {
   			         aux = DesempilhaC(operador);
   			         EmpilhaC(saida, aux);
   			         aux = AcessaTopoC(operador);
			      }

                  EmpilhaC(operador, texto[i]);
		        }
                else if (texto[i] == '(') // abre parentenses, pode empilhar
                  EmpilhaC(operador, texto[i]);
                else if (texto[i] == ')') // vamos desempilhar e empilhar até achar o abre
                {
                   aux = DesempilhaC(operador);
                   while(aux != '(')
                   {
                      EmpilhaC(saida,aux);
                      aux = DesempilhaC(operador);
                   }
                }
                else if (texto[i] == '+' || texto[i] == '-') // ver na pilha se tem maior que ele
                {
                   aux = AcessaTopoC(operador);
                   while(aux == '*' || aux == '/' || aux == '+' || aux == '-')
                   {
                      aux = DesempilhaC(operador);
                      EmpilhaC(saida, aux);
                      aux = AcessaTopoC(operador);
                   }
                   EmpilhaC(operador, texto[i]);
                }
                else if (texto[i] == '=')
                {
                   aux = AcessaTopoC(operador);
                   while(aux == '*' || aux == '/' || aux == '+' || aux == '-')
                   {
                      aux = DesempilhaC(operador);
                      EmpilhaC(saida, aux);
                      aux = AcessaTopoC(operador);
                   }
                   EmpilhaC(operador, texto[i]);
                }
            }
    }
    // depois que acabou o for, descarregar o resto da pilha operador
    while(!VaziaC(operador.Topo))
    {
      aux = DesempilhaC(operador);
      EmpilhaC(saida, aux);
    }
    //agora vamos empilhar tudo no operador para ficar na ordem certa
    while(!VaziaC(saida.Topo))
    {
       aux = DesempilhaC(saida);
       EmpilhaC(operador, aux);
    }

    // calcular a expressão pelo método polonesa, lembrando que a expressão está na pilha operador
    variavel = DesempilhaC(operador); // é a variavel que vai receber o resultado da expressão
    while(!VaziaC(operador.Topo))
    {
       aux = DesempilhaC(operador);
       if(aux == '+' || aux == '-' || aux == '*' || aux == '/' || aux == '=')
       {
          if(aux == '+')
             EmpilhaF(polonesa, DesempilhaF(polonesa) + DesempilhaF(polonesa));
          else if(aux == '-')
          {
             aux1 = DesempilhaF(polonesa);
             aux2 = DesempilhaF(polonesa);
             EmpilhaF(polonesa, aux2 - aux1);
          }
          else if(aux == '/')
          {
             aux1 = DesempilhaF(polonesa);
             aux2 = DesempilhaF(polonesa);
             EmpilhaF(polonesa, aux2 / aux1);
          }
          else if(aux == '*')
             EmpilhaF(polonesa, DesempilhaF(polonesa) * DesempilhaF(polonesa));
          else if(aux == '=')
          {
             i = variavel - 65; // pos do vetor
             valores[i] = DesempilhaF(polonesa);
          }
       }
       else // é uma letra, vamos empilhar o valor dela no polonesa
         EmpilhaF(polonesa, valores[aux-65]);

    }
    //ExibeC(operador);
}

void atribui_valores (char texto[30], float valor[26]) // passados por referencia 
{
     // pos 0 é a variavel e pos 1 é o sinal de =s
    int i,x=0;
    char aux[5];
    for(i=2;i<strlen(texto);i++)
        aux[x++] = texto[i];
    aux[x] = '\0';
    valor[texto[0] - 65] = atof(aux);
}


int arquivo_existe(char nome[50])
{
   if(fopen(nome,"r") != 0)
      return 1;
   else
      return 0;
}
