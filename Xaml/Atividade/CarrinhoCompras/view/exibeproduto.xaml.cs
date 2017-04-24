using CarrinhoCompras.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class exibeproduto : Page
    {
        ProdutoVM produtovm = new ProdutoVM();
        public exibeproduto()
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
            DataContext = produtovm.prod;
        }

        private void AddCarrinho_Click(object sender, RoutedEventArgs e)
        {
            if (produtovm.AdicionarAoCarrinho())
            {
                Mensagem("Produto adicionado ao Carrinho de Compras");
                (this.Parent as Frame).GoBack();
            }
            else
                Mensagem("Voce deve selecionar uma quantidade para adicionar ao carrinho!");
        }

        private async void Mensagem(string msg)
        {
            MessageDialog msgDialog = new MessageDialog("", msg);
            await msgDialog.ShowAsync();
        }
    }
}
