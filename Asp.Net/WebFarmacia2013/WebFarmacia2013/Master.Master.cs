using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFarmacia2013
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarCookie();
            if (Request.Cookies["FARMAFIPP"] != null)
            {
                lblBenvindo.Text = "Benvindo de volta " +
                    Request.Cookies["FARMAFIPP"].Value;
            }
            else
            {
                lblBenvindo.Text = "Benvindo visitante";
           }
        }

        protected void CriarCookie()
        {
            HttpCookie ck = new HttpCookie("FARMAFIPP");
            ck.Value = "Rodolpho";
            ck.Expires = DateTime.Now.AddDays(30); //expira o cookie em 30 dias
            Response.Cookies.Add(ck);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("login.aspx"); 
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}