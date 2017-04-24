import java.util.Scanner;

public class Ex_3 {
    public static void main(String[] args) {
    	Scanner leitura=new Scanner(System.in);
    	int dia=0,mes=0,ano=0,aux=0;
    	
    	
    	System.out.print("~*-* DATA DE NACIMENTO *-*~\n");
    	System.out.print("\n DIA:");
    			dia=leitura.nextInt();
    			aux=dia*1000000;
    	System.out.print(" MES:");
    			mes=leitura.nextInt();
    			aux=aux+(mes*10000);
    	System.out.print(" ANO:");
    			ano=leitura.nextInt();
    			aux=aux+ano;
    		
    		aux=aux%9;
    		
    		switch(aux)
    		{
    			case 0:System.out.print("\nIRRESISTIVEL:");break;
    			case 1:System.out.print("\nIMPETUOSO:");break;
    			case 2:System.out.print("\nDISCRETO:");break;
    			case 3:System.out.print("\nAMOROSO:");break;
    			case 4:System.out.print("\nTIMIDO:");break;
    			case 5:System.out.print("\nPAQUERADOR:");break;
    			case 6:System.out.print("\nESTUDIOSO:");break;
    			case 7:System.out.print("\nSONHADOR:");break;
    			case 8:System.out.print("\nCHARMOSO:");break;
    			
    		}
    			
    }
}
