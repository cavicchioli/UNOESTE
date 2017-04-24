using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Copa2010.CamadaLogica;
using Copa2010.CamadaNegocio;
using System.IO;
using System.Drawing.Imaging;

namespace Copa2010.CamadaApresentacao
{
    public partial class frmResultadosJogos : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Jogos negocio = new Jogos();
        private BancoDados dados = new BancoDados();
        private string erroRetorno = string.Empty;
        
        public frmResultadosJogos()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            //Preenche a Grid
            DataTable dt = new DataTable();
            string SQL = "";

            SQL = "select j.jog_codigo, CONVERT(varchar, j.jog_data, 103) as data, j.jog_hora, e1.equ_bandeira, e1.equ_nome, j.jog_goltime1, 'X' as sep, j.jog_goltime2, e2.equ_nome, e2.equ_bandeira, j.jog_local, f.fas_descricao from jogos j, equipes e1, equipes e2, fases f where f.fas_codigo = j.fas_codigo and e2.equ_codigo = j.equ_codigo2 and e1.equ_codigo = j.equ_codigo1 ";

            if (cbFase.SelectedValue.ToString().Trim() != "0")
            {
                SQL = SQL + " and j.fas_codigo =  " + cbFase.SelectedValue.ToString() + " ";
            }

            if (cbGrupo.SelectedValue.ToString().Trim() != "0")
            {
                SQL = SQL + " and e1.gru_codigo =  " + cbGrupo.SelectedValue.ToString() + " ";
            }
            

            dt = dados.retDataTable(SQL);

            dgvJogos.DataSource = dt;

            //Configura GRID
            dgvJogos.Columns[0].HeaderText = "Cód.";
            dgvJogos.Columns[0].Width = 35;
            dgvJogos.Columns[0].ReadOnly = true;
            //dgvJogos.Columns[0].Visible = false;

            dgvJogos.Columns[1].HeaderText = "Data";
            dgvJogos.Columns[1].Width = 70;
            dgvJogos.Columns[1].ReadOnly = true;

            dgvJogos.Columns[2].HeaderText = "Hora";
            dgvJogos.Columns[2].Width = 45;
            dgvJogos.Columns[2].ReadOnly = true;

            dgvJogos.Columns[3].HeaderText = "";
            dgvJogos.Columns[3].Width = 35;
            dgvJogos.Columns[3].ReadOnly = true;

            dgvJogos.Columns[4].HeaderText = "Equipe 1";
            dgvJogos.Columns[4].Width = 120;
            dgvJogos.Columns[4].ReadOnly = true;

            dgvJogos.Columns[5].HeaderText = "Gols";
            dgvJogos.Columns[5].Width = 60;

            dgvJogos.Columns[6].HeaderText = "X";
            dgvJogos.Columns[6].Width = 20;
            dgvJogos.Columns[6].ReadOnly = true;

            dgvJogos.Columns[7].HeaderText = "Gols";
            dgvJogos.Columns[7].Width = 60;

            dgvJogos.Columns[8].HeaderText = "Equipe 2";
            dgvJogos.Columns[8].Width = 120;
            dgvJogos.Columns[8].ReadOnly = true;

            dgvJogos.Columns[9].HeaderText = "";
            dgvJogos.Columns[9].Width = 35;
            dgvJogos.Columns[9].ReadOnly = true;

            dgvJogos.Columns[10].HeaderText = "Local";
            dgvJogos.Columns[10].Width = 120;
            dgvJogos.Columns[10].ReadOnly = true;

            dgvJogos.Columns[11].HeaderText = "Fase";
            dgvJogos.Columns[11].Width = 100;
            dgvJogos.Columns[11].ReadOnly = true;

            //Habilita Botão Gravar
            if (dgvJogos.RowCount > 0)
            {
                btnSalvar.Enabled = true;
            }

            btnCancelar.Enabled = true;
        }

        private void frmResultadosJogos_Activated(object sender, EventArgs e)
        {
            dados.PreencherCbo_Union(cbFase, "fases", "fas_codigo", "fas_descricao", "Todos");
            cbFase.SelectedValue = 0;

            dados.PreencherCbo_Union(cbGrupo, "grupos", "gru_codigo", "gru_descricao", "Todos");
            cbGrupo.SelectedValue = 0;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cbFase.SelectedValue = 0;
            cbGrupo.SelectedValue = 0;

            dgvJogos.DataSource = "";

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Grava Placares
            int cod_jogo = 0;
            int placar1 = 0;
            int placar2 = 0;

            int varErro = 0;

            foreach (DataGridViewRow linha in this.dgvJogos.Rows)
            {
                if ( (linha.Cells[5].Value.ToString().Trim() != "") && (linha.Cells[7].Value.ToString().Trim() != "") )
                {
                    cod_jogo = Convert.ToInt32(linha.Cells[0].Value);
                    placar1 = Convert.ToInt32(linha.Cells[5].Value);
                    placar2 = Convert.ToInt32(linha.Cells[7].Value);
                    
                    negocio.salvar_placar(cod_jogo, placar1, placar2 ,out erroRetorno);

                    if (erroRetorno != "")
                    {
                        funcoes.msgErro(erroRetorno);
                        varErro++;
                        break;
                    }
                }
            }

            if (varErro == 0)
            {
                btnCancelar_Click(sender, e);

                MessageBox.Show("Gravado com Sucesso !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvJogos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvJogos.Columns[e.ColumnIndex].HeaderText == "Gols")
            {
                e.CellStyle.BackColor = Color.AliceBlue;
            }
        }

    }
}
