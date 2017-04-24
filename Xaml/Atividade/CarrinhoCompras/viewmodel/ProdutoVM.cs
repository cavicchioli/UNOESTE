using CarrinhoCompras.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Popups;

namespace CarrinhoCompras.viewmodel
{
    class ProdutoVM
    {
        public ObservableCollection<Produto> Produtos = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> Carrinho = new ObservableCollection<Produto>();
        public Produto prod = new Produto();

        public ProdutoVM()
        {
            CarregarProdutosLocal("Assets\\produtos.xml");
        }

        private async void CarregarProdutosLocal(string path)
        {
            StorageFile arq = await Package.Current.InstalledLocation.GetFileAsync(path);
            var xmlDocument = await XmlDocument.LoadFromFileAsync(arq);
            for (int i = 0; i < xmlDocument.SelectNodes("/produtos/produto").Count; i++)
            {
                var nodeItem = xmlDocument.SelectNodes("/produtos/produto")[i];
                Produto prod = new Produto()
                {
                    Id = Convert.ToInt32(nodeItem.SelectSingleNode("id").InnerText.Trim()),
                    Descricao = nodeItem.SelectSingleNode("descricao").InnerText.Trim(),
                    Preco = Convert.ToDecimal(nodeItem.SelectSingleNode("preco").InnerText.Trim()),
                    Url = nodeItem.SelectSingleNode("url").InnerText.Trim()
                };
                Produtos.Add(prod);
            }
        }

        public bool AdicionarAoCarrinho()
        {
            if (prod.Quantidade > 0)
            {
                if (Carrinho.IndexOf(prod) == -1)
                    Carrinho.Add(prod);
                return true;
            }
            else
                return false;
        }

        public void RemoverCarrinho(Produto p)
        {
            p.Quantidade = 0;
            Carrinho.Remove(p);
        }

        public ObservableCollection<Produto> PesquisarProduto(string descricao)
        {
            return new ObservableCollection<Produto>(
                Produtos.Where(prod => 
                { 
                    return prod.Descricao.ToLower().Contains(descricao.ToLower()); 
                }).ToList()
                );
        }

        public void LimparCarrinho()
        {
            Carrinho.Clear();
            
            List<Produto> lista = Produtos.Where(prod =>
                {
                    return prod.Quantidade > 0;
                }).ToList();

            foreach (Produto p in lista)
                p.Quantidade = 0;
        }
    }
}
