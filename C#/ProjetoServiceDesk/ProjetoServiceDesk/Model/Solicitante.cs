using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoServiceDesk.Model
{
    public class Solicitante
    {
        public Solicitante() { }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        private string _observacao;

        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

        private List<Atividade> _atividades;

        public List<Atividade> Atividades
        {
            get { return _atividades; }
            set { _atividades = value; }
        }
    }
}
