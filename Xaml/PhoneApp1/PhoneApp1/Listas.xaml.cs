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

namespace PhoneApp1
{
    public partial class Listas : PhoneApplicationPage
    {
        List<Carro> carros = null;

        public Listas()
        {
            InitializeComponent();

            List<Carro> carros = new List<Carro>();
            carros.Add(new Carro { Nome = "Fusca", Cor = "Azul/Branco" });
            carros.Add(new Carro { Nome = "Brasilia", Cor = "Branca" });
            carros.Add(new Carro { Nome = "Variant", Cor = "Bege" });
            carros.Add(new Carro { Nome = "Passat", Cor = "Preto" });
            carros.Add(new Carro { Nome = "MP Lafer", Cor = "Azul" });
            carros.Add(new Carro { Nome = "Kombi", Cor = "Roxa" });
            carros.Add(new Carro { Nome = "Baja", Cor = "Vermelho" });
            carros.Add(new Carro { Nome = "Variant II", Cor = "Amarelo" });
            carros.Add(new Carro { Nome = "Gordine", Cor = "Azul calcinha" });
            carros.Add(new Carro { Nome = "Variant TL", Cor = "Marrom" });
            carros.Add(new Carro { Nome = "Kombi 2", Cor = "Roxa" });
            carros.Add(new Carro { Nome = "Baja 2", Cor = "Vermelho" });
            carros.Add(new Carro { Nome = "Variant II 2", Cor = "Amarelo" });
            carros.Add(new Carro { Nome = "Gordine 2", Cor = "Azul calcinha" });
            carros.Add(new Carro { Nome = "Variant TL 2", Cor = "Marrom" });

            lbSimples.ItemsSource = carros;
            lbCheck.ItemsSource = carros;

            this.ApplicationBar.IsVisible = false;
        }

        private void lbSimples_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Carro c = (Carro)lbSimples.SelectedItem;
            MessageBox.Show(string.Format("Carro: {0}, Cor: {1}", c.Nome, c.Cor));
        }

        private void mitemCaixaAlta_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            Carro c = mi.DataContext as Carro;
            c.Nome = c.Nome.ToUpper();
        }

        private void mitemCaixaBaixa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            Carro c = mi.DataContext as Carro;
            c.Nome = c.Nome.ToLower();
        }

        private void appbarOK_Click(object sender, EventArgs e)
        {
            string mensagens = "Seleção: ";

            foreach (Carro c in carros)
                if (c.IsSelected)
                    mensagens += c.Nome + " ";

            MessageBox.Show(mensagens);
        }

        private void appbarCancelar_Click(object sender, EventArgs e)
        {
            foreach (Carro c in carros)
                c.IsSelected = false;

            //lbCheck.Items.Clear();
            //lbCheck.ItemsSource = carros;


        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ApplicationBar.IsVisible = pivot.SelectedIndex == 0 ? false : true;
        }

        //private void CheckBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    var check = sender as CheckBox;
        //    Carro c = check.DataContext as Carro;
        //    if ((bool)check.IsChecked)
        //        c.IsSelected = true;
        //    else
        //        c.IsSelected = false;

        //}
    }
}