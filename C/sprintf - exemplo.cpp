/* sprintf exemplo: converter */
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main ()
{
    char string[64]; 
    
    int num = 453; 
    float fnum = 13.56; 
    
    sprintf(string,"%d",num); 
    printf("Número em string: %s\n", string);
    
    sprintf(string,"%f",fnum);
    printf("Número em string: %s\n", string);
    
    system("pause");
    return 0;
}
