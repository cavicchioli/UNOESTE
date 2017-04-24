package appheranca;

public class Gerente extends Funcionario // herança de Funcionario
{
    private double adicGerente; // atributo novo que calcula porcentagem
    
    public double getadicGerente() // metodo novo
    {
        return adicGerente;
    }
    
    public Gerente(String Nome, int ctps, double valorHora, double numHorasTrab, double adicGerente)
    {
      super(Nome,ctps,valorHora,numHorasTrab); // chama ao construtor da superclasse
      this.adicGerente = adicGerente;
    }
    
    @Override // fica mais legivel para o programador
    public double calcSalario() // metodo reescrito - EXISTE 3 TIPOS DE METODOS o Metodo ERDADO, NOVO e REESCRITO
    {
        //return valorHora * numHorasTrab * (1+adicGerente/100);
        return super.calcSalario() * (1+adicGerente/100);
    }
 
    
}
