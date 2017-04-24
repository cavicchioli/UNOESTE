
package appdicionario;

public class Termo {
   
    protected String port;
    protected String ingl;
    

    public Termo(String port, String ingl) {
        this.port = port;
        this.ingl = ingl;
    }

    public void setIngl(String ingl) {
        this.ingl = ingl;
    }
    
    public void setPort(String port)
    {
        this.port=port;
    }
   
    public String getIngl() {
        return ingl;
    }

    public String getPort() {
        return port;
    }
    
    public String toString() {
        return port+"#"+ingl;
    }
    
    
    
    
    
}
