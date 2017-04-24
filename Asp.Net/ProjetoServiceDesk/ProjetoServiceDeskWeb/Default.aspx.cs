using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoServiceDesk.Controller;
using ProjetoServiceDesk.Model;

namespace ProjetoServiceDeskWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.Cookies["Acesso"] != null && !IsPostBack)
            {
                txtUsuario.Text = Request.Cookies["Acesso"]["funcionario"];
                txtSenha.Attributes.Add("value", Request.Cookies["Acesso"]["senha"]);
                cbLembrar.Checked = true;
            }

            if (Request.QueryString["msg"] != null)
                lblMensagem.Text = Request.QueryString["msg"];

            txtUsuario.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;
            if (txtUsuario.Text.Trim() != "")
            {
                Funcionario user = new FuncionarioController().Autenticar(int.Parse(txtUsuario.Text), txtSenha.Text);
                if (user != null)
                {
                    if (cbLembrar.Checked)
                    {
                        HttpCookie ck = new HttpCookie("Acesso");
                        ck["funcionario"] = user.Codigo.ToString();
                        ck["senha"] = user.Senha;
                        ck.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(ck);
                    }
                    else
                    {
                        if (Request.Cookies["Acesso"] != null)
                        {
                            HttpCookie ck = Request.Cookies["Acesso"];
                            ck.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(ck);
                        }
                    }

                    Session["autenticado"] = "OK";
                    Session["codigoFuncionario"] = user.Codigo;
                    Session["nomeFuncionario"] = user.Nome;

                    Server.Transfer("Principal.aspx");
                }
                else
                    lblMensagem.Text = "Usuário e/ou senha inválida.";
            }
        }
    }
}