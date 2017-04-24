using App1.model;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class cadastranoticia : Page
    {
        NoticiaVM noticiaVM;

        public cadastranoticia()
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
            //AnimacaoTranslate();

            //AnimaOpacity();

           // AnimacaoRotate();

            noticiaVM = e.Parameter as NoticiaVM;
            ltvNoticias.ItemsSource = noticiaVM.Noticias;
            DataContext = noticiaVM.Noticia;

            noticiaVM.Noticia.Titulo = "Título da Notícia";
            noticiaVM.Noticia.Categoria = "Categoria";
            noticiaVM.Noticia.Texto = "Texto";
            noticiaVM.Noticia.URL = "http://www.fundosanimais.com/Imagens/imagens-lobos.jpg";

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            noticiaVM.GravarNoticia();

            DataContext = noticiaVM.Noticia;
        }

        private void AnimaOpacity()
        {
            Storyboard stb = new Storyboard();

            DoubleAnimation daX = new DoubleAnimation();
            ExponentialEase exe = new ExponentialEase();
            exe.EasingMode = EasingMode.EaseInOut;
            daX.EasingFunction = exe;
            daX.From = 0;
            daX.To = 1;
            daX.Duration = new Duration(new TimeSpan(0, 0, 0, 2, 0));
            daX.BeginTime = new TimeSpan(0);
            Storyboard.SetTarget(daX, grdPrincipal);
            Storyboard.SetTargetProperty(daX, "Opacity");

            stb.Children.Add(daX);

            stb.Begin();
        }

        private void AnimacaoTranslate()
        {
            Storyboard stb = new Storyboard();

            DoubleAnimation daX = new DoubleAnimation();
            var exe = new BounceEase();
            exe.EasingMode = EasingMode.EaseOut;
            daX.EasingFunction = exe;
            daX.From = -1000;
            daX.To = 0;
            daX.Duration = new Duration(new TimeSpan(0, 0, 0, 3, 0));
            daX.BeginTime = new TimeSpan(0);
            Storyboard.SetTarget(daX, cptFundo);
            Storyboard.SetTargetProperty(daX, "RotateTransform.TranslateY");

            stb.Children.Add(daX);

            stb.Begin();
        }

        private void AnimacaoRotate()
        {
            Storyboard stb = new Storyboard();

            DoubleAnimation daX = new DoubleAnimation();
            ExponentialEase exe = new ExponentialEase();
            exe.EasingMode = EasingMode.EaseInOut;
            daX.EasingFunction = exe;
            daX.From = 30;
            daX.To = 0;
            daX.Duration = new Duration(new TimeSpan(0, 0, 0, 1, 0));
            daX.BeginTime = new TimeSpan(0);
            Storyboard.SetTarget(daX, cptFundo);
            Storyboard.SetTargetProperty(daX, "RotateTransform.Rotation");

            stb.Children.Add(daX);

            stb.Begin();
        }

        private void ltvNoticias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            noticiaVM.Noticia = noticiaVM.Noticias[ltvNoticias.SelectedIndex];
            DataContext = noticiaVM.Noticia;
        }

    }
}
