using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2010.CamadaLogica;

namespace Copa2010.CamadaNegocio
{
    class Fases
    {
        private int _fas_codigo;
        private string _fas_descricao;

        //instância do banco
        private BancoDados banco = new BancoDados();

        public Fases()
        {
            _fas_codigo = 0;
            _fas_descricao = string.Empty;
        }
    
        public int Fas_codigo
        {
            get { return _fas_codigo; }
            set { _fas_codigo = value; }
        }

        public string Fas_descricao
        {
            get { return _fas_descricao; }
            set { _fas_descricao = value; }
        }

        //Método para buscar e carregar a grid do Localizar
        public static DataTable buscarDados(string valor, int tipo)
        {
            BancoDados bd = new BancoDados(); //db existe aqui porque buscarDados é um método static,
            DataTable dt = new DataTable();

            bd.abrirConexao();
            //ele não pode acessar a variável de instância banco.
            switch (tipo)
            {
                case 1: bd.SqlCmd.CommandText = "select fas_codigo, fas_descricao from fases where fas_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select fas_codigo, fas_descricao from fases where fas_descricao like '%" + valor + "%'";
                    break;
            }
            dt.Load(bd.SqlCmd.ExecuteReader());
            bd.fecharConexao();

            return dt;
        }

        //Método para localizar os dados quando o foco sai do campo código
        public bool buscarPorCodigo()
        {
            DataTable dt = new DataTable();
            dt = banco.retDataTable("select * from fases where fas_codigo = " + _fas_codigo);

            if (dt.Rows.Count > 0)
            {
                _fas_codigo = Convert.ToInt32(dt.Rows[0]["fas_codigo"]);
                _fas_descricao = Convert.ToString(dt.Rows[0]["fas_descricao"]);

                return true;
            }
            else
                return false;
        }

        //Método para configurar a grid do Localizar
        public static DataGridView configuraGrid(DataGridView dtaGridView)
        {
            dtaGridView.Columns[0].HeaderText = "Código";
            dtaGridView.Columns[0].Width = 50;
            dtaGridView.Columns[1].HeaderText = "Descrição";
            dtaGridView.Columns[1].Width = 290;
            return dtaGridView;
        }

        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;

            banco.SqlCmd.CommandText = "delete from fases where fas_codigo = " + _fas_codigo;
            if (!banco.executarComando())
                mensagem = "Erro na Exclusão !";
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;
            int retornoQualquer;

            if (_fas_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into fases (fas_descricao) values (@fas_descricao)";
                banco.SqlCmd.Parameters.AddWithValue("@fas_descricao", _fas_descricao);
            }
            else
            {
                banco.SqlCmd.CommandText = "update fases set fas_descricao = @fas_descricao where fas_codigo = @fas_codigo";
                banco.SqlCmd.Parameters.AddWithValue("@fas_descricao", _fas_descricao);
                banco.SqlCmd.Parameters.AddWithValue("@fas_codigo", _fas_codigo);
            }

            if (!banco.executarComando())
                mensagem = "Erro na gravação";

            //Exemplo com transação
            /*
            banco.AutoConexao = false;
            banco.iniciarTransacao();

            banco.executarComando();

            banco.SqlCmd.CommandText = "select max(fas_codigo) from fases";
            retornoQualquer = Convert.ToInt32(banco.SqlCmd.ExecuteScalar());
            mensagem = retornoQualquer.ToString();

            if (!banco.commitTransacao())
            {
                banco.rollbackTransacao();
                mensagem = "";
            }
            */

            banco.fecharConexao();

        }
    }
}
