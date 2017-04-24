/* atof exemplo: cálculo do seno */
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main ()
{
  double n,m;
  double pi=3.1415926535;
  char NStr[256];
  printf ( "Entre com o grau desejado: " );
  gets (NStr);
  n = atof (NStr);
  m = sin (n*pi/180);
  printf ( "O Sen de %0.3f graus é %0.3f\n" , n, m );
  system("pause");
  return 0;
}
