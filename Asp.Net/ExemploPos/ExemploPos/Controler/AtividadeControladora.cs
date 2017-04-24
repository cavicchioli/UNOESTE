using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploPos.Model;

namespace ExemploPos.Controler
{
    public class AtividadeControladora
    {
        public AtividadeControladora() { }

        public List<AtividadeDTO> ObterListaAtividades(int codigoFuncionario)
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    var dados = (from a in contexto.Atividade
                                 where a.CodigoFuncionario == codigoFuncionario
                                 orderby a.DataInicio descending
                                 select new AtividadeDTO
                                 {
                                     Codigo = a.Codigo,
                                     Descricao = a.Descricao,
                                     DataInicio = a.DataInicio,
                                     DataFim = a.DataFim,
                                     Status = a.Status.Descricao,
                                     Solicitante = a.Solicitante.Nome
                                 }).ToList();
                    return dados;
                }
            }
            catch
            {      
                return null;
            }
        }

        public List<AtividadeDTO> ObterListaAtividades(int codigoFuncionario, int numeroPagina, int registrosPorPagina)
        {
            int salto = 0;
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    if (numeroPagina > 1)
                        salto = (numeroPagina - 1) * registrosPorPagina;
                    var dados = (from a in contexto.Atividade
                                 where a.CodigoFuncionario == codigoFuncionario
                                 orderby a.DataInicio descending
                                 select new AtividadeDTO
                                 {
                                     Codigo = a.Codigo,
                                     Descricao = a.Descricao,
                                     DataInicio = a.DataInicio,
                                     DataFim = a.DataFim,
                                     Status = a.Status.Descricao,
                                     Solicitante = a.Solicitante.Nome
                                 }).Skip(salto).Take(registrosPorPagina).ToList();
                    return dados;
                }
            }
            catch
            {
                return null;
            }
        }

        public int ObterQuantidadeAtividades(int codigoFuncionario)
        {
            try
            {
                using (HelpDeskEntities contexto = new HelpDeskEntities(Util.ConnectionString))
                {
                    return (from a in contexto.Atividade
                            where a.CodigoFuncionario == codigoFuncionario
                            select a.Codigo).Count();
                }
            }
            catch
            {
                return -2;
            }
        }
    }
}
