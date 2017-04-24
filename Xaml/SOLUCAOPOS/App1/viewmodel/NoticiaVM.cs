using App1.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace App1.viewmodel
{
    class NoticiaVM
    {
        public ObservableCollection<Noticia> Noticias = new ObservableCollection<Noticia>();
        public Noticia Noticia = new Noticia();

        public NoticiaVM()
        {
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/entretenimento.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/brasil.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/celebridades.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/cotidiano.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/economia.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/esporte.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/televisao.xml");
            CarregarNoticias("http://www3.uol.com.br/xml/midiaindoor/internacional.xml");
        }


        public void NovaNoticia()
        {
            Noticia = new Noticia();
        }

        public void GravarNoticia()
        {
            Noticias.Add(Noticia);
            NovaNoticia();

        }

        private async void CarregarNoticias(string urlRss)
        {
            var xmlDocument = await XmlDocument.LoadFromUriAsync(new Uri(urlRss));
            for (int i = 0; i < xmlDocument.SelectNodes("/rss/channel/item").Count; i++)
            {
                var nodeItem = xmlDocument.SelectNodes("/rss/channel/item")[i];
                Noticia noticia = new Noticia()
                {
                    Titulo = nodeItem.SelectSingleNode("title").InnerText.Trim(),
                    Texto = nodeItem.SelectSingleNode("description").InnerText.Trim(),
                    URL = nodeItem.SelectSingleNode("linkfoto").InnerText.Trim()
                    
                };
                Noticias.Add(noticia);
            }
        }

    }
}
