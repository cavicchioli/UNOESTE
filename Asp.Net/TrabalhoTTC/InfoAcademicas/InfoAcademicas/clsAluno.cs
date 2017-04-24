using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InfoAcademicas
{
    public class clsAluno: clsBanco
    {
        private Int32 _aluno_RA;
        private String _aluno_nome;
        private String _aluno_email;
        private String _aluno_foto;

        public Int32 Aluno_RA
        {
            get { return _aluno_RA; }
            set { _aluno_RA = value; }
        }

        public String Aluno_nome
        {
            get { return _aluno_nome; }
            set { _aluno_nome = value; }
        }

        public String Aluno_email
        {
            get { return _aluno_email; }
            set { _aluno_email = value; }
        }

        public String Aluno_foto
        {
            get { return _aluno_foto; }
            set { _aluno_foto = value; }
        }

        public int proximoCodigo()
        {
            SqlDataReader drAluno;
            String sql;
            int codigo = 0;

            sql = "SELECT coalesce(MAX(aluno_ra),0) AS ultimo FROM aluno ";
            drAluno = ExecutarDataReader(sql);
            if (drAluno.HasRows)
            {
                drAluno.Read();
                codigo = Convert.ToInt32(drAluno["ultimo"]) + 1;
            }
            else
                codigo = 1;
            drAluno.Close();
            DesconectaBanco();
            return codigo;
        }

        public int IncluirAluno()
        {
            int iLinhas = 0;
            String sSQL = "";
            try
            {
                if (ConectaBanco())
                {
                    _aluno_RA = proximoCodigo();
                    sSQL = "insert into aluno(aluno_ra,aluno_nome,aluno_email,aluno_foto) values(" +
                        _aluno_RA + "," +
                        "'" + _aluno_nome + "'," +
                        "'" + _aluno_email + "'," +
                        "'" + _aluno_foto + "')";

                    iLinhas = ExecutarSQL(sSQL);
                }
            }
            catch
            { }
            finally
            {
                DesconectaBanco();
            }
            return iLinhas;
        }

        public int AlterarAluno()
        {
            int iLinhas = 0;
            String sSQL = "";

            if (ConectaBanco())
            {
                sSQL = "update aluno set "+
                    "aluno_nome = '"+_aluno_nome + "', " +
                    "aluno_email = '"+_aluno_email+"',"+
                    "aluno_foto = '" + _aluno_foto + "' " +
                    "where aluno_ra = " + _aluno_RA;

                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();

            return iLinhas;
        }

        public int ExcluirAluno()
        {
            int iLinhas = 0;
            String sSQL = "";

            if (ConectaBanco())
            {
                sSQL = "delete from aluno "+
                "where aluno_ra = " + _aluno_RA;
                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();
            return iLinhas;

        }

        public void RecuperarDados()
        {
            SqlDataReader drAluno;
            string sSQL;

            if (ConectaBanco())
            {
                sSQL = "select aluno_nome,aluno_email,aluno_foto from aluno" +
                       " where aluno_ra = " + _aluno_RA;

                drAluno = ExecutarDataReader(sSQL);
                if (drAluno.HasRows)
                {
                    drAluno.Read();
                    _aluno_nome = Convert.ToString(drAluno["aluno_nome"]);
                    _aluno_email = Convert.ToString(drAluno["aluno_email"]);
                    _aluno_foto = Convert.ToString(drAluno["aluno_foto"]);
                }
                drAluno.Close();
            }
            DesconectaBanco();
        }

        public DataSet Popula_Gridview(String pesquisa)
        {
            String sql = "";

            sql = "select * from aluno "+
                "where aluno_nome like '%" + pesquisa + "%' and aluno_ra != 1";
            return RetornaDS(sql);
        }
    }
}