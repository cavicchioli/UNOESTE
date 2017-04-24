package appclientes;

public class Clientes {
    
    private int rg;
    private String nome;
    private String fone;
    private double renda;
    
    //b) Dois construtores: um sem parâmetros e outro com os parâmetros rg, nome, fone e renda.
    
    public Clientes(int rg, String nome, String fone, double renda)  // construtor
    {   
        setRg(rg);
        setNome(nome);
        setFone(fone);
        setRenda(renda);
        
    }
    
    public Clientes()  // construtor sobrecarregado
    {
        rg=0;
        nome="";
        fone="";
        renda=0;
    }
    
    public void setRg(int rg)
    {
       this.rg=rg;
    }
    
    public void setNome(String nome)
    {
       this.nome=nome;
    }
    
    public void setFone(String fone)
    {
       this.fone=fone;
    }
    
    public void setRenda(double renda)
    {
       this.renda=renda;
    }
    
    public int getRg()
    {
     return rg;
    }
    
    public String getNome()
    {
        return nome;
    }
    
    public String getFone()
    {
        return fone;
    }
    
    public double getRenda()
    {
        return renda;
    }
    
    public String toStr()
    {
        String ret="";
        
        ret=Integer.toString(rg);
        ret=ret+nome;
        ret=ret+fone;
        ret=ret+Double.toString(renda);
        
        return (ret);
    }
}
