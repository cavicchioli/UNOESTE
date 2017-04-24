#include<conio2.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

char *infixaParaPosfixa (char inf[50]) {
   char *posf; 
   char *pi; int t; // pilha
   int n, i, j;

   n = strlen (inf);
   posf = malloc(n * sizeof (char));
   pi = malloc(n * sizeof (char));
   t = 0;
   pi[t++] = inf[0];                          // empilha '('
   for (j = 0, i = 1; /*X*/ inf[i] != '\0'; ++i) {
      // a pilha est� em pi[0..t-1]
      switch (inf[i]) {
         char x;
         case '(': pi[t++] = inf[i];          // empilha
                   break;
         case ')': while (1) {                // desempilha
                      x = pi[--t];
                      if (x == '(') break;
                      posf[j++] = x;
                   }
                   break;
         case '+': 
         case '-': while (1) {
                      x = pi[t-1];
                      if (x == '(') break;
                      --t;                    // desempilha
                      posf[j++] = x;
                   }
                   pi[t++] = inf[i];          // empilha
                   break;
         case '*':
         case '/': while (1) {
                      x = pi[t-1];
                      if (x == '(' || x == '+' || x == '-') 
                         break;
                      --t;
                      posf[j++] = x;
                   }
                   pi[t++] = inf[i];
                   break;
         default:  posf[j++] = inf[i];
      }
   }
   free (pi);
   posf[j] = '\0'; 
   
   printf("%s",posf);     
   return posf;
}

int main (void)
{
    char ret[50];
    printf("digite a expressao infixa  ");
    gets(ret);
    
    infixaParaPosfixa(ret);
    
    printf("%s",ret);
    getch();
}
