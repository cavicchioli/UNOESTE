package controloil;

import javax.swing.JOptionPane;

public class Banco 
{
    static public Conexao con;
    Banco()
    {
        con = new Conexao("controloil");
        if(!con.getEstadoConexao())
            JOptionPane.showMessageDialog(null, "ERRO " + con.getMensagemErro());
    }
}
