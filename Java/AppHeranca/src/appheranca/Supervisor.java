
package appheranca;

public class Supervisor extends Funcionario
{
    private int diasSupervisao;
    private double valorDiasSuperv;
    
    public Supervisor(String Nome, int ctps, double valorHora, double numHorasTrab, int diasSupervisao, double valorDiasSuperv)
    {
      super(Nome,ctps,valorHora,numHorasTrab); // chama ao construtor da superclasse
      this.diasSupervisao = diasSupervisao;
      this.valorDiasSuperv = valorDiasSuperv;
    }
    
    public int getdiasSupervisao()
    {
        return diasSupervisao;
    }
    
    @Override
    public double calcSalario()
    {
        return super.calcSalario() + (diasSupervisao * valorDiasSuperv) ;
    }
}
