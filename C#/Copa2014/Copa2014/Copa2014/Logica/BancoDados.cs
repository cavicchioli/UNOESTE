using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Copa2014.Logica
{
    class BancoDados
    {
        private string conexao;
        private SqlConnection sqlCon = null;
        private SqlTransaction sqlTrans = null;
        private SqlCommand _sqlCmd = null;
        private bool _autoConexao = true;

        public bool AutoConexao
        {
            get { return _autoConexao; }
            set { _autoConexao = value; }
        }

        public SqlCommand SqlCmd
        {
            get { return _sqlCmd; }
            set { _sqlCmd = value; }
        }

        public BancoDados()
        {
            conexao = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Copa2014;User Id=sa;Password=a12345z;";
            sqlCon = new SqlConnection(conexao);
            _sqlCmd = sqlCon.CreateCommand();
        }

        public void abrirConexao()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        public void fecharConexao()
        {
            if ((sqlCon != null) && (sqlCon.State == ConnectionState.Open))
            {
                sqlCon.Close();
                _sqlCmd.CommandText = "";
                _sqlCmd.Parameters.Clear();
            }
        }

        /// <summary>
        /// Método que associa uma transacao ao comando
        /// Utilizar banco.AutoConexao = false;
        /// </summary>
        public void iniciarTransacao()
        {
            abrirConexao();
            sqlTrans = sqlCon.BeginTransaction();
            _sqlCmd.Transaction = sqlTrans;
        }

        public bool commitTransacao()
        {
            try
            {
                sqlTrans.Commit();
                sqlTrans = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void rollbackTransacao()
        {
            sqlTrans.Rollback();
            sqlTrans = null;
        }

        /// <summary>
        /// Método que executa comando sql: insert, update e delete
        /// </summary>
        /// <returns>bool</returns>
        public bool executarComando()
        {
            try
            {
                abrirConexao();
                SqlCmd.ExecuteNonQuery();
                if (_autoConexao)
                    fecharConexao();
                return true;
            }
            catch //(Exception ex)
            {
                return false;
                //Tratamento de erro em camadas
                //throw new Exception(ex.Message,ex.InnerException);
            }
        }
        
        /// <summary>
        /// Método que executa uma consulta SQL e retorna uma Datatable preenchida
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable executarReader()
        {
            return null;
        }

        /// <summary>
        /// Método que executa comando select count, sum, etc com um único valor de retorno
        /// </summary>
        /// <returns>object genérico</returns>
        public object executarScalar()
        {
            return null;   
        }

    }
        
}
