#include <conio2.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>

int main(void)
{
    char txt[100];
    printf("Digite um texto:");
    gets(txt);
    while(!kbhit())
    {
        gotoxy(rand()%160+1,rand()%61+1);
        textbackground(rand()%15+1);
        clrscr();
        _sleep(10);
        puts(txt);
    }
    getch();
}
