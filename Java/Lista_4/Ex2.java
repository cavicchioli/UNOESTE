import javax.swing.*;

public class Ex2 {

    public static void main(String[] args)
    {
    	String Cpf;
    	int c;


    	Cpf=cpf.recebeCPF("Digite seu CPF:");
    	c=cpf.charAt(Cpf);
    	
    	if(c==1)
    	  JOptionPane.showConfirmDialog(null,"VALIDO");
    	else 
          JOptionPane.showConfirmDialog(null,"INVALIDO");		 
    	

    }


}