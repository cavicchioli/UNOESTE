#include <stdio.h>
#include <string.h>
#include <conio2.h>
#include <ctype.h>
#include <stdlib.h>
#include "pilhaF.h"
#include "pilhaS.h"

void calcula_expressao (char texto[30], float valores[26])
{
    TpPilhaC operador,saida; // var é onde guarda os nomes das variaveis , A, B, C
    TpPilhaF valor;
    InicializaC(operador);
    InicializaC(saida);
    InicializaF(valor);
    int i,tl=0;
    char aux, variavel,aux_calculo[30];
    float aux1,aux2,aux3;
 
    //processo de separar a expressao
    for(i=0;i<strlen(texto);i++)
    {
            if(texto[i] != '/' && texto[i] != '*' && texto[i] != '+' && texto[i] != '-' && texto[i] != '=' && texto[i] != '(' && texto[i] != ')' || texto[i]=='.' || texto[i] == ',') // quer dizer que é operando
            {
              aux_calculo[tl++]=texto[i];  
             }
            else
            {
                if(tl>0)
                {
                    aux_calculo[tl++]='\0';
                    EmpilhaC(saida,aux_calculo);
                    strcpy(aux_calculo,"");
                    tl=0;
                }
                
                
                
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
            printf("\nAQUI EH OPERADOR==============> ");
            ExibeC(operador);
            printf("\nAQUI EH SAIDA=================> ");
            ExibeC(saida);
    }
    getch();
    // depois que acabou o for, descarregar o resto da pilha operador
    while(!VaziaC(operador.Topo))
    {
      aux = DesempilhaC(operador);
      EmpilhaC(saida, aux);
    }
    printf("\nAQUI DESEMPILHOU DO OPERADOR.... ");
    ExibeC(operador);
    printf("\nAQUI EMPILHOU NA SAIDA.... ");
    ExibeC(saida);
    getch();
    //agora vamos empilhar tudo no operador para ficar na ordem certa
    while(!VaziaC(saida.Topo))
    {
       aux = DesempilhaC(saida);
       EmpilhaC(operador, aux);
    }
    printf("\nAQUI DESEMPILHOU NA SAIDA.... (PARA COLOKAR NA ORDEM) ");
    ExibeC(saida);
    printf("\nAQUI EMPILHOU DO OPERADOR....(PARA ORDEM) ");
    ExibeC(operador);
    getch();

    // calcular a expressão pelo método polonesa, lembrando que a expressão está na pilha operador
    //variavel = DesempilhaC(operador);
     // é a variavel que vai receber o resultado da expressão
    
    printf("\nAQUI IMPRIMI O VALOR DA VARIAVEL %c --------",variavel);
    getch();
    
    while(!VaziaC(operador.Topo))
    {
        printf("\nAQUI EMPILHOU DO OPERADOR....(PARA CALCULAR) ");
        ExibeC(operador);
        printf("\nAQUI MOSTRA OQUE TEM NA POLONESA   ");
        ExibeF(valor);
        
       aux = DesempilhaC(operador);
       
       printf("\nOLHA OQUE O AUX RECEBEU ==> %c ",aux);
       
       if(aux == '+' || aux == '-' || aux == '*' || aux == '/' || aux == '=')
       {
          if(aux == '+')
             EmpilhaF(valor, DesempilhaF(valor) + DesempilhaF(valor));
          else if(aux == '-')
          {
             aux1 = DesempilhaF(valor);
             aux2 = DesempilhaF(valor);
             EmpilhaF(valor, aux2 - aux1);
          }
          else if(aux == '/')
          {
             aux1 = DesempilhaF(valor);
             aux2 = DesempilhaF(valor);
             EmpilhaF(valor, aux2 / aux1);
          }
          else if(aux == '*')
             EmpilhaF(valor, DesempilhaF(valor) * DesempilhaF(valor));
             
          /*
          else if(aux == '=')
          {
             i = variavel - 65; // pos do vetor
             valores[i] = DesempilhaF(valor);
          }*/
       }
       else
       {
            EmpilhaF(valor,1);
            //int valor=atoi(aux);
            
            //aux3=teste;
            //EmpilhaF(polonesa,aux3);
            
            
        } // é uma letra, vamos empilhar o valor dela no polonesa
         
       ExibeF(valor);
       
        
    }
    getch();
    //printf("\n%c",variavel);
    //ExibeC(operador);
    //ExibeF(polonesa);
}


int main(void) 
{
    char txt[30];
    float valor[26];
    
    printf("Digite a Expressao!! para calcular!");
    gets(txt);
    
    calcula_expressao (txt,valor);
    
    /*for(int i=0; i<26;i++)
    printf("\n%d--> %f",i,valor[i]);
    */
    getch();
}
