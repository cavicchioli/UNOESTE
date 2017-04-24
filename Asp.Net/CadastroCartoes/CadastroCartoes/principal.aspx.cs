using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroCartoes
{
    public partial class principal : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btnAdd"]) || !string.IsNullOrEmpty(Request.Form["btnGravar"]))
            {
                int qtdAdd;

                if (!string.IsNullOrEmpty(Request.Form["btnAdd"]))
                    qtdAdd = int.Parse(Request.Form["hfQtd"]) + 1;
                else
                    qtdAdd = int.Parse(Request.Form["hfQtd"]);

                for (int i = 2; i <= qtdAdd; i++)
                {
                    TableRow r1 = new TableRow();
                    TableCell c1 = new TableCell
                    {
                        Text = "Nome"
                    };
                    TableCell c2 = new TableCell();
                    c2.ColumnSpan = 4;
                    TextBox t1 = new TextBox
                    {
                        ID = "tbNomeAdicional" + i.ToString(),
                        MaxLength = 50,
                        Columns = 50
                    };
                    c2.Controls.Add(t1);
                    r1.Controls.Add(c1);
                    r1.Controls.Add(c2);

                    TableRow r2 = new TableRow();
                    TableCell c3 = new TableCell
                    {
                        Text = "Dt.Nascimento"
                    };
                    TableCell c4 = new TableCell();
                    TextBox t2 = new TextBox
                    {
                        ID = "tbDtNascimento" + i.ToString(),
                        MaxLength = 10,
                        Columns = 10
                    };
                    c4.Controls.Add(t2);
                    TableCell c5 = new TableCell
                    {
                        Text = "Tipo"
                    };
                    TableCell c6 = new TableCell();
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.ID = "rblQuantidade" + i.ToString();
                    rbl.RepeatDirection = RepeatDirection.Horizontal;
                    rbl.Items.Add(new ListItem { Text = "Cônjuge" });
                    rbl.Items.Add(new ListItem { Text = "Filho" });
                    rbl.Items.Add(new ListItem { Text = "Pai" });
                    rbl.Items.Add(new ListItem { Text = "Mãe" });
                    rbl.Items.Add(new ListItem { Text = "Outro" });
                    c6.Controls.Add(rbl);

                    r2.Controls.Add(c3);
                    r2.Controls.Add(c4);
                    r2.Controls.Add(c5);
                    r2.Controls.Add(c6);

                    tableCartoes.Controls.Add(r1);
                    tableCartoes.Controls.Add(r2);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btnAdd"]))
            {
                hfQtd.Value = (Convert.ToInt32(hfQtd.Value) + 1).ToString(); ;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableCartoes.Controls)
            {
                if (c.GetType().FullName == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox aux = c as TextBox;
                    aux.Text = "";
                }
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            lbValores.Text = "";
            foreach (Control c in tableCartoes.Controls)
            {
                if (c.GetType().FullName == "System.Web.UI.WebControls.TextBox")
                {
                    TextBox aux = c as TextBox;
                    lbValores.Text += aux.ID + " = " + aux.Text + "<br />";
                }
            }
        }
}
}