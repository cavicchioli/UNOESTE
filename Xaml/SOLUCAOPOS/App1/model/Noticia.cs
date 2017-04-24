using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.model
{
    class Noticia : INotifyPropertyChanged
    {
        private String _categoria;
        private String _titulo;
        private String  _texto;
        private String _url;

        public  Noticia()
        {

        }

        public String URL
        {
            get { return _url; }
            set { _url = value; OnPropertyChanged("URL"); }
        }

        public String  Texto
        {
            get { return _texto; }
            set { _texto = value; OnPropertyChanged("Texto"); }
        }

        public String Titulo
        {
            get { return _titulo; }
            set { _titulo = value; OnPropertyChanged("Titulo"); }
        }
        

        public String Categoria
        {
            get { return _categoria; }
            set { _categoria = value; OnPropertyChanged("Categoria"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
