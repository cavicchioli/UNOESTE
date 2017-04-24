
import java.util.Scanner;

public class ex_1 {

    public ex_1() {
    }
    
    public static void main(String[] args) {

		
			Scanner leitura = new Scanner(System.in);
			int seg=0, hora=0, min=0;
			
				System.out.printf("Digite Segundos:");
					
				seg = leitura.nextInt();
				
				hora=(seg/60)/60;
				seg=seg-(hora*60*60);
				min=seg/60;
				seg=seg-(min*60);
	
				System.out.printf("%d:%d:%d",hora,min,seg);

    }
}
