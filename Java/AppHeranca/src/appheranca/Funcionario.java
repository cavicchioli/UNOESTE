
package appheranca;

public class Funcionario 
{
    protected String Nome;
    protected int ctps; // Carteira de trabalho 
    protected double valorHora; // Salario valor hora
    protected double numHorasTrab; // horas trabalhadas
    
         public Funcionario(String Nome, int ctps, double valorHora, double numHorasTrab) 
         {
            this.Nome = Nome;
            this.ctps = ctps;
            this.valorHora = valorHora;
            this.numHorasTrab = numHorasTrab;
         }
    
    public double getvalorHora()
    {
        return valorHora;
    }
    
    public double calcSalario()
    {
        return valorHora*numHorasTrab;
    }
    
    public String getDados()
    {
        return Nome+" "+ctps+" Valor Hora R$"+valorHora+"  Horas Trabalhadas"+numHorasTrab+" Salario R$"+calcSalario();
    }
    
}
