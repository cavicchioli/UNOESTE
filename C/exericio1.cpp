



int hash(int chave)
{    return chave%N;}
struct pont
{
    int chave;
    int pos;
    struct pont *prox;
};
typedef struct pont Pont;

struct tpReg
{
    int numero;
    char nome[20];
    char status;
};

/*  *INSERE
    *EXCLUSAO LOGICA
    *REORGANIZA (EXCLUSAO FISICA)
    *EXIBE
*/

void insere(Pont *t[], tpReg TabDados[], int *tl)
{
    tpReg reg;
    Pont *aux;
    Pont *nova;
    int ender;
    char resp;
    
    printf("Numero: ");
    scanf("%d", &reg.numero);
    while(reg.numero > 0)
    {
        ender = hash(reg.numero);
        aux = busca(t[ender], reg.numero);
        if(aux == NULL) // nao achou
        {
            printf("Nome: ");
            gets(reg.nome);
            reg.status = 1;
            TabDados[*tl] = reg;
            nova = criaNo(reg.numero,*tl,t[ender]);
            t[ender] = nova;
            (*tl)++;
        }
        else // nao achou
        {
            if(TabDados[aux->pos].status)
                printf("Chave já cadastrada");
            else
            {
                printf("Reg. está marcado para exclusao!");
                resp = toupper(getche());
                if(resp=='S')
                    TabDados[aux->pos].status = 1;
            }
        }
        printf("Numero: ");
        scanf("%d", &reg.numero);
    }
}
        
        
    }
    
    
    
}    
