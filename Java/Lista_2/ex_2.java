import java.util.Scanner;

public class ex_2 {

    public ex_2() {
    }
    
    public static void main(String[] args) {

		
			Scanner leitura = new Scanner(System.in);
			int valor=0,cem,ciq,dez,cin;
			
				System.out.printf("Digite o Valor:");
					
				valor = leitura.nextInt();
				
				cem=valor/100;
				valor=valor-(100*cem);
				ciq=valor/50;
				valor=valor-(50*ciq);
				dez=valor/10;
				valor=valor-(10*dez);
				cin=valor/10;
				valor=valor-(5*cin);
	
				System.out.printf("%d\n%d\n%d\n%d\n%d",cem,ciq,dez,cin,valor);
				

    }
}
