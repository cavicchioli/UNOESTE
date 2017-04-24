using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoServiceDeskWeb
{
    public partial class Sistema : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["autenticado"] != null && Session["autenticado"].ToString() == "OK")
            {
                lblUsuario.Text = string.Format("{0}|{1}", 
                    Session["codigoFuncionario"].ToString(), 
                    Session["nomeFuncionario"].ToString());
                pnlMenu.Visible = true;
            }
            else
            {
                lblUsuario.Text = string.Empty;
                pnlMenu.Visible = false;
            }

        }
    }
}