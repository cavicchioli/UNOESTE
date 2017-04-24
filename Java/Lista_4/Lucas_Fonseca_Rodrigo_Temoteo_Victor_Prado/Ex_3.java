import javax.swing.*;
public class Ex_3 
{
        
    static String AnalisaPalavra(String vPal)
    {
    	int i,vCont=0;
    	boolean vAchou1=false,vAchou2=false, vEmail=false, vNome=false, vVar=false, vPlaca=false;
    	
    	String vResult="";
		
		for(i=0;i < vPal.length();i++) 
		{
			
			if (vPal.length() >= 3)
			{
				if (Character.isLetter(vPal.charAt(i))==true)
					vCont++;
					
				if (vPal.length() == vCont)
					vNome=true;
						
			}
			
	    	if (vPal.length() >= 8)
		    {
		    		if (vPal.charAt(i)=='@' && i > 3)
		    			vAchou1 = true;
		    			
		    		if (vPal.charAt(i) == '.' )
		    			vAchou2 = true;

			    	if (vAchou1==true && vAchou2==true)
			    		vEmail=true;
	    	}
			
			if (i==0 && (Character.isLetter(vPal.charAt(i))==true || vPal.charAt(i)=='_' || vPal.charAt(i)=='$'))
				vVar=true;
				
			if (i >0 && vVar==true) 
				if (Character.isLetter(vPal.charAt(i))==true || Character.isDigit(vPal.charAt(i))==true || vPal.charAt(i)=='_' || vPal.charAt(i)=='$')
					vVar=true;
				else
					vVar=false;
		
			
			if (vPal.length()==8)
			{
				if (i==0 && Character.isLetter(vPal.charAt(i))==true)
					vPlaca=true;
				
				if ((i==1 || i==2) && vPlaca==true)
					if (!Character.isLetter(vPal.charAt(i))==true)
						vPlaca=false;
				
				if (i==3 && vPlaca==true)
					if (vPal.charAt(i)!='-')
						vPlaca=false;
				
				if ((i>=4 && i<=7) && vPlaca==true)
					if (Character.isDigit(vPal.charAt(i))==false)			
						vPlaca=false;
			}
			else
				vPlaca=false;
		}
    	
		if (vNome==true)			
			vResult = vResult + "NOME\n";
		
		if (vEmail==true)
			vResult = vResult + "EMAIL\n";
				
		if (vVar==true)
			vResult = vResult + "VARIAVEL\n";
		
		if (vPlaca==true)
			vResult = vResult + "- PLACA\n";

		if (vResult=="")
			vResult = "DESCONHECIDO";
		else
			vResult = "CLASSIFICAÇÃO: \n\n"+vResult;
		return vResult;
    }


    
    public static void main(String[] args) 
    {
		int i;
        String vPalavra = JOptionPane.showInputDialog("Digite uma palavra: ");
        
        JOptionPane.showMessageDialog(null,AnalisaPalavra(vPalavra));
		        
    }
}
