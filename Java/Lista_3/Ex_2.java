import java.io.*;
import javax.swing.JOptionPane;
import java.text.DecimalFormat;


public class Ex_2 {

    public Ex_2() {
    }

    public static void main(String[] args) {

    	DecimalFormat twoDigits=new DecimalFormat( " 0.00 " );


		int parcelas, i;
		String resultado="";
		double emprestimo, prestacao, juros, percentj, aux,
		tabjuros, tabemprestimo, tabamortizacao, somajuros = 0;


        System.out.println("-----------------------SISTEMA DE AMORTIZAÇÃO PRICE------------------------\n");

		emprestimo=Double.parseDouble(JOptionPane.showInputDialog(null, "Montante Emprestado"));

		parcelas=Integer.parseInt(JOptionPane.showInputDialog(null, "Número de Parcelas."));

		juros=Integer.parseInt(JOptionPane.showInputDialog(null, "Juros ao Mês."));

		percentj=juros / 100;
		aux=Math.pow((1+percentj),parcelas);

		prestacao=emprestimo*((percentj*aux)/(aux - 1));

		System.out.println("---------------------------------------------------------------------------");
		System.out.println("Montante: R$ "+emprestimo);
		System.out.println("Parcelas: "+parcelas+'x');
		System.out.println("Juros:    "+juros+'%');
		System.out.println("---------------------------------------------------------------------------\n");

		System.out.println("---------------------------------------------------------------------------");
		System.out.println("Parcela     Valor                 Amortização      Juros            Devedor");
		System.out.println("---------------------------------------------------------------------------");
		tabemprestimo=emprestimo;

		for(i=1;i<=parcelas;i++)
		{
			tabjuros=percentj*tabemprestimo;
			tabamortizacao=prestacao-tabjuros;
			tabemprestimo=tabemprestimo-tabamortizacao;
			somajuros=tabjuros+somajuros;

			resultado+=String.format("%03d     %10.2f            %10.2f       %10.2f       %10.2f\n", i, prestacao, tabamortizacao, tabjuros, tabemprestimo);
			//System.out.println(resultado);
		}

		System.out.println("---------------------------------------------------------------------------");
		resultado+=String.format("Valor de juros pagos %10.2f", somajuros);
		
        JOptionPane.showMessageDialog(null,resultado);
		System.out.println("---------------------------------------------------------------------------");
		System.out.println(resultado);
    }
}
