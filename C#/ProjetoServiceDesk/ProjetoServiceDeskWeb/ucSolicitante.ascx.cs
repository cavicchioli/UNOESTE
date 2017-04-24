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
    public partial class ucSolicitante : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public int Gravar()
        {
            Solicitante s = new Solicitante();
            s.Nome = txtNome.Text;
            s.Email = txtEmail.Text;
            s.Telefone = txtTelefone.Text;
            s.Observacao = txtObservacao.Text;

            SolicitanteController cSolicitante = new SolicitanteController();
            return cSolicitante.Gravar(s,'I');
        }

        public void Limpar()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtObservacao.Text = string.Empty;
        }
    }
}