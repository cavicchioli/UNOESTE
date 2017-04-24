using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPos.Model;

namespace ExemploPos.Controler
{
    public class FuncionarioControladora
    {
        public FuncionarioControladora() { }

        public Funcionario ValidarAcesso(int codigo, string senha)
        {
            Funcionario func = null;
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    return (from f in contexto.Funcionario
                            where f.Codigo == codigo && f.Senha == senha &&
                                  f.Ativo == "S" && f.DataDemissao == null
                            select f).FirstOrDefault();
                }
            }
            catch
            {
                return func;
            }
        }
    }
}
