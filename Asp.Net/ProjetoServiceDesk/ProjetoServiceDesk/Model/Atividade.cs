using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoServiceDesk.Model
{
    public class Atividade
    {
        public Atividade() { _codigo = 0; }

        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        private DateTime _dataInicio;

        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set { _dataInicio = value; }
        }
        private DateTime? _dataFim;

        public DateTime? DataFim
        {
            get { return _dataFim; }
            set { _dataFim = value; }
        }
        private int _codigoFuncionario;

        public int CodigoFuncionario
        {
            get { return _codigoFuncionario; }
            set { _codigoFuncionario = value; }
        }

        private int _codigoStatus;

        public int CodigoStatus
        {
            get { return _codigoStatus; }
            set { _codigoStatus = value; }
        }

        private string _emailSolicitante;

        public string EmailSolicitante
        {
            get { return _emailSolicitante; }
            set { _emailSolicitante = value; }
        }

        private List<Classificacao> _classificacoes;

        public List<Classificacao> Classificacoes
        {
            get { return _classificacoes; }
            set { _classificacoes = value; }
        }

        private Solicitante _solicitante;

        public Solicitante Solicitante
        {
            get { return _solicitante; }
            set { _solicitante = value; }
        }

        private Funcionario _funcionario;

        public Funcionario Funcionario
        {
            get { return _funcionario; }
            set { _funcionario = value; }
        }

        private Status _status;

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
