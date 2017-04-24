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
    public partial class frmJogos : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Jogos negocio = new Jogos();
        private BancoDados dados = new BancoDados();
        private string erroRetorno = string.Empty;

        public frmJogos()
        {
            InitializeComponent();
            funcoes.limparTextBox(grpDados);
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
        }

        private void mtbCodigo_Leave(object sender, EventArgs e)
        {
            if (mtbCodigo.Text != "" && !btnSair.Focused)
            {
                negocio.Jog_codigo = Convert.ToInt32(mtbCodigo.Text);
                if (negocio.buscarPorCodigo())
                {
                    preencheTela();
                    funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Alteracao);
                }
                else
                {
                    MessageBox.Show("Jogo não encontrado!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcoes.limparTextBox(grpDados);
                    mtbCodigo.Clear();
                    mtbCodigo.Focus();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            mtbCodigo.Text = "0";
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            dtpData.Focus();

            dados.PreencherCbo(cbEquipe1, "equipes", "equ_codigo", "equ_nome");
            dados.PreencherCbo(cbEquipe2, "equipes", "equ_codigo", "equ_nome");
            dados.PreencherCbo(cbFase, "fases", "fas_codigo", "fas_descricao");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            dtpData.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //efetua a exclusão no banco
                negocio.Jog_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.excluir(out erroRetorno);
                if (erroRetorno != "")
                    funcoes.msgErro(erroRetorno);
                //..........................
                btnCancelar_Click(sender, e);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dtpData.Text == "")
                errorProvider.SetError(dtpData, "Informe a Data");

            if (mtbHora.Text == "")
                errorProvider.SetError(mtbHora, "Informe a Hora");

            if (tbLocal.Text == "")
                errorProvider.SetError(tbLocal, "Informe o Local");

            if (cbEquipe1.SelectedItem.ToString() == "")
                errorProvider.SetError(cbEquipe1, "Informe a Equipe 1");

            if (cbEquipe2.SelectedItem.ToString() == "")
                errorProvider.SetError(cbEquipe2, "Informe a Equipe 2");

            if (cbFase.SelectedItem.ToString() == "")
                errorProvider.SetError(cbFase, "Informe a Fase");


            if ((dtpData.Text != "") && (mtbHora.Text != "") && (tbLocal.Text != "") && (cbEquipe1.SelectedValue.ToString() != "") && (cbEquipe2.SelectedValue.ToString() != "") && (cbFase.SelectedValue.ToString() != ""))
            {
                negocio.Jog_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.Jog_data = Convert.ToDateTime(dtpData.Value.ToString());
                negocio.Jog_hora = mtbHora.Text;
                negocio.Jog_local = tbLocal.Text;
                negocio.Equ_codigo1 = Convert.ToInt32(cbEquipe1.SelectedValue.ToString());
                negocio.Equ_codigo2 = Convert.ToInt32(cbEquipe2.SelectedValue.ToString());
                negocio.Fas_codigo = Convert.ToInt32(cbFase.SelectedValue.ToString());

                negocio.Goltime1 = 0;
                negocio.Goltime2 = 0;

                negocio.salvar(out erroRetorno);

                if (erroRetorno != "")
                    funcoes.msgErro(erroRetorno);

                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Clear();
            funcoes.limparTextBox(grpDados);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
            errorProvider.Clear();
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Focus();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaPadrao form = new frmConsultaPadrao();
            form.configuraTamanhoJanela(750, 500); //(width minimo = 440, height)
            //Configurando a Consulta
            string[] vet = new string[2];
            vet[0] = "Código";
            vet[1] = "Equipe";
            //vet[2] = "Data";
            //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, Nome Classe negócio)
            form.configuraOpcoes(vet, 2, 1, "Jogos");
            //........................   
            form.ShowDialog();
            if (form.Codigo != 0)
            {
                mtbCodigo.Text = Convert.ToString(form.Codigo);
                form.Dispose();
                mtbCodigo_Leave(sender, e);
            }
            else
            {
                form.Dispose();
                mtbCodigo.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int getCodigo()
        {
            return negocio.Jog_codigo;
        }

        private void frmJogos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
            }
        }

        private void frmJogos_Activated(object sender, EventArgs e)
        {
            mtbCodigo.Focus();

            dados.PreencherCbo(cbEquipe1, "equipes", "equ_codigo", "equ_nome");
            dados.PreencherCbo(cbEquipe2, "equipes", "equ_codigo", "equ_nome");
            dados.PreencherCbo(cbFase, "fases", "fas_codigo", "fas_descricao");
        }

        private void frmJogos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSalvar.Enabled)
            {
                if (MessageBox.Show("Inclusão ou Alteração em andamento! \nDeseja realmente Sair?", "Fechar Formulário",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void preencheTela()
        {
            mtbCodigo.Text = Convert.ToString(negocio.Jog_codigo);
            dtpData.Value = negocio.Jog_data;
            mtbHora.Text = negocio.Jog_hora;
            tbLocal.Text = negocio.Jog_local;
            cbEquipe1.SelectedValue = negocio.Equ_codigo1;
            cbEquipe2.SelectedValue = negocio.Equ_codigo2;
            cbFase.SelectedValue = negocio.Fas_codigo;
        }
    }
}
