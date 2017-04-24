using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace InfoAcademicas
{
    public partial class CadDisc : System.Web.UI.Page
    {
        DataSet dataSet = new DataSet(); //instanciando a classe dataSet para manipular e popular o gridview.
        clsDisciplina objDisciplina = new clsDisciplina();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void limpaCampos()
        {
            txtDisciplina.Text = "";
        }

        public void preparaDados()
        {
            objDisciplina.Disc_codigo = Convert.ToInt32(Session["codigo"]);
            objDisciplina.Disc_nome = txtDisciplina.Text;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            
            preparaDados();
            if (objDisciplina.Disc_nome != "" && objDisciplina.Disc_nome != null)
            {

                iLinhas = objDisciplina.IncluirDisciplina();
                if (iLinhas > 0)
                {
                    btnCancelar_Click(sender, e);
                    objDisciplina.MostraMensagem("Dados Cadastrados com Sucesso!!!", Page);
                }
                else
                    objDisciplina.MostraMensagem("Erro ao cadastrar disciplina", Page);
            }
            else
            {
                objDisciplina.MostraMensagem("Campo Disciplina não preenchido!",Page);
                txtDisciplina.Focus();
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            preparaDados();
            iLinhas = objDisciplina.AlterarDisciplina();
            if (iLinhas > 0)
            {
                btnPesquisar_Click(sender, e);
                btnCancelar_Click(sender, e);
                objDisciplina.MostraMensagem("Dados Alterados com Sucesso!!!", Page);
            }
            else
                objDisciplina.MostraMensagem("Erro ao Alterar a disciplina", Page);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            preparaDados();
            iLinhas = objDisciplina.ExcluirDisciplina();
            if (iLinhas > 0)
            {
                btnPesquisar_Click(sender, e);
                btnCancelar_Click(sender, e);
                objDisciplina.MostraMensagem("Dados Excluidos com Sucesso!!!", Page);
            }
            else
                objDisciplina.MostraMensagem("Erro ao Excluir a disciplina", Page);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            objDisciplina.Popula_Gridview(txtPesquisa.Text);
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            gdwDisciplinas.DataSource = objDisciplina.Popula_Gridview(txtPesquisa.Text);
            gdwDisciplinas.DataBind();
        }

        protected void gdwDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["codigo"] = Convert.ToInt32(gdwDisciplinas.SelectedRow.Cells[1].Text);
            objDisciplina.Disc_codigo = Convert.ToInt32(Session["codigo"]);
            objDisciplina.RecuperarDados();

            txtDisciplina.Text = objDisciplina.Disc_nome;
                
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            //volta para a aba dos dados
            TabContainer1.ActiveTabIndex = 0;
            txtDisciplina.Focus();
        }

        protected void gdwDisciplinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdwDisciplinas.PageIndex = e.NewPageIndex;
            btnPesquisar_Click(sender, e);
        }
    }
}