import java.util.Scanner;
import java.util.Calendar; 

public class ex_3 {
    public static void main(String[] args) 
    {
    	Calendar cal = Calendar.getInstance(); 
    	Scanner leitura = new Scanner(System.in);
    	        
    	int ano ,idd;
 		int year = cal.get(Calendar.YEAR); 

    	System.out.printf("\nAno em que você nasceu: ");
    	ano=leitura.nextInt();
    	idd=year-ano;
    	System.out.printf("\nNo Ano de (%d) você terá %d anos de idade!!!\n",year,idd);
    	
    }
}
