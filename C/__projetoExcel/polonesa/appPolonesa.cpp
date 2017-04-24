#include <stdio.h>
#include <string.h>
#include <conio2.h>
#include <ctype.h>
#include <stdlib.h>
#include "pilhaF.h"
#include "pilhaC.h"
#include "polonesa.h"


int main(void) 
{
    char txt[30];
    float valor;
    
    printf("Digite a Expressao!! para calcular!");
    gets(txt);
    
    valor=polonesa(txt);
    printf("%.2f",valor);
    
    getch();
    
}
