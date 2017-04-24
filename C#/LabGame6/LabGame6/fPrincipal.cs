using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabGame6
{
    public partial class fPrincipal : Form
    {
        //faltei na aula leo que me passou o projeto!
        DataTable dtContatos;
        byte[] imgContato;

        public fPrincipal()
        {
            InitializeComponent();

            dtContatos = new DataTable();

            dtContatos.Columns.Add("nome", typeof(string));
            dtContatos.Columns.Add("telefone", typeof(string));
            dtContatos.Columns.Add("foto", typeof(byte[]));

            dgvContatos.DataSource = dtContatos;
        }

        private void bSalvarFoto_Click(object sender, EventArgs e)
        {
            sfdSalvar.FileName = "";
            sfdSalvar.Filter = "JPeg Image|*.jpg";
            sfdSalvar.ShowDialog();

            if (sfdSalvar.FileName != "")
            {
                //pbFoto.Image.Save(sfdSalvar.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //System.IO.FileStream fs = (System.IO.FileStream)sfdSalvar.OpenFile();
                //pbFoto.Image.Save(sfdSalvar.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                
            }
        }

        private void bSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void bLimpar_Click(object sender, EventArgs e)
        {
            dtContatos.Clear();
            limpaCampos();
        }

        private void bExcluir_Click(object sender, EventArgs e)
        {
            if (dgvContatos.SelectedRows.Count > 0)
                dtContatos.Rows.RemoveAt(dgvContatos.SelectedRows[0].Index);
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            ofdAbrir.FileName = "";
            ofdAbrir.Filter = "Arquivos de imagem (*.jpg; *.bmp | *.jpg; *.bmp)";
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                //modo dificil
                FileStream f = new FileStream(ofdAbrir.FileName, FileMode.Open);
                imgContato = new byte[f.Length];

                f.Read(imgContato, 0, (int)f.Length);
                pbFoto.Image = new Bitmap(f);
                f.Dispose();

                // carrega a foto no picture box
                // modo facil
                //pbFoto.Image = Image.FromFile(ofdAbrir.FileName);
            }
        }

        private void bExportar_Click(object sender, EventArgs e)
        {
            sfdSalvar.FileName = "Contatos.xml";
            sfdSalvar.Filter = "Arquivos XML *.xml | *.xml";
            if (sfdSalvar.ShowDialog() == DialogResult.OK)
            {
                dtContatos.Namespace = "Contatos";
                dtContatos.WriteXml(sfdSalvar.FileName);
            }
        }

        private void bGravar_Click(object sender, EventArgs e)
        {
            DataRow dr = dtContatos.NewRow();
            dr["nome"] = txtNome.Text;
            dr["telefone"] = txtTel.Text;
            dr["foto"] = imgContato;

            dtContatos.Rows.Add(dr);

            limpaCampos();
            txtNome.Focus();
        }

        private void bAbrir_Click(object sender, EventArgs e)
        {
            ofdAbrir.FileName = "";
            ofdAbrir.Filter = "Arquivos XML *.xml | *.xml";
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
                dtContatos.ReadXml(ofdAbrir.FileName);
        }

        private void limpaCampos()
        {
            txtNome.Text = "";
            txtTel.Text = "";
            pbFoto.Image = null;
        }
    }
}
