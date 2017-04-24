using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabalhoAula3
{
    public partial class principal : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btnAddCartao"]) || !string.IsNullOrEmpty(Request.Form["btnGravar"]))
            {
                int qtdAdd;
                if (!string.IsNullOrEmpty(Request.Form["btnAddCartao"]))
                    qtdAdd = int.Parse(Request.Form["hfQtdAdicionais"]) + 1;
                else
                    qtdAdd = int.Parse(Request.Form["hfQtdAdicionais"]);
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

                    tabelaAdicionais.Controls.Add(r1);
                    tabelaAdicionais.Controls.Add(r2);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btnAddCartao"]))
            {
                hfQtdAdicionais.Value = (int.Parse(hfQtdAdicionais.Value) + 1).ToString(); ;
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}