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
    public partial class FrmExercicio1 : Form
    {
        public FrmExercicio1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ttbNumero.Text != "")
            {
                //add ---- adiciona um elem no listbox
                ltbLista.Items.Add(ttbNumero.Text);
                ttbNumero.Clear();

            }
            else
               {
                  MessageBox.Show("Digitr um número, POR FAVOR!!!");
               }
            //manda o foco da app para o ttbNumero
            ttbNumero.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ltbLista.Items.Clear();
            ttbIntervalo1.Clear();
            ttbIntervalo2.Clear();
            ttbIntervalo3.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int ret;

            int cont0_25 = 0, cont39_50 = 0, cont57_75 = 0;
            int i,num;
            String palavra;

            for (i = 0; i < ltbLista.Items.Count; i++)
            {
                palavra = Convert.ToString(ltbLista.Items[i]);
                
                if (Int32.TryParse(palavra, out ret))
                {


                    num = Convert.ToInt32(ltbLista.Items[i]);

                    if (num >= 0 && num <= 25)
                    {
                        cont0_25++;
                    }
                    else
                    {
                        if (num >= 39 && num <= 50)
                        {
                            cont39_50++;
                        }
                        else
                            if (num >= 57 && num <= 75)
                            {
                                cont57_75++;
                            }
                    }
                }
                
            }
            

            ttbIntervalo1.Text = Convert.ToString(cont0_25);
            ttbIntervalo2.Text = Convert.ToString(cont39_50);
            ttbIntervalo3.Text = Convert.ToString(cont57_75);
        }
    }
}
