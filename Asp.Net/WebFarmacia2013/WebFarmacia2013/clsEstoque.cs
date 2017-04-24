using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebFarmacia2013
{
    public class clsEstoque : clsBanco
    {
        private int _codigoProduto;
        private int _quantidadeProduto;

        public int CodigoProduto
        {
            get { return _codigoProduto; }
            set { _codigoProduto = value; }
        }

        public int QuantidadeProduto
        {
            get { return _quantidadeProduto; }
            set {  _quantidadeProduto = value; }
        }

        public clsEstoque(int codigo, int qtde)
        {
            _codigoProduto = codigo;
            _quantidadeProduto = qtde;
        }

        public DataTable retornaSaldoEstoque()
        {           
            string sql = "";
            
            DataTable dt = new DataTable();

            sql = "select estoque from Produtos where medicamento ="+_codigoProduto;

            dt=RetornaDT(sql);

            return dt;
        }

        public int decrementaSaldoEstoque(int saldo)
        {
            string sql = "";
            int saldoNovo = saldo - _quantidadeProduto;

            sql = "update Produtos  set estoque="+saldoNovo+" where medicamento ="+_codigoProduto;

            return ExecutarSQL(sql);

        }

        public bool verificaSaldo()
        {
            bool flag = true;
            int saldo;
            DataTable dt = new DataTable();

            dt = retornaSaldoEstoque();

            if (dt.Rows.Count > 0)
            {
                saldo = Convert.ToInt32(dt.Rows[0]["estoque"]);

                if (saldo < _quantidadeProduto)
                {
                    flag = false;
                }
                else
                    decrementaSaldoEstoque(saldo);
            }
            
            return flag;
        }
    }
}