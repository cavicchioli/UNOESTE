import java.util.Scanner;

public class ex_6 {
    public static void main(String[] args) {
      Scanner leitura = new Scanner(System.in);
      
      int sexo=0,idd=0,alt=0,atv=0;
      double peso=0, ndc=0;
      double tmb=0,qtd=0;
      
      System.out.println("MAGROS PARA SEMPRE - VEJA CALC.");
      
      	   System.out.println("Digite o Peso em kg.:");
      	   peso=leitura.nextFloat();
      	   
      	   System.out.println("Digite a Altura em cm.:");
      	   alt=leitura.nextInt();
      	   
      	   System.out.println("Digite a Idade.:");
      	   idd=leitura.nextInt();
      
      
      System.out.println("Digite o sexo <1-M | 2-F>:");
      sexo=leitura.nextInt();
      
       if(sexo==1)
       {
       	 tmb=66+(13.7*peso)+(5*alt)-(6.8*idd);
       	 
       	 System.out.println("Quantidade de Atividade Fisica!!!");
       	 System.out.println("[1] Nenhuma");
       	 System.out.println("[2] Moderada");
       	 System.out.println("[3] Intensa");
         atv=leitura.nextInt();
         
         switch(atv)
         {
         	case 1:
         	{
         		ndc=tmb+((25*tmb)/100);
         	}
         	
         	case 2:
         	{
         		ndc=tmb+((35*tmb)/100);
         	}
      
       	    case 3:
       	    {
       	    	ndc=tmb+((45*tmb)/100);
         	}	
      	 }
       }
       
       if(sexo==2)
       {
       	 tmb=655+(9.6*peso)+(1.7*alt)-(4.7*idd);
       	 
       	 System.out.println("Quantidade de Atividade Fisica!!!");
       	 System.out.println("[1] Nenhuma");
       	 System.out.println("[2] Moderada");
       	 System.out.println("[3] Intensa");
         atv=leitura.nextInt();
         
         switch(atv)
         {
         	case 1:
         	{
         		ndc=tmb+((20*tmb)/100);
         	}
         	
         	case 2:
         	{
         		ndc=tmb+((30*tmb)/100);
         	}
      
       	    case 3:
       	    {
       	    	ndc=tmb+((40*tmb)/100);
         	}	
      	 }
       }
      	
      	qtd = ndc-550;
      	
      System.out.println("Quantidade de calorias:");
      System.out.println(qtd);	   
      	   
}
}
