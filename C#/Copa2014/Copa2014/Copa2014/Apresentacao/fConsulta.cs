using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Copa2014.Logica;
using Copa2014.Negocio;

namespace Copa2014.Apresentacao
{
    public partial class fConsulta : Form
    {
        private Funcoes funcoes = new Funcoes();
        private int _codigo = 0;
        private string[] vetOpcoes = new string[8];
        private int tl;
        private int posDefault;
        private string tabela;

        public fConsulta()
        {
            InitializeComponent();
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public void configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, string tabela)
        {
            this.tl = tl;
            this.vetOpcoes = vetOpcoes;
            this.posDefault = posDefault;
            this.tabela = tabela;
            this.Text = "Localiza " + tabela;
        }

        public void configuraTamanhoJanela(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            grpBotoes.SetBounds(width - 162, -1, 149, 85);
            grpDados.Width = width - 19;
            grpDados.Height = height - (31 + 86);
            dgvLocaliza.Width = width - 35;
            dgvLocaliza.Height = grpDados.Height - 26;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            tbLocaliza.Text = tbLocaliza.Text.Replace("'", "´");
            switch (tabela)
            {
                case "Grupos":
                    if (cmbBox.Text == "Código")
                        dgvLocaliza.DataSource = (Grupos.buscarDados(mtbLocaliza.Text, 1));
                    else
                        if (cmbBox.Text == "Descrição")
                        {
                            dgvLocaliza.DataSource = (Grupos.buscarDados(tbLocaliza.Text, 2));
                        }
                    dgvLocaliza = Grupos.configuraGrid(dgvLocaliza);
                    break;

                case "Fases":
                    if (cmbBox.Text == "Código")
                        dgvLocaliza.DataSource = (Fases.buscarDados(mtbLocaliza.Text, 1));
                    else
                        if (cmbBox.Text == "Descrição")
                        {
                            dgvLocaliza.DataSource = (Fases.buscarDados(tbLocaliza.Text, 2));
                        }
                    dgvLocaliza = Fases.configuraGrid(dgvLocaliza);
                    break;

                case "Equipes":
                    if (cmbBox.Text == "Código")
                        dgvLocaliza.DataSource = (Equipes.buscarDados(mtbLocaliza.Text, 1));
                    else
                        if (cmbBox.Text == "Descrição")
                        {
                            dgvLocaliza.DataSource = (Equipes.buscarDados(tbLocaliza.Text, 2));
                        }
                    dgvLocaliza = Equipes.configuraGrid(dgvLocaliza);
                    break;

                case "Jogos":
                    if (cmbBox.Text == "Código")
                        dgvLocaliza.DataSource = (Jogos.buscarDados(mtbLocaliza.Text, 1));
                    else
                        if (cmbBox.Text == "Equipe")
                        {
                            dgvLocaliza.DataSource = (Jogos.buscarDados(tbLocaliza.Text, 2));
                        }
                    dgvLocaliza = Jogos.configuraGrid(dgvLocaliza);
                    break;

                case "Jogadores":
                    if (cmbBox.Text == "Código")
                        dgvLocaliza.DataSource = (Jogadores.buscarDados(mtbLocaliza.Text, 1));
                    else
                        if (cmbBox.Text == "Nome")
                        {
                            dgvLocaliza.DataSource = (Jogadores.buscarDados(tbLocaliza.Text, 2));
                        }
                    dgvLocaliza = Jogadores.configuraGrid(dgvLocaliza);
                    break;
            }

            cmbBox_SelectedIndexChanged(sender, e);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            _codigo = 0;
            Close();
        }

        private void dgvLocaliza_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _codigo = Convert.ToInt32(dgvLocaliza.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }

        private void fConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
                case Keys.Escape:
                    _codigo = 0;
                    this.Close();
                    break;
            }
        }

        private void fConsulta_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < tl; i++)
            {
                cmbBox.Items.Add(vetOpcoes[i]);
            }
            cmbBox.Text = vetOpcoes[posDefault];

            mtbLocaliza.Visible = false; //Código
            tbLocaliza.Visible = true; //Nome, Descrição etc... sempre colocar o campo texto como default
            //Data
            dtTimePdata.Visible = false;
            dtTimePdata2.Visible = false;
            lblInicial.Visible = false;
            lblFinal.Visible = false;

            tbLocaliza.Focus();
        }

        private void cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBox.Text == "Código")
            {
                tbLocaliza.Visible = false;
                dtTimePdata.Visible = false;
                dtTimePdata2.Visible = false;
                lblInicial.Visible = false;
                lblFinal.Visible = false;
                mtbLocaliza.Visible = true;
                mtbLocaliza.Focus();
                mtbLocaliza.SelectionStart = mtbLocaliza.Text.Length;
            }
            else
                if (cmbBox.Text == "Nome" || cmbBox.Text == "Descrição")
                {
                    tbLocaliza.Visible = true;
                    dtTimePdata.Visible = false;
                    dtTimePdata2.Visible = false;
                    lblInicial.Visible = false;
                    lblFinal.Visible = false;
                    mtbLocaliza.Visible = false;
                    tbLocaliza.Focus();
                    tbLocaliza.SelectionStart = tbLocaliza.Text.Length;
                }
                else
                    if (cmbBox.Text == "Data")
                    {
                        tbLocaliza.Visible = false;
                        dtTimePdata.Visible = true;
                        dtTimePdata2.Visible = true;
                        lblInicial.Visible = true;
                        lblFinal.Visible = true;
                        mtbLocaliza.Visible = false;
                        dtTimePdata.Value = DateTime.Now.Date;
                        dtTimePdata2.Value = DateTime.Now.Date;
                        dtTimePdata.Focus();
                    }
        }

        private void mtbLocaliza_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
