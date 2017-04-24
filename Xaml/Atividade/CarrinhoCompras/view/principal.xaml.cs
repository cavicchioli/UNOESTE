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

namespace CarrinhoCompras
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class principal : Page
    {
        ProdutoVM produtosVM = new ProdutoVM();
        public principal()
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
            MainFrame.Navigate(typeof(view.listaprodutos), produtosVM);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.CanGoBack)
                btnVoltar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            else
                btnVoltar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            if (MainFrame.Content is view.listaprodutos)
            {
                ola.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                ola.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();

            verificaBusca();
        }

        private void verificaBusca()
        {
            if (ola.Visibility == Windows.UI.Xaml.Visibility.Visible)
            {
                if (!ttbDescricao.Text.Equals(""))
                    btnPesquisar_Click(null, null);
            }
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(view.listaprodutos), produtosVM);
        }

        private void btnCarrinhoProduto_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(view.carrinho), produtosVM);
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is view.listaprodutos)
            {
                view.listaprodutos lista = MainFrame.Content as view.listaprodutos;
                lista.Pesquisar(ttbDescricao.Text);
            }
        }

        private void btnLimparCarrinho_Click(object sender, RoutedEventArgs e)
        {
            produtosVM.LimparCarrinho();
        }

        private void btnRestauraProd_Click(object sender, RoutedEventArgs e)
        {
            ttbDescricao.Text = "";
            view.listaprodutos lista = MainFrame.Content as view.listaprodutos;
            lista.RestauraLista();
        }
    }
}
