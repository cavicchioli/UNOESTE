
package controloil;

public class ControlOil {

    public static void main(String[] args) {
        new Banco();
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                new TelaPrincipal().setVisible(true);
            }
        });
    }
}
