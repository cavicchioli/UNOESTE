using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;//serve para datatable e dataset
using System.Data.SqlClient; //serve para o banco sqlserver
using System.Web.UI; // serve para a messagebox

namespace carPlace
{
    public class clsBancoSQL
    {
        public string sStringConexao;
        public string sResultado = "";

        public SqlConnection objConexao;
        public SqlCommand objComando;

        public clsBancoSQL()
        {
            
            sStringConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename= |DataDirectory|Dados.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            
            
            objConexao = new SqlConnection(sStringConexao);
            objComando = new SqlCommand();
            objComando.Connection = objConexao; 
        }

        //conecta no banco
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

        public SqlDataReader ExecutarDataReader(string sSQL)
        {
            if (objConexao.State == ConnectionState.Closed)
            {
                objConexao.Open(); 
            }

            objComando.CommandText = sSQL;
            SqlDataReader  drReader = objComando.ExecuteReader();

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
            }
            DesconectaBanco(); 

            return dsDados; 
        }

        public DataTable RetornaDT(string sSQL)
        {
            DataTable dtDados = new DataTable();

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                dtDados.Load(objComando.ExecuteReader());
            }
            DesconectaBanco(); 

            return dtDados; 
        }

        public int ExecutarSQL(string sSQL)
        {
            int iLinhasAfetadas = 0;

            if (ConectaBanco())
            {
                objComando.CommandText = sSQL;
                iLinhasAfetadas = objComando.ExecuteNonQuery();
            }
            DesconectaBanco();

            return iLinhasAfetadas;
        }

        public void MostraMensagem(string MessageText, Page Mypage)
        {
            Mypage.ClientScript.RegisterStartupScript(Mypage.GetType(),
                "Messagebox", "alert('" +
                MessageText.Replace("'", "\'") + "');", true);
        }
    }
}