

package appsena;

import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.Scanner;

public class AppSena {
    public static int[] criaVetor()
    {
     	int v[]=new int[61];
     	for(int i=0;i<v.length;i++)
     		v[i]=0;
     	return v;
    }
    
    public static int[][] matriz(int v[])
    {
     	int m[][]=new int[61][2];
     	for(int i=0;i<v.length;i++)
        {
            m[i][0] = i+1;
            m[i][1] = v[i];       
        }
     	return m;
    }
    
    public static void contando(int aux[],int v[])
    {
    	for(int i=0;i<6;i++)
    		v[aux[i]]++;
    }
    
    static public int[] calc(String linha, int v[])
    {
    	String aux[];
    	int vetor[]=new int[6];
     
    	int tam=linha.length();
    	aux=linha.split("\t");
    	for (int i=0;i<6;i++)
    	{
    		vetor[i]=Integer.parseInt(aux[i]);    		
    	}
 	    
 	return vetor;
    }
    
    static public String compara(int sorteados[],int jogo[],int v[])
    {
    	int cont=0;
    	for(int i=0;i<6;i++)
    	{
    		for(int j=0;j<6;j++)
    		{
    			if(jogo[i]==sorteados[j])
    				cont++;
    				ele(sorteados[i],v);
    		}
    	}
    
    	if(cont==6)
    		return "sena";
        else
            if(cont==5)
                return "quina";
            else
                if(cont==4)
                    return "quadra";
                else
                    return "";
    		
    }
    
    static public void ele(int ele,int v[])
    {
    	for(int i=0;i<v.length;i++)
    	{
    		if(ele==v[i])
    			v[i]+=1;
    	}
    }
    
	
	static public void leituralinha(int v[]/*vetor criado de 60 posi*/, int jogo[])
    {
    	int sorteios[][];
    	sorteios = new int[5000][6];
        
    	int vet[];
    	String linha;
    	int k=0, sena=0, quina=0, quadra=0;
    	String resp;
    	try
    	{
         RandomAccessFile arq; // declaração do objeto arq
         arq=new RandomAccessFile("sena.txt","r");
         
         while(arq.getFilePointer()<arq.length())
         {
          linha = arq.readLine();
          vet=calc(linha,v);
          
          contando(vet,v);    	    
          
          sorteios[k]=vet;	
          k++;
          resp=compara(vet,jogo,v);
          if(resp=="sena")
              sena++;
          else
          if(resp=="quina")
              quina++;
          else
          if(resp=="quadra")
              quadra++;	 
         }
        arq.close();
        }
        catch(IOException e)
        {
        	System.out.println("Problema ao abrir arquivo "+e.getMessage());
        }
        finally
        {
          System.out.println("....:::COM ESSE JOGO VOCÊ ACERTARIA:::.... \n");
          System.out.println("A SENA: "+sena+" vezes \n");
          System.out.println("A QUINA: "+quina+" vezes \n");
          System.out.println("A QUADRA: "+quadra+" vezes \n");
          System.out.println("\n............................................");
        }
    }
        
    public static void bolha(int v[][])
    {
        int i = 0 , k = 61 , aux, pos;
        
        
        while(k > 1)
        {
            for(i=0;i<k-1;i++)
            if(v[i][1] < v[i+1][1])
            {
                aux = v[i][1];
                pos = v[i][0];
                v[i][1] = v[i+1][1];
                v[i][0] = v[i+1][0];
                v[i+1][1] = aux;
                v[i+1][0] = pos;
            }    
            k--;
        }
    }
    

    public static void main(String[] args) 
    {
    	int g[];
        int m[][] = new int[61][2];
        
		int soma;
		Scanner leitura = new Scanner(System.in);
		g=criaVetor();
		
		int jogo[];
		jogo=new int [6];
		
    	System.out.printf("\nDigite 6 números para apostar:  ");
    	
    	for(int i=0;i<6;i++)
    	{
    		jogo[i]=leitura.nextInt();
    	}
       leituralinha(g,jogo);
       m = matriz(g);
       bolha(m);
       System.out.println(" ");
       for(int q=1;q<g.length;q++)
    		System.out.printf ("%d: %d vezes\n",m[q][0],m[q][1]);
       
       
    }
    
}
