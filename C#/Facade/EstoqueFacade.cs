using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEINT
{
    class EstoqueFacade
    {
        private int _codigoMaterial;

        public int CodigoMaterial
        {
            get { return _codigoMaterial; }
            set { _codigoMaterial = value; }
        }
        private int _quantidadeSaida;

        public int QuantidadeSaida
        {
            get { return _quantidadeSaida; }
            set { _quantidadeSaida = value; }
        }

        ChecarEstoque check;

        public EstoqueFacade(int codigoMaterial, int quantidadeSaida)
        {
            
            _codigoMaterial = codigoMaterial;
            _quantidadeSaida = quantidadeSaida;

            check = new ChecarEstoque(_codigoMaterial, _quantidadeSaida);

        }

        public void verficarSaldo()
        {
            bool flag;

            flag = check.verificaSaldo();
        }
    }
}
