using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp1.Model;

namespace PhoneApp1.DAL
{
    public class AtendimentoBD
    {
        public AtendimentoBD() { }

        public List<Atendimento> ObterAtendimentos()
        {
            using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                List<Atendimento> dados = contexto.Atendimentos.OrderBy(x => x.IdCliente).ToList();
                return dados;
            }
        }

        public int Gravar(Atendimento atendimento)
        {
            try
            {
                using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    contexto.Atendimentos.InsertOnSubmit(atendimento);
                    contexto.SubmitChanges();
                }
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public int Excluir(int codigoAtendimento)
        {
            try
            {
                using (DataBaseContext contexto = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Atendimento a = contexto.Atendimentos.Where(x => x.ID == codigoAtendimento).FirstOrDefault();
                    contexto.Atendimentos.DeleteOnSubmit(a);
                    contexto.SubmitChanges();
                }
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
