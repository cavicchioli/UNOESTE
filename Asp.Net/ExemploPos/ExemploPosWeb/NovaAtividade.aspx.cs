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
    public partial class NovaAtividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Controle.VerificaLogin();

            if (!IsPostBack)
            {
                ddlHoraInicial.DataSource = ObterHoras();
                ddlHoraInicial.DataBind();

                ddlHoraFinal.DataSource = ObterHoras();
                ddlHoraFinal.DataBind();

                ddlMinutoInicial.DataSource = ObterMinutos();
                ddlMinutoInicial.DataBind();

                ddlMinutoFinal.DataSource = ObterMinutos();
                ddlMinutoFinal.DataBind();

                #region Preenchimento DropDownLists
                StatusControladora cStatus = new StatusControladora();
                DropDownList1.DataSource = cStatus.ObterStatus();
                DropDownList1.DataValueField = "Codigo";
                DropDownList1.DataTextField = "Descricao";
                DropDownList1.DataBind();

                PreencherSolicitante();

                ddlClassificacao.DataSource = new ClassificacaoControladora().ObterClassificacoes();
                ddlClassificacao.DataValueField = "Codigo";
                ddlClassificacao.DataTextField = "Nome";
                ddlClassificacao.DataBind();
                #endregion
            }

            ddlHoraInicial.SelectedValue = DateTime.Now.Hour.ToString();
            ddlHoraFinal.SelectedValue = DateTime.Now.Hour.ToString();
            ddlMinutoInicial.SelectedValue = DateTime.Now.Minute.ToString();
            ddlMinutoFinal.SelectedValue = DateTime.Now.Minute.ToString();
        }

        private void PreencherSolicitante()
        {
            SolicitanteControladora cSol = new SolicitanteControladora();
            ddlSolicitante.DataSource = cSol.ObterSolicitantes();
            ddlSolicitante.DataValueField = "Email";
            ddlSolicitante.DataTextField = "Nome";
            ddlSolicitante.DataBind();
        }

        protected List<int> ObterHoras()
        {
            List<int> h = new List<int>();
            for (int i = 0; i < 24; i++)
                h.Add(i);
            return h;
        }

        protected List<int> ObterMinutos()
        {
            List<int> m = new List<int>();
            for (int i = 0; i < 60; i++)
                m.Add(i);
            return m;
        }

        protected void lbNovo_Click(object sender, EventArgs e)
        {
            pnlNovoSolicitante.Visible = !pnlNovoSolicitante.Visible;
            txtEmail.Text = string.Empty;
            txtNomeSolicitante.Text = string.Empty;
            txtTelefoneSolicitante.Text = string.Empty;
            txtObservacoesSolicitante.Text = string.Empty;
        }

        protected void btnCancelarSolicitante_Click(object sender, EventArgs e)
        {
            pnlNovoSolicitante.Visible = false;
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            DateTime aux = Convert.ToDateTime(txtDtInicio.Text);
            DateTime DataHoraInicial = new DateTime(aux.Year, aux.Month, aux.Day, int.Parse(ddlHoraInicial.SelectedValue), int.Parse(ddlMinutoInicial.SelectedValue), 0);
            DateTime DataHoraFinal = DateTime.MinValue;

            if (txtDtTermino.Text.Trim() != "")
            {
                aux = Convert.ToDateTime(txtDtTermino.Text);
                DataHoraFinal = new DateTime(aux.Year, aux.Month, aux.Day, int.Parse(ddlHoraFinal.SelectedValue), int.Parse(ddlMinutoFinal.SelectedValue), 0);
            }

            Atividade a = new Atividade();
            a.Descricao = txtDescricao.Text;
            a.DataInicio = DataHoraInicial;
            if (DataHoraFinal.Year == 1)
                a.DataFim = null;
            else
                a.DataFim = DataHoraFinal;
            a.CodigoFuncionario = 
                int.Parse(Session["codigoFuncionario"].ToString());
            a.CodigoStatus = short.Parse(DropDownList1.SelectedValue);
            a.EmailSolicitante = ddlSolicitante.SelectedValue;
            a.Classificacao = Session["classificacao"] as List<Classificacao>;
            Session.Remove("classificacao");

            AtividadeControladora cAtividade = new AtividadeControladora();
            if (cAtividade.Gravar(a) > 0)
                Response.Redirect("MinhasAtividades.aspx");
        }

        protected void btnGravarSolicitante_Click(object sender, EventArgs e)
        {
            SolicitanteControladora cSol = new SolicitanteControladora();
            if (cSol.Gravar(new Solicitante
            {
                Email = txtEmail.Text,
                Nome = txtNomeSolicitante.Text,
                Telefone = txtTelefoneSolicitante.Text,
                Observacao = txtObservacoesSolicitante.Text
            }) > 0)
            {
                PreencherSolicitante();
                btnCancelarSolicitante_Click(null, null);
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            ClassificacaoControladora cClassificacao = new ClassificacaoControladora();

            List<Classificacao> lista;
            if (Session["classificacao"] != null)
                lista = Session["classificacao"] as List<Classificacao>;
            else
                lista = new List<Classificacao>();

            lista.Add(cClassificacao.Obter(
                int.Parse(ddlClassificacao.SelectedValue)));

            Session["classificacao"] = lista;

            gvClassificacoes.DataSource = lista;
            gvClassificacoes.DataBind();
        }

        protected void gvClassificacoes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Classificacao> lista = Session["classificacao"] as List<Classificacao>;
            Classificacao c = lista[e.RowIndex];
            lista.Remove(c);

            Session["classificacao"] = lista;

            gvClassificacoes.DataSource = lista;
            gvClassificacoes.DataBind();
        }
    }
}