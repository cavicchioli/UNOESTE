using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrjCadastro
{
    public partial class FrmCadCidades : Form
    {
        DataTable dttCidades = new DataTable();
        public FrmCadCidades()
        {
            InitializeComponent();
            //atribuir uma valor para o TableName 
            dttCidades.TableName = "cidades";
            //definindo as colunas do DataTable
            dttCidades.Columns.Add("codigo", typeof(int));
            dttCidades.Columns.Add("nomecidade");
            dttCidades.Columns.Add("UF",typeof(string));

            //vincular o DataGridView ao DataTable
            dgvCidades.DataSource = dttCidades;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //adicionar uma linha no DataTable
            //1ª forma
            DataRow linha = dttCidades.NewRow();
            linha["codigo"] = Convert.ToInt32(ttbCodigo.Text);
            linha["nomecidade"] = ttbNome.Text;
            linha["UF"] = cbbUF.Text;
            //adicionar a linha no Datatable
            dttCidades.Rows.Add(linha);

            //2ª forma
            //dttCidades.Rows.Add(Convert.ToInt32(ttbCodigo.Text),
            //                    ttbNome.Text,
            //                    cbbUF.Text);

            //chama o click do botão novo
            btnNovo.PerformClick();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //verificar se tem elementos selecionados na Grid
            //dttCidades.Rows[0].Delete();exclui da posição 0
            //SelectedRows --> armazena as linhas selecionadas
            if (dgvCidades.SelectedRows.Count > 0)
            {
                int posExclui = dgvCidades.SelectedRows[0].Index;
                dttCidades.Rows[posExclui].Delete();
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dttCidades.Rows.Clear();
            //dttCidades.Clear();
        }

        private void btnFormatar_Click(object sender, EventArgs e)
        {
            //percorrer o Datatable e alterar os valores dos nomes das
            //cidades
            string nome = "";
            for (int pos = 0; pos < dttCidades.Rows.Count; pos++)
            {
                nome = dttCidades.Rows[pos]["nomecidade"].ToString();
                dttCidades.Rows[pos]["nomecidade"] = nome.ToUpper();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ttbCodigo.Clear();
            ttbNome.Clear();
            cbbUF.SelectedIndex = -1;
            ttbCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.PerformClick();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(sfdSalvar.ShowDialog() == DialogResult.OK)
            dttCidades.WriteXml(sfdSalvar.FileName);
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if(ofdImportar.ShowDialog()==DialogResult.OK)
            dttCidades.ReadXml(ofdImportar.FileName);
        }

    }
}
