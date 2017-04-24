/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CamadaNegocio;

import CamadaLogica.BancoDados;
import java.awt.font.NumericShaper;
import java.sql.Date;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;

/**
 *
 * @author Rafael
 */
public class Vendas_ {
    private BancoDados banco = new BancoDados();      
      
    private int vend_codigo; 
    private Date vend_data; 
    private double vend_valor_total; 
    private int func_codigo;
    private int cli_codigo;    
    private  Vendas_produtos [] vp ;    
    
    private String strSql = "";

    public BancoDados getBanco() {
        return banco;
    }

    public void setBanco(BancoDados banco) {
        this.banco = banco;
    }

    public int getVend_codigo() {
        return vend_codigo;
    }

    public void setVend_codigo(int vend_codigo) {
        this.vend_codigo = vend_codigo;
    }

    public Date getVend_data() {
        return vend_data;
    }

    public void setVend_data(Date vend_data) {
        this.vend_data = vend_data;
    }

    public double getVend_valor_total() {
        return vend_valor_total;
    }

    public void setVend_valor_total(double vend_valor_total) {
        this.vend_valor_total = vend_valor_total;
    }

    public int getFunc_codigo() {
        return func_codigo;
    }

    public void setFunc_codigo(int func_codigo) {
        this.func_codigo = func_codigo;
    }

    public int getCli_codigo() {
        return cli_codigo;
    }

    public void setCli_codigo(int cli_codigo) {
        this.cli_codigo = cli_codigo;
    }

    public Vendas_produtos[] getVp() {
        return vp;
    }

    public void setVp(Vendas_produtos[] vp) {
        this.vp = vp;
    }

    public String getStrSql() {
        return strSql;
    }

    public void setStrSql(String strSql) {
        this.strSql = strSql;
    }
    
    
    
    
    
    public Vendas_(Date vend_data, double vend_valor_total, int func_codigo, int cli_codigo, Vendas_produtos [] v) {
        this.vend_data = vend_data;
        this.vend_valor_total = vend_valor_total;
        this.func_codigo = func_codigo;
        this.cli_codigo = cli_codigo;
        this.vp = v; 
    }      

    public Vendas_() {
    }
    
    
    
    public boolean addItensVenda(int venda)
    {
        Vendas_produtos vendP; 
        for(int i = 0; i < this.vp.length; i++)
        {
            vp[i].setVend_cod(venda);
            vendP = vp[i];
            vendP.GravaItem();
            
            
            Vector vetor = new Vector();
            String sql = "UPDATE produtos  SET  prod_estoque = (select prod_estoque from produtos  WHERE prod_codigo = "+vp[i].getProd_codigo()+" ) - "+vp[i].getVendprod_quantidade()+" WHERE prod_codigo = "+vp[i].getProd_codigo();
            vetor.add(sql);           
            banco.executarComandosTransacao(vetor);
            
            
        }        
        return true; 
    }
    

    
    
    
    public boolean UltimaVenda()
    {
        try
        {
            String query = "select max(vend_codigo) as ven from vendas";
            ResultSet rs = banco.retornaResultSet(query);
            rs.next();
            if (rs.getRow() != 0)
            {
                vend_codigo = rs.getInt("ven");

                return true;
            }
        }
        catch (SQLException sqlex)
        { System.out.println("Erro: \n" + sqlex.toString()); }
        return false;
    }
    
     public boolean BuscaVendas()
    {
        try
        {
            String query = "select * from vendas where vend_codigo = "+this.vend_codigo;
            ResultSet rs = banco.retornaResultSet(query);
            rs.next();
            if (rs.getRow() != 0)
            {
                this.vend_codigo = rs.getInt("vend_codigo");
                this.vend_data = rs.getDate("vend_data");
                this.vend_valor_total = rs.getDouble("vend_valor_total");
                this.func_codigo = rs.getInt("vend_codigo");
                this.cli_codigo = rs.getInt("cli_codigo");

                return true;
            }
        }
        catch (SQLException sqlex)
        { System.out.println("Erro: \n" + sqlex.toString()); }
        return false;
    }
    
    
    
    
    
    
    public boolean EfetuarVenda()
    {     
        Vector vetor = new Vector();
        try
        {       
            /// Grava Venda inteira. 
            this.strSql = "INSERT INTO vendas(\n" +
            "             vend_data, vend_valor_total, func_codigo, cli_codigo)\n" +
            "    VALUES ( CURRENT_DATE,  "
                           +this.vend_valor_total+" , "
                           +this.func_codigo+ ", "
                           +this.cli_codigo+ " )";
         
                      
           vetor.add(this.strSql);
           banco.executarComandosTransacao(vetor);      
           
           
           UltimaVenda();
           
           /// adiciona cada item da venda  
           if(addItensVenda(vend_codigo))
             return true; 
           
        }catch (Exception ex)
        {
            return false;
        }
              
        System.out.println(this.strSql);
        
       
     
        
        return true; 
    }
    
}