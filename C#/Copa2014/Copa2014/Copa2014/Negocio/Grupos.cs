using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2014.Logica;

namespace Copa2014.Negocio
{
    class Grupos
    {
        private int _codigo;
        private string _descricao;
        //instância do banco
        private BancoDados banco = new BancoDados();
        
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
                     
        public Grupos()
        {
            _codigo = 0;
            _descricao = string.Empty;
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;

            if (_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into grupos (gru_descricao) values (@descricao)";
                banco.SqlCmd.Parameters.AddWithValue("@descricao", _descricao);
            }
            else
            {
                banco.SqlCmd.CommandText = "update grupos set gru_descricao = @descricao where gru_codigo = @codigo";
                banco.SqlCmd.Parameters.AddWithValue("@descricao", _descricao);
                banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);
            }
            
            if (!banco.executarComando())
                mensagem = "Erro na gravação";            
        }

        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;
            
            banco.SqlCmd.CommandText = "delete from grupos where gru_codigo = @codigo";
            banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);
            if (!banco.executarComando())
                mensagem = "Erro na exclusão";
        }

        /// <summary>
        /// Método para localizar os dados quando o foco sai do campo código
        /// </summary>
        /// <returns></returns>
        public bool buscarPorCodigo()
        {
            banco.abrirConexao();
            banco.SqlCmd.CommandText = "select * from grupos where gru_codigo = @codigo";
            banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);

            DataTable dt = new DataTable();
            dt.Load(banco.SqlCmd.ExecuteReader());
            banco.fecharConexao();

            if (dt.Rows.Count > 0)
            {
                _codigo = Convert.ToInt32(dt.Rows[0]["gru_codigo"]);
                _descricao = Convert.ToString(dt.Rows[0]["gru_descricao"]);
                return true;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Método para buscar e carregar a grid do Localizar
        /// </summary>
        /// <param name="termoBusca">String pesquisada</param>
        /// <returns></returns>
        public static DataTable buscarDados(string valor, int tipo)
        {
            BancoDados bd = new BancoDados(); //db existe aqui porque buscarDados é um método static,
            DataTable dt = new DataTable();

            bd.abrirConexao();
            //ele não pode acessar a variável de instância banco.
            switch (tipo)
            {
                case 1: bd.SqlCmd.CommandText = "select gru_codigo, gru_descricao from grupos where gru_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select gru_codigo, gru_descricao from grupos where gru_descricao like '%" + valor + "%'";
                    break;
            }
            dt.Load(bd.SqlCmd.ExecuteReader());
            bd.fecharConexao();

            return dt;
        }

        public static DataGridView configuraGrid(DataGridView dtaGridView)
        {
            dtaGridView.Columns[0].HeaderText = "Código";
            dtaGridView.Columns[0].Width = 50;
            dtaGridView.Columns[1].HeaderText = "Descrição";
            dtaGridView.Columns[1].Width = 290;
            return dtaGridView;
        }

    }
}
