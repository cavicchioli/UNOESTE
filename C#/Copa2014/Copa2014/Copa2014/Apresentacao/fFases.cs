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
    public partial class fFases : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Fases fases = new Fases();
        private string erroRetorno = string.Empty;

        public fFases()
        {
            InitializeComponent();
            funcoes.limparControles(grpDados);
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
        }

        private void mtbCodigo_Leave(object sender, EventArgs e)
        {
            if (mtbCodigo.Text != "" && !btnSair.Focused)
            {
                fases.Codigo = Convert.ToInt32(mtbCodigo.Text);
                if (fases.buscarPorCodigo())
                {
                    preencheTela();
                    funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Alteracao);
                }
                else
                {
                    MessageBox.Show("Grupo não encontrado!", "Mensagem de Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    funcoes.limparControles(grpDados);
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
            tbDescricao.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Enabled = false;
            grpDados.Enabled = true;
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Digitacao);
            tbDescricao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão?", "Confirmação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //efetua a exclusão no banco
                fases.Codigo = Convert.ToInt32(mtbCodigo.Text);
                fases.excluir(out erroRetorno);
                if (erroRetorno != "")
                    funcoes.msgErro(erroRetorno);
                //..........................
                btnCancelar_Click(sender, e);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tbDescricao.Text == "")
                errorProvider.SetError(tbDescricao, "Informe a descrição");
            if (tbDescricao.Text != "")
            {
                fases.Codigo = Convert.ToInt32(mtbCodigo.Text);
                fases.Descricao = tbDescricao.Text;

                fases.salvar(out erroRetorno);
                if (erroRetorno != "")
                    funcoes.msgErro(erroRetorno);

                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtbCodigo.Clear();
            funcoes.limparControles(grpDados);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
            errorProvider.Clear();
            funcoes.estadoBotoes(grpBotoes, Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Focus();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            fConsultaFases form = new fConsultaFases();
            form.ShowDialog();
            if (form.Codigo != 0)
            {
                mtbCodigo.Text = Convert.ToString(form.Codigo);
                form.Dispose(); //Libera todos os componentes utilizados pelo form para coleta de lixo
                mtbCodigo.Focus();
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

        private void fFases_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                    break;
            }
        }

        private void fFases_FormClosing(object sender, FormClosingEventArgs e)
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

        private void fFases_Activated(object sender, EventArgs e)
        {
            mtbCodigo.Focus();
        }

        private void preencheTela()
        {
            mtbCodigo.Text = Convert.ToString(fases.Codigo);
            tbDescricao.Text = fases.Descricao;
        }
    }
}
