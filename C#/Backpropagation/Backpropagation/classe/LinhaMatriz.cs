using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropagation.classe
{
    class LinhaMatriz
    {
        private String[] Linha;

        // CONSTRUTOR //
        public LinhaMatriz()
        {
        }

        // CONSTRUTOR //
        public LinhaMatriz(String valores)
        {
            this.Linha = valores.Split(',');
        }

        // RETORNA O TAMANHO DA LINHA (QUANTIDADE DE COLUNAS ) //
        public Int32 getTamanho()
        {
            return this.Linha.Length;
        }

        // RETORNA UMA LINHA //
        public String[] getLinha()
        {
            return this.Linha;
        }

        // RETORNA VALOR NA POSIÇÃO PARAMETRO //
        public String getValor(Int32 i)
        {
            return this.Linha[i];
        }
    }
}
