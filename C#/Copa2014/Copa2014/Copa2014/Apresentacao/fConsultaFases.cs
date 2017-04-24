using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Copa2014.Negocio;

namespace Copa2014.Apresentacao
{
    public partial class fConsultaFases : Form
    {
        private int _codigo = 0;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public fConsultaFases()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //dgvLocaliza.DataSource = Fases.buscarDados(tbLocaliza.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            _codigo = 0;
            Close();
        }

        private void tbLocaliza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLocalizar_Click(sender, e);
            }
        }

        private void dgvLocaliza_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _codigo = Convert.ToInt32(dgvLocaliza.Rows[e.RowIndex].Cells[0].Value);
                Close();
            }
        }
    }
}
