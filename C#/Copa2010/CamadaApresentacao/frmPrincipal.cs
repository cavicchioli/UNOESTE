using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Copa2010.CamadaApresentacao;
using Copa2010.Relatorios;

namespace Copa2010
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrupos frm = new frmGrupos();
            frm.ShowDialog();
            frm.Close();
        }

        private void equipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEquipes frm = new frmEquipes();
            frm.ShowDialog();
            frm.Close();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.ShowDialog();
            frm.Close();
        }

        private void fasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFases frm = new frmFases();
            frm.ShowDialog();
            frm.Close();
        }

        private void jogadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmJogadores frm = new frmJogadores();
            frm.ShowDialog();
            frm.Close();
        }

        private void jogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJogos frm = new frmJogos();
            frm.ShowDialog();
            frm.Close();
        }

        private void resultadoJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResultadosJogos frm = new frmResultadosJogos();
            frm.ShowDialog();
            frm.Close();
        }

        private void fasesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelBasicos relBasicos = new frmRelBasicos("relFases.rpt", "Relatório de Fases");
            relBasicos.ShowDialog();
            relBasicos.Close();
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelBasicos relBasicos = new frmRelBasicos("relGrupos.rpt", "Relatório de Grupos");
            relBasicos.ShowDialog();
            relBasicos.Close();
        }

        private void jogadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelJogadores frm = new frmRelJogadores();
            frm.ShowDialog();
            frm.Close();
        }

        private void equipesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelBasicos relBasicos = new frmRelBasicos("relEquipes.rpt", "Relatório de Equipes");
            relBasicos.ShowDialog();
            relBasicos.Close();
        }

        private void tabelaDeJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelTabelaJogos frm = new frmRelTabelaJogos();
            frm.ShowDialog();
            frm.Close();
        }
    }
}
