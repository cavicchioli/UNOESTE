#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <conio.h>

int main(void)
{
    int i;
    char pass[50],login[50];
    
    printf("\nLogin: ");
    gets(login);
    
    printf("\nPassword: ");
    for(i=0;(pass[i]=getch())!=13 && i<50-1;i++)
    {
        printf("*");
    }
    pass[i]='\0';
    
    printf("\n\n\nLogin:\t\t%s",login);
    printf("\nPassword:\t%s",pass);
    
    getch();
}
