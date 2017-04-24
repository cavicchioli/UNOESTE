using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace PhoneApp1
{
    public partial class teclado : PhoneApplicationPage
    {
        public teclado()
        {
            InitializeComponent();

            List<Model.Keyboard> keyboards = new List<Model.Keyboard>();
            keyboards.Add(new Model.Keyboard { Tipo = "01", Descricao = "Text" });
            keyboards.Add(new Model.Keyboard { Tipo = "02", Descricao = "Number" });
            keyboards.Add(new Model.Keyboard { Tipo = "03", Descricao = "TelephoneNumber" });
            keyboards.Add(new Model.Keyboard { Tipo = "04", Descricao = "URL" });
            keyboards.Add(new Model.Keyboard { Tipo = "05", Descricao = "EmailNameOrAddress" });
            keyboards.Add(new Model.Keyboard { Tipo = "06", Descricao = "PersonalFullName" });
            keyboards.Add(new Model.Keyboard { Tipo = "07", Descricao = "Search" });

            tiposTeclados.ItemsSource = keyboards;
        }

        public void TrocarTeclado(string tipo, string descricao)
        {
            InputScope inputScope = new InputScope();
            InputScopeName inputScopeName = new InputScopeName();

            switch (tipo)
            {
                case "01":
                    inputScopeName.NameValue = InputScopeNameValue.Text;
                    break;
                case "02":
                    inputScopeName.NameValue = InputScopeNameValue.Number;
                    break;
                case "03":
                    inputScopeName.NameValue = InputScopeNameValue.TelephoneNumber;
                    break;
                case "04":
                    inputScopeName.NameValue = InputScopeNameValue.Url;
                    break;
                case "05":
                    inputScopeName.NameValue = InputScopeNameValue.EmailNameOrAddress;
                    break;
                case "06":
                    inputScopeName.NameValue = InputScopeNameValue.PersonalFullName;
                    break;
                case "07":
                    inputScopeName.NameValue = InputScopeNameValue.Search;
                    break;
            }

            inputScope.Names.Add(inputScopeName);
            txtTexto.InputScope = inputScope;
            txtTeste.InputScope = inputScope;

            MessageBox.Show(descricao, "Novo teclado:", MessageBoxButton.OK);
        }

        private void tiposTeclados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Keyboard kk = (Model.Keyboard)tiposTeclados.SelectedItem;
            TrocarTeclado(kk.Tipo, kk.Descricao);
        }

        private void txtTeste_ActionIconTapped(object sender, EventArgs e)
        {
            MessageBox.Show(txtTeste.Text);
        }
    }
}