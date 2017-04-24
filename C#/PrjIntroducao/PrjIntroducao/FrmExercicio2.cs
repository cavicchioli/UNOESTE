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
    public partial class FrmExercicio2 : Form
    {
        int tl = 0;
        int[] numeros = new int[100];
        

        public FrmExercicio2()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ltbImpar.Items.Clear();
            ltbPares.Items.Clear();
            Array.Clear(numeros, 0, 100);
            tl = 0;
        }

        private void btnInserirVetor_Click(object sender, EventArgs e)
        {
            bool result;

            if (ttbNumero.Text != "")
            {
                    result = Int32.TryParse(ttbNumero.Text, out numeros[tl]);

                    if (result)
                    {
                        numeros[tl] = Convert.ToInt32(ttbNumero.Text);
                        ttbNumero.Clear();
                        tl++;
                    }
                    else
                    {
                        MessageBox.Show("Você digitou uma string!!");
                    }
                }
            else
            {
                MessageBox.Show("Digitar um número, POR FAVOR!!!");
            }
           
            ttbNumero.Focus();
        }

        private void btnSeparar_Click(object sender, EventArgs e)
        {
            ltbImpar.Items.Clear();
            ltbPares.Items.Clear();

            for (int i = 0; i < tl; i++)
            {
                if ((numeros[i] % 2) == 0)
                    ltbPares.Items.Add(Convert.ToString(numeros[i]));
                else
                    ltbImpar.Items.Add(Convert.ToString(numeros[i]));
               
            }
        }
    }
}
