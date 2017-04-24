using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoServiceDesk.Model
{
    public class Status
    {
        public Status() 
        {
            _codigo = 0;
        }

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
        private char _ativo;

        public char Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        private List<Atividade> _atividades;

        public List<Atividade> Atividades
        {
            get { return _atividades; }
            set { _atividades = value; }
        }
    }
}
