using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmTrabalhoPratico : Form
    {

        public FrmTrabalhoPratico()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInsereL1_Click(object sender, EventArgs e)
        {
            if(ttbInsere.Text != "")
            {
                ltb1.Items.Add(ttbInsere.Text);
                ttbInsere.Clear();
            }
        }

        private void btnInsereL2_Click(object sender, EventArgs e)
        {
            if (ttbInsere.Text != "")
            {
                ltb2.Items.Add(ttbInsere.Text);
                ttbInsere.Clear();
            }
        }

        private void btnTransfL1L2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ltb1.SelectedItems.Count; i++)//percorrendo os itens selecionados!
            {
                string aux = ltb1.SelectedItems[i].ToString();
                int pos = ltb1.Items.IndexOf(aux);
                ltb1.Items.RemoveAt(pos);
                //ltb1.Items.Insert(0,parametro);<----- usa pra colocar no topo;
            }
        }

        private void btnTransfL2L1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ltb2.SelectedItems.Count; i++)//percorrendo os itens selecionados!
            {
                string aux = ltb2.SelectedItems[i].ToString();
                int pos = ltb2.Items.IndexOf(aux);
                ltb2.Items.RemoveAt(pos);
                //ltb1.Items.Insert(0,parametro) <----- usa pra colocar no topo;
            }
        }

        private void btnApagaL1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ltb1.SelectedItems.Count; i++)//percorrendo os itens selecionados!
            {
                string aux = ltb1.SelectedItems[i].ToString();
                int pos = ltb1.Items.IndexOf(aux);
                ltb1.Items.RemoveAt(pos);
                ltb1.Items.Insert(0, ltb1.Items.IndexOf(0));
            }
        }

        private void btnMoveTopo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ltb1.SelectedItems.Count; i++)//percorrendo os itens selecionados!
            {
                string aux = ltb1.SelectedItems[i].ToString();
                int pos = ltb1.Items.IndexOf(aux);
                

            }
        }

        
    }
}
