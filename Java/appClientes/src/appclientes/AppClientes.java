
package appclientes;

public class AppClientes {

    public static void main(String[] args) {
       
        Clientes c1;
        c1=new Clientes(123,"Val","3264-1812",1200);
        System.out.println(c1.toString());
        
        Clientes c2;
        c2=new Clientes(123,"Valdire","3264-1289",500);
        System.out.println(c2.toString());
       
    }
}
