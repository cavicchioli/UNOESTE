
import java.util.Scanner;

public class ex_4 {
    public static void main(String[] args) {
    	
        Scanner leitura = new Scanner(System.in);
			int A=0, B=0, C=0, D=0, E=0, F=0, G=0, H=0;
			int N=0, M=0, L=0, K=0, J=0, I=0, ano;
			
				System.out.printf("Digite o Ano:");
					
				ano = leitura.nextInt();
				
				A=ano%19;
				B=ano/100;
				C=ano%100;
				D=B/4;
				E=B%4;
				F=(B+8)/25;
				G=(B-F+1)/3;
				H=(19*A+B-D-G+15)%30;
				I=C/4;
				J=C%4;
				K=(32+2*E+2*I-H-J)%7;
				L=(A+11*H+22*K)/451;
				M=(H+K-7*L+114)/31;
				N=(H+K-7*L+114)%31;
			
				System.out.println("A Pascoa Sera em:");
				
				System.out.printf("%d",N+1);
				System.out.print(" de ");
				
				if(M==3)
				{	
					System.out.print("MARCO");	
				}
				if(M==4)
				{
					System.out.print("ABRIL");
				}
					
	
				
    }
}
