package appdicionario;

import java.io.RandomAccessFile;

public class Dicionario 
{   private String vetport[];
    private String vetingl[];
    private int tl;
    
    public Dicionario(int tf)  // construtor
    {   vetport=new String[tf];
        vetingl=new String[tf];
        tl=0;
    }
    public Dicionario()  // construtor sobrecarregado
    {   vetport=new String[100];
        vetingl=new String[100];
        tl=0;
    }
    public int getTotal() 
    {   return tl;
    }  
     
    public boolean addTerm(String port, String ingl)
    {
        if(tl<vetport.length)
        {
         vetport[tl]=port;
         vetingl[tl]=ingl;
         tl++;
         return true;
        }
         return false;
    }
    
    public boolean contains(String palavra)
    {
        for(int i=0;i<tl;i++)
        {
            if(vetport[i].equalsIgnoreCase(palavra))
                return true;
        }
        return false;
    }
    
    public String translate(String palavra)
    {
        for(int i=0;i<tl;i++)
        {
            if(vetport[i].equalsIgnoreCase(palavra))
                return vetingl[i];
        }
        return palavra;
    }
    
    public void SaveToFile(String narq)
    {
        RandomAccessFile arq;
        try
        {
            arq=new RandomAccessFile(narq,"rw");
            String termo;
            for(int i=0;i<tl;i++)
            {
                termo=vetport[i]+"#"+vetingl[i];
                arq.writeBytes(termo+"\r\n");
            }
            
        }catch(Exception ex){ }
    }
    
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
               this.addTerm(pedaco[0],pedaco[1]);
             }
             arq.close();
            
        } catch (Exception e) {
        }
                
    }
}
