#include <stdlib.h>
#include <stdio.h>
#include <conio2.h>

int main(void)
{
	int num = 15;
	char s[25];

	clrscr();
	itoa(num, s, 10);
	printf("Inteiro = %d para Cadeia de Caracteres (Base 10) = %s\n", num, s);
	itoa(num, s, 2);
	printf("Inteiro = %d para Cadeia de Caracteres (Base 2) = %s\n", num, s);
	itoa(num, s, 16);
	printf("Inteiro = %d para Cadeia de Caracteres (Base 16) = %s\n", num, s);
	itoa(num, s, 8);
	printf("Inteiro = %d para Cadeia de Caracteres (Base 8) = %s\n", num, s);
	getch();
	return 0;
}

