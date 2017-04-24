import java.util.Scanner;

public class ex_5 {
    public static void main(String[] args) {
    	
    	Scanner leitura = new Scanner(System.in);
    	
    	double xa=0,xb=0,ya=0,yb=0;
    	double d=0,y=0,x=0;
    	
    		System.out.print("Digite o Ponto xA:");
    			xa=leitura.nextDouble();
    			
    		System.out.print("Digite o Ponto xB:");
    			xb=leitura.nextDouble();
    			
    		System.out.print("Digite o Ponto yA:");
    			ya=leitura.nextDouble();
    			
    		System.out.print("Digite o Ponto yB:");
    			yb=leitura.nextDouble();	
    	
    	x=Math.pow((yb-ya),2);
    	y=Math.pow((xb-xa),2);
    		    	
    	d=Math.sqrt((x+y));
    	
    	System.out.println(d);
    
    }
}
