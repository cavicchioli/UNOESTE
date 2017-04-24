using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebFarmacia2013
{
    public class clsCompraFacade
    {
        private int _codigoProduto;
        private int _quantidadeEstoque;
        private string _sessionCompra;

        public int CodigoProduto
        {
            get { return _codigoProduto; }
            set { _codigoProduto = value; }
        }

        public int QuantidadeEstoque
        {
            get { return _quantidadeEstoque; }
            set { _quantidadeEstoque = value; }
        }

        public string SessionCompra
        {
            get { return _sessionCompra; }
            set { _sessionCompra = value; }
        }

        public int Comprar(int codProduto, int qtdProduto, string sessionCompra, int flag)
        {
            int iLinhas=0;
            clsEstoque Estoque = new clsEstoque(codProduto, qtdProduto);
            clsPedidos Pedido;

            //aqui vamos aplicar facade no estoque
            if (!Estoque.verificaSaldo())
              return -1;

            Pedido = new clsPedidos(sessionCompra, codProduto, qtdProduto);

            if (flag==0)
                iLinhas = Pedido.IncluirPedidoTransacao();
            else
               iLinhas = Pedido.IncluirPedidoItensTransacao("X");

            return iLinhas;
        }
    }
}