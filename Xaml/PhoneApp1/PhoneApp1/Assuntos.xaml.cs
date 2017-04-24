using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class Assuntos : PhoneApplicationPage
    {
        public Assuntos()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja sair da APP?", "Confirmação",
                MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                base.OnBackKeyPress(e);
            }
            else
                e.Cancel = true;
        }

        private void hubOrientacao_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Orientacao.xaml", UriKind.Relative));
        }

        private void hubTeclado_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/teclados.xaml", UriKind.Relative));
        }

        private void hubNavigation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Parametros.xaml?p1=FIPP&p2=UNOESTE&p3=Windows Phone", UriKind.Relative));
        }

        private void hubDateTimePicker_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DataHora.xaml", UriKind.Relative));
        }

        private void hubLista_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Listas.xaml", UriKind.Relative));
        }

        private void hubIsolatedStored_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/IsolatedStored.xaml", UriKind.Relative));
        }

        private void hubBancoDados_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Database.xaml", UriKind.Relative));
        }

        private void hubGeo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Geo.xaml", UriKind.Relative));
        }

        private void hubMapa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Mapa.xaml", UriKind.Relative));
        }
    }
}