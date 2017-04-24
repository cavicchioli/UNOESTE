/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CamadaNegocio;

import CamadaLogica.BancoDados;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;

/**
 *
 * @author Rafael
 */
public class Vendas_produtos {
    
    private BancoDados banco = new BancoDados();
    
    private int vend_cod; 
    private int prod_codigo;
    private int vendprod_quantidade; 
    private double vendprod_valor; 

    public int getProd_codigo() {
        return prod_codigo;
    }
    
    
    
    private String strSql = ""; 

    public int getVend_cod() {
        return vend_cod;
    }

    public void setVend_cod(int vend_cod) {
        this.vend_cod = vend_cod;
    }

    public int getVendprod_quantidade() {
        return vendprod_quantidade;
    }

    public void setVendprod_quantidade(int vendprod_quantidade) {
        this.vendprod_quantidade = vendprod_quantidade;
    }

    public double getVendprod_valor() {
        return vendprod_valor;
    }

    public void setVendprod_valor(double vendprod_valor) {
        this.vendprod_valor = vendprod_valor;
    }

    
      
    
    public  ResultSet BuscaItensVendas(int venda)
    {    
        BancoDados bd = new BancoDados();
        String query = "select *  from vendas_produtos where vend_codigo = " + venda;            
        return bd.retornaResultSet(query);
    }
    
    
    public Vendas_produtos(int vend_cod, int prod_codigo, int vendprod_quantidade, double vendprod_valor) {
        this.vend_cod = vend_cod;
        this.prod_codigo = prod_codigo;
        this.vendprod_quantidade = vendprod_quantidade;
        this.vendprod_valor = vendprod_valor;
    }

    public Vendas_produtos() {
    }
    
    public boolean GravaItem()
    {
        Vector vetor = new Vector();
        try
        {       
            this.strSql = "INSERT INTO vendas_produtos(\n" +
        "            vend_codigo, prod_codigo, vendprod_quantidade, vendprod_valor)\n" +
        "    VALUES ("+this.vend_cod+", "
                      +this.prod_codigo+", "
                      +this.vendprod_quantidade+", "
                      +this.vendprod_valor+")";       
                      
           vetor.add(this.strSql);
           banco.executarComandosTransacao(vetor);  
           
           /// BAIXA NO STOQUE ut
           
           return true; 
           
        }catch (Exception ex)
        {
            return false;
        }
    }
    
    
}
