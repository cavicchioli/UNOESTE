using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.IO.IsolatedStorage;
using PhoneApp1.Model;
using PhoneApp1.DAL;

namespace PhoneApp1
{
    public partial class Principal : PhoneApplicationPage
    {
        private AtendimentoBD atendBD = null;

        #region LOAD
        public Principal()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-br");
            InitializeComponent();

            dtpDataI.Value = DateTime.Now.Date;
            tmpHoraI.Value = DateTime.Now.Date;

            if (loadSettings())
            {
                btnGravar.Visibility = System.Windows.Visibility.Collapsed;
                btnFinalizar.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                btnGravar.Visibility = System.Windows.Visibility.Visible;
                btnFinalizar.Visibility = System.Windows.Visibility.Collapsed;
            }

            atendBD = new AtendimentoBD();
            ObterAtendimentos();
        }
        #endregion
        #region METHODS
        private void ObterAtendimentos()
        {
            lbAtendRealizados.ItemsSource = atendBD.ObterAtendimentos();
        }
        #endregion
        #region SETTINGS METHODS
        private bool loadSettings()
        {
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            string cliente = "";
            DateTime data, hora;

            if (iso.TryGetValue<string>("atendimento.cliente", out cliente))
                txtCliente.Text = cliente;

            if (iso.TryGetValue<DateTime>("atendimento.data", out data))
                dtpDataI.Value = data;

            if (iso.TryGetValue<DateTime>("atendimento.hora", out hora))
                tmpHoraI.Value = hora;

            return cliente != null ? true : false;
        }  
        private void saveSettings()
        {
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            if (iso.Contains("atendimento.cliente"))
            {
                iso["atendimento.cliente"] = txtCliente.Text;
                iso["atendimento.data"] = dtpDataI.Value;
                iso["atendimento.hora"] = tmpHoraI.Value;
            }
            else
            {
                iso.Add("atendimento.cliente", txtCliente.Text);
                iso.Add("atendimento.data", dtpDataI.Value);
                iso.Add("atendimento.hora", tmpHoraI.Value);
            }
            iso.Save();
        }
        private void removeSettings()
        {
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            if (iso.Contains("atendimento.cliente"))
            {
                iso.Remove("atendimento.cliente");
                iso.Remove("atendimento.data");
                iso.Remove("atendimento.hora");
            }
        }
        #endregion
        #region PHONE EVENTS
        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtCliente.Text.Trim().Length > 0))
                MessageBox.Show("A identificação do cliente é obrigatória!");
            {
                saveSettings();
                btnGravar.Visibility = System.Windows.Visibility.Collapsed;
                btnFinalizar.Visibility = System.Windows.Visibility.Visible;

            }
        }
        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Atendimento a = new Atendimento();
            loadSettings();
            a.IdCliente = txtCliente.Text.Trim();
            a.DataInicial = (DateTime)dtpDataI.Value;
            a.HoraInicial = (DateTime)tmpHoraI.Value;
            a.DataFinal = (DateTime)dtpDataF.Value;
            a.HoraFinal = (DateTime)tmpHoraF.Value;
            a.Latitude = txtLatitude.Text.Trim();
            a.Longitude = txtLongitude.Text.Trim();

            if (atendBD.Gravar(a) > 0)
            {
                txtCliente.Text = txtLatitude.Text = txtLongitude.Text = string.Empty;
                dtpDataI.Value = tmpHoraI.Value = DateTime.Now;
                ckAtendido.IsChecked = false;
                ckAtendido_Tap(null, null);
                removeSettings();
                ObterAtendimentos();
                panAtendimentos.TabIndex = 1;
            }
        }
        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (MessageBox.Show("Excluir Atendimento?", "Confirmação", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var i = sender as Image;
                if (i != null)
                {
                    Atendimento a = i.DataContext as Atendimento;
                    if (atendBD.Excluir(a.ID) > 0)
                        ObterAtendimentos();
                }
            }
        }
        private async void ckAtendido_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if ((bool)ckAtendido.IsChecked)
            {
                gdAtendido.Opacity = 1;
                btnGravar.Visibility = System.Windows.Visibility.Collapsed;
                btnFinalizar.Visibility = System.Windows.Visibility.Visible;
                dtpDataF.Value = DateTime.Now.Date;
                tmpHoraF.Value = DateTime.Now.Date;

                Geolocator geo = new Geolocator();
                if (geo.LocationStatus != PositionStatus.Disabled)
                {
                    geo.MovementThreshold = 100;
                    geo.ReportInterval = 1000;
                    geo.DesiredAccuracy = PositionAccuracy.High;
                    geo.PositionChanged += geo_PositionChanged;

                    Geoposition pos = await geo.GetGeopositionAsync();
                    txtLatitude.Text = pos.Coordinate.Latitude.ToString();
                    txtLongitude.Text = pos.Coordinate.Longitude.ToString();
                }
            }
            else
            {
                gdAtendido.Opacity = 0;
                btnGravar.Visibility = System.Windows.Visibility.Visible;
                btnFinalizar.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        void geo_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                txtLatitude.Text = args.Position.Coordinate.Latitude.ToString();
                txtLongitude.Text = args.Position.Coordinate.Longitude.ToString();
            });
        }
        #endregion
    }
}