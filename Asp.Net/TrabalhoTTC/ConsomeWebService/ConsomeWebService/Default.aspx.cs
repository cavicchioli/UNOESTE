using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace ConsomeWebService
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Service.Service objService = new Service.Service();

            Service.Autenticador objAutenticador = new Service.Autenticador();

            objAutenticador.Usuario = "PEDROBO";
            objAutenticador.Senha = "NAPOLEAO";

            objService.AutenticadorValue = objAutenticador;

            DataSet dsClientes = objService.RetornaTodosClientes();

            if (dsClientes != null)
            {
                if (dsClientes.Tables[0].Rows.Count > 0)
                {
                    txtCodigo.Text = dsClientes.Tables[0].Rows[0]["codigo"].ToString();
                    txtNome.Text = dsClientes.Tables[0].Rows[0]["nome"].ToString();
                    txtCidade.Text = dsClientes.Tables[0].Rows[0]["cidade"].ToString();

                }
            }
            GridView1.DataSource = dsClientes;
            GridView1.DataBind();
        }
    }
}
