using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExemploPosWeb
{
    public partial class Sistema : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["autenticado"] == null || Session["autenticado"].ToString() != "OK")
            {
                pnlMenu.Visible = false;
            }
            else
                lblUsuario.Text = Session["nomeFuncionario"].ToString().ToUpper();
        }
    }
}