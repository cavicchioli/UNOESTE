using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrjTrabalhoPratico
{
    public partial class FrmPrincipal : Form
    {
        string sLine = "";
        //ArrayList arrText = new ArrayList();


        private void AbreArquivo(string nomearq, ListBox lista)
        {
            StreamReader objReader = new StreamReader(nomearq);
            lista.Items.Clear();
            while (!objReader.EndOfStream) //endOfStream = true --> está no final do arquivo
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    lista.Items.Add(sLine);
                //arrText.Add(sLine);
            }
            objReader.Close();
        }

        public void GravarArquivo(string nomearq, ListBox lista)
        {
            StreamWriter objWriter = new StreamWriter(nomearq, true, Encoding.ASCII);
            int i = 0;
            //while (!objWriter.EndOfStream) //endOfStream = true --> está no final do arquivo
            while (lista.Items.Count != i)
            {
                sLine = lista.Items[i].ToString();

                objWriter.WriteLine(sLine);
                i++;

            }
            objWriter.Close();
        }
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnInsereL1_Click(object sender, EventArgs e)
        {
            if (ttbInsere.Text != "")
            {
                ltb1.Items.Add(ttbInsere.Text);
                ttbInsere.Clear();
            }
            else
            {
                MessageBox.Show("Digite um valor válido!!");
            }

            ttbInsere.Focus();
        }

        private void btnInsereL2_Click(object sender, EventArgs e)
        {
            if (ttbInsere.Text != "")
            {
                ltb2.Items.Add(ttbInsere.Text);
                ttbInsere.Clear();
            }
            else
            {
                MessageBox.Show("Digite um valor válido!!");
            }

            ttbInsere.Focus();
        }

        private void btnMoveTopo_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < ltb1.SelectedItems.Count; i++)
            {
                string aux = ltb1.SelectedItems[i].ToString(); // recebe oque é

                int pos = ltb1.Items.IndexOf(aux); // posiçao do que será removido

                ltb1.Items.Insert(0, aux); //inserir
                ltb1.Items.RemoveAt(pos + 1); //remover

            }
        }

        private void btnApagaL1_Click(object sender, EventArgs e)
        {
            while (ltb1.SelectedItems.Count != 0)
            {
                string aux = ltb1.SelectedItems[0].ToString();

                int pos = ltb1.Items.IndexOf(aux);

                ltb1.Items.Insert(0, aux); //inserir
                ltb1.Items.RemoveAt(pos + 1); //remover
                ltb1.Items.RemoveAt(0); //remover
            }
        }

        private void btnApagaL2_Click(object sender, EventArgs e)
        {
            while (ltb2.SelectedItems.Count != 0)
            {
                string aux = ltb2.SelectedItems[0].ToString();

                int pos = ltb2.Items.IndexOf(aux);

                ltb2.Items.Insert(0, aux); //inserir
                ltb2.Items.RemoveAt(pos + 1); //remover
                ltb2.Items.RemoveAt(0); //remover
            }
        }

        private void cbxLista1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLista1.Checked == true)
                ltb1.Sorted = true;
            else
                ltb1.Sorted = false;
        }

        private void cbxLista2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLista2.Checked == true)
                ltb2.Sorted = true;
            else
                ltb2.Sorted = false;
        }

        private void btnTransfL1L2_Click(object sender, EventArgs e)
        {
            while (ltb1.SelectedItems.Count != 0)
            {
                string aux = ltb1.SelectedItems[0].ToString();

                int pos = ltb1.Items.IndexOf(aux);

                ltb2.Items.Add(aux);//inserir
                ltb1.Items.RemoveAt(pos); //remover
                
                
            }
        }

        private void btnTransfL2L1_Click(object sender, EventArgs e)
        {
            while (ltb2.SelectedItems.Count != 0)
            {
                string aux = ltb2.SelectedItems[0].ToString();

                int pos = ltb2.Items.IndexOf(aux);

                ltb1.Items.Insert(0, aux);//inserir
                ltb2.Items.RemoveAt(pos); //remover
                
                
            }

        }

        private void btnGravaTXT_Click(object sender, EventArgs e)
        {

            if (sfdSavar.ShowDialog() == DialogResult.OK)
            {
                GravarArquivo(sfdSavar.FileName, ltb2);
            }
        }

        private void btnImportaTXT_Click(object sender, EventArgs e)
        {
            if (ofdAbre.ShowDialog() == DialogResult.OK)
            {
                AbreArquivo(ofdAbre.FileName, ltb2);
            }
        }
    }
}
