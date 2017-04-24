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
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = string.Empty;
            int codigo = 0;
            if (int.TryParse(txtUsuario.Text, out codigo))
            {
                FuncionarioControladora cFuncionario = new FuncionarioControladora();
                Funcionario func = cFuncionario.ValidarAcesso(int.Parse(txtUsuario.Text), txtSenha.Text);

                if (func != null)
                {
                    if (cbLembrar.Checked)
                    {
                        HttpCookie ck = new HttpCookie("Acesso");
                        ck["funcionario"] = func.Codigo.ToString();
                        ck["senha"] = func.Senha;
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
                    Session["codigoFuncionario"] = func.Codigo;
                    Session["nomeFuncionario"] = func.Nome;

                    Server.Transfer("Principal.aspx");
                }
                else
                    lblMensagem.Text = "Usuário e/ou senha inválida.";
            }
        }
    }
}