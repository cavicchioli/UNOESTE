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
    public partial class frmJogadores : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Jogadores negocio = new Jogadores();
        private BancoDados dados = new BancoDados();
        private string erroRetorno = string.Empty;
        
        public frmJogadores()
        {
            InitializeComponent();
            funcoes.limparTextBox(grpDados);
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                pbFoto.Image = img;
            }
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
                    MessageBox.Show("Jogador não encontrado!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcoes.limparTextBox(grpDados);
                    mtbCodigo.Clear();
                    mtbCodigo.Focus();
                }
            }
        }

        private void frmJogadores_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
            }
        }

        private void frmJogadores_Activated(object sender, EventArgs e)
        {
            mtbCodigo.Focus();

            dados.PreencherCbo(cbEquipe, "equipes", "equ_codigo", "equ_nome");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            mtbCodigo.Text = "0";
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            tbNome.Focus();
            
            dados.PreencherCbo(cbEquipe, "equipes", "equ_codigo", "equ_nome");
        }

        private void frmJogadores_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int getCodigo()
        {
            return negocio.Jog_codigo;
        }

        private void preencheTela()
        {
            mtbCodigo.Text = Convert.ToString(negocio.Jog_codigo);
            tbNome.Text = negocio.Jog_nome;
            dtpDataNasc.Value = negocio.Jog_dtnascimento;
            tbPosicao.Text = Convert.ToString(negocio.Jog_posicao);
            cbEquipe.SelectedValue = negocio.Equ_codigo;

            MemoryStream msImagem = new MemoryStream(negocio.Jog_foto);
            pbFoto.Image = Image.FromStream(msImagem);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            tbNome.Focus();
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
            if (tbNome.Text == "")
                errorProvider.SetError(tbNome, "Informe o Nome");

            if (dtpDataNasc.Text == "")
                errorProvider.SetError(dtpDataNasc, "Informe a Data de Nascimento");

            if (tbPosicao.Text == "")
                errorProvider.SetError(tbPosicao, "Informe a Posição");

            if (cbEquipe.SelectedItem.ToString() == "")
                errorProvider.SetError(cbEquipe, "Informe a Equipe");

            if (pbFoto.Image == null)
                errorProvider.SetError(pbFoto, "Informe a Foto");

            if ((tbNome.Text != "") && (dtpDataNasc.Text != "") && (tbPosicao.Text != "") && (cbEquipe.SelectedValue.ToString() != "") && (pbFoto.Image != null))
            {
                negocio.Jog_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.Jog_nome = tbNome.Text;
                negocio.Jog_dtnascimento = Convert.ToDateTime(dtpDataNasc.Value.ToString());
                negocio.Jog_posicao = tbPosicao.Text;
                negocio.Equ_codigo = Convert.ToInt32(cbEquipe.SelectedValue.ToString());

                //Salvando a imagem
                if (pbFoto.Image != null)
                {
                    MemoryStream msImagem = new MemoryStream();
                    pbFoto.Image.Save(msImagem, ImageFormat.Png);
                    negocio.Jog_foto = msImagem.GetBuffer();
                }

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

            pbFoto.Image = null;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaPadrao form = new frmConsultaPadrao();
            form.configuraTamanhoJanela(750, 500); //(width minimo = 440, height)
            //Configurando a Consulta
            string[] vet = new string[2];
            vet[0] = "Código";
            vet[1] = "Nome";
            //vet[2] = "Data";
            //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, Nome Classe negócio)
            form.configuraOpcoes(vet, 2, 1, "Jogadores");
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

    }
}
