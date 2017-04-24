using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.DAO;

namespace ProjetoServiceDesk.Controller
{
    public class AtividadeController
    {
        public AtividadeController() { }

        public List<Atividade> ObterSolicitanteFuncionario(string emailSolicitante, int codigoFuncionario, int codigoStatus)
        {
            return new AtividadeBD().ObterSolicitanteFuncionario(emailSolicitante, codigoFuncionario, codigoStatus);
        }
        public List<Atividade> Obter(char status)
        {
            List<Atividade> dados = null;
            switch(status)
            {
                case 'A':
                    dados = new AtividadeBD().ObterAbertas();
                    break;
                case 'F':
                    dados = new AtividadeBD().ObterFechadas();
                    break;
            }
            return dados;
        }

        public Atividade ObterAtividade(int codigoAtividade)
        {
            return codigoAtividade > 0 ? new AtividadeBD().Obter(codigoAtividade) : null;
        }
        
        public List<Atividade> ObterPorFuncionario(int codigoFuncionario)
        {
            if (codigoFuncionario > 0)
                return new AtividadeBD().ObterPorFuncionario(codigoFuncionario);
            else
                return null;
        }

        public List<Atividade> ObterPorStatus(int codigoStatus)
        {
            if (codigoStatus > 0)
                return new AtividadeBD().ObterPorStatus(codigoStatus);
            else
                return null;
        }

        public List<Atividade> ObterPorSolicitante(string emailSolicitante)
        {
            if (emailSolicitante.Contains("@"))
                return new AtividadeBD().ObterPorSolicitante(emailSolicitante);
            else
                return null;
        }

        public List<Atividade> ObterPorClassificacao(int codigoClassificacao)
        {
            if (codigoClassificacao > 0)
                return new AtividadeBD().ObterPorClassificacao(codigoClassificacao);
            else
                return null;
        }

        public int Gravar(Atividade ati)
        {
            if (ati.CodigoFuncionario > 0 && ati.EmailSolicitante.Trim().Length > 0 && ati.CodigoStatus > 0 && ati.Descricao.Trim().Length > 0)
                return new AtividadeBD().Gravar(ati);
            else
                return -1;
        }

        public int Excluir(int codigo)
        {
            if (codigo > 0)
                return new AtividadeBD().Excluir(codigo);
            else
                return -1;
        }
    }
}
