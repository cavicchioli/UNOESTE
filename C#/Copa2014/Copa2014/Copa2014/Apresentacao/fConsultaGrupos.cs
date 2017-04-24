using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Copa2014.Negocio;
using Copa2014.Logica;

namespace Copa2014.Apresentacao
{
    public partial class fConsultaGrupos : Form
    {
        private int _codigo = 0;
        
        public fConsultaGrupos()
        {
            InitializeComponent();
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        //--- evento dos botões --------------------------------------
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //dgvLocaliza.DataSource = Grupos.buscarDados(tbLocaliza.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            _codigo = 0;
            Close();
        }

        //--- evento click e duplo click --------------------------------
        private void dtaGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _codigo = Convert.ToInt32(dgvLocaliza.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }

        //--- eventos do formulário -------------------------------------
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocalizar_Click(sender, e);
            }
        }
    }
}