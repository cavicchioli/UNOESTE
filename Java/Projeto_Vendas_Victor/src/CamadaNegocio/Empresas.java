/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CamadaNegocio;

import CamadaLogica.BancoDados;
import CamadaLogica.ReadOnlyTableModel;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;
import javax.swing.JTable;

/**
 *
 * @author Victor
 */
public class Empresas extends Pessoas{
    private BancoDados banco = new BancoDados();
    
    private int emp_codigo;
    private String emp_razao_social;
    private String emp_nome_fantasia;
    private String emp_cnpj;

    public Empresas()
    {
        super();
        emp_codigo = 0;
        emp_razao_social = "";
        emp_nome_fantasia = "";
        emp_cnpj = "";
    }

    public BancoDados getBanco() {
        return banco;
    }

    public void setBanco(BancoDados banco) {
        this.banco = banco;
    }

    public int getEmp_codigo() {
        return emp_codigo;
    }

    public void setEmp_codigo(int emp_codigo) {
        this.emp_codigo = emp_codigo;
    }

    public String getEmp_razao_social() {
        return emp_razao_social;
    }

    public void setEmp_razao_social(String emp_razao_social) {
        this.emp_razao_social = emp_razao_social.replace("'", "`");
    }

    public String getEmp_nome_fantasia() {
        return emp_nome_fantasia;
    }

    public void setEmp_nome_fantasia(String emp_nome_fantasia) {
        this.emp_nome_fantasia = emp_nome_fantasia.replace("'", "`");
    }

    public String getEmp_cnpj() {
        return emp_cnpj;
    }

    public void setEmp_cnpj(String emp_cnpj) {
        this.emp_cnpj = emp_cnpj.replace("'", "`");
        
    }
    
    public boolean excluir()
    {
        Vector vetor = new Vector();
        try
        {
            //tabela empresas
            vetor.add("delete from empresa where emp_codigo = " + emp_codigo);

            //tabela pessoas
            vetor.add("delete from pessoas where pes_codigo = " + emp_codigo);
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
        if (emp_codigo == 0)
        {
            //tabela pessoas
            vetor.add("insert into pessoas (pes_logradouro, pes_nro, pes_cidade, pes_uf, pes_cep, pes_ddd, pes_telefone) values ('" + pes_logradouro + "', " + pes_nro + ", '" + pes_cidade + "', '" + pes_uf + "', '" + pes_cep + "', " + pes_ddd + ", '" + pes_telefone + "')");
            vetor.add("select max(pes_codigo) as pes_codigo from pessoas ");

            //tabela empresas
            vetor.add("insert into empresa(emp_codigo, emp_razao_social, emp_nome_fantasia, emp_cnpj) values (");
            vetor.add(", '" + emp_razao_social + "', '" + emp_nome_fantasia + "', '" + emp_cnpj + "')");

            banco.executarInsercaoTransacao(vetor, "pes_codigo");
        } else
        {
            //tabela_pessoas
            vetor.add("update pessoas set pes_logradouro='"+ pes_logradouro +"', pes_nro='" + pes_nro + "', pes_cidade='" + pes_cidade +"', pes_uf='" + pes_uf +"',pes_cep='" + pes_cep +"', pes_ddd='" + pes_ddd +"', pes_telefone='" + pes_telefone + "' where prod_codigo = " + pes_codigo);

            //tabela_empresa
            vetor.add("update empresa set emp_razao_social='"+ emp_razao_social +"', emp_nome_fantasia='" + emp_nome_fantasia + "', emp_cnpj='" + emp_cnpj + "' where emp_codigo = " + pes_codigo);

            banco.executarComandosTransacao(vetor);
        }
    }

    public boolean buscarPorCodigo()
    {
        try
        {
            String query = "select * from pessoas p, empresa em " +
                    "where p.pes_codigo = em.emp_codigo " +
                    "and em.emp_codigo = " + emp_codigo;
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

                //tabela empresa
                emp_codigo = rs.getInt("emp_codigo");
                emp_razao_social = rs.getString("emp_razao_social");
                emp_nome_fantasia = rs.getString("emp_nome_fantasia");
                emp_cnpj = rs.getString("emp_cnpj");

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
                query = "select pe.*, em.* from pessoas pe, empresa em where em.emp_codigo = pe.pes_codigo and pe.pes_codigo ="+Integer.parseInt(valor);
                break;
            case 1:
                 query = "select pe.*, em.* from pessoas pe, empresa em where em.emp_codigo = pe.pes_codigo and em.emp_nome_fantasia like '%" + valor + "%'";
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
    
    
    
}
