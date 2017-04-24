import java.util.*;
import javax.swing.*;


public class Ex_6
{
	
	static String sfrase(String str)
	{
		String aux="";
		int quant=0;
		char c;
		
		for(int i=0;i<str.length();i++)
		{
			c=str.charAt(i);
			if(i%40==0 && c==' ')	
				aux=aux+"\n";
			
			aux=aux+c;
			
			if(c=='.')
				aux=aux+"\n";
		}
		
		return aux;
		
	}
        

    public static void main(String[] args) 
    {
    	String str;
    	
    	str=JOptionPane.showInputDialog("Digite seu texto: ");
    	
    	
    	JOptionPane.showMessageDialog(null,sfrase(str));
    	
    }
}
