using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Copa2014.Logica;
using Copa2014.Negocio;

namespace Copa2014.Apresentacao
{
    public partial class fGrupos : Form
    {
        private Funcoes funcoes = new Funcoes();
        private Grupos grupos = new Grupos();
        private string erroRetorno = string.Empty;
        
        public fGrupos()
        {
            InitializeComponent();
            funcoes.limparControles(grpDados);
            funcoes.estadoBotoes(grpBotoes,Funcoes.eEstadoBotoes.Inicial);
            mtbCodigo.Enabled = true;
            grpDados.Enabled = false;
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
                grupos.Codigo = Convert.ToInt32(mtbCodigo.Text);
                grupos.excluir(out erroRetorno);
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
                grupos.Codigo = Convert.ToInt32(mtbCodigo.Text);
                grupos.Descricao = tbDescricao.Text;
                
                grupos.salvar(out erroRetorno);
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
            fConsulta form = new fConsulta();
            form.configuraTamanhoJanela(440, 368); //(width minimo = 440, height)
            //Configurando a Consulta
            string[] vet = new string[2];
            vet[0] = "Código";
            vet[1] = "Descrição";
            //vet[2] = "Data";
            //configuraOpcoes(string[] vetOpcoes, int tl, int posDefault, Nome Classe negócio)
            form.configuraOpcoes(vet, 2, 1, "Grupos");
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
            mtbCodigo.Text = Convert.ToString(grupos.Codigo);
            tbDescricao.Text = grupos.Descricao;
        }

        private void mtbCodigo_Leave(object sender, EventArgs e)
        {        
            if (mtbCodigo.Text != "" && !btnSair.Focused)
            {
                grupos.Codigo = Convert.ToInt32(mtbCodigo.Text);
                if (grupos.buscarPorCodigo())
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
