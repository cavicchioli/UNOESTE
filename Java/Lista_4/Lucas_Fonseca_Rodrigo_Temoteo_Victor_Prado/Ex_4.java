import  javax.swing.*;

public class Ex_4 {
	
	static String dataf(String dia, int mes, String ano)
	{
		String frase="aa", mess="aa";
		
	  switch(mes) {  
      case 1:  mess = "Janeiro";break;
      case 2:  mess = "Fevereiro";break;  
      case 3:  mess = "Março";break;  
      case 4:  mess = "Abril";break;  
      case 5:  mess = "Maio";break;  
      case 6:  mess = "Junho";break;  
      case 7:  mess = "Julho";break;  
      case 8:  mess = "Agosto";break;  
      case 9:  mess = "Setembro";break;  
      case 10: mess = "Outubro";break;  
      case 11: mess = "Novembro";break;  
      case 12: mess = "Dezembro";  
     }  

	frase=dia+" de "+mess+" de "+ano;
		
	return frase;	
	}
    public static void main(String[] args) {
    	
    	String aux1,aux2,aux3,result;
    	int num2;
		aux1= JOptionPane.showInputDialog(null,"Digite o dia!");
		aux2= JOptionPane.showInputDialog(null,"Digite o mes!");
		aux3= JOptionPane.showInputDialog(null,"Digite o ano!");
	
			try
	 	{
	 	  
	 	  num2=Integer.parseInt(aux2);
	 	  
	 	}
	 	catch(Exception e)
	 	{
	 	  
	 	  num2=0;
	 	  
	 	}
	 	result= dataf(aux1,num2,aux3);
	 	
		JOptionPane.showMessageDialog(null,result);
       
    }
}
