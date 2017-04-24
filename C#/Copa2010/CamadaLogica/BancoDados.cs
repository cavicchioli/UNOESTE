using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Copa2010.CamadaLogica
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

        //Método que executa comando sql: insert, update e delete
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

        //retorna um DataTable 
        public DataTable retDataTable(String SQL)
        {
            abrirConexao();
            SqlCmd.CommandText = SQL;

            DataTable dt = new DataTable();
            dt.Load(SqlCmd.ExecuteReader());

            if (_autoConexao)
                fecharConexao();

            return (dt);
        }
    
        //ExecuteScalar
        public string execSQLScalar(String SQL)
        {
            try
            {
                abrirConexao();
                SqlCmd.ExecuteNonQuery();
                abrirConexao();

                return (SqlCmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                //ex.Message.ToString()
                return ("");
            }

            finally
            {
                if (_autoConexao)
                    fecharConexao();
            }
        }

        public void PreencherCbo(ComboBox pCombo, string pTabela, string pChave, string pDescricao)
        {

            string strSQL = ("SELECT "
                                    + (pChave + (", "
                                    + (pDescricao + (" FROM "
                                    + (pTabela + (" ORDER BY " + pDescricao)))))));

            try
            {
                abrirConexao();
                SqlCmd.CommandText = strSQL;

                DataTable dt = new DataTable(pTabela);

                dt.Load(SqlCmd.ExecuteReader());
                pCombo.ValueMember = pChave.ToString();
                pCombo.DisplayMember = pDescricao.ToString();
                pCombo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_autoConexao)
                    fecharConexao();
            }
        }

        public void PreencherCbo_Union(ComboBox pCombo, string pTabela, string pChave, string pDescricao, string desc_union)
        {

            string strSQL = (" SELECT "
                                    + (pChave + (", "
                                    + (pDescricao + (" FROM "
                                    + (pTabela + (" ORDER BY " + pChave)))))));

            try
            {
                abrirConexao();
                SqlCmd.CommandText = strSQL;

                DataTable dt = new DataTable(pTabela);

                dt.Load(SqlCmd.ExecuteReader());

                dt.Rows.Add(0, desc_union);

                pCombo.ValueMember = pChave.ToString();
                pCombo.DisplayMember = pDescricao.ToString();
                pCombo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERRO: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_autoConexao)
                    fecharConexao();
            }
        }
    }
}
