using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.DAO;

namespace ProjetoServiceDesk.Controller
{
    public class ClassificacaoController
    {
        public ClassificacaoController() { }

        public int Gravar(Classificacao cla)
        {
            if (cla.Nome.Trim().Length > 0)
                return new ClassificacaoBD().Gravar(cla);
            else
                return -1;
        }

        public Classificacao Obter(int codigo, bool obterAtividades = true)
        {
            if (codigo > 0)
                return new ClassificacaoBD().Obter(codigo, obterAtividades);
            else
                return null;
        }

        /// <summary>
        /// Obter as classificação de acordo com seus status
        /// </summary>
        /// <param name="ativa">T=Todos; S=Ativas; N=Inativas</param>
        /// <returns></returns>
        public List<Classificacao> ObterPorStatus(char ativa)
        {
            if (ativa == 'T' || ativa == 'S' || ativa == 'N')
                return new ClassificacaoBD().ObterPorStatus(ativa);
            else
                return null;
        }

        public List<Classificacao> ObterPorAtividade(int codigoAtividade)
        {
            if (codigoAtividade > 0)
                return new ClassificacaoBD().ObterPorAtividade(codigoAtividade);
            else
                return null;
        }

        public int Excluir(int codigo)
        {
            if (codigo > 0)
                return new ClassificacaoBD().Excluir(codigo);
            else
                return -1;
        }

    }
}
