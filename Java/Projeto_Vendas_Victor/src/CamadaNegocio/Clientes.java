package CamadaNegocio;

import CamadaLogica.BancoDados;
import CamadaLogica.ReadOnlyTableModel;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;
import javax.swing.JTable;

public class Clientes extends Fisicas
{

    private BancoDados banco = new BancoDados();
    private int cli_codigo;
    private int cli_ddd;
    private String cli_celular;

    public Clientes()
    {
        super();
        cli_codigo=0;
        cli_ddd=0;
        cli_celular="";
    }

    public boolean excluir()
    {
        Vector vetor = new Vector();
        try
        {
            //tabela funcioarios
            vetor.add("delete from clientes where cli_codigo = " + cli_codigo);

            //tabela fisicas
            vetor.add("delete from fisicas where fis_codigo = " + cli_codigo);

            //tabela pessoas
            vetor.add("delete from pessoas where pes_codigo = " + cli_codigo);
            banco.executarComandosTransacao(vetor);
            return true;
        } catch (Exception ex)
        {
            return false;
        }
    }

    public void salvarDados()
    {
        Vector vetor = new Vector();
        if (cli_codigo == 0)
        {
            //tabela pessoas
            vetor.add("insert into pessoas (pes_logradouro, pes_nro, pes_cidade, pes_uf, pes_cep, pes_ddd, pes_telefone) values ('" + pes_logradouro + "', " + pes_nro + ", '" + pes_cidade + "', '" + pes_uf + "', '" + pes_cep + "', " + pes_ddd + ", '" + pes_telefone + "')");
            vetor.add("select max(pes_codigo) as pes_codigo from pessoas ");

            //tabela fisicas
            vetor.add("insert into fisicas (fis_codigo, fis_nome, fis_rg, fis_cpf) values (");
            vetor.add(", '" + fis_nome + "', '" + fis_rg + "', '" + fis_cpf + "')");

            //tabela funcionarios
            vetor.add("insert into clientes(cli_codigo, cli_ddd, cli_celular) values (");
            vetor.add(", '" + cli_ddd + "', '" + cli_celular + "')");

            banco.executarInsercaoTransacao(vetor, "pes_codigo");
        } else
        {
            //tabela_pessoas
            vetor.add("update pessoas set pes_logradouro='"+ pes_logradouro +"', pes_nro='" + pes_nro + "', pes_cidade='" + pes_cidade +"', pes_uf='" + pes_uf +"',pes_cep='" + pes_cep +"', pes_ddd='" + pes_ddd +"', pes_telefone='" + pes_telefone + "' where prod_codigo = " + pes_codigo);

            //tabela_fisicas
            vetor.add("update fisicas set fis_nome='"+ fis_nome + "', fis_rg='" + fis_rg + "', fis_cpf='" + fis_cpf +"' where fis_codigo = " + fis_codigo);

            //tabela_funcionarios
            vetor.add("update clientes set cli_ddd='"+ cli_ddd +"', cli_celular='" + cli_celular + "' where pes_codigo = " + pes_codigo);

            banco.executarComandosTransacao(vetor);
        }
    }

    public boolean buscarPorCodigo()
    {
        try
        {
            String query = "select * from pessoas p, fisicas fi, clientes f " +
                    "where p.pes_codigo = fi.fis_codigo and fi.fis_codigo = f.cli_codigo " +
                    "and f.cli_codigo = " + cli_codigo;
            ResultSet rs = banco.retornaResultSet(query);
            rs.next();
            if (rs.getRow() != 0)
            {
                //tabela pessoas
                pes_codigo = rs.getInt("pes_codigo");
                pes_logradouro = "pes_logradouro";
                pes_nro = rs.getInt("pes_nro");
                pes_cidade = rs.getString("pes_cidade");
                pes_uf = rs.getString("pes_uf");
                pes_cep = rs.getString("pes_cep");
                pes_ddd = rs.getInt("pes_ddd");
                pes_telefone = rs.getString("pes_telefone");

                //tabela fisicas
                fis_codigo = rs.getInt("fis_codigo");
                fis_nome = rs.getString("fis_nome");
                fis_rg = rs.getString("fis_rg");
                fis_cpf = rs.getString("fis_cpf");

                //tabela funcionarios
                cli_codigo = rs.getInt("cli_codigo");
                cli_ddd = rs.getInt("cli_ddd");
                cli_celular = rs.getString("cli_celular");
                return true;
            }
        } catch (SQLException sqlex)
        {
            System.out.println("Erro: \n" + sqlex.toString());
        }
        return false;
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
                query = "select pe.*, pf.*, cl.* from pessoas pe, fisicas pf, clientes cl where cl.cli_codigo = pf.fis_codigo and pf.fis_codigo = pe.pes_codigo and pe.pes_codigo ="+Integer.parseInt(valor);
                break;
            case 1:
                 query = "select pe.*, pf.*, cl.* from pessoas pe, fisicas pf, clientes cl where cl.cli_codigo = pf.fis_codigo and pf.fis_codigo = pe.pes_codigo and pf.fis_nome like '%" + valor + "%'";
                break;
        }
        return bd.retornaResultSet(query);
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

    public int getCli_codigo() {
        return cli_codigo;
    }

    public void setCli_codigo(int cli_codigo) {
        this.cli_codigo = cli_codigo;
    }

    public int getCli_ddd() {
        return cli_ddd;
    }

    public void setCli_ddd(int cli_ddd) {
        this.cli_ddd = cli_ddd;
    }

    public String getCli_celular() {
        return cli_celular;
    }

    public void setCli_celular(String cli_celular) {
        this.cli_celular = cli_celular;
    }
    
    
}
