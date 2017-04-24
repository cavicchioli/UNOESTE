#include <stdio.h>
#include <string.h>
#include <conio2.h>
#include <ctype.h>
#include <stdlib.h>

int Tipo(char expressao[],char &ltr1,char &ltr2,int &numero1, int &numero2)//A1:D3 recebe esse tipo de expressao e retorna qual é tipo horizontal, vertical ou diagonal..
{
    int tl1=0,tl2=0,cond=0;
    char num1[4],num2[4];
 
    for(int i=0;i<strlen(expressao);i++)
    {
        if(expressao[i]==':')
         cond=1;
        
        if((expressao[i]>='0' && expressao[i]<='9'))
            if(cond==0)
             num1[tl1++]=expressao[i];
            else
             num2[tl2++]=expressao[i];
             
        if((expressao[i]>='A' && expressao[i]<='Z') || (expressao[i]>='a' && expressao[i]<='z'))
         if(cond==0)
             ltr1=expressao[i];
            else
             ltr2=expressao[i];
    }
    numero1= atoi(num1);
    numero2= atoi(num2);
    
    if(ltr1==ltr2 && numero1!=numero2)
     return 1; //A1:A5 VERTICAL
    
    if(ltr1!=ltr2 && numero1==numero2)
     return 2;
    else
     return 3;
}

float SUM(char valores[])//SUM(A1:D4) dentro de valores
{
    float numeros[20],somatorio=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
        somatorio+=numeros[i];
    return somatorio;
}


int main(void) 
{
    char txt[30];
    int valor,num1,num2;
    char ltr1,ltr2;
    
    printf("Digite a Expressao!!: ");
    gets(txt);
    
    valor=Tipo(txt,ltr1,ltr2,num1,num2);
    printf("%d\n",valor);
    printf("%c",ltr1);printf("%d",num1);printf(":");printf("%c",ltr2);printf("%d",num2);
    
    getch();
    
}    

/*


float AVG(char valores[])
{
    float numeros[20],somatorio=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
        somatorio+=numeros[i];
    return somatorio/tl2;
}

float SUM(char valores[])
{
    float numeros[20],somatorio=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
        somatorio+=numeros[i];
    return somatorio;
}

float MAX(char valores[])
{
    float numeros[20],maior=0;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
    {
        if(numeros[i]>maior)
            maior=numeros[i];
    }
    return maior;
}

float MIN(char valores[])
{
    float numeros[20],menor=99999;
    int tl=0,tl2=0,i;
    char num[8];
    strcpy(num,"");

    for(i=0;i<=strlen(valores);i++)
    {
        if((valores[i]>='0' && valores[i]<='9') || valores[i]=='.')
            num[tl++]=valores[i];
        else
        {
            if(valores[i]==',' || valores[i]=='\0')
            {
                num[tl]='\0';
                numeros[tl2++]=atof(num);
                tl=0;
            }
        }
    }
    for(i=0;i<tl2;i++)
    {
        if(numeros[i]<menor)
            menor=numeros[i];
    }
    return menor;
}*/

