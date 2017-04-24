#include <iostream.h>
#include <conio.h>

int soma_horizont(int i,int tabuleiro[8][8]){
//Verifica se tem alguma rainha na linha atual
int soma_horizontal=0;
for(int a=0;a<8;a++){
soma_horizontal=soma_horizontal+tabuleiro[i][a];
}
return(soma_horizontal);}

int soma_vert(int j,int tabuleiro[8][8]){
//Verifica se tem alguma rainha na coluna atual
int soma_vertical=0;
for(int b=0;b<8;b++){
soma_vertical=soma_vertical+tabuleiro[b][j];
}
return(soma_vertical);}

int soma_diagonal_ne(int i,int j,int tabuleiro[8][8]){
//Verifica se tem alguma rainha na diagonal nordeste da posicao atual
int soma_diagonal_nordeste=0;
for(int e=0;e<=i&&e<(8-j);e++){
soma_diagonal_nordeste=soma_diagonal_nordeste+tabuleiro[i-e][j+e];
}
return(soma_diagonal_nordeste);}

int soma_diagonal_no(int i,int j,int tabuleiro[8][8]){
//Verifica se tem alguma rainha na diagonal nordeste da posicao atual
int soma_diagonal_noroeste=0;
for(int c=0;c<=i&&c<=j;c++){
soma_diagonal_noroeste=soma_diagonal_noroeste+tabu leiro[i-c][j-c];
}
return(soma_diagonal_noroeste);}

int soma_direc(int i, int j, int tabuleiro[8][8]){
//Diz se existe alguma rainha em alguma das posicoes citadas acima
int soma_diagonal_nordeste;
int soma_diagonal_noroeste;
int soma_vertical;
int soma_horizontal;
int soma_direcoes=0;

soma_diagonal_nordeste=soma_diagonal_ne(i,j,tabule iro);
soma_diagonal_noroeste=soma_diagonal_no(i,j,tabule iro);
soma_vertical=soma_vert(j,tabuleiro);
soma_horizontal=soma_horizont(i,tabuleiro);

soma_direcoes=soma_diagonal_nordeste+soma_diagonal _noroeste+soma_horizontal+soma_vertical;
return(soma_direcoes);}

int soma_tot(int tabuleiro[8][8],int i, int j){
//Complemento da funcao acima
int soma_direcoes=0;
int soma_total=0;

soma_direcoes=soma_direc(i,j,tabuleiro);

if (soma_direcoes==0)
tabuleiro[i][j]=1;
else
tabuleiro[i][j]=0;

for(int g=0;g<8;g++){
for(int h=0;h<8;h++){
soma_total=soma_total+tabuleiro[g][h];
}}
return(soma_total);}

void main(){
int tabuleiro[8][8];
int soma_total;
//Esse for abaixo tira todas as rainhas do tabuleiro
for(int n=0;n<8;n++){
for(int o=0;o<8;o++){
tabuleiro[n][o]=0;
}}

//Esse for abaixo coloca as rainhas nos seus devidos lugares
for(int i=0;i<8;i++){
for(int j=0;j<8;j++){
soma_total=soma_tot(tabuleiro,i,j);

//O comentario abaixo foi utilizado para ver cada matriz feita depois q as 4 solucoes encontradas são exibidas
/*if((tabuleiro[0][0]==0)&&(soma_total==7)){
for(int l=0;l<8;l++){
for(int m=0;m<8;m++){
cout<<tabuleiro[l][m]<<" ";
}
cout<<"\n";}getch();cout<<"\n";}*/

//Esse bloco imprime um tabuleiro com 8 rainhas e procura outra solucao
if(soma_total==8){
for(int l=0;l<8;l++){
for(int m=0;m<8;m++){
cout<<tabuleiro[l][m]<<" ";
}
cout<<"\n";}getch();cout<<"\n";
for(int p=7;p>=0;p--){
for(int q=7;q>=0;q--){
if (tabuleiro[p][q]==1){
tabuleiro[p][q]=0;
i=p;
j=q;
p=0;
q=0;}}}}

//Esse bloco procura outra solucao se não for possivel colocar 8 rainhas no tabuleiro
else if((soma_total!=8)&&(i==7)&&(j==7)){
for(int p=7;p>=0;p--){
for(int q=7;q>=0;q--){
if (tabuleiro[p][q]==1){
tabuleiro[p][q]=0;
i=p;
j=q;
p=0;
q=0;}}}}
}}

//Esse bloco eu fiz apenas para ver qual a ultima matriz feita antes q o programa terminasse inesperadamente
for(int l=0;l<8;l++){
for(int m=0;m<8;m++){
cout<<tabuleiro[l][m]<<" ";
}
cout<<"\n";}
} 
