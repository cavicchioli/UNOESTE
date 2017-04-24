using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropagation.classe
{
    class Neuronio
    {
        private Double valor;
        private Double[] w;
        private Double net;
        private Double i;
        private Double erro;

        // CONSTRUTOR //
        public Neuronio()
        {
        }

        public void setValor(Double valor)
        {
            this.valor = valor;
        }

        public Double getValor()
        {
            return this.valor;
        }

        public Neuronio(Int32 numNeuros)
        {
            this.w = new Double[numNeuros];
            this.net = 0;
            this.i = 0;
            this.erro = 0;
        }

        public void setW(Int32 pos, Double w)
        {
            this.w[pos] = w;
        }

        public Double getW(Int32 pos)
        {
            return this.w[pos];
        }

        public void setNet(Double net)
        {
            this.net = net;
        }

        public Double getNet()
        {
            return this.net;
        }

        public void setI(Double i)
        {
            this.i = i;
        }

        public Double getI()
        {
            return this.i;
        }

        public void setErro(Double erro)
        {
            this.erro = erro;
        }

        public Double getErro()
        {
            return this.erro;
        }
    }
}
