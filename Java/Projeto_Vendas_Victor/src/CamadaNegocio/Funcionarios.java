package CamadaNegocio;

import CamadaLogica.BancoDados;
import CamadaLogica.ReadOnlyTableModel;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Vector;
import javax.swing.JTable;

public class Funcionarios extends Fisicas
{

    private BancoDados banco = new BancoDados();
    private int func_codigo;
    private int func_matricula;

    public Funcionarios()
    {
        super();
        func_codigo = 0;
        func_matricula = 0;
    }

    public boolean excluir()
    {
        Vector vetor = new Vector();
        try
        {
            //tabela funcioarios
            vetor.add("delete from funcionarios where func_codigo = " + func_codigo);

            //tabela fisicas
            vetor.add("delete from fisicas where fis_codigo = " + func_codigo);

            //tabela pessoas
            vetor.add("delete from pessoas where pes_codigo = " + func_codigo);
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
        if (func_codigo == 0)
        {
            //tabela pessoas
            vetor.add("insert into pessoas (pes_logradouro, pes_nro, pes_cidade, pes_uf, pes_cep, pes_ddd, pes_telefone) values ('" + pes_logradouro + "', " + pes_nro + ", '" + pes_cidade + "', '" + pes_uf + "', '" + pes_cep + "', " + pes_ddd + ", '" + pes_telefone + "')");
            vetor.add("select max(pes_codigo) as pes_codigo from pessoas ");

            //tabela fisicas
            vetor.add("insert into fisicas (fis_codigo, fis_nome, fis_rg, fis_cpf) values (");
            vetor.add(", '" + fis_nome + "', '" + fis_rg + "', '" + fis_cpf + "')");

            //tabela funcionarios
            vetor.add("insert into funcionarios(func_codigo, func_matricula) values (");
            vetor.add(", " + func_matricula + ")");

            banco.executarInsercaoTransacao(vetor, "pes_codigo");
        } else
        {
            //tabela_pessoas
            vetor.add("update pessoas set pes_logradouro='"+ pes_logradouro +"', pes_nro='" + pes_nro + "', pes_cidade='" + pes_cidade +"', pes_uf='" + pes_uf +"',pes_cep='" + pes_cep +"', pes_ddd='" + pes_ddd +"', pes_telefone='" + pes_telefone + "' where prod_codigo = " + pes_codigo);

            //tabela_fisicas
            vetor.add("update fisicas set fis_nome='"+ fis_nome + "', fis_rg='" + fis_rg + "', fis_cpf='" + fis_cpf +"' where fis_codigo = " + fis_codigo);

            //tabela_funcionarios
            vetor.add("update funcionarios set func_matricula='"+func_matricula+"' where func_codigo = " + func_codigo);

            banco.executarComandosTransacao(vetor);
        }
    }

    public boolean buscarPorCodigo()
    {
        try
        {
            String query = "select * from pessoas p, fisicas fi, funcionarios f " +
                    "where p.pes_codigo = fi.fis_codigo and fi.fis_codigo = f.func_codigo " +
                    "and f.func_codigo = " + func_codigo;
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
                func_codigo = rs.getInt("func_codigo");
                func_matricula = rs.getInt("func_matricula");
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
                query = "select pe.*, pf.*, fu.* from pessoas pe, fisicas pf, funcionarios fu where fu.func_codigo = pf.fis_codigo and pf.fis_codigo = pe.pes_codigo and pe.pes_codigo ="+Integer.parseInt(valor);
                break;
            case 1:
                 query = "select pe.*, pf.*, fu.* from pessoas pe, fisicas pf, funcionarios fu where fu.func_codigo = pf.fis_codigo and pf.fis_codigo = pe.pes_codigo and pf.fis_nome like '%" + valor + "%'";
                break;
        }
        return bd.retornaResultSet(query);
    }
    
        public ArrayList<Funcionarios> listarFuncionarios() throws SQLException{  
      
       String query = "";
       BancoDados bd = new BancoDados();
       
       query = "select fis_codigo, fis_nome from fisicas fi, funcionarios fu where fu.func_codigo = fi.fis_codigo";
      
        ResultSet rs = bd.retornaResultSet(query);
      
        ArrayList <Funcionarios> lista = new ArrayList<Funcionarios>();  
      
        while(rs.next()) {  
            Funcionarios fun;  
            fun = new Funcionarios();  
            //depto.setCd_depto(rs.getString("cd_depto"));  
            fun.setFis_codigo(rs.getInt("fis_codigo"));  
            fun.setFis_nome(rs.getString("fis_nome"));
            lista.add(fun);  
        }  

        return lista;  

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

    public int getFunc_codigo()
    {
        return func_codigo;
    }

    public void setFunc_codigo(int func_codigo)
    {
        this.func_codigo = func_codigo;
    }

    public int getFunc_matricula()
    {
        return func_matricula;
    }

    public void setFunc_matricula(int func_matricula)
    {
        this.func_matricula = func_matricula;
    }
}
