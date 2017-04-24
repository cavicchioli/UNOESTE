#include <stdlib.h>
#include <stdio.h>
#include <conio2.h>

int main(void)
{
	int num;
	float r;
	char s[20] = "12345.67";
	clrscr();
	num = atoi(s);
	printf("Cadeia de Caracteres = %s para Inteiro = %d\n", s, num);
	r = atof(s);
	printf("Cadeia de Caracteres = %s para Real = %.2f\n", s, r);

	getch();
	return 0;
}
