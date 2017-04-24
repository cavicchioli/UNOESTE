using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrjIntroducao
{
    public partial class FrmExercicio3 : Form
    {
        int tl = 0;
        String[] palavra = new String[100];

        public FrmExercicio3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i=0,achou=0;


            if (ttbPalavra.Text != "" )
            {
                for (i = 0; i < tl;i++)
                {
                    if (palavra[i] == ttbPalavra.Text)
                        achou = 1;
                }

                if (achou == 1)
                {

                    if ((MessageBox.Show("Deseja adicionar novamente?", "MENSAGEM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)) == DialogResult.Yes)
                    {
                        palavra[tl] = ttbPalavra.Text;
                        ttbPalavra.Clear();
                        tl++;
                    }
                }
                else
                {
                    palavra[tl] = ttbPalavra.Text;
                    ttbPalavra.Clear();
                    tl++;
                }

            }
            else
            {
                MessageBox.Show("Digitar uma palavra!");
            }

            ttbPalavra.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ltbPalavras.Items.Clear();
            Array.Clear(palavra, 0, tl);
            tl = 0;
        }

        private void btnDescarrecar_Click(object sender, EventArgs e)
        {
            if (tl == 0)
            {
                MessageBox.Show("Vetor Vazio!!");
            }
            else
            {

                ltbPalavras.Items.Clear();

                for (int i = 0; i < tl; i++)
                {
                    ltbPalavras.Items.Add(palavra[i]);

                }
            }
        }
    }
}
