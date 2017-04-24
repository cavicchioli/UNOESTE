using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoServiceDesk.Model
{
    public class Funcionario
    {
        public Funcionario() { _codigo = 0; }

        #region Propriedades do Funcionario
        private int _codigo;
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }
        private string _nome;

        public string Nome
        {
            get 
            {
                //string nome = _nome.ToUpper();
                return _nome; 
            }
            set { _nome = value; }
        }
        private DateTime _dataContratacao;

        public DateTime DataContratacao
        {
            get { return _dataContratacao; }
            set { _dataContratacao = value; }
        }
        private DateTime? _dataDemissao;

        public DateTime? DataDemissao
        {
            get { return _dataDemissao; }
            set { _dataDemissao = value; }
        }
        private char _ativo;

        public char Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        private char _tipo;

        public char Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public List<Atividade> Atividades { get; set; }
        #endregion
    }
}
