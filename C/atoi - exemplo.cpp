/* atoi exemplo */
#include <stdio.h>
#include <stdlib.h>

int main ()
{
  int i;
  char StrN[256];
  printf ("Entre com um n�mero: ");
  fgets (StrN,256,stdin);
  i = atoi (StrN);
  printf ("Entrada como string: %d. Sa�da num�rica como o dobro: %d.\n",i,i*2);
  system("pause");
  return 0;
}
