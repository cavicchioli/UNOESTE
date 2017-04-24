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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAlterarIncluirCliente_Click(object sender, EventArgs e)
        {
            if(!customerIDTextBox.Text.Equals(""))
            {
                try
                {
                    acessoLinqCrud.InsertOrUpdateCustomer(customerIDTextBox.Text, companyNameTextBox.Text, contactNameTextBox.Text, contactTitleTextBox.Text,
                        addressTextBox.Text, cityTextBox.Text, regionTextBox.Text, postalCodeTextBox.Text, countryTextBox.Text, phoneTextBox.Text,
                        faxTextBox.Text);
                    MessageBox.Show("Cliente atualizado/incluído com sucesso !");
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

        private void Form2_Load(object sender, EventArgs e)
        {
            customerIDTextBox.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
