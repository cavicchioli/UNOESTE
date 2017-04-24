using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail; 

namespace WebFarmacia2013
{
    public partial class FecharCompras : System.Web.UI.Page
    {
        clsClientes objClientes = new clsClientes();
        int iLinhas = 0;
        DataTable dtClientes = new DataTable(); 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

            objClientes.Cpf = txtCPF.Text;
            iLinhas= objClientes.RecuperaDadosCPF();
            if (iLinhas > 0)
            {
                if (objClientes.Senha == txtSenha.Text)
                {
                    txtBairro.Text = objClientes.Bairro;
                    txtCelular.Text = objClientes.Celular;
                    txtCEP.Text = objClientes.Cep;
                    txtCidade.Text = objClientes.Cidade;
                    txtEmail.Text = objClientes.Email;
                    txtEndereco.Text = objClientes.Endereco;
                    txtEstado.Text = objClientes.Estado;
                    txtFone.Text = objClientes.Telefone;
                    txtNascimento.Text = objClientes.Nascimento;
                    txtNome.Text = objClientes.Nome;
                    txtRG.Text = objClientes.Rg;
                    btnAtualizar.Enabled = true;
                    btnReenviar.Enabled = false;
                    btnFechar.Enabled = true;
                    Session["CODIGO"] = objClientes.Codigo;  
                }
                else
                {
                    objClientes.MostraMensagem("Senha inválida !!!", Page);
                    btnReenviar.Enabled = true;
                    btnAtualizar.Enabled = false;
                    btnFechar.Enabled = false;
                }
            }
            else
            {
                objClientes.MostraMensagem("Cadastro não encontrado !!!", Page);
                btnAtualizar.Enabled = true;
                btnFechar.Enabled = false;
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            btnFechar.Enabled = true;
            PrepararDados();
            if (Session["CODIGO"] != null)
            {
                iLinhas = objClientes.AlterarClientes(Convert.ToInt32(Session["CODIGO"]));   
            }
            else
            {
                iLinhas = objClientes.IncluirClientes();  
            }
            if (iLinhas > 0)
            {
                objClientes.MostraMensagem("Dados atualizados com sucesso !!!", Page);
                btnFechar.Enabled = true;
            }
            else
            {
                objClientes.MostraMensagem("Dados não foram atualizados !!!", Page);
                btnFechar.Enabled = false;  
            }
        }

        protected void PrepararDados()
        {
            objClientes.Bairro =txtBairro.Text  ;
            objClientes.Celular = txtCelular.Text  ;
            objClientes.Cep=txtCEP.Text  ;
            objClientes.Cidade=txtCidade.Text  ;
            objClientes.Email =txtEmail.Text  ;
            objClientes.Endereco =txtEndereco.Text  ;
            objClientes.Estado =txtEstado.Text  ;
            objClientes.Telefone =txtFone.Text  ;
            objClientes.Nascimento = txtNascimento.Text  ;
            objClientes.Nome = txtNome.Text  ;
            objClientes.Rg = txtRG.Text  ;
            objClientes.Cpf = txtCPF.Text;
            objClientes.Senha = txtSenha.Text;  
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            clsPedidos objPedidos = new clsPedidos();

            objPedidos.Numero = Convert.ToString(Session["PEDIDO"]);
            objPedidos.Cliente = Convert.ToInt32(Session["CODIGO"]);
            iLinhas = objPedidos.FecharPedido();
            if (iLinhas > 0)
            {
                objPedidos.MostraMensagem("Pedido fechado com sucesso!",Page );
                Envia_Email_Pedido(); 
            }
            else
            {
                objPedidos.MostraMensagem("Pedido não foi fechado !",Page );

            }
        }

