package appclientes;

public class TodosClientes {
    
    private Clientes vetClientes[];
    private int cont=0;
    
    public TodosClientes()
    {
      vetClientes=new Clientes[100];
    }
    
    public TodosClientes(int tl)
    {
        vetClientes=new Clientes[tl];
    }
    
    public void insere(Clientes c)
    {
        vetClientes[cont]=c;
        cont++;
    }
    
    public String listaClientes()
    {
        String lista="";
        
        for(int i=0;i<cont;i++)
            lista=lista+", "+(vetClientes[i].getNome());
        
        return lista;
    }
    
    public String listaClientesPorRenda(double renda)
    {
        String lista="";
        
        for(int i=0;i<cont;i++)
        {
            if((vetClientes[i].getRenda())> renda)
             lista=lista+", "+(vetClientes[i].getNome());
        }
           
        return lista;
    }
}
