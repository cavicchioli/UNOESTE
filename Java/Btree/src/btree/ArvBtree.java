package btree;
public class ArvBtree {
    private No raiz;
    public ArvBtree() {raiz = null;}
    
    No Navega_ate_folha(int info)
    {
        int i=0;
        No p;
        boolean flag=false;
        p = raiz;
        while(p.getvLig(0) != null && !flag)
        {
            i = 0;
            while(i<p.getTl() && info>p.getvInfo(i))
                i++;
            if(p.getvInfo(i) == info)
                flag = true;
            else
                p = p.getvLig(i);
        }
        return p;
}
    
    No Navega_ate_folha_mesmo(int info)
    {
        int i=0;
        No p;
        p = raiz;
        while(p.getvLig(0) != null)
        {
            i = 0;
            while(i<p.getTl() && info>p.getvInfo(i))
                i++;
                p = p.getvLig(i);
        }
        return p;
}
    
    int retorna_PosLig(int info)
    {
        int i=0;
        No p;
        p = raiz;
        while(p.getvLig(0) != null)
        {
            i = 0;
            while(i<p.getTl() && info>p.getvInfo(i))
                i++;
            p = p.getvLig(i);
        }
        return i;
    }
    
    int Procura_posicao(No folha, int info)
    {
        int i;
        i=0;
        while(i<folha.getTl() && info>folha.getvInfo(i))
            i++;
        return i;
    }
    
    void Remaneja(No folha, int pos)
    {
        int i;
        folha.setvLig(folha.getTl()+1, folha.getvLig(folha.getTl()));
        for(i = folha.getTl(); i>pos; i--)
        {
            folha.setvInfo(i, folha.getvInfo(i-1));
            folha.setvPos(i, folha.getvPos(i-1));
            folha.setvLig(i, folha.getvLig(i-1));
        }
    }
    
    private No localizaPai(No raiz, No folha, int info) 
    {
        No p,pai;
        int i;
        p=raiz;
        pai=p;
        while(p!=folha)
        {
            i=0;
            while (i<p.getTl() && info>p.getvInfo(i))
                i++;
            pai=p;
            p=p.getvLig(i);
        }

        return pai;
    }
    
    private No localizaPaidopai(No pai) {
        No p,pp;
        int i, info = pai.getvInfo(0);
        p=raiz;
        pp = p;
        while(p!=pai)
        {
            i=0;
            while (i<p.getTl() && info>p.getvInfo(i))
                i++;
            pp = p;
            p=p.getvLig(i);
        }

        return pp;
    }

    
    void Split(No folha, No pai, int info)
    {
        No cx1, cx2;
        int pos, i;
        cx1 = new No();
        cx2 = new No();
        for(i=0; i<folha.getN(); i++)
        {
            cx1.setvInfo(i, folha.getvInfo(i));
            cx1.setvPos(i, folha.getvPos(i));
            cx1.setvLig(i, folha.getvLig(i));
        }
        cx1.setvLig(folha.getN(), folha.getvLig(folha.getN()));
        cx1.setTl(folha.getN());
        
        for(i=folha.getN()+1; i<2*folha.getN()+1; i++)
        {
            cx2.setvInfo(i - (folha.getN()+1), folha.getvInfo(i));
            cx2.setvPos(i - (folha.getN()+1), folha.getvPos(i));
            cx2.setvLig(i - (folha.getN()+1), folha.getvLig(i));
        }
        cx2.setvLig(folha.getN(), folha.getvLig(2*folha.getN()+1));
        cx2.setTl(folha.getN());
        if(pai == folha)
        {
            folha.setvInfo(0, folha.getvInfo(folha.getN()));
            folha.setvPos(0, folha.getvPos(folha.getN()));
            folha.setvLig(0, cx1);
            folha.setvLig(1, cx2);
            folha.setTl(1);   
        }
        else
        {
            info = folha.getvInfo(folha.getN());
            pos = Procura_posicao(pai, info);
            Remaneja(pai, pos);
            pai.setTl(pai.getTl()+1);
            pai.setvInfo(pos, folha.getvInfo(folha.getN()));
            pai.setvPos(0, folha.getvPos(folha.getN()));
            pai.setvLig(pos, cx1);
            pai.setvLig(pos+1, cx2);
            if(pai.getTl() > 2*folha.getN())
            {
                folha = pai;
                info = folha.getvInfo(folha.getN());
                pai = localizaPai(raiz, pai, info);
                Split(folha, pai, info);
            }
        }
    }
    
