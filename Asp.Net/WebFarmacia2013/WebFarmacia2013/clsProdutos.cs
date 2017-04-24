using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 

namespace WebFarmacia2013
{
    public class clsProdutos: clsBanco 
    {
        public DataSet RetornaProdutos(string sDescricao, string sOrdem)
        {
            DataSet dsProdutos = new DataSet();
            string sSQL = "SELECT DESCRICAO, PRECO, ESTOQUE, FOTO FROM PRODUTOS " +
                " WHERE DESCRICAO LIKE '%" + sDescricao + "%'" +
                " AND   ESTOQUE  > 0 " +
                sOrdem;
            dsProdutos = RetornaDS(sSQL);

            return dsProdutos; 
        }

        public DataTable RetornaProdutosCompleto(string sDescricao)
        {
            DataTable dtProdutos = new DataTable();

            string sSQL = "SELECT PRODUTOS.PRECO, PRODUTOS.ESTOQUE, PRODUTOS.FOTO, " +
                " PRODUTOS.LABORATORIO, PRODUTOS.MEDICAMENTO, PRODUTOS.APRESENTACAO, " +
                " LABORATORIOS.DESCRICAO AS LABDESC, MEDICAMENTOS.DESCRICAO AS MEDDESC, APRESENTACOES.DESCRICAO APRDESC" +
                " FROM PRODUTOS, LABORATORIOS, MEDICAMENTOS, APRESENTACOES " +
                " WHERE PRODUTOS.DESCRICAO = '" + sDescricao + "'" +
                " AND   PRODUTOS.LABORATORIO = LABORATORIOS.CODIGO " +
                " AND   PRODUTOS.MEDICAMENTO = MEDICAMENTOS.CODIGO " +
                " AND   PRODUTOS.APRESENTACAO = APRESENTACOES.CODIGO ";

            dtProdutos = RetornaDT(sSQL);

            return dtProdutos;
        }
    }
}