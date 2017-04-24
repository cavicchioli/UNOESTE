using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjParcela
{
    public partial class frmPrincipal : Form
    {
        DataTable dttParcelas= new DataTable();

        public frmPrincipal()
        {
            InitializeComponent();
            dttParcelas.TableName = "parc";
            dttParcelas.Columns.Add("Parcelas", typeof(int));
            dttParcelas.Columns.Add("Vencimentos", typeof(DateTime));
            dttParcelas.Columns.Add("Valores", typeof(Decimal));
            dgvTabela.DataSource = dttParcelas;
        }

      

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int i;
            dttParcelas.Rows.Clear();

            if (ttbValor.Text != "" && ttbParcela.Text != "" && ttbDiasParcelas.Text != "")
            {
                Decimal parcela;
                DateTime dia = new DateTime();
                
                dia = dtpData.Value;
                
               parcela = Convert.ToDecimal(ttbValor.Text)/Convert.ToInt32(ttbParcela.Text);
               parcela=Decimal.Round(parcela,2);

                for (i = 0; i < Convert.ToInt32(ttbParcela.Text); i++)
                {
                    dttParcelas.Rows.Add(i+1,dia,parcela);
                    dia = dia.AddDays(Convert.ToInt32(ttbDiasParcelas.Text));
                }
                
            }
            else
               MessageBox.Show("Dados Incompletos!!!");

            ttbDiasParcelas.Clear();
            ttbValor.Clear();
            ttbValor.Focus();
            ttbParcela.Clear();
        }

        private void grava(string nome)//metodo genérico para gravar!
        {
            dttParcelas.WriteXml(nome);
        }
        
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (sfdSalvar.ShowDialog() == DialogResult.OK)
            {
                grava(sfdSalvar.FileName);
            }
        }

        private void abre(string nome)
        {
            int i;
            Decimal ult_valor, ult_parcela, valor;
            DateTime parc1,parc2,ini;
            TimeSpan dias;

            dttParcelas.ReadXml(nome);
            i = dttParcelas.Rows.Count-1;

            parc1 = Convert.ToDateTime(dttParcelas.Rows[0]["Vencimentos"]);
            parc2 = Convert.ToDateTime(dttParcelas.Rows[1]["Vencimentos"]);
            ini=Convert.ToDateTime(dttParcelas.Rows[0]["Vencimentos"]);
            ult_parcela = Convert.ToInt32(dttParcelas.Rows[i]["Parcelas"]);
            ult_valor=Convert.ToDecimal(dttParcelas.Rows[i]["Valores"]);

            dias = parc2.Subtract(parc1);
            ttbDiasParcelas.Text = Convert.ToString(dias.TotalDays);

            dtpData.Value = ini;

            ttbParcela.Text = Convert.ToString(ult_parcela);
            
            valor = ult_parcela * ult_valor;
            
            valor = Decimal.Round(valor, 0);

            ttbValor.Text = Convert.ToString(valor);



        }


        private void btnImportar_Click(object sender, EventArgs e)
        {
            
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                dttParcelas.Rows.Clear();
                abre(ofdAbrir.FileName);
            }
        }

       
    }
}
