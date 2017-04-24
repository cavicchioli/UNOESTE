using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp1.Model;
using PhoneApp1.DAL;

namespace PhoneApp1.DAL
{
    class ProdutoBD
    {
        public List<Produto> ObterProdutos()
        {
            using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                List<Produto> dados = contexto.Produtos.OrderBy(x => x.Nome).ToList();
                return dados;
            }
        }

        public int Gravar(Produto p)
        {
            using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                contexto.Produtos.InsertOnSubmit(p);
                contexto.SubmitChanges();
            }
            return 1;
        }

        public int Selecionar(int cod)
        {
            try
            {
                using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Produto p = contexto.Produtos.Where(x => x.ID == cod).FirstOrDefault();
                    p.Selecionado = !p.Selecionado;
                    contexto.SubmitChanges();

                }
                return 1;

            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int Excluir(int cod)
        {
            try
            {
                using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Produto p = contexto.Produtos.Where(x => x.ID == cod).FirstOrDefault();
                    contexto.Produtos.DeleteOnSubmit(p);
                    contexto.SubmitChanges();

                }
                return 1;

            }
            catch (Exception)
            {

                return -1;
            }
        }


    }

}
