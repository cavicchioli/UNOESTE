using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 

namespace Prova
{
    public class clsProdutos: clsBanco 
    {
        //tb produto
        private Int32 _codigo;
        private string _descricao;
        private decimal _preco;
        private decimal _estoque;

        public Int32 Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        public decimal Estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }

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

        public int RetornaCodProduto(string sDescricao)
        {
            DataTable dtProdutos = new DataTable();
             DataSet dsProdutos = new DataSet();
             string sSQL = "SELECT CODIGO FROM PRODUTOS " +
                 " WHERE DESCRICAO ='" + sDescricao+"'";

             dtProdutos = RetornaDT(sSQL);

             if (dtProdutos.Rows.Count > 0)
             {
                 return Convert.ToInt32(dtProdutos.Rows[0]["CODIGO"].ToString());
             }
             return 1;
        }
    }
}