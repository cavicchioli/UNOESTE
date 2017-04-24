using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class IsolatedStored : PhoneApplicationPage
    {
        public IsolatedStored()
        {
            InitializeComponent();
            string usuario, senha;
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            if (iso.TryGetValue<string>("login.Usuario", out usuario))
                txtUsuario.Text = usuario;

            if (iso.TryGetValue<string>("login.Senha", out senha))
            {
                txtSenha.Password = senha;
                ckbLembrar.IsChecked = true;
            }
        }
        private void btnAcesso_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;

            if (txtUsuario.Text == "admin" && txtSenha.Password == "123")
            {
                if ((bool)ckbLembrar.IsChecked)
                {
                    if (iso.Contains("login.Usuario"))
                    {
                        iso["login.Usuario"] = txtUsuario.Text;
                        iso["login.Senha"] = txtSenha.Password;
                    }
                    else
                    {
                        iso.Add("login.Usuario", txtUsuario.Text);
                        iso.Add("login.Senha", txtSenha.Password);
                    }
                    iso.Save();
                }
                else
                {
                    if (iso.Contains("login.Usuario"))
                    {
                        iso.Remove("login.Usuario");
                        iso.Remove("login.Senha");
                    }
                }

                NavigationService.Navigate(new Uri("/Notepad.xaml", UriKind.Relative));

                //MessageBox.Show("Acesso Concedido!");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "";
            txtSenha.Password = "";
        }
    }
}