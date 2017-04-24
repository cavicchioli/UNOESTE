using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoAcademicas
{
    public partial class CadDiscAluno : System.Web.UI.Page
    {
        clsDiscAluno objDiscAluno = new clsDiscAluno();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void limpaCampos()
        {
            ddlAluno.SelectedIndex = 0;
            ddlDisciplina.SelectedIndex = 0;
            txtNota1b.Text = "";
            txtNota2b.Text = "";
            txtSemestre.Text = "";
            txtTurma.Text = "";
        }

        private void preparaDados()
        {
            objDiscAluno.Disc_codigo = Convert.ToInt32(ddlDisciplina.SelectedValue);
            objDiscAluno.Aluno_ra = Convert.ToInt32(ddlAluno.SelectedValue);
            try{objDiscAluno.Nota1b = Convert.ToSingle(txtNota1b.Text);}
            catch(Exception){objDiscAluno.Nota1b = 0;}
            try { objDiscAluno.Nota2b = Convert.ToSingle(txtNota2b.Text); }
            catch(Exception){objDiscAluno.Nota2b = 0;}
            objDiscAluno.Turma = txtTurma.Text;
            objDiscAluno.Semestre = Convert.ToChar(txtSemestre.Text);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            if (!ddlDisciplina.SelectedValue.Equals("1"))
            {
                if (!ddlAluno.SelectedValue.Equals("1"))
                {
                    if (txtNota1b.Text != null && txtNota1b.Text != "")
                    {
                        
                        if (txtTurma.Text != null && txtTurma.Text != "")
                        {
                            if (txtSemestre.Text != null && txtSemestre.Text != "")
                            {
                                preparaDados();
                                iLinhas = objDiscAluno.IncluirDiscAluno();
                                if (iLinhas > 0)
                                {
                                    btnCancelar_Click(sender, e);
                                    objDiscAluno.MostraMensagem("Dados cadastro com sucesso!", Page);
                                }
                                else
                                    objDiscAluno.MostraMensagem("Erro ao cadastrar os dados!", Page);
                                    
                            }
                            else
                            {
                                txtSemestre.Focus();
                                objDiscAluno.MostraMensagem("Campo Semestre não preenchido!", Page);
                            }
                        }
                        else
                        {
                            txtTurma.Focus();
                            objDiscAluno.MostraMensagem("Campo Turma não preenchido!", Page);
                        }
                    }
                    else
                    {
                        txtNota1b.Focus();
                        objDiscAluno.MostraMensagem("Campo Nota 1ºB não preenchido!", Page);
                    }
                }
                else
                {
                    ddlAluno.Focus();
                    objDiscAluno.MostraMensagem("Aluno não Selecionado!", Page);
                }
            }
            else
            {
                ddlDisciplina.Focus();
                objDiscAluno.MostraMensagem("Disciplina não Selecionada!", Page);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            if (!ddlDisciplina.SelectedValue.Equals("1"))
            {
                if (!ddlAluno.SelectedValue.Equals("1"))
                {
                    if (txtNota1b.Text != null && txtNota1b.Text != "")
                    {
                        if (txtNota2b.Text != null && txtNota2b.Text != "")
                        {
                            if (txtTurma.Text != null && txtTurma.Text != "")
                            {
                                if (txtSemestre.Text != null && txtSemestre.Text != "")
                                {
                                    preparaDados();
                                    iLinhas = objDiscAluno.AlterarDiscAluno();
                                    if (iLinhas > 0)
                                    {
                                        btnCancelar_Click(sender, e);
                                        objDiscAluno.MostraMensagem("Dados Alterados com sucesso!", Page);
                                    }
                                    else
                                        objDiscAluno.MostraMensagem("Erro ao Alterar os dados!", Page);

                                }
                                else
                                {
                                    txtSemestre.Focus();
                                    objDiscAluno.MostraMensagem("Campo Semestre não preenchido!", Page);
                                }
                            }
                            else
                            {
                                txtTurma.Focus();
                                objDiscAluno.MostraMensagem("Campo Turma não preenchido!", Page);
                            }
                        }
                        else
                        {
                            txtNota2b.Focus();
                            objDiscAluno.MostraMensagem("Campo Nota 2ºB não preenchido!", Page);
                        }
                    }
                    else
                    {
                        txtNota1b.Focus();
                        objDiscAluno.MostraMensagem("Campo Nota 1ºB não preenchido!", Page);
                    }
                }
                else
                {
                    ddlAluno.Focus();
                    objDiscAluno.MostraMensagem("Aluno não Selecionado!", Page);
                }
            }
            else
            {
                ddlDisciplina.Focus();
                objDiscAluno.MostraMensagem("Disciplina não Selecionada!", Page);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            preparaDados();
            iLinhas = objDiscAluno.ExcluirDiscAluno();
            if (iLinhas > 0)
            {
                btnCancelar_Click(sender,e);
                objDiscAluno.MostraMensagem("Dados Excluidos com sucesso!",Page);
            }
            else
                objDiscAluno.MostraMensagem("Erro ao Excluir os dados!", Page);

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            gdwDiscAluno.DataSource = objDiscAluno.Popula_Gridview(txtPesquisa.Text);
            gdwDiscAluno.DataBind();
        }

        protected void gdwDiscAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            String disc,alun;
            
            disc = objDiscAluno.PegaDisc_Codigo(gdwDiscAluno.SelectedRow.Cells[1].Text);
            alun = objDiscAluno.PegaAluno_RA(gdwDiscAluno.SelectedRow.Cells[2].Text);
            
            ddlDisciplina.Items.FindByValue(disc).Selected = true;
            ddlAluno.Items.FindByValue(alun).Selected = true;
            
            objDiscAluno.Disc_codigo = Convert.ToInt32(disc);
            objDiscAluno.Aluno_ra = Convert.ToInt32(alun);
            objDiscAluno.RecuperarDados();


            txtNota1b.Text = Convert.ToString(objDiscAluno.Nota1b);
            txtNota2b.Text = Convert.ToString(objDiscAluno.Nota2b);
            txtTurma.Text = objDiscAluno.Turma;
            txtSemestre.Text = Convert.ToString(objDiscAluno.Semestre);

            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            //volta para a aba dos dados
            TabContainer1.ActiveTabIndex = 0;
            txtNota1b.Focus();
        }

        protected void gdwDiscAluno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdwDiscAluno.PageIndex = e.NewPageIndex;
            btnPesquisar_Click(sender, e);
        }

        
    }
}