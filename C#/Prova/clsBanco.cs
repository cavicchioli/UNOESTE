using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Prova
{
    public class clsBanco
    {

        public string sStringConexao;
        public SqlConnection objConexao = new SqlConnection();
        public SqlCommand objComando = new SqlCommand();
        public string sSQL;
        public string sResultado;


        public clsBanco()
        {
            string sStringConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Dados.mdf;Integrated Security=True;User Instance=True";

            objConexao = new SqlConnection(sStringConexao);
            objComando = new SqlCommand();
            objComando.Connection = objConexao;
        }


        public bool ConectaBanco()
        {
            try
            {
                objConexao.Open();
                return true;
            }
            catch (Exception erro)
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

            return drReader;
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
            //DesconectaBanco();

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                iLinhasAfetadas = objComando.ExecuteNonQuery();
                DesconectaBanco();
            }
            return iLinhasAfetadas;
        }

        //===================================================================================================================
        public void MostraMensagem(string MessageText, Page MyPage)
        {
            MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(), "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }
}