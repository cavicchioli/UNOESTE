using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoAcademicas
{
    public partial class CadAluno : System.Web.UI.Page
    {
        clsAluno objAluno = new clsAluno();
        String nomefoto,urlFoto;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limpaCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            imgFoto.ImageUrl = "";
        }

        protected void preparaDados()
        {
            objAluno.Aluno_RA = Convert.ToInt32(Session["codigo"]);
            objAluno.Aluno_nome = txtNome.Text;
            objAluno.Aluno_email = txtEmail.Text;
            objAluno.Aluno_foto = imgFoto.ImageUrl;
        }

        
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            
            if (txtNome.Text != null && txtNome.Text != "")
            {
                if (txtEmail.Text != null && txtEmail.Text != "")
                {
                    if (imgFoto.ImageUrl == "")
                        urlFoto = null;
                    else
                    {
                        int p = objAluno.proximoCodigo();
                        nomefoto = p + txtNome.Text +".jpg";
                        urlFoto = @"~\\Imagens\" + nomefoto;
                    }

                    preparaDados();
                    iLinhas = objAluno.IncluirAluno();
                    if (iLinhas > 0)
                    {
                        btnCancelar_Click(sender, e);
                        objAluno.MostraMensagem("Dados Cadastrados com Sucesso!!!", Page);    
                    }
                    else
                        objAluno.MostraMensagem("Erro ao cadastrar disciplina", Page);
                }
                else
                {
                    objAluno.MostraMensagem("E-mail não informado!", Page);
                    txtEmail.Focus();
                }
            }
            else
            {
                objAluno.MostraMensagem("Nome não informado!", Page);
                txtNome.Focus();
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;

            if (txtNome.Text != null && txtNome.Text != "")
            {
                if (txtEmail.Text != null && txtEmail.Text != "")
                {
                    if (imgFoto.ImageUrl == "")
                        urlFoto = null;
                    /*else
                    {
                        int p = objAluno.proximoCodigo();
                        nomefoto = p + objAluno.Aluno_nome + ".jpg";
                        urlFoto = @"~\\Imagens\" + nomefoto;
                    }*/

                    preparaDados();
                    iLinhas = objAluno.AlterarAluno();
                    if (iLinhas > 0)
                    {
                        btnPesquisar_Click(sender, e);
                        btnCancelar_Click(sender, e);
                        objAluno.MostraMensagem("Dados Alterados com Sucesso!!!", Page);
                    }
                    else
                        objAluno.MostraMensagem("Erro ao Alterar o Aluno", Page);
                }
                else
                {
                    objAluno.MostraMensagem("E-mail não informado!", Page);
                    txtEmail.Focus();
                }
            }
            else
            {
                objAluno.MostraMensagem("Nome não informado!", Page);
                txtNome.Focus();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            preparaDados();
            iLinhas = objAluno.ExcluirAluno();
            if (iLinhas > 0)
            {
                btnPesquisar_Click(sender, e);
                btnCancelar_Click(sender, e);
                objAluno.MostraMensagem("Dados Excluídos com Sucesso!!!", Page);
            }
            else
                objAluno.MostraMensagem("Erro ao Excluir diciplina", Page);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            objAluno.Popula_Gridview(txtPesquisa.Text);
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            gdwAlunos.DataSource = objAluno.Popula_Gridview(txtPesquisa.Text);
            gdwAlunos.DataBind();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string sCaminho, sCaminhoMini, codigo = "";
            int cod;
            if (txtNome.Text != "" && txtNome.Text != null)
            {
                cod = objAluno.proximoCodigo();
                codigo = Convert.ToString(cod);
                codigo += txtNome.Text + ".jpg";

                //se escolheu a imagem
                if (FileUpload.HasFile)
                {
                    sCaminho = Server.MapPath("Imagens") + "\\";
                    sCaminhoMini = Server.MapPath("Miniaturas") + "\\";

                    //salva a foto no site com o nome escolhido
                    FileUpload.SaveAs(sCaminho + codigo);
                    imgFoto.ImageUrl = "~/Imagens/" + codigo;

                    //FileUploadFoto.SaveAs(sCaminho + txtNomeFoto.Text  );
                    //imgFoto.ImageUrl = "~/Imagens/" + txtNomeFoto.Text;

                    //fuImagem.SaveAs(sCaminho + txtCodigo.Text + ".jpg");
                    //                imgFoto.ImageUrl = "~/Imagens/" + txtCodigo.Text + ".jpg";

                    //miniatura Thumbnail
                    //int iLargura, iAltura;
                    /*System.Drawing.Image miniatura = System.Drawing.Image.FromFile(sCaminho +
                        txtNomeFoto.Text);

                    iLargura = Convert.ToInt32(miniatura.Width * 0.2);
                    iAltura = Convert.ToInt32(miniatura.Height * 0.2);

                    miniatura = miniatura.GetThumbnailImage(iLargura, iAltura,
                        new System.Drawing.Image.GetThumbnailImageAbort(Retorno), IntPtr.Zero);

                    miniatura.Save(sCaminhoMini + txtNomeFoto.Text);
                    imgFoto.ImageUrl = "~/Miniaturas/" + txtNomeFoto.Text;*/
                }
            }
            else
                objAluno.MostraMensagem("Antes de carregar a foto, preencha o campo Nome!", Page);
        }

        protected void gdwAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["codigo"] = Convert.ToInt32(gdwAlunos.SelectedRow.Cells[1].Text);
            objAluno.Aluno_RA = Convert.ToInt32(Session["codigo"]);
            objAluno.RecuperarDados();

            txtNome.Text = objAluno.Aluno_nome;
            txtEmail.Text = objAluno.Aluno_email;
            imgFoto.ImageUrl = objAluno.Aluno_foto;

            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            //volta para a aba dos dados
            TabContainer1.ActiveTabIndex = 0;
            txtNome.Focus();
        }

        protected void gdwAlunos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdwAlunos.PageIndex = e.NewPageIndex;
            btnPesquisar_Click(sender,e);
        }


    }
}