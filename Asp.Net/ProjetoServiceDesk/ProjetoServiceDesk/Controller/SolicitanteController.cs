using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.DAO;
using ProjetoServiceDesk.Model;

namespace ProjetoServiceDesk.Controller
{
    public class SolicitanteController
    {
        public SolicitanteController() { }

        /// <summary>
        /// Inserir ou Alterar um Solicitante
        /// </summary>
        /// <param name="sol">Solicitante</param>
        /// <param name="acao">I=Insert; U=Update</param>
        /// <returns></returns>
        public int Gravar(Solicitante sol, char acao)
        {
            if (acao == 'I' || acao == 'U')
                return new SolicitanteBD().Gravar(sol, acao);
            else
                return -1;
        }

        public Solicitante Obter(string email, bool obterAtividades = true)
        {
            if (email.Contains("@"))
                return new SolicitanteBD().Obter(email, obterAtividades);
            else
                return null;
        }

        public List<Solicitante> Obter(string palavraChave)
        {
            if (palavraChave.Trim().Length > 0)
                return new SolicitanteBD().Obter(palavraChave);
            else
                return null;
        }

        public List<Solicitante> Obter()
        {
           return new SolicitanteBD().Obter();
        }


        public List<Solicitante> Obter(int codigoFuncionario, int codigoStatus)
        {
            if (codigoFuncionario > 0 && codigoStatus > 0)
                return new SolicitanteBD().Obter(codigoFuncionario, codigoStatus);
            else
                return null;
        }

        public int Excluir(string email)
        {
            if (email.Trim().Length > 0)
                return new SolicitanteBD().Excluir(email);
            else
                return -1;
        }
    }
}
