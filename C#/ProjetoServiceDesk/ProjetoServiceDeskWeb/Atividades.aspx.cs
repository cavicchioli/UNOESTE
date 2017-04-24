using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.Controller;

namespace ProjetoServiceDeskWeb
{
    public partial class Atividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Controle.VerificaLogin();

            if (!IsPostBack)
            {
                PreencheSolicitante();
                PreencheStatus();
                PreencheAtividades(int.Parse(Session["codigoFuncionario"].ToString()));
            }
        }

        private void PreencheAtividades(int codigoFuncionario)
        {
            /*====================================================
              * Preencher o GridView gvAtividades com as atividades
              * relativas ao funcionário que está autenticado no
              * sistema.
              *====================================================*/

            //FuncionarioController cr = new FuncionarioController();

            AtividadeController cr = new AtividadeController();
            gvAtividades.DataSource = cr.ObterPorFuncionario(codigoFuncionario);
            //gvAtividades.DataSource = cr.Obter(codigoFuncionario).Atividades;
            gvAtividades.DataBind();
        }

        private void PreencheStatus()
        {
            /*====================================================
             * Preencher o DropDownList ddlStatus com os status
             * disponíveis no banco de dados.
             *====================================================*/

            StatusController cr = new StatusController();
            ddlStatus.DataSource = cr.Obter('T');
            ddlStatus.DataTextField = "Descricao";
            ddlStatus.DataValueField = "Codigo";
            ddlStatus.DataBind();
        }

        private void PreencheSolicitante()
        {
            /*====================================================
             * Preencher o DropDownList ddlSolicitante com os
             * dados dos solicitantes disponíveis no banco de dados.
             *====================================================*/

            SolicitanteController cr = new SolicitanteController();
            ddlSolicitante.DataSource = cr.Obter();
            ddlSolicitante.DataTextField = "Nome";
            ddlSolicitante.DataValueField = "Email";
            ddlSolicitante.DataBind();

        }

        protected void btnCancelarSolicitante_Click(object sender, EventArgs e)
        {
            ucSol.Limpar();
            pnlSolicitante.Visible = false;
        }

        protected void btnGravarSolicitante_Click(object sender, EventArgs e)
        {
            /*=====================================================
             * Gravar um novo solicitante, atualizar o DropDownList
             * ddlSolicitante e fechar o painel que "cuida" da 
             * inserção do novo solicitante.
             * Não esqueça de verificar os itens já implementados
             * no UserControl do solicitante e emitir mensagens de
             * erro caso necessário.
             *=====================================================*/

            if (ucSol.Gravar() > 0)
            {
                PreencheSolicitante();

                lblMensagemSolicitante.Text = string.Empty;
                pnlSolicitante.Visible = !pnlSolicitante.Visible;
            }
            else
                lblMensagem.Text = "Erro ao inserir novo solicitante.";

        }

        protected void btnNovoSolicitante_Click(object sender, ImageClickEventArgs e)
        {
            ucSol.Limpar();
            lblMensagemSolicitante.Text = string.Empty;
            pnlSolicitante.Visible = !pnlSolicitante.Visible;
        }

        /// <summary>
        /// Este método cuida das ações associadas ao GridView
        /// </summary>
        protected void gvAtividades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = int.Parse(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Excluir":
                    //Código necessário para excluir uma determinada atividade
                    AtividadeController cr1 = new AtividadeController();
                    if (cr1.Excluir(codigo) > 0)
                    {
                        PreencheAtividades(int.Parse(Session["codigoFuncionario"].ToString()));
                        btnCancelar_Click(null, null);
                    }
                    else
                        lblMensagem.Text = "Erro ao excluir a atividade.";
                    break;
                case "Finalizar":
                    //Codigo necessário para marcar uma determinada atividade como atendida
                    AtividadeController cr2 = new AtividadeController();
                    Atividade a1 = new AtividadeController().ObterAtividade(codigo);
                    a1.CodigoStatus = 4;

                    if (cr2.Gravar(a1) > 0)
                    {
                        PreencheAtividades(int.Parse(Session["codigoFuncionario"].ToString()));
                        btnCancelar_Click(null, null);
                    }
                    else
                        lblMensagem.Text = "Erro ao finalizar a atividade.";

                    break;
                case "Editar":
                    Atividade a = new AtividadeController().ObterAtividade(codigo); //Necessário desenvolver um método que devolva uma atividade de acordo com o seu código
                    txtDescricao.Text = a.Descricao;
                    txtDataInicio.Text = a.DataInicio.ToShortDateString();
                    txtDataFinal.Text = a.DataFim != null ? ((DateTime)a.DataFim).ToShortDateString() : "";
                    ddlSolicitante.SelectedValue = a.EmailSolicitante;
                    ddlStatus.SelectedValue = a.CodigoStatus.ToString();
                    ViewState["codigoAtividade"] = codigo;
                    break;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;
            ViewState["codigoAtividade"] = null;
            txtDescricao.Text = string.Empty;
            txtDataFinal.Text = string.Empty;
            txtDataFinal.Text = string.Empty;
            ddlStatus.SelectedIndex = -1;
            ddlSolicitante.SelectedIndex = -1;
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            Atividade a = new Atividade();
            a.Codigo = 0;
            if (ViewState["codigoAtividade"] != null) //Cadastro
                a.Codigo = int.Parse(ViewState["codigoAtividade"].ToString());

            a.Descricao = txtDescricao.Text.Trim();
            a.DataInicio = Convert.ToDateTime(txtDataInicio.Text);
            if (txtDataFinal.Text.Trim() == "")
                a.DataFim = null;
            else
                a.DataFim = Convert.ToDateTime(txtDataFinal.Text);
            a.CodigoStatus = short.Parse(ddlStatus.SelectedValue);
            a.CodigoFuncionario = int.Parse(Session["codigoFuncionario"].ToString());
            a.EmailSolicitante = ddlSolicitante.SelectedValue;

            AtividadeController cAtividade = new AtividadeController();
            if (cAtividade.Gravar(a) > 0)
            {
                PreencheAtividades(int.Parse(Session["codigoFuncionario"].ToString()));
                btnCancelar_Click(null, null);
            }
            else
                lblMensagem.Text = "Erro ao inserir/alterar a atividade.";
        }
    }
}