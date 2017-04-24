using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;

namespace PhoneApp1
{
    public partial class DataHora : PhoneApplicationPage
    {
        public DataHora()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                new CultureInfo("pt-br");

            InitializeComponent();
        }

        private void dtpData_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            DateTime data = (DateTime)dtpData.Value;
            MessageBox.Show(data.ToLongDateString());
        }
    }
}