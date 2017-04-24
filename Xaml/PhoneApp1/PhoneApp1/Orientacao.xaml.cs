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
    public partial class Orientacao : PhoneApplicationPage
    {
        public Orientacao()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.SupportedOrientations = SupportedPageOrientation.Portrait;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.SupportedOrientations = SupportedPageOrientation.Landscape;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            this.SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (meuPanorama.SelectedIndex == 1)
            {
                if ((e.Orientation & PageOrientation.Portrait) == PageOrientation.Portrait)
                {
                    Grid.SetColumn(txtMensagemGrid, 0);
                    Grid.SetRow(txtMensagemGrid, 1);
                }
                if ((e.Orientation & PageOrientation.Landscape) == PageOrientation.Landscape)
                {
                    Grid.SetColumn(txtMensagemGrid, 1);
                    Grid.SetRow(txtMensagemGrid, 0);
                }
            }
            if ((e.Orientation & PageOrientation.Portrait) == PageOrientation.Portrait)
            {
                txtMensagem.Text = "Modo PORTRAIT";
                txtMensagemGrid.Text = "Modo PORTRAIT";
            }
            if ((e.Orientation & PageOrientation.Landscape) == PageOrientation.Landscape)
            {
                txtMensagem.Text = "Modo LANDSCAPE";
                txtMensagemGrid.Text = "Modo LANDSCAPE";
            }
        }
    }
}