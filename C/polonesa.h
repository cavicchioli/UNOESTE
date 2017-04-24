
typedef char TKey;
typedef double TValue;

struct TItem 
{
  Tkey Key;
  TValeu Value;
 };

struct TPilha 
{
  TItem Item;
  TPilha *P;
 }

struct TopoPilha
{
   TPilha *topo;
}



void CriaPilha (TopoPilha *P) // Cria Pilha dinamica
{
   P->topo = (TPilha  *)malloc(sizeof(TPilha));
   P->topo -> P = NULL;
}

void FPEmpty ( TopoPilha * P)
{
    P->topo = (TPilha *)malloc(sizeof(TPilha));
    P->topo->P = NULL;
}

int PEmpty(TopoPilha P) // Verifica Pilha
{
   return (P.topo->P == NULL);
}

void Insert (TItem I, TopoPilha* Pilha)
{
   TPilha *aux;
   aux = (TPilha  *)malloc(sizeof(TPilha));
   aux->Item = I;
   aux->P = Pilha->topo->P;
   Pilha ->topo->P = aux;
 }

void remover (TopoPilha *Pilha , TItem *Item)
{
   TPilha *aux;
    if(PEmpty(*Pilha))
    {
       printf("ERRO!! ");
       return 0;
     }
    aux = Pilha->topo;
    Pilha->topo = Pilha->topo->P;
    *Item = aux->P->Item;
    free(aux);
    return 1;
}

int verificaNumero (char C)
{
    return (C>=48 && C<=57)
}

int verificaOperador(char C)
{
    return(C == 36 || C==42 || C==43 || C==45 || C==47);
}

int verificaPAbre ( char C)
{
   return (C==40);
}

int verificaPFecha ( char C)
{
   return ( C ==41);
}


int prioridade (char C)
{
   if(C==40)
      return 1;
  if(C==43 || C==45)
      return 2;
  if(C==42 || C==47)
      return 3;
  if(C==36)
      return 4;
  return 0;
}


TItem CriaItem (TKey A, TValue V)
{
   TItem Item;
    Item.Key = A;
    Item.Value=V;
   return Item;
}


int verificaInfixa (char Exp[])
{
   int Parent = 0;
   int i = 0;
 
     while ( Exp[i] != '\0' && Parent>=0)
     {
        if(verificaPAbre(Exp[i]))
        {
           Parent++;
           if(verificaPFecha (Exp[i+1]) || verificaOperador(Exp[i+1])
              return 0;
         }
         else
            if(verificaNumero(Exp[i]))
            {
               if(verificaNumero(Exp[i+1]) || verificaPAbre(Exp[i+1]))
               return 0;
            }
            else
                if(verificaOperador(Exp[i]))
                 {
                      if(verificaOperador(Exp[i+1] || verificaPFecha(Exp[i+1]))
                      return 0;
                  }
                  else
                       if(verificaPFecha[Exp[i]))
                       {
                            Parent--;
                            if(verificaNumero(Exp[i+1]) || verificaPAbre(Exp[i+1]))
                            return 0;
                       }
                   i++;
         }
        return ( !Parent);
}


int convertPos (char ExpINF[], char ExpFIX[])
{
  if(!verificaInfixa(ExpINF))
   return 0;
  
  int i = 0, j = 0;
  
  TItem ItemAux;
   TopoPilha topo;
   
    FPEmpty(& topo);
  
      while(ExpINF[i] != '\0')
      {
          if(verificaNumero(ExpINF[i]))
             ExpFIX[j++] = ExpINF[i];
          else
             if(verificaOperador (ExpINF[i]))
             {
                while(!PEmpty(topo) && (prioridade(topo.topo->P->Item.Key) >= prioridade (ExpINF[i])))
                 { 
                     remover(&topo, &ItemAux);
                     ExpFIX[j++] = ItemAux.Key;
                 }
                 insert(criaItem(ExpINF[i],0), &topo);
             }
             else
               if(verificaPAbre[ExpINF[i]))
                 insert(criaItem(ExpINF[i],0), & topo);
               else
               {
                  while(!verificaPAbre (topo.topo->P->Item.Key))
                   {
                         remover(&topo, &ItemAux);
                         ExpFIX[j++] = ItemAux.Key;
                    }
                    remover(&topo,& ItemAux);
                 }
                 i++;
           }
           while( !PEmpty(topo))
           {
              remover(&topo, &ItemAux);
              ExpFIX[j++] = ItemAux.Key;
           }
           ExpFIX[j] = '\0';
           return 1;
}

double CalculaExp ( char Expres[])
{
  int i = 0;
 
  TValue V1,V2;
   TItem ItemAux;
    TopoPilha topo;

      FPEmpty(& topo);
      while(Expres [i] != '\0')
      {
          if( verificaNumero(Expres[i]))
           {
               insert (CriaItem('0', Expres[i] - 48), &topo);
           }
           else
               {
                   remover(&topo, &ItemAux);
                   V2 = ItemAux.Value;
                   remover(&topo, &ItemAux);
                   V1 = ItemAux.Value;
                   switch(Expres[i])
                   {
                          case 36 :
                                 insert(CriaItem('0', pow(V1,V2)), &topo);
                                 break;
                          case 42 : 
                                 insert(CriaItem('0', V1*V2), &topo);
                                 break;
                           case 43 :
                                 insert(CriaItem('0', V1+V2), &topo);
                                 break;
                          case 45: 
                                 insert(CriaItem('0', V1-V2), &topo);
                                 break;
                           case 47: 
                                 insert(CriaItem('0', V1/V2), &topo);
                                 break;
                    }
               }   
              i++;
     }
     remover(&topo, &ItemAux);
     return ItemAux.Value;
}


            



