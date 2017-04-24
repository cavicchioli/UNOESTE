using AppProdutos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace AppProdutos.ViewModel
{
    class ProdutoVM
    {
        public ObservableCollection<Produto> Produtos = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> Carrinho = new ObservableCollection<Produto>();
        public Produto Produto = new Produto();

        public ProdutoVM()
        {
            Carregar();
        }

        public void AdicionarAoCarrinho()
        {
            Carrinho.Add(Produto);
        }

        public void RemoverDoCarrinho(Produto p)
        {
            Carrinho.Remove(p);
        }


        public ObservableCollection<Produto> PesquisarProduto(string descricao)
        {
            return new ObservableCollection<Produto>(
                Produtos.Where( prod => 
                {
                    return prod.Descricao.ToLower().Contains(descricao.ToLower());
                }).ToList()
            );
        }

        private async void Carregar()
        {
            StorageFile arq = await Package.Current.InstalledLocation.GetFileAsync("Assets\\produtos.xml");
            var xmlDocument = await XmlDocument.LoadFromFileAsync(arq);
            for (int i = 0; i < xmlDocument.SelectNodes("/produtos/produto").Count; i++)
            {
                var nodeItem = xmlDocument.SelectNodes("/produtos/produto")[i];
                Produto prod = new Produto()
                {
                    Id = Convert.ToInt32(nodeItem.SelectSingleNode("id").InnerText.Trim()),
                    Descricao = nodeItem.SelectSingleNode("descricao").InnerText.Trim(),
                    Preco = Convert.ToDecimal(nodeItem.SelectSingleNode("preco").InnerText.Trim()),
                    Url = nodeItem.SelectSingleNode("url").InnerText.Trim(),
                    Quantidade = 0
                };
                Produtos.Add(prod);
            }
        }
    }
}
