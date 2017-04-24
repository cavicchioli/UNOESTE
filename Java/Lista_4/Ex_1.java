import javax.swing.*;

public class Ex_1 {
	
	static String LerString(String titulo, String mensagem)
	{
	  String aux;
	 
	   aux= JOptionPane.showInputDialog(null,mensagem,titulo,JOptionPane.PLAIN_MESSAGE);
	 	
	 return aux;
	}
	
	static float LerFloat(String titulo, String mensagem)
	{
	  float  num;
	  String aux;
	 
	   aux= JOptionPane.showInputDialog(null,mensagem,titulo,JOptionPane.PLAIN_MESSAGE);
	   
	    try
	 	{
	 	  num=Float.parseFloat(aux);
	 	}
	 	catch(Exception e)
	 	{
	 	  num=0;
	 	}
	 	
	 return num;
	}
	
	static int LerInt(String titulo, String mensagem)
	{
	  int num;
	  String aux;
	 
	   aux= JOptionPane.showInputDialog(null,mensagem,titulo,JOptionPane.PLAIN_MESSAGE);
	   
	    try
	 	{
	 	  num=Integer.parseInt(aux);
	 	}
	 	catch(Exception e)
	 	{
	 	  num=0;
	 	}
	 	
	 return num;
	}
    public static void main(String[] args) 
    {
     String frase1, frase2, frase3,frase4;
      frase1="ATENÇÃO";
      frase2="Digite sua Idade!";
      frase3="Digite um numero Real";
      frase4="Digite uma Frase!";
     
    // LerInt(frase1,frase2);
    
       System.out.println(LerInt(frase1,frase2));//para imprimir o resultado de sucesso ou nao!!
       System.out.println(LerFloat(frase1,frase3));
       System.out.println(LerString(frase1,frase4));
    }
}
