import javax.swing.*;
public class Utilidades 
{
    static int LerInteiro(String mensagem)  // função ou metodo estatico
	{  String aux;
	   int n;
       aux=JOptionPane.showInputDialog(null,mensagem);
       try
       {   n=Integer.parseInt(aux);
       }
       catch(Exception e)
       {   //JOptionPane.showMessageDialog(null,"Valor invalido! "+
       	                                              //e.getMessage());
       	   n=0;
       }
       return n;    
	}
	static double Media(int a, int b)
	{   return (double)(a+b)/2;
		
	}
    
    
}