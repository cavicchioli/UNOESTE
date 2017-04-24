import javax.swing.*;
import java.util.Scanner;
public class ex3 {
        
   
    public ex3() {
    }
    
    
    public static void main(String[] args) {
        Scanner leitor;
        leitor = new Scanner(System.in);
        String i;
        int dia,mes,ano,resto;
        int aux=0,z;
        double k;
        char j;
        System.out.println("Digite a data de nascimento");
        dia = leitor.nextInt();
        mes = leitor.nextInt();
        ano = leitor.nextInt();
        k = (dia*1000000) + (mes*10000) + (ano);
        resto=(int)k%9;
        switch(resto)
        { case 0:
        	       System.out.println("Irrestivel");break;
          case 1:
        	       System.out.println("Impetuoso");break;
          case 2:
        	       System.out.println("Discreto");break;
          case 3:
        	       System.out.println("Amoroso");break;
          case 4:
        	       System.out.println("Timido");break;
       	  case 5:
        	       System.out.println("Paqerador");break;
          case 6:
        	       System.out.println("Estudioso");break;
          case 7:
        	       System.out.println("Sonhador");break;
          case 8:
        	       System.out.println("Charmoso");break;
          
        	
        }
          
        }
     
    
}
