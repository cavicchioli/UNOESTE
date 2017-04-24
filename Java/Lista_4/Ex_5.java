import javax.swing.*;
public class Ex_5 {
	static boolean Palindromo(String sent1)
	{
		int qtde1=0,j=0,i=0;
		String aux1="",aux2="";
		boolean resp;
		
		qtde1=sent1.length()+1;
		
		j=0;
		for(i=1;i<qtde1-1;i++)
		{
			char c=sent1.charAt(i);
			if(Character.isLetter(c))
			{
				aux1=aux1+sent1.charAt(j);
				j++;
			}
		}
		j=0;
		for(i=qtde1-1;i>0;i--)
		{
			char c=sent1.charAt(i);
			if(Character.isLetter(c))
			{
				aux2=aux2+sent1.charAt(j);
				j++;
			}
		}
		
		
		System.out.println(aux1);
		System.out.println(aux2);
	
	return aux2.equals(aux1);
	}
    public static void main(String[] args) {
        String frase1;
        
        frase1=JOptionPane.showInputDialog(null,"Digite a Frase!");
        
        if(Palindromo(frase1)==true)
        {
        	System.out.println(Palindromo(frase1));
        	JOptionPane.showMessageDialog(null,"E PALINDROMO!!!");
        }
        else
        {
         System.out.println(Palindromo(frase1));
         JOptionPane.showMessageDialog(null,"NAO E PALINDROMO!!!");
        }
         
    }
}
