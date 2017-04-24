using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace EF4_Crud_DAL
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Fom inicializa componentes
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        Cliente registro;
        ClientesDAL clientes;

        /// <summary>
        /// Evento Load do formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            clientes = new ClientesDAL();
            registro = new Cliente();

            List<Cliente> resultado = clientes.GetAll();
            dgvClientes.DataSource = resultado.ToList();
            int codigo = Convert.ToInt32(dgvClientes.Rows[0].Cells[0].Value);
            if (codigo > 0 )
            {
                Cliente cli = clientes.GetRegistroPorCodigo(codigo);
                preencheControles(cli);
            }
        }
        /// <summary>
        /// preencheControles do formulário com dados
        /// </summary>
        /// <param name="cliente"></param>
        private void preencheControles(Cliente cliente)
        {
            txtID.Text = cliente.id.ToString();
            txtNome.Text = cliente.nome;
            txtEndereco.Text = cliente.endereco;
            txtCep.Text = cliente.cep;
            txtCidade.Text = cliente.cidade;
            txtCelular.Text = cliente.celular;
            txtTelefone.Text = cliente.telefone;
            txtEmail.Text = cliente.email;
            txtContato.Text = cliente.contato;
            txtObs.Text = cliente.obs;
        }

        /// <summary>
        /// Evento CellEnter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           int codCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Value);
           Cliente resultado = clientes.GetRegistroPorCodigo(codCliente);
           preencheControles(resultado);
        }

        /// <summary>
        /// Excluir registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja excluir este registro?", "Excluir", MessageBoxButtons.YesNo);
            switch (resposta)
            {
                case DialogResult.Yes:
                    clientes = new ClientesDAL();
                    registro = new Cliente();
                    registro.id = Convert.ToInt32(txtID.Text);
                    if (clientes.DeleteRegistro(registro))
                    {
                        MessageBox.Show("Registro excluido com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o registro");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        /// <summary>
        /// Sair do programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja encerrar a aplicação?", "Encerrar", MessageBoxButtons.YesNo);
            switch (resposta)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        /// <summary>
        /// Botão atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            clientes = new ClientesDAL();
            registro = new Cliente();

            atualizaRegistro(registro);

            if (clientes.UpdateRegistro(registro))
            {
                MessageBox.Show("Registro atualizado com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao atualizar o registro");
            }
        }

        /// <summary>
        /// atualizaRegistro
        /// </summary>
        /// <param name="cliente"></param>
        private void atualizaRegistro(Cliente cliente)
        {
            cliente.nome = txtNome.Text;
            cliente.endereco = txtEndereco.Text;
            cliente.cep = txtCep.Text;
            cliente.cidade = txtCidade.Text;
            cliente.celular = txtCelular.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.email = txtEmail.Text;
            cliente.contato = txtContato.Text;
            cliente.obs = txtObs.Text;
        }
        /// <summary>
        /// Evento Click do botão Incluir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            limparControles(this);
            txtNome.Focus();
            btnSalvar.Visible = true;
        }
   
        /// <summary>
        /// validaDados
        /// </summary>
        /// <returns></returns>
        private bool validaDados()
        {
            if (txtNome.Text == string.Empty || txtEndereco.Text == String.Empty || txtEmail.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// limparControles
        /// </summary>
        /// <param name="control"></param>
        private void limparControles(Control control)
        {
            foreach (Control textBox in control.Controls)
            {
                if (textBox is TextBox)
                {
                    ((TextBox)textBox).Text = string.Empty;
                }
            }
        }
        /// <summary>
        /// Salva os registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clientes = new ClientesDAL();
            registro = new Cliente();
            if (validaDados())
            {
                atualizaRegistro(registro);
                int retorno = clientes.SaveRegistro(registro);

                if (retorno > 0)
                {
                    MessageBox.Show("Registro atualizado com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o registro");
                }
            }
            else
            {
                MessageBox.Show("Dados Inválidos...");
            }
            btnSalvar.Visible = false;
        }
    }
}
