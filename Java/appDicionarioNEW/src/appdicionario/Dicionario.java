package appdicionario;

import java.io.RandomAccessFile;

public class Dicionario 
{   private Termo vetTermos[];
    private Termo vetRetorno[];
    private int tl;
    private String ret;
   
    public Dicionario(int tf)  // construtor 
    {   vetTermos=new Termo[tf];
        tl=0;
    }
    
    public Dicionario()  // construtor sobrecarregado
    {   vetTermos=new Termo[100];
        tl=0;
    }
    
    public String todosTermos(Termo vet[])
    {
        ret="";
        
        for(int i=0;i<tl;i++)
        {
            ret+="\n"+vet[i].toString();
        }
        return ret;
    }
    
    
    public Termo[] getTermos()
    {
       vetRetorno=new Termo[tl];
       
       for(int i=0;i<tl;i++)
       {
          vetRetorno[i] =vetTermos[i]; // ou copy array
       }
       
       return vetRetorno;
    }
    
    public int getTotal() 
    {   return tl;
    } 
    
    
    public boolean addTerm(String port, String ingl, String definicao)
    {
        return addTerm(new EspTermo(port,ingl,definicao));
    }
      
    public boolean addTerm(String port, String ingl)
    {
        return addTerm(new Termo(port,ingl));
    }
        
    public boolean addTerm(Termo t)
    {
        if(this.contains(t.getPort()))
            return false;
        
        if(tl<vetTermos.length)
        {
         vetTermos[tl]=t;
         tl++;
         return true;
        }
         return false;//acabou o espaço
    }
    
    public boolean contains(String palavra)
    {
        for(int i=0;i<tl;i++)
        {
            if(vetTermos[i].getPort().equalsIgnoreCase(palavra))
                return true;
        }
        return false;
    }
    
    public String translate(String palavra)//se é arquivo que tem definiçao tem que retornar o termo em ingles e a definição
    {
        for(int i=0;i<tl;i++)
        {
            if(vetTermos[i].getPort().equalsIgnoreCase(palavra))
            {
                if(vetTermos[i] instanceof EspTermo)
                 return vetTermos[i].getIngl()+" / "+((EspTermo)vetTermos[i]).getSignificado();
                else
                 return vetTermos[i].getIngl();
            }
        }
        return palavra;
    }
    
    public void SaveToFile(String narq)
    {
        RandomAccessFile arq;
        try
        {
            arq=new RandomAccessFile(narq,"rw");
            for(int i=0;i<tl;i++)
            {
                arq.writeBytes(vetTermos[i].toString()+"\r\n");
            }
            
        }catch(Exception ex){ }
    }
    
    //readequar o método loadfile
    public void LoadFromFile(String narq)
    {
        RandomAccessFile arq;
        try {
             arq=new RandomAccessFile(narq,"r");
             String termo;
             while(arq.length()>=arq.getFilePointer())
             {
               termo=arq.readLine();
               String pedaco[]=termo.split("#");
               if(pedaco.length==1)
               this.addTerm(pedaco[0],pedaco[1]);
               else
                 this.addTerm(pedaco[0],pedaco[1],pedaco[2]);//////
             }
             arq.close();
            
        } catch (Exception e) {
        }
                
    }
}
