using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace InfoAcademicas
{
    public class clsBanco
    {
        public string StringConexao;
        public SqlConnection Conexao = new SqlConnection();

        public SqlCommand Comando = new SqlCommand();
        public string sSQL;
        public string resultado;

        public clsBanco()
        {
            //StringConexao = @"Data Source=.;AttachDbFilename=|DataDirectory|\Farmacia.mdf;Integrated Security=True;User Instance=True";
            StringConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Trabalho\BancoTTC.mdf;Integrated Security=True;User Instance=True";
            Conexao = new SqlConnection(StringConexao);
            Comando = new SqlCommand();
            Comando.Connection = Conexao;
        }

        //===================================================================================================================
        public bool ConectaBanco()
        {
            try
            {
                Conexao.Open();
                return true;
            }
            catch (Exception erro)
            {
                resultado = erro.Message;
                return false;
            }
        }
        public bool DesconectaBanco()
        {
            try
            {
                if (Conexao.State == ConnectionState.Open)
                    Conexao.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //===================================================================================================================
        public SqlDataReader ExecutarDataReader(string sSQL)
        {
            //se a conexão estiver fechada abre a conexão
            if (Conexao.State == ConnectionState.Closed)
            {
                Conexao.Open();
            }
            Comando.CommandText = sSQL;
            SqlDataReader drReader = Comando.ExecuteReader();
            return drReader;
        }

        //===================================================================================================================
        public int ExecutarSQL(string sSQL)
        {
            if (Conexao.State == ConnectionState.Closed)
            {
                Conexao.Open();
            }
            int lLinhasAfetadas = 0;
            Comando.CommandText = sSQL;
            lLinhasAfetadas = Comando.ExecuteNonQuery();
            Conexao.Close();
            return lLinhasAfetadas;
        }

        //===================================================================================================================
        public DataSet RetornaDS(string sSQL)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dsDados = new DataSet();

            Comando.CommandText = sSQL;
            dataAdapter.SelectCommand = Comando;
            dataAdapter.Fill(dsDados);

            return dsDados;
        }

        //===================================================================================================================
        public DataTable RetornaDT(string sSQL)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dtDados = new DataTable();

            Comando.CommandText = sSQL;
            dataAdapter.SelectCommand = Comando;
            dataAdapter.Fill(dtDados);

            return dtDados;
        }

        //===================================================================================================================
        public void MostraMensagem(string MessageText, Page MyPage)
        {
            MyPage.ClientScript.RegisterStartupScript(MyPage.GetType(), "MessageBox", "alert('" + MessageText.Replace("'", "\'") + "');", true);
        }
    }
}