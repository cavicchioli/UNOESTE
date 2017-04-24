using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Model;
using PhoneApp1.DAL;

namespace PhoneApp1
{
    public partial class Database : PhoneApplicationPage
    {
        ProdutoBD prodBD = null;

        public Database()
        {
            InitializeComponent();
            prodBD = new ProdutoBD();
            ObterProdutos();

        }

        private void ObterProdutos()
        {
            lbProdutos.ItemsSource = prodBD.ObterProdutos();
            
        }

        private void ckProdutos_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Dispatcher.BeginInvoke(() =>
                {
                    var p = sender as CheckBox;
                    if (p != null)
                    {
                        Produto prod = p.DataContext as Produto;
                        prodBD.Selecionar(prod.ID);
                    }
                });
            
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var i = sender as Image;
            if (i != null)
            {
                Produto p = i.DataContext as Produto;

                if (prodBD.Excluir(p.ID) > 0)
                    ObterProdutos();
            }
        }

        private void txtProdutos_ActionIconTapped(object sender, EventArgs e)
        {
            if (txtProdutos.Text.Trim().Length > 0)
            {
                string[] produto = null;
                Produto p = new Produto();

                if (txtProdutos.Text.Contains(','))
                {
                    produto = txtProdutos.Text.Split(',');
                    p.Nome = produto[0].Trim();
                    p.Marca = produto[1].Trim();
                }
                else
                    p.Nome = txtProdutos.Text.Trim();

                p.Selecionado = false;

                prodBD.Gravar(p);

                txtProdutos.Text = string.Empty;
                ObterProdutos();
            }
            else
                MessageBox.Show("Digite alguma informação");
        }
    }
}