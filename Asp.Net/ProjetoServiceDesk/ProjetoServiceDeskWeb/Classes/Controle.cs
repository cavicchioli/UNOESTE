using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoServiceDeskWeb.Classes
{
    public static class Controle
    {
        public static void VerificaLogin()
        {
            if (HttpContext.Current.Session["autenticado"] == null || 
                HttpContext.Current.Session["autenticado"].ToString() != "OK")
            {
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Redirect("Default.aspx?msg=Por favor, autentique-se");
            }
        }
    }
}