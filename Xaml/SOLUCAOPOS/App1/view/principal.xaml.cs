using App1.viewmodel;
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

namespace App1.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class principal : Page
    {
        NoticiaVM noticiavm = new NoticiaVM();

        public principal()
        {
            this.InitializeComponent();

            //noticiavm.Noticia.Categoria = "Categoria";
            //noticiavm.Noticia.Titulo = "Título";
            //noticiavm.Noticia.Texto = "Texto";
            //noticiavm.Noticia.URL = "URL";




        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainFrame.Navigate(typeof(view.listanoticias), noticiavm);
            btnVoltar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(view.cadastranoticia),noticiavm);
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(view.listanoticias),noticiavm);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) //voltar
            {
                MainFrame.GoBack();
                if(!MainFrame.CanGoBack)
                    btnVoltar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
                
        }
    }
}
