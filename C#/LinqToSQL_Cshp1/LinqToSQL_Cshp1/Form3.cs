using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqToSQL_Cshp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            customerIDTextBox.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            if (!customerIDTextBox.Text.Equals(""))
            {
                try
                {
                    acessoLinqCrud.DeleteCustomer(customerIDTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
            else
            {
                MessageBox.Show("Valores inválidos.");
            }
        }

    }
}
