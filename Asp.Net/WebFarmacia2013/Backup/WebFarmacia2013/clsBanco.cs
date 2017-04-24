using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //serve para datatable e dataset
using System.Data.SqlClient;  //serve para o banco sqlserver
using System.Web.UI;  // serve para a messagebox


namespace WebFarmacia2013
{
    public class clsBanco
    {
        SqlConnection objConexao;
        SqlCommand objComando;
        SqlTransaction objTransacao;

        string sResultado = "";
        string sStringConexao = 
   @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Farmacia.mdf;Integrated Security=True;User Instance=True";

        public clsBanco()
        {
            objConexao = new SqlConnection(sStringConexao);
            objComando = new SqlCommand();
            objComando.Connection = objConexao; 
        }


        public bool ConectaBancoTransacao()
        {
            if (ConectaBanco())
            {
                objTransacao = objConexao.BeginTransaction();
                objComando.Transaction = objTransacao;
                return true;
            }
            return false;
        }

        public void ExecutaCommit()
        {
            objTransacao.Commit();
        }

        public void ExecutaRoolback()
        {
            objTransacao.Rollback();
        }

        public int ExecutaSQLTransacao(string sSQL)
        {
            int iLinhas = 0;
            //try
            //{
                objComando.CommandText = sSQL;
                iLinhas = objComando.ExecuteNonQuery();
            //}
            //catch
            //{
            //    iLinhas = 0;
            //}
            return iLinhas;
        }
        

        public bool ConectaBanco()
        {
            try
            {
                objConexao.Open();
                return true;
            }
            catch(Exception erro)
            {
                sResultado = erro.Message;
                return false;
            }
        }

        public bool DesconectaBanco()
        {
            try
            {
                objConexao.Close();
                return true;
            }
            catch (Exception erro)
            {
                sResultado = erro.Message;
                return false;
            }
        }

        public SqlDataReader RetornaDR(string sSQL)
        {
            if (objConexao.State == ConnectionState.Closed)
            {
                objConexao.Open();  
            }

            objComando.CommandText = sSQL;
            SqlDataReader drReader = objComando.ExecuteReader();

            return drReader ;
        }

        public DataSet RetornaDS(string sSQL)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dsDados = new DataSet();

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                dataAdapter.SelectCommand = objComando;
                dataAdapter.Fill(dsDados);
                DesconectaBanco();
            }

            return dsDados; 
        }

        public DataTable RetornaDT(string sSQL)
        {
            DataTable dtDados = new DataTable();

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                dtDados.Load(objComando.ExecuteReader());
                DesconectaBanco(); 
            }
            return dtDados; 
        }

        public DataTable RetornaDTTransacao(string sSQL)
        {
            DataTable dtDados = new DataTable();

            objComando.CommandText = sSQL;
            dtDados.Load(objComando.ExecuteReader());
            return dtDados;
        }

        public int ExecutarSQL(string sSQL)
        {
            int iLinhasAfetadas = 0;

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                iLinhasAfetadas = objComando.ExecuteNonQuery();
                DesconectaBanco(); 
            }
            return iLinhasAfetadas; 
        }

        public void MostraMensagem(string MessageText, Page Mypage)
        {
            Mypage.ClientScript.RegisterStartupScript(
                Mypage.GetType(), "MessageBox", "alert('" +
                MessageText.Replace("'", "\'") + "');", true);   
        }

    }


}