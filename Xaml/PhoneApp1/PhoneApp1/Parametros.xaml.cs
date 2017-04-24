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
    public partial class Parametros : PhoneApplicationPage
    {
        public Parametros()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Recuperando um parâmetro
            string x = NavigationContext.QueryString["p1"];

            //Recuperando parâmetros e criando elementos em tempo de execução
            int i = 1;
            foreach (string parametro in NavigationContext.QueryString.Values)
            {
                TextBlock txt = new TextBlock
                {
                    FontSize = 24,
                    Margin = new Thickness(12,10,0,0),
                    Text = string.Format("Parâmetro[{0}]={1}",i.ToString(),parametro)
                };
                i++;
                ContentPanel.Children.Add(txt);
            }
            base.OnNavigatedTo(e);
        }
    }
}