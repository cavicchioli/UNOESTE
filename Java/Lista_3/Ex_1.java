import java.util.Scanner;
import javax.swing.JOptionPane;

public class Ex_1 {
    public static void main(String[] args) {

      Scanner leitura=new Scanner(System.in);
     	 int num,cht=0,cont=19,resp=0;
	  do
      {
        JOptionPane.showMessageDialog(null,"JOGO DE ADIVINHA","EXERC�CIO - 1",JOptionPane.INFORMATION_MESSAGE);

     	 num=(int)(Math.random()*100);

      	do
      	{
      		String rec = JOptionPane.showInputDialog(null,"Digite um n�mero","Entrada de n�meros",JOptionPane.QUESTION_MESSAGE);
        	cht=Integer.parseInt(rec);

      		if(cht<num)
      			JOptionPane.showMessageDialog(null,"NUMERO MAIOR \nCHUTES RESTANTES "+cont,"RESULTADO",JOptionPane.INFORMATION_MESSAGE);
        	if(cht>num)
        		JOptionPane.showMessageDialog(null,"NUMERO MENOR \nCHUTES RESTANTES "+cont,"RESULTADO",JOptionPane.INFORMATION_MESSAGE);

      		cont--;
      	}while(cht!=num && cont!=0);


      if(cht!=num && cont==0)
      	JOptionPane.showMessageDialog(null,"\nTENTE OUTRA VEZ!!!\nVOC� PERDEU! \n\nN�MERO SORTEADO "+num,"Final",JOptionPane.INFORMATION_MESSAGE);
     	else
        JOptionPane.showMessageDialog(null,"\nPARAB�NS!!!\nVOC� GANHOU! \n\nN�MERO SORTEADO "+num,"Final",JOptionPane.INFORMATION_MESSAGE);

       resp=JOptionPane.showConfirmDialog(null,"Jogar outra vez?","Iniciar",JOptionPane.YES_NO_OPTION,JOptionPane.QUESTION_MESSAGE);
       cont=19;
      }while(resp==0);
    }
}