    void In_Ordem(No raiz)
    {
        int i;
        if(raiz != null)
        {
            for(i=0; i<raiz.getTl(); i++)
            {
                In_Ordem(raiz.getvLig(i));
                System.out.println(raiz.getvInfo(i));
            }
            In_Ordem(raiz.getvLig(i));
        }
    }
    
    void Insere(int info, int pos_arq)
    {
        No folha, pai;
        int i, pos;
        if(raiz == null)
            raiz = new No(info, pos_arq);
        else
        {
            folha = Navega_ate_folha(info);
            pos = Procura_posicao(folha, info);
            Remaneja(folha, pos);
            folha.setTl(folha.getTl()+1);
            folha.setvInfo(pos, info);
            folha.setvPos(pos, pos_arq);
            if(folha.getTl() > 2*folha.getN())
            {
                pai = localizaPai(raiz, folha, info);
                Split(folha, pai, info);
            }
        }
    }
    
    public void concatena(No pai, No folha, int pos, int chave)
    {
        No aux;
        int lig;
        if(pos < pai.getTl() )
        {
            if(pai.getvLig(pos+1) != null)
            {
                aux = pai.getvLig(pos+1);
                int i=folha.getTl(),j=0;
                folha.setvInfo(i,pai.getvInfo(pos));
                folha.setTl(folha.getTl()+1);
                lig = folha.getTl();
                for(i = folha.getTl(); j < aux.getTl(); i++)
                    folha.setvInfo(i, aux.getvInfo(j++));
                folha.setTl(i);
                pai.setvLig(pos, folha);
                for(int k=pos; k< pai.getTl(); k++){
                        pai.setvInfo(k, pai.getvInfo(k+1));
                        pai.setvLig(k+1, pai.getvLig(k+2));
                }
                pai.setTl(pai.getTl()-1);
                if(folha.getvLig(0) != null) // se for a segunda chamada 
                {
                    if(this.raiz == pai)
                        this.raiz = folha;
                    pai= folha;int k=0;
                    for(i =lig; i <= pai.getTl(); i++)
                    {
                        pai.setvLig(i, aux.getvLig(k));
                        pai.setvPos(i, pai.getvPos(k++));
                    }
                }
            }
        }
        else
        {
            if(pai.getvLig(pos-1)!= null)
            {
                aux = pai.getvLig(pos-1);
                int i=aux.getTl(),j=0;
                aux.setvInfo(i,pai.getvInfo(pos-1));
                aux.setTl(aux.getTl()+1);
                lig = aux.getTl();
                for(i = aux.getTl(); j < folha.getTl(); i++)
                    aux.setvInfo(i, folha.getvInfo(j++));
                aux.setTl(i);
                pai.setvLig(pos, folha);
                for(int k=pos; k< pai.getTl(); k++){
                        pai.setvInfo(k, pai.getvInfo(k+1));
                        pai.setvLig(k+1, pai.getvLig(k+2));
                }
                pai.setTl(pai.getTl()-1);
                if(aux.getvLig(0) != null)
                {
                    pai= aux;int k=0;
                    for(i =lig; i <= pai.getTl(); i++)
                    {
                        pai.setvLig(i, aux.getvLig(k));
                        pai.setvPos(i, pai.getvPos(k++));
                    }
                }   
            }
        }
        if(pai.getTl() < pai.getN())
        {
                No pp = localizaPaidopai(pai);
                int i = retorna_PosLig(pai.getvInfo(pai.getTl()-1));
                concatena(pp,pai,i,chave);
        }
    }
    
    public void buscaSubstituto(No p,int pos, int chave)
    {
        No folha = p.getvLig(pos);
        while(folha.getvLig(folha.getTl()) != null)
              folha =  folha.getvLig(folha.getTl());
        int subs = folha.getvInfo(folha.getTl()-1);
        p.setvInfo(pos, subs);
        Exclusao(subs);    
    }
    
