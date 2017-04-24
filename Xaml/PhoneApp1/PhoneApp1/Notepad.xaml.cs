using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PhoneApp1
{
    public partial class Notepad : PhoneApplicationPage
    {
        public Notepad()
        {
            InitializeComponent();
            LerDados();

        }

        private async void CriarPasta(string nomePasta)
        {
            StorageFolder folder;

            try
            {
                folder = await ApplicationData.Current.LocalFolder.GetFolderAsync(nomePasta);
            }
            catch (Exception)
            {
                folder = null;
            }
            if (folder == null)
                await ApplicationData.Current.LocalFolder.CreateFolderAsync(nomePasta);
        }

        private async void LerDados()
        {
            CriarPasta("myNotes");
            StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("myNotes");

            try
            {
                StorageFile file = await folder.GetFileAsync("notes.txt");
                IRandomAccessStream randomStream = await file.OpenAsync(FileAccessMode.Read);
                using (DataReader reader = new DataReader(randomStream.GetInputStreamAt(0)))
                {
                    uint bytes = await reader.LoadAsync((uint)randomStream.Size);
                    string texto = reader.ReadString(bytes);
                    txtTexto.Text = texto;
                }
                randomStream.Dispose();
            }
            catch { }
        }

        private async void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("myNotes");
            StorageFile file = await folder.CreateFileAsync("notes.txt",CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream randomStream = await file.OpenAsync(FileAccessMode.ReadWrite);

            using (DataWriter writer = new DataWriter(randomStream.GetOutputStreamAt(0)))
            {
                writer.WriteString(txtTexto.Text);
                await writer.StoreAsync();
            }
            randomStream.Dispose();

        }

        private async void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Limpar Anotações?", "Confirmação", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                StorageFolder folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("myNotes");

                try
                {
                    StorageFile file = await folder.GetFileAsync("notes.txt");
                    await file.DeleteAsync();
                    txtTexto.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Não há anotações para serem deletadas.", "informações", MessageBoxButton.OK);
                }
            }

        }
    }
}