using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Exercicio_Pratico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsereLista1_Click(object sender, EventArgs e)
        {
            if (ttbEntrada.Text != "")
            {
                lista1.Items.Add(ttbEntrada.Text);
                ttbEntrada.Clear();
                ttbEntrada.Focus();
            }
        }

        private void btnApagaLista1_Click(object sender, EventArgs e)
        {
            while (lista1.SelectedItems.Count != 0)
            {
                string aux = lista1.SelectedItems[0].ToString();

                int pos = lista1.Items.IndexOf(aux);

                lista1.Items.Insert(0, aux); //inserir
                lista1.Items.RemoveAt(pos + 1); //remover
                lista1.Items.RemoveAt(0); //remover
            }
        }

        private void btnMoveTopo_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < lista1.SelectedItems.Count; i++)
            {
                string aux = lista1.SelectedItems[i].ToString();
                int pos = lista1.Items.IndexOf(aux);
                lista1.Items.Insert(0, aux);
            }
        }

        private void btnInsereLista2_Click(object sender, EventArgs e)
        {
            if (ttbEntrada.Text != "")
            {
                lista2.Items.Add(ttbEntrada.Text);
                ttbEntrada.Clear();
                ttbEntrada.Focus();
            }
        }

        private void btnApagaLista2_Click(object sender, EventArgs e)
        {
            while (lista2.SelectedItems.Count != 0)
            {
                string aux = lista2.SelectedItems[0].ToString();

                int pos = lista2.Items.IndexOf(aux);

                lista2.Items.Insert(0, aux); //inserir
                lista2.Items.RemoveAt(pos + 1); //remover
                lista2.Items.RemoveAt(0); //remover
            }
        }

        private void btnMandaLista2_Click(object sender, EventArgs e)
        {
            while (lista1.SelectedItems.Count != 0)
            {
                string aux = lista1.SelectedItems[0].ToString();

                int pos = lista1.Items.IndexOf(aux);

                lista2.Items.Add(aux);//inserir
                lista1.Items.RemoveAt(pos); //remover
                //ltb1.Items.RemoveAt(0); //remover
            }
        }

        private void btnMandaLista1_Click(object sender, EventArgs e)
        {
            while (lista2.SelectedItems.Count != 0)
            {
                string aux = lista2.SelectedItems[0].ToString();

                int pos = lista2.Items.IndexOf(aux);

                lista1.Items.Insert(0, aux);//inserir
                lista2.Items.RemoveAt(pos); //remover

            }
        }

        private void ccbLista1_CheckedChanged(object sender, EventArgs e)
        {
            if (ccbLista1.Checked == true)
                lista1.Sorted = true;
            else
                lista1.Sorted = false;
        }

        private void ccbLista2_CheckedChanged(object sender, EventArgs e)
        {
            if (ccbLista2.Checked == true)
                lista2.Sorted = true;
            else
                lista2.Sorted = false;
        }

        private void btnGrava_Click(object sender, EventArgs e)
        {
            String lista = "", aux = "", arq = @"H:\Faculdade\4° semestre\LP2\Trabalho Prático\Exercicio_Pratico\backup.txt"; 
            int a;
            StreamWriter gr = new StreamWriter(arq);

            for (a = 0; a < lista2.Items.Count; a++)
            {
                aux = lista2.Items[a].ToString();
                gr.WriteLine(aux);
            }
            gr.Close();               
            
        }

        private void btnImporta_Click(object sender, EventArgs e)
        {
            String linha, arq = @"H:\Faculdade\4° semestre\LP2\Trabalho Prático\Exercicio_Pratico\produtos.txt";
            StreamReader sr = new StreamReader(arq);
            while (!sr.EndOfStream)
            {
                linha = sr.ReadLine();
                lista2.Items.Add(linha);
            }
            sr.Close(); 
        }
    }
}
