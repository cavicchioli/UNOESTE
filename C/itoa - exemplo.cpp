/* itoa exemplo */
#include <stdio.h>
#include <stdlib.h>

int main ()
{
  int i;
  char Nconvert[50];
  printf ("Entre com um número: ");
  scanf ("%d",&i);
  itoa (i,Nconvert,10);
  printf ("Decimal: %s\n",Nconvert);
  itoa (i,Nconvert,16);
  printf ("Hexadecimal: %s\n",Nconvert);
  itoa (i,Nconvert,2);
  printf ("Binário: %s\n",Nconvert);
  system("pause");
  return 0;
}
