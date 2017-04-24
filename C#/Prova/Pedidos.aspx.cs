using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Prova
{
    public partial class Pedidos : System.Web.UI.Page
    {
        decimal estoque = 0;
        clsPedidos objPedido = new clsPedidos();
        clsBanco objBanco = new clsBanco();
        clsProdutos objProduto = new clsProdutos();

        protected void Page_Load(object sender, EventArgs e)
        {
            Popular_GridView();
        }

        protected void Popular_GridView()
        {
            string sSQL = "SELECT * FROM PRODUTOS ";

            DataSet dsProdutos = new DataSet();
            dsProdutos = objBanco.RetornaDS(sSQL);


            if (dsProdutos.Tables[0].Rows.Count > 0)
            {
                gdvProdutos.DataSource = dsProdutos;
                gdvProdutos.DataBind();
            }

            sSQL = "SELECT PEDIDOSITENS.*, CODIGO AS DESCRICAO FROM PEDIDOSITENS";


            DataSet dsProdutos2 = new DataSet();
            dsProdutos2 = objBanco.RetornaDS(sSQL);

            gdvPedidos.DataSource = dsProdutos2;
            gdvPedidos.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void PreparaDados()
        {
            objProduto.Codigo = Convert.ToInt32(lblCodigo.Text);
            objProduto.Descricao = lblDescricao.Text;
            objProduto.Preco = Convert.ToDecimal(lblPreco.Text);
            objProduto.Estoque = estoque;
        }

        protected void gdvProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCodigo.Text = objProduto.RetornaCodProduto(gdvProdutos.Rows[gdvProdutos.SelectedRow.RowIndex].Cells[1].Text).ToString();
            lblDescricao.Text = gdvProdutos.Rows[gdvProdutos.SelectedRow.RowIndex].Cells[1].Text;
            lblPreco.Text = gdvProdutos.Rows[gdvProdutos.SelectedRow.RowIndex].Cells[2].Text;

        }

        protected void Prepara_Itens()
        {
            objPedido.Numero = Session["PEDIDO"].ToString();
            objPedido.Quantidade = Convert.ToInt32(txtQtd.Text);
            objPedido.Total = Convert.ToDecimal(lblPreco.Text) * Convert.ToInt32(txtQtd.Text);
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            if (txtQtd.Text == "")
            {
                return; 
            }

            if (lblCodigo.Text == "")
            {
                return;
            }

            estoque = Convert.ToDecimal(gdvProdutos.Rows[gdvProdutos.SelectedRow.RowIndex].Cells[3].Text);
            if (Convert.ToInt32(txtQtd.Text) > Convert.ToInt32(estoque))
            {
                objBanco.MostraMensagem("Quantidade maior que o estoque atual !", Page);
                return;
            }

            if (Session["PEDIDO"] == null)
            {
                Session["PEDIDO"] = Session.SessionID;

                string sData = DateTime.Now.ToShortDateString();

                sData = sData.Substring(3, 2) + "/" + sData.Substring(0, 2) + "/" + sData.Substring(6, 4); 
                
                objPedido.Numero = Session.SessionID;
                objPedido.Cliente = 0;
                objPedido.Data = sData;

                Prepara_Itens();

                iLinhas = objPedido.IncluirPedido();
                if (iLinhas > 0)
                {
                    objPedido.MostraMensagem("Pedido incluido com sucesso!", Page);
                }
                else
                {
                    objPedido.MostraMensagem("Problemas na inclusão do pedido!", Page);
                }
            }
            else
            {
                Prepara_Itens();
                iLinhas = objPedido.IncluirPedidoItens("X");
                if (iLinhas > 0)
                {
                    objPedido.MostraMensagem("O pedido foi incluido!", Page);
                }
                else
                {
                    objPedido.MostraMensagem("Problemas na inclusão do pedido!", Page);
                }
            }
        
        }

        protected void gdvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProdutos.PageIndex = e.NewPageIndex;
            Popular_GridView(); 
        }

        protected void gdvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPedidos.PageIndex = e.NewPageIndex;
            Popular_GridView(); 
        }

        protected void gdvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPedido.Numero = Session.SessionID;
            objPedido.Quantidade = Convert.ToInt32(gdvPedidos.Rows[gdvPedidos.SelectedRow.RowIndex].Cells[3].Text);
            objPedido.Total = Convert.ToDecimal(gdvPedidos.Rows[gdvPedidos.SelectedRow.RowIndex].Cells[4].Text);

            objPedido.ExcluirPedidoItens();
            Popular_GridView();
            
        }
    }
}