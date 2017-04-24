using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPos.Model;

namespace ExemploPos.Controler
{
    public class ClassificacaoControladora
    {
        public ClassificacaoControladora() { }

        public List<Classificacao> ObterClassificacoes()
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    return (from c in contexto.Classificacao
                            where c.Ativa == "S"
                            orderby c.Nome
                            select c).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Classificacao Obter(int codigo)
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    return (from c in contexto.Classificacao
                            where c.Codigo == codigo
                            select c).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
