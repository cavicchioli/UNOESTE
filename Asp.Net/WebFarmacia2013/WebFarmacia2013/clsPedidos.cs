using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebFarmacia2013
{
    public class clsPedidos: clsBanco
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private Int32 _cliente;

        public Int32 Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        private string _data;

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private Int32 _laboratorio;

        public Int32 Laboratorio
        {
            get { return _laboratorio; }
            set { _laboratorio = value; }
        }
        private Int32 _medicamento;

        public Int32 Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }
        private string _apresentacao;

        public string Apresentacao
        {
            get { return _apresentacao; }
            set { _apresentacao = value; }
        }
        private Int32 _quantidade;

        public Int32 Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public clsPedidos()
        {
           
        }

        public clsPedidos(string session, int codPro, int qtd)
        {
            string sData = DateTime.Now.ToShortDateString();
            sData = sData.Substring(3, 2) + "/" + sData.Substring(0, 2) + "/" + sData.Substring(6, 4);

            _data = sData;
            _cliente = 0;
            _numero = session;
            _medicamento = codPro;
            _quantidade = qtd;

            PreparaPedido(codPro);
        }

        public int IncluirPedidoTransacao()
        {
            int iLinhas = 0;
            string sSQL = "";

            if (ConectaBancoTransacao())
            {
                sSQL = "INSERT INTO PEDIDOS (NUMPEDIDO, CODCLIENTE, DATA) VALUES(" +
                    "'" + _numero + "'," +
                    _cliente + "," +
                    "'" + _data + "')";

                iLinhas = ExecutaSQLTransacao(sSQL);
                if (iLinhas > 0)
                {
                    iLinhas = IncluirPedidoItensTransacao("T");
                    if (iLinhas > 0)
                    {
                        ExecutaCommit();
                    }
                    else
                    {
                        ExecutaRoolback(); 
                    }
                }
            }
            DesconectaBanco(); 
            return iLinhas;
        }

        public int IncluirPedidoItensTransacao(string sTipo)
        {
            DataTable dtPedidos = new DataTable();

            int iLinhas = 0;
            string sSQL = " SELECT * FROM PEDIDOSITENS " +
                " WHERE NUMPEDIDO ='" + _numero + "'" +
                " AND   LABORATORIO = " + _laboratorio +
                " AND   MEDICAMENTO = " + _medicamento +
                " AND   APRESENTACAO = '" + _apresentacao + "'";
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
                    " AND   LABORATORIO = " + _laboratorio +
                    " AND   MEDICAMENTO = " + _medicamento +
                    " AND   APRESENTACAO ='" + _apresentacao + "'";
            }
            else
            {
                sSQL = "INSERT INTO PEDIDOSITENS (NUMPEDIDO, LABORATORIO, " +
                    " MEDICAMENTO, APRESENTACAO, QUANTIDADE, PRECOTOTAL) VALUES (" +
                    "'" + _numero + "'," +
                    _laboratorio + "," +
                    _medicamento + "," +
                    "'" + _apresentacao + "'," +
                    _quantidade + "," +
                    _total.ToString().Replace(",", ".") + ")";   
            }
            if (sTipo == "T")
            {
                iLinhas = ExecutaSQLTransacao(sSQL);
            }
            else
            {
                iLinhas = ExecutarSQL(sSQL); 
            }
            dtPedidos.Dispose();
            return iLinhas; 
        }

        public int ExcluirPedidos()
        {
            int iLinhas = 0;
            string sSQL = "DELETE FROM PEDIDOSITENS " +
                        " WHERE NUMPEDIDO ='" + _numero + "'" +
                        " AND   LABORATORIO = " + _laboratorio +
                        " AND   MEDICAMENTO = " + _medicamento +
                        " AND   APRESENTACAO ='" + _apresentacao + "'";
            iLinhas = ExecutarSQL(sSQL);  

            return iLinhas; 
        }

        public double TotalizaPedido()
        {
            DataTable dtPedidos = new DataTable();
            double dTotal = 0;
            string sSQL = "SELECT COALESCE(SUM(PRECOTOTAL), 0) AS TOTAL FROM PEDIDOSITENS" +
                        " WHERE NUMPEDIDO ='" + _numero + "'";
            dtPedidos = RetornaDT(sSQL);
            if (dtPedidos.Rows.Count > 0)
            {
                dTotal = Convert.ToDouble(dtPedidos.Rows[0]["TOTAL"]);    
            }
            return dTotal;
        }

        public DataTable RecuperarDados(string sPedido)
        {
            _numero = sPedido;
            DataTable dtPedidos = new DataTable();
            string sSQL = "SELECT DESCRICAO, QUANTIDADE, PRECOTOTAL " +
                        " FROM PEDIDOSITENS, PRODUTOS " + 
                        " WHERE NUMPEDIDO ='" + _numero + "'" +
                        " AND   PRODUTOS.LABORATORIO = PEDIDOSITENS.LABORATORIO " +
                        " AND   PRODUTOS.MEDICAMENTO = PEDIDOSITENS.MEDICAMENTO " +
                        " AND   PRODUTOS.APRESENTACAO = PEDIDOSITENS.APRESENTACAO ";
           dtPedidos = RetornaDT(sSQL);
           return dtPedidos;
        }

        public int FecharPedido()
        {
            int iLinhas = 0;
            string sSQL = "UPDATE PEDIDOS SET CODCLIENTE = " + _cliente + 
                " WHERE NUMPEDIDO = '" + _numero + "'";
            iLinhas = ExecutarSQL(sSQL);  
            return iLinhas;
        }

        public void PreparaPedido(int codProd)
        {
            DataTable dt = new DataTable();
            string sSQL ="SELECT APRESENTACAO, LABORATORIO, PRECO " +
                        " FROM PRODUTOS " +
                        " WHERE MEDICAMENTO ='" + codProd + "'";
            dt = RetornaDT(sSQL);

            _apresentacao = (dt.Rows[0]["apresentacao"]).ToString();
            _laboratorio = Convert.ToInt32(dt.Rows[0]["laboratorio"]);
            _total = Convert.ToDecimal(dt.Rows[0]["preco"])*_quantidade;
        }
    }
}