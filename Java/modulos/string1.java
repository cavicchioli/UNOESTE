import javax.swing.*;
public class string1 
{
	
    public static void main(String[] args) 
    {
       int num1,num2;
       num1=Utilidades.LerInteiro("Digite um numero");
       num2=Utilidades.LerInteiro("Digite outro numero");
       
       double media = Utilidades.Media(num1,num2);
              
       JOptionPane.showMessageDialog(null,"Voce digitou "+num1);
       JOptionPane.showMessageDialog(null,"e "+num2);
       JOptionPane.showMessageDialog(null,"Media = "+media);
    }
}
