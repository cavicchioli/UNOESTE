import javax.swing.JOptionPane;
public class Ex_5 
{
	static boolean palindromo(String frase)
	{
		int i,j,cont=0,tam;
		String s=""; 
		boolean comp;
		
		s=frase.replace(" ","");
		tam=s.length();
		j=tam-1;
		i=0;
		do
		{
			if(s.charAt(i)!= s.charAt(j))
				cont++;
				
				j--;
				i++;
		}while(i<tam);
		
	if(cont==0)
	return true;
	else
	return false;
	}
    
    public static void main(String[] args)
    {
    	String s1;
    	String tam;
    	
    	
    	s1= JOptionPane.showInputDialog(null,"Digite a palavra");
        // TODO code application logic here
        
        if(palindromo(s1)==true)
        	JOptionPane.showMessageDialog(null,"Palindromo");
        else
        	JOptionPane.showMessageDialog(null,"NAO é Palindromo");	
    }
}
