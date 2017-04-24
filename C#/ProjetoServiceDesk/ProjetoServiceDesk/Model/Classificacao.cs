using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoServiceDesk.Model
{
    public class Classificacao
    {
        public Classificacao() { _codigo = 0; }

        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private char _ativa;

        public char Ativa
        {
            get { return _ativa; }
            set { _ativa = value; }
        }

        private List<Atividade> _atividades;

        public List<Atividade> Atividades
        {
            get { return _atividades; }
            set { _atividades = value; }
        }
    }
}
