using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Copa2014.Apresentacao;

namespace Copa2014
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fGrupos frm = new fGrupos();
            frm.ShowDialog();
            frm.Close();
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Relatorios.fRelGrupos frm = new Relatorios.fRelGrupos();
            frm.ShowDialog();
            frm.Close();
        }

        private void fasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fFases frm = new fFases();
            frm.ShowDialog();
            frm.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSobre frm = new fSobre();
            frm.ShowDialog();
            frm.Close();
        }

        private void equipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fEquipes frm = new fEquipes();
            frm.ShowDialog();
            frm.Close();
        }

        private void jogadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fJogadores frm = new fJogadores();
            frm.ShowDialog();
            frm.Close();
        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fJogos frm = new fJogos();
            frm.ShowDialog();
            frm.Close();
            
        }

        private void resultadoJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fResultados frm = new fResultados();
            frm.ShowDialog();
            frm.Close();
        }

    }
}
