bool numero(char elem)
{
    return (elem>='0' && elem<='9');
}

bool letra(char elem)
{
    return (elem>='a' && elem<='z') || (elem>='A' && elem<='Z');
}

bool operador(char elem)
{
    return (elem=='+' || elem=='-' || elem=='*' || elem=='/');
}

void resolve(TpPilhaC &operadores,TpPilhaF &valores)
{
    float num1,num2;
    char aux_operador;
    
        aux_operador=DesempilhaC(operadores);    
        num2=DesempilhaF(valores);
        num1=DesempilhaF(valores);
        
        switch(aux_operador)
        {
            case'+':EmpilhaF(valores,num1+num2);
                break;
            case'-':EmpilhaF(valores,num1-num2);
                break;
            case'*':EmpilhaF(valores,num1*num2);
                break;
            case'/':EmpilhaF(valores,num1/num2);
                break;
        }
}

float polonesa(char expressao[])
{
    
    TpPilhaC operador;//declaraçao e inicializaçao das pilhas utilizadas
    TpPilhaF valores;
    InicializaC(operador);
    InicializaF(valores);
    
    char aux_expressao[TF];//criei auxiliar para expressao e atribui o valor da expressao
    strcpy(aux_expressao,"");
    strcpy(aux_expressao,expressao);
    
    char aux_calculo[TF],oper;
    int tl=0;
    //float aux_convercao;
    
    
    for(int i=0;i<strlen(aux_expressao);i++)
    {
        if(numero(aux_expressao[i]) || aux_expressao[i]=='.' || aux_expressao[i] == ',')
        {
            aux_calculo[tl++]
        }
        else//se ele nao é mais numero nem . ou , é operador ou letra... portanto acabou o numero.
            {
                if(tl>0)//se o tl é maior quer dizer que foi pego um numero.. entao empilha na pilha de valores..
                {
                    aux_calculo[tl++]='\0';
                    EmpilhaF(valores,atof(aux_calculo));
                    strcpy(aux_calculo,"");
                    tl=0; //limpo o aux, e retorno o tl ao zero para contiar a captura dos números...
                }
                
                if(aux_calculo[i]==')' && !VaziaF(valores.Topo))//if(aux_calculo[i]==')' && !VaziaC(operador.Topo))
                {
                    while(AcessaTopoC(operador) != '(')
                    {
                        resolve(operador,valores);//<====no resolve alterei uma condiçao de while rever depois!!
                    }
                    oper=DesempilhaC(operador);//retirar o ( que ficou na pilha!   
                }
                else
                    {
                     if(!VaziaC(operador.Topo) && ((aux_expressao[i]=='+' || aux_expressao[i]=='-') && (AcessaTopoC(operador)=='*' || AcessaTopoC(operador)=='/')))
                     {
                        resolve(operador,valores);
                        EmpilhaC(operador,aux_expressao[i]);
                     }
                      else 
                         if(!VaziaC(operador.Topo) && aux_expressao[i]=='+' && AcessaTopoC(operador)=='-')
                         {
                            resolve(operador,valores);
                            EmpilhaC(operador,aux_expressao[i]);
                         }
                         else 
                            if(!VaziaC(operador.Topo) && (aux_expressao[i]=='*' || aux_expressao[i]=='/') && (AcessaTopoC(operador)=='*' || AcessaTopoC(operador)=='/'))
                            {
                             resolve(operador,valores);
                             EmpilhaC(operador,aux_expressao[i]);
                            }
                            else
                                {
                                 if(aux_expressao[i]=='+' || aux_expressao[i]=='-' || aux_expressao[i]=='*' || aux_expressao[i]=='/' || aux_expressao[i]=='(')
                                 EmpilhaC(operador,aux_expressao[i]);
                                }
                        
                    }
                
            }
    }
    
  if(tl>0)//se o tl é maior quer dizer que foi pego um numero.. entao empilha na pilha de valores..
  {
   aux_calculo[tl++]='\0';
   EmpilhaF(valores,atof(aux_calculo));
   strcpy(aux_calculo,"");
   tl=0; //limpo o aux, e retorno o tl ao zero para contiar a captura dos números...
  }  
    
}

    resolve(operador,valores);//calculo(pilha,pilha2,pilha2.topo+1);
    return DesempilhaF(valores);
}*/

