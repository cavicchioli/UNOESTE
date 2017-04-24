using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPos.Model;

namespace ExemploPos.Controler
{
    public class StatusControladora
    {
        public StatusControladora() { }

        public List<Status> ObterStatus()
        {
            try
            {
                using (HelpDeskEntities contexto =
                    new HelpDeskEntities(Util.ConnectionString))
                {
                    var dados = (from s in contexto.Status
                                 where s.Ativo == "S"
                                 select s).ToList();
                    return dados;
                }
            }
            catch
            {
                return null;
            }
        }

        public int Alterar(Status status)
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    contexto.Entry(status).State = System.Data.EntityState.Modified;
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
