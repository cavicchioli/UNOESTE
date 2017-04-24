package appquadradomagico;

import javax.swing.JFrame;

public class AppQuadradoMagico {

    public static void main(String[] args) {
        JFrame.setDefaultLookAndFeelDecorated(true);//Look & feel opcional
        Janela frame = new Janela();
        frame.setTitle("Quadrado Mágico");
        frame.setVisible(true);  
    }
}
