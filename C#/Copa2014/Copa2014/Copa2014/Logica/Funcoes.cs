using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Copa2014.Logica
{
    class Funcoes
    {
        public enum eEstadoBotoes { Inicial, Digitacao, Alteracao };

        public void limparControles(Control controles)
        {
            foreach (Control ctl in controles.Controls)
            {
                if (ctl is TextBox) ctl.Text = string.Empty;
                if (ctl is MaskedTextBox) ctl.Text = string.Empty;
                if (ctl is ComboBox) ctl.Text = string.Empty;
                if (ctl is DateTimePicker) ctl.Text = Convert.ToString(DateTime.Now);
            }
        }

        public void estadoBotoes(Control controles, eEstadoBotoes estado)
        {
            //Sempre habilita todos botoes
            foreach (Control ctl in controles.Controls)
            {
                if (ctl is Button)
                    ctl.Enabled = true;
            }
            if (estado == eEstadoBotoes.Inicial)
            {
                foreach (Control ctl in controles.Controls)
                {
                    if (ctl is Button && (ctl.Name != "btnNovo" && ctl.Name != "btnLocalizar" && ctl.Name != "btnSair"))
                        ctl.Enabled = false;
                }
            }
            if (estado == eEstadoBotoes.Digitacao)
            {
                foreach (Control ctl in controles.Controls)
                {
                    if (ctl is Button && (ctl.Name != "btnSalvar" && ctl.Name != "btnCancelar" && ctl.Name != "btnSair"))
                        ctl.Enabled = false;
                }
            }
            if (estado == eEstadoBotoes.Alteracao)
            {
                foreach (Control ctl in controles.Controls)
                {
                    if (ctl is Button && (ctl.Name != "btnAlterar" && ctl.Name != "btnCancelar" && ctl.Name != "btnExcluir" && ctl.Name != "btnSair"))
                        ctl.Enabled = false;
                }
            }
        }

        public void msgErro (string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
