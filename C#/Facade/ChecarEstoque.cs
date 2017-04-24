using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CEINT
{
    class ChecarEstoque : Banco2
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private int _qtdeSaida;

        public int QtdeSaida
        {
            get { return _qtdeSaida; }
            set { _qtdeSaida = value; }
        }

        public ChecarEstoque(int codigo, int qtde)
        {
            _codigo = codigo;
            _qtdeSaida = qtde;
        }

        public DataTable retornaSaldoEstoque()
        {
            bool flag = false;

            string sql = "";

            DataTable dt = new DataTable();

            sql = "select codigo, saldo from Materiais where codigo = @pcod";

            flag = ExecuteQuery(sql, out dt, "@pcod", _codigo);

            return dt;
        }

        public bool decrementaSaldoEstoque()
        {
            string sql = "";

            bool flag = false;

            sql = "update Materiais set saldo = @pqtde where @pcodigo";

            flag = ExecuteNonQuery(sql, "@pqtde", _qtdeSaida, "@pcodigo", _codigo);

            return flag;
        }

        public bool verificaSaldo()
        {
            bool flag = true;
            int saldo;
            DataTable dt = new DataTable();

            dt = retornaSaldoEstoque();

            if (dt.Rows.Count > 0)
            {
                saldo = Convert.ToInt32(dt.Rows[0]["saldo"]);

                if (saldo < _qtdeSaida)
                {
                    flag = false;
                }
                else
                    decrementaSaldoEstoque();
            }
            
            return flag;
        }
    }
}
