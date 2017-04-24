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
    public partial class Geo : PhoneApplicationPage
    {
        public Geo()
        {
            InitializeComponent();
        }

        private async void btnObter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            pbAguardar.IsIndeterminate = true;

            Geolocator geo = new Geolocator();
            if (geo.LocationStatus != PositionStatus.Disabled)
            {

                geo.MovementThreshold = 100;
                geo.ReportInterval = 1000;
                geo.DesiredAccuracy = PositionAccuracy.High;
                geo.PositionChanged+= geo_PositionChanged;

                Geoposition pos = await geo.GetGeopositionAsync();
                txtLatitude.Text = pos.Coordinate.Latitude.ToString();
                txtLongitude.Text = pos.Coordinate.Longitude.ToString();

            }

            pbAguardar.IsIndeterminate = false;

        }

        private void geo_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() => {
                txtLatitude.Text = args.Position.Coordinate.Latitude.ToString();
                txtLongitude.Text = args.Position.Coordinate.Longitude.ToString();
            
            });
        }
    }
}