        protected void Envia_Email_Pedido()
        {
            clsPedidos objPedidos = new clsPedidos(); 
            DataTable dtPedidos = new DataTable();
            string sTexto1 = "";

            int iEspaco = txtNome.Text.IndexOf(" ");
            if (iEspaco > 0)
            {
                sTexto1 = "Prezado (a) " + txtNome.Text.Split(' ');
            }
            else
            {
                sTexto1 = "Prezado (a) " + txtNome.Text;
            }

            string sTexto2 = "Recebemos seu pedido número :" + Session["PEDIDO"];
            string sTexto3 = "Composto pelos seguintes itens: ";
            string sTexto4 = "Obrigado por comprar na FARMAFIPP ";
            string sTexto5 = "Em caso de dúvida entre em contato com nossa central de atendimento.";
            string sTexto6 = "Atenciosamente";
            string sTexto7 = "Departamento Comercial - FARMAFIPP";
            string sTexto8 = "";


            string sTotalPedido = Convert.ToString(objPedidos.TotalizaPedido());

            sTexto8 = "<table border=2 width=500px>" +
                " <tr> " +
                "<td width=50%> Descrição</td>" +
                "<td width=20%> Quantidade</td>" +
                "<td width=30%> Valor</td>" +
                "</tr> " ;

            dtPedidos = objPedidos.RecuperarDados(Session["PEDIDO"].ToString());
            if (dtPedidos.Rows.Count > 0)
            {
                int i = 0;
                while (dtPedidos.Rows.Count > i)
                {
                    sTexto8 = sTexto8 + "<tr>" +
                        "<td width=50%> " +
                        dtPedidos.Rows[i]["DESCRICAO"].ToString() + "</td>" +   
                        "<td width=20%> " +
                        dtPedidos.Rows[i]["QUANTIDADE"].ToString() + "</td>" +   
                        "<td width=30%> " +
                        String.Format("{0:c}", dtPedidos.Rows[i]["PRECOTOTAL"]) + "</td>" +  
                        "</tr>";
                    i++;
                }
            }
            sTexto8 = sTexto8 + "</table>";

            dtPedidos.Dispose();
            string sMensagem = sTexto1 + "<br> " + sTexto2 + "<br>" +
                sTexto3 + "<br>" + sTexto8 + "<br>" + sTexto4 + "<br>" + sTexto6 + "<br>" +
                sTexto7 + "<br>";

            SmtpClient email = new SmtpClient("mail.unoeste.br");
            try
            {
                MailMessage msg = new MailMessage();
                MailAddress remetente = new MailAddress("farmafipp@unoeste.br", "FarmaFIPP Medicamentos Ltda");
                msg.From = remetente;
                msg.Subject = "Pedido número :" + Session["NUMPEDIDO"];
                msg.Body = sMensagem;
                msg.IsBodyHtml = true;
                msg.To.Add("rodolpho@unoeste.br");
                email.Send(msg);
                objClientes.MostraMensagem("E-mail enviado com sucesso!!!", Page);
            }
            catch
            {
                objClientes.MostraMensagem("Problemas no envio do e-mail!!!", Page);
            }

        }

        protected void btnReenviar_Click(object sender, EventArgs e)
        {
            string sSenha = "";
            objClientes.Cpf = txtCPF.Text;
            iLinhas = objClientes.RecuperaDadosCPF();
            if (iLinhas > 0)
            {
                sSenha= objClientes.Senha;
                SmtpClient email = new SmtpClient("mail.unoeste.br");
                try
                {
                    MailMessage msg = new MailMessage();
                    MailAddress remetente = new MailAddress("farmafipp@unoeste.br", "FarmaFIPP Medicamentos Ltda");
                    msg.From = remetente;
                    msg.Subject = "Senha do site";
                    msg.Body = "Sua senha de acesso é " + sSenha;
                    msg.IsBodyHtml = true;
                    msg.To.Add("rodolpho@unoeste.br");
                    email.Send(msg);
                    objClientes.MostraMensagem("E-mail enviado com sucesso!!!", Page);
                }
                catch
                {
                    objClientes.MostraMensagem("Problemas no envio do e-mail!!!", Page);
                }
            }
            else
            {
                objClientes.MostraMensagem("Cadastro não encontrado !!!", Page);
                btnAtualizar.Enabled = true;
                btnFechar.Enabled = false;
            }
        }
    }
}