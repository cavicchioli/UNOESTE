package CamadaNegocio;

import CamadaLogica.BancoDados;
import CamadaLogica.ReadOnlyTableModel;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JTable;

public class Produtos
{
    private BancoDados banco = new BancoDados();
    private int prod_codigo;
    private String prod_nome;
    private double prod_valor;
    private int prod_estoque;

    public Produtos()
    {
        prod_codigo = 0;
        prod_nome = "";
        prod_valor = 0.0;
        prod_estoque = 0;
    }

    public boolean excluir()
    {
        String query = "";
        try
        {
            query = "delete from produtos where prod_codigo = " + prod_codigo;
            banco.executarComando(query);
            return true;
        } catch (Exception ex)
        { return false; }
    }

    public void salvarDados()
    {
        String query = "";
        if (prod_codigo == 0)
            query = "insert into produtos (prod_nome, prod_valor, prod_estoque) values ('" + prod_nome + "', " + prod_valor + ", " + prod_estoque + ")";
        else
            query = "update produtos set prod_nome = '" + prod_nome + "', prod_valor = " + prod_valor + ", prod_estoque = " + prod_estoque + " where prod_codigo = " + prod_codigo;
        banco.executarComando(query);
    }

    public boolean buscarPorCodigo()
    {
        try
        {
            String query = "select * from produtos where prod_codigo = " + prod_codigo;
            ResultSet rs = banco.retornaResultSet(query);
            rs.next();
            if (rs.getRow() != 0)
            {
                prod_codigo = rs.getInt("prod_codigo");
                prod_nome = rs.getString("prod_nome");
                prod_valor = rs.getDouble("prod_valor");
                prod_estoque = rs.getInt("prod_estoque");
                return true;
            }
        }
        catch (SQLException sqlex)
        { System.out.println("Erro: \n" + sqlex.toString()); }
        return false;
    }

    public static void configuraModel(JTable jTable)
    {
         //configura o cabeçalho
         String colunas[] = new String []{"Código","Nome"};

         jTable.setModel(new ReadOnlyTableModel(colunas,0));

         //configurando a largura das colunas
         jTable.getColumnModel().getColumn(0).setPreferredWidth(50); //Código
         jTable.getColumnModel().getColumn(1).setPreferredWidth(450); //Nome
    }

    public static ResultSet buscarDados(String valor, int tipo)
    {
        BancoDados bd = new BancoDados();
        String query = "";
        switch (tipo)
        {
            case 0:
                if (valor.equals(""))
                    valor = "0";
                query = "select prod_codigo, prod_nome from produtos where prod_codigo = " + Integer.parseInt(valor);
                break;
            case 1:
                query = "select prod_codigo, prod_nome from produtos where prod_nome like '%" + valor + "%'";
                break;
        }
        return bd.retornaResultSet(query);
    }

    public int getProd_codigo()
    {
        return prod_codigo;
    }

    public void setProd_codigo(int prod_codigo)
    {
        this.prod_codigo = prod_codigo;
    }

    public int getProd_estoque()
    {
        return prod_estoque;
    }

    public void setProd_estoque(int prod_estoque)
    {
        this.prod_estoque = prod_estoque;
    }

    public String getProd_nome()
    {
        return prod_nome;
    }

    public void setProd_nome(String prod_nome)
    {
        this.prod_nome = prod_nome.replace("'", "`");
    }

    public double getProd_valor()
    {
        return prod_valor;
    }

    public void setProd_valor(double prod_valor)
    {
        this.prod_valor = prod_valor;
    }
}
