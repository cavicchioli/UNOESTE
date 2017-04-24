using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebFarmacia2013
{
    public partial class Default : System.Web.UI.Page
    {
        clsPedidos objPedidos = new clsPedidos();
        clsProdutos objProdutos = new clsProdutos();
        DataTable dtProdutos = new DataTable() ;

        string sSQL, sDescricao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Popular_GridView();
            }
        }
        protected void Popular_GridView()
        {
            //if (Session["ORDEM"] == null)
            //{
            //    Session["ORDEM"] = "ORDER BY DESCRICAO";
            //}
            //gdvProdutos.DataSource = objProdutos.RetornaProdutos(txtPesquisa.Text  ,Session["ORDEM"].ToString());
            //gdvProdutos.DataBind();  
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Popular_GridView();
        }

        protected void gdvProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            sDescricao = gdvProdutos.SelectedRow.Cells[1].Text ;

            dtProdutos = objProdutos.RetornaProdutosCompleto(sDescricao);
            if (dtProdutos.Rows.Count > 0)
            {
                lblLaboratorio.Text = "Laboratório :" + dtProdutos.Rows[0]["LABDESC"].ToString() ;
                lblMedicamento.Text  = "Medicamento :" + dtProdutos.Rows[0]["MEDDESC"].ToString() ;
                lblPreco.Text  = "Preço :" + dtProdutos.Rows[0]["PRECO"].ToString(); 

                lblCodApr.Text =  dtProdutos.Rows[0]["APRESENTACAO"].ToString(); 
                lblCodMed.Text =  dtProdutos.Rows[0]["MEDICAMENTO"].ToString() ;
                lblCodLab.Text = dtProdutos.Rows[0]["LABORATORIO"].ToString();
                lblPreco2.Text = dtProdutos.Rows[0]["PRECO"].ToString();
                lblEstoque.Text = dtProdutos.Rows[0]["ESTOQUE"].ToString(); 
 
            }
   
        }

        protected void imgComprar_Click(object sender, ImageClickEventArgs e)
        {
            int iLinhas = 0;
            if (txtQtd.Text == "")
            {
                return; 
            }

            if (lblCodLab.Text == "")
            {
                return;
            }

            clsCompraFacade novaCompra = new clsCompraFacade();

            if (Session["PEDIDO"] == null)
            {
                Session["PEDIDO"] = Session.SessionID;
                lblID.Text = Session.SessionID;

                iLinhas = novaCompra.Comprar(Convert.ToInt32(lblCodMed.Text), Convert.ToInt32(txtQtd.Text), Session.SessionID, 0);

                if (iLinhas == -1)
                {
                    objProdutos.MostraMensagem("Quantidade maior que o estoque atual !", Page);
                    return;
                }
                else
                    if (iLinhas > 0)
                    {
                        objPedidos.MostraMensagem("Pedido incluido com sucesso!", Page);
                    }
                    else
                    {
                        objPedidos.MostraMensagem("Problemas na inclusão do pedido!", Page);
                    }
            }
            else
            {
                iLinhas = novaCompra.Comprar(Convert.ToInt32(lblCodMed.Text), Convert.ToInt32(txtQtd.Text), Session.SessionID, 1);
                if (iLinhas == -1)
                {
                    objProdutos.MostraMensagem("Quantidade maior que o estoque atual !", Page);
                    return;
                }
                else
                    if (iLinhas > 0)
                    {
                        objPedidos.MostraMensagem("Pedido incluido com sucesso!", Page);
                    }
                    else
                    {
                        objPedidos.MostraMensagem("Problemas na inclusão do pedido!", Page);
                    }
            }

            #region  CODIGO ANTIGO
            ////aqui vamos aplicar facade no estoque
            //if (Convert.ToInt32(txtQtd.Text) > Convert.ToInt32(lblEstoque.Text))
            //{
            //    objProdutos.MostraMensagem("Quantidade maior que o estoque atual !", Page);
            //    return;
            //}


            //if (Session["PEDIDO"] == null)
            //{
            //    Session["PEDIDO"] = Session.SessionID;
            //    lblID.Text = Session.SessionID;
            //    string sData = DateTime.Now.ToShortDateString();

            //    sData = sData.Substring(3, 2) + "/" + sData.Substring(0, 2) + "/" + sData.Substring(6, 4);
            //    objPedidos.Numero = Session.SessionID;
            //    objPedidos.Cliente = 0;
            //    objPedidos.Data = sData;

            //    Prepara_Itens();

            //    iLinhas = objPedidos.IncluirPedidoTransacao();
            //    if (iLinhas > 0)
            //    {
            //        objPedidos.MostraMensagem("Pedido incluido com sucesso!", Page);
            //    }
            //    else
            //    {
            //        objPedidos.MostraMensagem("Problemas na inclusão do pedido!", Page);
            //    }
            //}
            //else
            //{
            //    Prepara_Itens();
            //    iLinhas = objPedidos.IncluirPedidoItensTransacao("X");
            //    if (iLinhas > 0)
            //    {
            //        objPedidos.MostraMensagem("Pedido incluido com sucesso!", Page);
            //    }
            //    else
            //    {
            //        objPedidos.MostraMensagem("Problemas na inclusão do pedido!", Page);
            //    }
            //}
            #endregion
        }

        #region CODIGO ANTIGO
        //protected void Prepara_Itens()
        //{
        //    objPedidos.Numero = Session["PEDIDO"].ToString();
        //    objPedidos.Apresentacao = lblCodApr.Text;
        //    objPedidos.Medicamento= Convert.ToInt32( lblCodMed.Text);
        //    objPedidos.Laboratorio= Convert.ToInt32( lblCodLab.Text);
        //    objPedidos.Apresentacao = lblCodApr.Text;
        //    objPedidos.Quantidade = Convert.ToInt32( txtQtd.Text);
        //    objPedidos.Total = Convert.ToDecimal(lblPreco2.Text) * Convert.ToInt32(txtQtd.Text);     
        //}
        #endregion

        protected void gdvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvProdutos.PageIndex = e.NewPageIndex;
            Popular_GridView(); 
        }

        protected void gdvProdutos_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (Session["ORDEM"] != null)
            {
                if (Session["ASCDESC"] == "A")
                {
                    Session["ASCDESC"] = "D";
                    e.SortDirection = SortDirection.Descending;
                }
                else
                {
                    Session["ASCDESC"] = "A";
                    e.SortDirection = SortDirection.Ascending;
                }
            }
            else
            {
                Session["ASCDESC"] = "A";
                e.SortDirection = SortDirection.Ascending;
            }


            if (Session["ASCDESC"] == "A")
            {
                Session["ORDEM"] = "ORDER BY DESCRICAO  ASC ";
            }
            else
            {
                Session["ORDEM"] = "ORDER BY DESCRICAO  DESC ";
            }

            Popular_GridView();  
        }


        protected void imgCarrinho_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MostrarCompras.aspx");
        }
    }
}