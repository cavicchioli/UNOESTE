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

namespace PhoneApp1
{
    public partial class Mapa : PhoneApplicationPage
    {
        public Mapa()
        {
            InitializeComponent();
            this.Loaded += Mapa_Loaded;
        }

        private async void Mapa_Loaded(object sender, RoutedEventArgs e)
        {
            Geolocator geo = new Geolocator();
            if (geo.LocationStatus != PositionStatus.Disabled)
            {
                Geoposition pos = await geo.GetGeopositionAsync();
                mapa.Center = pos.Coordinate.ToGeoCoordinate();
            }
        }

        private void zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                mapa.ZoomLevel = e.NewValue;
            }
            catch 
            {
               
            }
        }
    }
}