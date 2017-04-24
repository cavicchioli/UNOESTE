/* atoi exemplo */
#include <stdio.h>
#include <stdlib.h>

int main ()
{
  int i;
  char StrN[256];
  printf ("Entre com um número: ");
  fgets (StrN,256,stdin);
  i = atoi (StrN);
  printf ("Entrada como string: %d. Saída numérica como o dobro: %d.\n",i,i*2);
  system("pause");
  return 0;
}
