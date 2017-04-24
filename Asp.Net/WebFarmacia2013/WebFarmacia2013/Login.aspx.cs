using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebFarmacia2013
{
    public partial class Login : System.Web.UI.Page
    {
        clsBanco objBanco = new clsBanco();
        string sSQL = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            sSQL = "SELECT * FROM LOGIN WHERE LOGIN = '" + Login1.UserName.ToUpper() + "'";
            DataTable dtLogin = new DataTable();
            dtLogin = objBanco.RetornaDT(sSQL);
            if (dtLogin.Rows.Count > 0)
            {
                if (Convert.ToString(dtLogin.Rows[0]["SENHA"]) == Convert.ToString(Login1.Password.ToUpper()))
                {
                    e.Authenticated = true;
                    Session["LOGIN"] = Login1.UserName.ToUpper();
                    Response.Redirect("Administracao.aspx");
                }
                else
                {
                    e.Authenticated = false;
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}