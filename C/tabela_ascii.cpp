#include <stdio.h>
#include <conio2.h>

#include <stdlib.h>
int main(void)
{
    int i;
    printf("**TABELA ASCII**\n");
    for(i=0;i<256;i++)
    {
        textcolor(rand()%15+1);
        printf("%d - %c - %o - %x \n",i,i,i,i);
        _sleep(10);
    }
    getch();
}
