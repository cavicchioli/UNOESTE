using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExemploPos.Model;
using ExemploPos.Controler;

namespace ExemploPosWeb
{
    public partial class MinhasAtividades : System.Web.UI.Page
    {
        const int numeroRegistroPorPagina = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Controle.VerificaLogin();
            if (!IsPostBack)
                PreparaGridPaginacaoInicial();
        }

        protected void PreparaGridPaginacaoInicial()
        {
            int codigoFuncionario = int.Parse(Session["codigoFuncionario"].ToString());
            AtividadeControladora cAtividade = new AtividadeControladora();

            int numeroPaginas = 1;
            int numeroAtividades = cAtividade.ObterQuantidadeAtividades(codigoFuncionario);
            if (numeroRegistroPorPagina >= numeroAtividades)
                gvAtividades.DataSource = cAtividade.ObterListaAtividades(codigoFuncionario);
            else
            {
                if (numeroAtividades % numeroRegistroPorPagina > 0)
                    numeroPaginas = ((int)numeroAtividades / numeroRegistroPorPagina) + 1;
                else
                    numeroPaginas = ((int)numeroAtividades / numeroRegistroPorPagina);

                gvAtividades.DataSource = cAtividade.ObterListaAtividades(codigoFuncionario, 1, numeroRegistroPorPagina);
            }
            for (int i = 1; i <= numeroPaginas; i++)
                ddlPagina.Items.Add(i.ToString());
            gvAtividades.DataBind();
        }

        protected void gvAtividades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                switch (e.Row.Cells[4].Text)
                {
                    case "Agendado":
                        e.Row.BackColor = System.Drawing.Color.LightYellow;
                        break;
                    case "Em andamento":
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case "Cancelado":
                        e.Row.BackColor = System.Drawing.Color.LightSalmon;
                        break;
                    case "Atendido":
                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    default:
                        e.Row.BackColor = System.Drawing.Color.LightGray;
                        break;
                }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlDetalhes.Visible = false;
        }

        protected void gvAtividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDetalhes.Visible = true;
            int codigo = int.Parse(gvAtividades.SelectedValue.ToString());
            AtividadeControladora cAtividade = new AtividadeControladora();
            Atividade a = cAtividade.Obter(codigo);

            lblID.Text = a.Codigo.ToString();
            lblDescricao.Text = a.Descricao;
            lblInicio.Text = a.DataInicio.ToString();
            lblTermino.Text = a.DataFim.ToString();
            lblSolicitante.Text = a.Solicitante.Nome;
            lblStatus.Text = a.Status.Descricao;

            foreach (Classificacao c in a.Classificacao)
            {
                lblClassificacao.Text += "<br/>" + c.Nome;
            }
        }

        protected void PaginacaoGrid(int codigoFuncionario, int numeroPagina)
        {
            AtividadeControladora cAtividade = new AtividadeControladora();
            gvAtividades.DataSource = cAtividade.ObterListaAtividades(codigoFuncionario, numeroPagina, numeroRegistroPorPagina);
            gvAtividades.DataBind();
        }

        protected void ddlPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaginacaoGrid(int.Parse(Session["codigoFuncionario"].ToString()), int.Parse(ddlPagina.SelectedValue));
        }

        protected void lbAnterior_Click(object sender, EventArgs e)
        {
            if (ddlPagina.SelectedIndex >= 1)
            {
                ddlPagina.SelectedIndex--;
                ddlPagina_SelectedIndexChanged(null, null);
            }
        }

        protected void lbProxima_Click(object sender, EventArgs e)
        {
            int maximo = ddlPagina.Items.Count - 1;
            if (ddlPagina.SelectedIndex < maximo)
            {
                ddlPagina.SelectedIndex++;
                ddlPagina_SelectedIndexChanged(null, null);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            AtividadeControladora cAtividade = new AtividadeControladora();
            int codigo = int.Parse(lblID.Text);
            if (cAtividade.Excluir(codigo) > 0)
            {
                btnCancelar_Click(null, null);
                PaginacaoGrid(int.Parse(Session["codigoFuncionario"].ToString()), int.Parse(ddlPagina.SelectedValue));
            }
        }
    }
}