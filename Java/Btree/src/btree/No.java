package btree;
public class No 
{
    private int n = 2;
    private int vInfo[] = new int[2*n+1];
    private int vPos[] = new int[2*n+1];
    private No vLig[] = new No[2*n+2];
    private int tl;
    
    public No(int info, int pos_arq)
    {
        vInfo[0] = info;
        vPos[0] = pos_arq;
        tl=1;
        for(int i=0; i<2*n+2; i++)
           vLig[i] = null;
    }
    
    public No()
    {
        for(int i=0; i<2*n+2; i++)
           vLig[i] = null;
        tl = 0;
    }

    public int getN() {
        return n;
    }

    public int getTl() {
        return tl;
    }

    public void setTl(int tl) {
        this.tl = tl;
    }

    public int getvInfo(int pos) {
        return vInfo[pos];
    }

    public void setvInfo(int pos, int info) {
        vInfo[pos] = info;
    }

    public No getvLig(int pos) {
        return vLig[pos];
    }

    public void setvLig(int pos, No lig) {
        vLig[pos] = lig;
    }

    public int getvPos(int pos) {
        return vPos[pos];
    }

    public void setvPos(int pos, int pos_arq) {
        vPos[pos] = pos_arq;
    }
}
