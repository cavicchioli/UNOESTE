using CarrinhoCompras.model;
using CarrinhoCompras.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CarrinhoCompras.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class listaprodutos : Page
    {
        ProdutoVM produtovm = new ProdutoVM();
        public listaprodutos()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            produtovm = e.Parameter as ProdutoVM;
            ltvProdutos.ItemsSource = produtovm.Produtos;
        }

        private void ltvProdutos_ItemClick(object sender, ItemClickEventArgs e)
        {
            produtovm.prod = e.ClickedItem as Produto;
            (this.Parent as Frame).Navigate(typeof(exibeproduto), produtovm);
        }

        public void Pesquisar(string descricao)
        {
            ltvProdutos.ItemsSource = produtovm.PesquisarProduto(descricao);
        }

        public void RestauraLista()
        {
            ltvProdutos.ItemsSource = produtovm.Produtos;
        }
    }
}
