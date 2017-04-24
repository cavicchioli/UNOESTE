import javax.swing.*;

public class cpf {

    static String recebeCPF(String mensagem)
    {
    	String numeros;

    	numeros=JOptionPane.showInputDialog(null,mensagem,"CPF",JOptionPane.PLAIN_MESSAGE);

        return numeros;

    }

    static int charAt(String c)
    {
      	char a,l,n;
        int soma=0,t,sol;
        int divide,sub,sub2,d,d2;
     
       for(t=8;t>=2;t--)
       {
       	 a=c.charAt(t);
       	 sol=Integer.parseInt(String.valueOf(a))*t;
       	 soma=soma+sol;
       }

       divide=soma%11;
        System.out.println((int) divide);
       sub=11-divide;
         System.out.println((int) sub);
       ////////////////////////////////////////////////////////////////////////////////
       
       soma=0;
       for(t=9;t>=2;t--)
       {
       	 a=c.charAt(t);
       	 sol=Integer.parseInt(String.valueOf(a))*t;
       	 soma=soma+sol;
       }

       divide=soma%11;
        System.out.println((int) divide);
       sub2=11-divide;
         System.out.println((int) sub2);
         
      l=c.charAt(9);
      n=c.charAt(10);
        
       d=Integer.parseInt(String.valueOf(l));
       d2=Integer.parseInt(String.valueOf(n));
       
   
       
       if(d==sub2 || d==sub )
       	  return 1;
       else
       	  return 0;

    }
}