
package appdicionario;

public class EspTermo extends Termo{
    
    public String definicao;
    
     public EspTermo(String port, String ingl,String definicao) {
        super(port,ingl);
        this.definicao=definicao;
    }
    
    public String getSignificado() {
        return definicao;
    }
   
    @Override
    public String toString()
    {
        return port+"#"+ingl+"#"+definicao; //super.toString()"#"+definicao;
    }
}
