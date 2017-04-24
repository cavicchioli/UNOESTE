using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Prova
{
    public class clsPedidos: clsBanco
    {
        //tb pedido
        private string _numero;
        private Int32 _cliente;
        private string _data;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }    
        public Int32 Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }  
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        //tb pedidos itens
        private Int32 _quantidade;
        private decimal _total;
        private decimal _vlrUnit;
        private Int32 _codProduto;

        public Int32 Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public decimal ValorUnit
        {
            get { return _vlrUnit; }
            set { _vlrUnit = value; }
        }
        public Int32 Produto
        {
            get { return _codProduto; }
            set { _codProduto = value; }
        }

        public int IncluirPedido()
        {
            int iLinhas = 0;
            string sSQL = "";

            if (ConectaBanco())
            {
                sSQL = "INSERT INTO PEDIDOS (NUMPEDIDO, CLIENTE, DATA) VALUES(" +
                    "'" + _numero + "'," +
                    _cliente + "," +
                    "'" + _data + "')";

                iLinhas = ExecutarSQL(sSQL);
                if (iLinhas > 0)
                {
                    iLinhas = IncluirPedidoItens("T");
                }
            }
            DesconectaBanco();
            return iLinhas;
        }

        public int IncluirPedidoItens(string sTipo)
        {
            DataTable dtPedidos = new DataTable();

            int iLinhas = 0;
            string sSQL = " SELECT * FROM PEDIDOSITENS " +
                " WHERE NUMPEDIDO ='" + _numero + "'" +
                " AND   QUANTIDADE = " + _quantidade +
                " AND   VALORUNIT = " + _vlrUnit +
                " AND   VALORTOTAL = '" + _total + "'";
            if (sTipo == "T")
            {
                dtPedidos = RetornaDTTransacao(sSQL);
            }
            else
            {
                dtPedidos = RetornaDT(sSQL);
            }
            if (dtPedidos.Rows.Count > 0)
            {
                _total = _total + Convert.ToDecimal(dtPedidos.Rows[0]["PRECOTOTAL"]);
                _quantidade = _quantidade + Convert.ToInt32(dtPedidos.Rows[0]["QUANTIDADE"]);

                sSQL = "UPDATE PEDIDOSITENS SET " +
                    " QUANTIDADE = " + _quantidade + "," +
                    " PRECOTOTAL = " + _total.ToString().Replace(",", ".") +
                    " WHERE NUMPEDIDO ='" + _numero + "'" +
                    " AND   CODIGO = " + _codProduto +
                    " AND   VALORUNIT ='" + _vlrUnit + "'";
            }
            else
            {
                sSQL = "INSERT INTO PEDIDOSITENS (NUMPEDIDO, CODIGO, " +
                   " QUANTIDADE, VALORUNIT, VALORTOTAL) VALUES (" +
                   "'" + _numero + "'," +
                   _codProduto + "," +
                   _quantidade + "," +
                   "'" + _vlrUnit + "'," +
                   _total + ")";
            }
            if (sTipo == "T")
            {
                iLinhas = ExecutarSQL(sSQL);
            }
            else
            {
                iLinhas = ExecutarSQL(sSQL);
            }
            dtPedidos.Dispose();
            return iLinhas;
        }

        public int ExcluirPedidoItens()
        {
            int iLinhas = 0;
            string sSQL = "DELETE FROM PEDIDOSITENS " +
                        " WHERE NUMPEDIDO ='"+ _numero+"'";
                        
            iLinhas = ExecutarSQL(sSQL);  

            return iLinhas; 
        }

        public DataTable RecuperarDados(string sPedido)
        {
            _numero = sPedido;
            DataTable dtPedidos = new DataTable();
            string sSQL = "SELECT DESCRICAO, QUANTIDADE, VALORTOTAL " +
                        " FROM PEDIDOSITENS, PRODUTOS " + 
                        " WHERE NUMPEDIDO ='" + _numero + "'";

           dtPedidos = RetornaDT(sSQL);
           return dtPedidos;
        }
    }
}