    public void Exclusao(int chave)
    {
        int pos=0;
        No folha, pai;
        folha = Navega_ate_folha(chave);
        if(folha.getvLig(0) != null)
        {
            No f2 = Navega_ate_folha_mesmo(chave);
            for(int k =0; k < f2.getTl(); k++)
                if(f2.getvInfo(k) == chave)
                    folha = f2;
        }
        if(folha.getvLig(0)== null)
        {
            pos = Procura_posicao(folha, chave);
            if(folha.getTl() > folha.getN())// Se for uma folha e tiver mais que o numero mínimo de elementos
            {
                if(folha.getvInfo(pos) == chave)
                {
                    for(int j=pos; j< folha.getTl(); j++)
                        folha.setvInfo(j, folha.getvInfo(j+1));
                    folha.setTl(folha.getTl()-1);
                }            
            }
            else 
            {
                int aux=0,i=0;
                pai = localizaPai(raiz, folha, chave);
                i = retorna_PosLig(chave);
                if(folha.getvInfo(pos)== chave)
                {
                    int k;
                    for( k=pos; k< folha.getTl(); k++)   // retira o elemento da folha
                        folha.setvInfo(k, folha.getvInfo(k+1));
                    folha.setTl(folha.getTl()-1);
                    if(folha.getTl() < folha.getN())// se ficar com menos que o número minimo de elementos
                    {
                            if(pai.getvLig(i-1) != null && pai.getvLig(i-1).getTl() > pai.getN())// verifica a irmã da esquerda
                            {
                                No f = pai.getvLig(i-1);
                                aux = pai.getvInfo(pai.getTl()-1); 
                                int aux2 = folha.getvInfo(0);
                                folha.setvInfo(0, aux);
                                folha.setvInfo(k-1, aux2);
                                folha.setTl(folha.getTl()+1);
                                pai.setvInfo(pai.getTl()-1, f.getvInfo(f.getTl()-1));
                                f.setTl(f.getTl()-1);
                            }
                        
                        else
                            if(pai.getvLig(i+1) != null && pai.getvLig(i+1).getTl() > pai.getN())// verifica a irmã da direita
                            {
                                aux = pai.getvInfo(pai.getTl()-1);
                                folha.setvInfo(k-1, aux);
                                folha.setTl(folha.getTl()+1);
                                pai.setvInfo(pai.getTl()-1, pai.getvLig(i+1).getvInfo(0));
                                for(int j=0; j< pai.getvLig(i+1).getTl(); j++)
                                    pai.getvLig(i+1).setvInfo(j, pai.getvLig(i+1).getvInfo(j+1));
                                pai.getvLig(i+1).setTl(pai.getvLig(i+1).getTl()-1);
                            }
                            else // se as páginas irmãs tiverem apenas o número mínimo de elementos, ai a porra fica séria....
                            {
                               // localiza o pai do pai caso tenha que ocorrer uma concatenação entre outros níveis
                                concatena(pai, folha, i,chave); // dece o elemento pai para folha e concatena 
                                                         //sempre pega a da direita a menos que seja o ultimo nó do pai ai pega da esquerda
                            }
                        
                    }
                }
            }
        }
        else
        {
            pos = Procura_posicao(folha,chave);
            buscaSubstituto(folha,pos,chave);
        }
        
    }
    
    public void executa()
    {
        Insere( 31, 0);
        Insere( 37, 0);
        Insere( 43, 0);
        Insere( 47, 0);
        Insere( 61, 0);
        Insere( 20, 0);
        Insere( 30, 0);
        Insere( 32, 0);
        Insere( 33, 0);
        Insere( 40, 0);
        Insere( 41, 0);
        Insere( 42, 0);
        Insere( 44, 0);
        Insere( 45, 0);
        Insere( 50, 0);
        Insere( 60, 0);
        Insere( 62, 0);
        Insere( 63, 0);
        In_Ordem(raiz); 
        Exclusao(42);
        Exclusao(40);
        Exclusao(41);
        Exclusao(37);
        Exclusao(63);
        Exclusao(61);
        Exclusao(62);
        Exclusao(43);
        Exclusao(60);
        Exclusao(44);
        
       // Exclusao(32); dá pau aqui...
        System.out.print("\n");
        In_Ordem(raiz);
    }
}
