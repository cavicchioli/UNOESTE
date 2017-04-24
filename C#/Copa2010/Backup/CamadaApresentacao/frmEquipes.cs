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
    public partial class frmEquipes : Form
    {

        private Funcoes funcoes = new Funcoes();
        private Equipes negocio = new Equipes();
        private BancoDados dados = new BancoDados();
        private string erroRetorno = string.Empty;

        public frmEquipes()
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
                pbBandeira.Image = img;
            }
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            negocio.Equ_nome = "Brasil";
            negocio.Gru_codigo = 3;

            //Salvando a imagem
            if (pbBandeira.Image != null)
            {
                MemoryStream msImagem = new MemoryStream();
                pbBandeira.Image.Save(msImagem, ImageFormat.Png);
                negocio.Equ_bandeira = msImagem.GetBuffer();
            }

            negocio.salvar(out erroRetorno);
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            pbBandeira.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            negocio.Equ_codigo = 3;
            negocio.buscarPorCodigo();

            MemoryStream msImagem = new MemoryStream(negocio.Equ_bandeira);
            pbBandeira.Image = Image.FromStream(msImagem);
        }
        */

        private void btnNovo_Click(object sender, EventArgs e)
        {
            mtbCodigo.Text = "0";
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            tbNome.Focus();

            dados.PreencherCbo(cbGrupo, "grupos", "gru_codigo", "gru_descricao");
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
                negocio.Equ_codigo = Convert.ToInt32(mtbCodigo.Text);
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

            if (cbGrupo.SelectedItem.ToString() == "")
                errorProvider.SetError(cbGrupo, "Informe o Grupo");

            if (pbBandeira.Image == null)
                errorProvider.SetError(pbBandeira, "Informe a Imagem");

            if ( (tbNome.Text != "") && (cbGrupo.SelectedValue.ToString() != "") && (pbBandeira.Image != null) )
            {
                negocio.Equ_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.Equ_nome = tbNome.Text;
                negocio.Gru_codigo = Convert.ToInt32(cbGrupo.SelectedValue.ToString());

                //Salvando a imagem
                if (pbBandeira.Image != null)
                {
                    MemoryStream msImagem = new MemoryStream();
                    pbBandeira.Image.Save(msImagem, ImageFormat.Png);
                    negocio.Equ_bandeira = msImagem.GetBuffer();
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

            pbBandeira.Image = null;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaPadrao form = new frmConsultaPadrao();
            form.configuraTamanhoJanela(440, 368); //(width minimo = 440, height)
            //Configurando a Consulta
            string[] vet = new string[2];
            vet[0] = "Código";
            vet[1] = "Descrição";
            //vet[2] = "Data";
            //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, Nome Classe negócio)
            form.configuraOpcoes(vet, 2, 1, "Equipes");
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

        public int getCodigo()
        {
            return negocio.Equ_codigo;
        }


        private void preencheTela()
        {
            mtbCodigo.Text = Convert.ToString(negocio.Equ_codigo);
            tbNome.Text = negocio.Equ_nome;
            cbGrupo.SelectedValue = negocio.Gru_codigo;

            MemoryStream msImagem = new MemoryStream(negocio.Equ_bandeira);
            pbBandeira.Image = Image.FromStream(msImagem);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquipes_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmEquipes_Activated(object sender, EventArgs e)
        {
            mtbCodigo.Focus();

            dados.PreencherCbo(cbGrupo, "grupos", "gru_codigo", "gru_descricao");
        }

        private void frmEquipes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
            }
        }

        private void mtbCodigo_Leave(object sender, EventArgs e)
        {
            if (mtbCodigo.Text != "" && !btnSair.Focused)
            {
                negocio.Equ_codigo = Convert.ToInt32(mtbCodigo.Text);
                if (negocio.buscarPorCodigo())
                {
                    preencheTela();
                    funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Alteracao);
                }
                else
                {
                    MessageBox.Show("Equipe não encontrada!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcoes.limparTextBox(grpDados);
                    mtbCodigo.Clear();
                    mtbCodigo.Focus();
                }
            }
        }
    }
}
