using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebFarmacia2013
{
    public partial class MostrarCompras : System.Web.UI.Page
    {
        clsPedidos objPedidos = new clsPedidos(); 
        DataTable dtPedidos = new DataTable();
        decimal dTotalParcial = 0;
        decimal dTotalGeral = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Popular_GridView(); 
        }

        protected void Popular_GridView()
        {
            dTotalGeral = 0;
            dTotalParcial = 0;
            string sPedido = Session["PEDIDO"].ToString();

            dtPedidos = objPedidos.RecuperarDados(Session["PEDIDO"].ToString()) ; 
            if (dtPedidos.Rows.Count > 0)
            {
                gdvCarrinho.DataSource = dtPedidos;
                gdvCarrinho.DataBind(); 
            }
        }



        protected void gdvCarrinho_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsProdutos objProdutos = new clsProdutos();

            DataTable dtProdutos = new DataTable();

            int iLinhas = 0;

            dtProdutos = objProdutos.RetornaProdutosCompleto(
                        gdvCarrinho.SelectedRow.Cells[1].Text);
            if (dtProdutos.Rows.Count > 0)
            {
                objPedidos.Numero = Session["PEDIDO"].ToString();
                objPedidos.Laboratorio = Convert.ToInt32(dtProdutos.Rows[0]["LABORATORIO"]);
                objPedidos.Medicamento = Convert.ToInt32(dtProdutos.Rows[0]["MEDICAMENTO"]);
                objPedidos.Apresentacao = Convert.ToString(dtProdutos.Rows[0]["APRESENTACAO"]);
                iLinhas = objPedidos.ExcluirPedidos();
                if (iLinhas > 0)
                {
                    Popular_GridView();
                }
                else
                {
                    objPedidos.MostraMensagem("Problemas ao retirar o produto carrinho!", Page); 
                }
            }
        }

        protected void gdvCarrinho_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //linha normal do gridview com dados
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dTotalParcial = dTotalParcial + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PRECOTOTAL"));
                dTotalGeral = dTotalGeral + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PRECOTOTAL"));
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[0].Text = "TOTAL PARCIAL :" +
                            string.Format("{0:C}", dTotalParcial);


                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[3].Text = "TOTAL DO PEDIDO:" +
                            string.Format("{0:C}", dTotalGeral);
                    
                }
            }
 
        }

        protected void imgContinuar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void imgFinalizar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FecharCompras.aspx");
        }
    }
}