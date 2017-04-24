using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Copa2010.CamadaLogica;
using Copa2010.CamadaNegocio;

namespace Copa2010.CamadaApresentacao
{
    public partial class frmFases : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Fases negocio = new Fases();
        private string erroRetorno = string.Empty;
        
        public frmFases()
        {
            InitializeComponent();
            funcoes.limparTextBox(grpDados);
            funcoes.estadoBotoes(grpBotoes,Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
        }

        public int getCodigo()
        {
            return negocio.Fas_codigo;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            mtbCodigo.Text = "0";
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            tbDescricao.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes,Funcoes.eEstadoBotoes.Digitacao);
            tbDescricao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão?", "Confirmação",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //efetua a exclusão no banco
                negocio.Fas_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.excluir(out erroRetorno);
                if (erroRetorno != "")
                    funcoes.msgErro(erroRetorno);
                //..........................
                btnCancelar_Click(sender,e);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tbDescricao.Text == "")
                errorProvider.SetError(tbDescricao, "Informe a descrição");
            if (tbDescricao.Text != "")
            {
                negocio.Fas_codigo = Convert.ToInt32(mtbCodigo.Text);
                negocio.Fas_descricao = tbDescricao.Text;
                
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
            form.configuraTamanhoJanela(440, 368); //(width minimo = 440, height)
            //Configurando a Consulta
            string[] vet = new string[2];
            vet[0] = "Código";
            vet[1] = "Descrição";
            //vet[2] = "Data";
            //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, Nome Classe negócio)
            form.configuraOpcoes(vet, 2, 1, "Fases");
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
        
        private void preencheTela()
        {
            mtbCodigo.Text = Convert.ToString(negocio.Fas_codigo);
            tbDescricao.Text = negocio.Fas_descricao;
        }

        private void mtbCodigo_Leave(object sender, EventArgs e)
        {        
            if (mtbCodigo.Text != "" && !btnSair.Focused)
            {
                negocio.Fas_codigo = Convert.ToInt32(mtbCodigo.Text);
                if (negocio.buscarPorCodigo())
                {
                    preencheTela();
                    funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Alteracao);
                }
                else
                {
                    MessageBox.Show("Fase não encontrada!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcoes.limparTextBox(grpDados);
                    mtbCodigo.Clear();
                    mtbCodigo.Focus();
                }
            }

        }

        private void frmGrupos_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmGrupos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
            }
        }

        private void frmGrupos_Activated(object sender, EventArgs e)
        {
            mtbCodigo.Focus();
        }


    }
}
