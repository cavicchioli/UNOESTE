using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPos.Model;

namespace ExemploPos.Controler
{
    public class SolicitanteControladora
    {
        public SolicitanteControladora() { }

        public List<Solicitante> ObterSolicitantes()
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    return (from s in contexto.Solicitante
                            orderby s.Nome
                            select s).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Gravar(Solicitante sol)
        {
            try
            {
                using (HelpDeskEntities contexto =
                    new HelpDeskEntities(Util.ConnectionString))
                {
                    contexto.Solicitante.Add(sol);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
