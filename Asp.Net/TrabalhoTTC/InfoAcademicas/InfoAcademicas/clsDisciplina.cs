using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InfoAcademicas
{
    public class clsDisciplina: clsBanco
    {
        private Int32 _disc_codigo;
        private String _disc_nome;

        public Int32 Disc_codigo
        {
            get { return _disc_codigo; }
            set { _disc_codigo = value; }
        }
        
        public String Disc_nome
        {
            get { return _disc_nome; }
            set { _disc_nome = value; }
        }

        private Int32 ProximoCodigo()
        {
            SqlDataReader drDisciplina;
            String sSQL;
            sSQL = "select coalesce(Max(disc_codigo),0) as ultimo from disciplina";
            drDisciplina = ExecutarDataReader(sSQL);
            if (drDisciplina.HasRows)
            {
                drDisciplina.Read();
                _disc_codigo = Convert.ToInt32(drDisciplina["ultimo"]) + 1;
            }
            drDisciplina.Close();
            return _disc_codigo;
        }

        public int IncluirDisciplina()
        {
            int iLinhas = 0;
            String sSQL = "";

            if (ConectaBanco())
            {

                _disc_codigo = ProximoCodigo();
                sSQL = "insert into disciplina(disc_codigo,disc_nome) values(" +
                    _disc_codigo + "," + "'" + _disc_nome + "')";

                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();

            return iLinhas;
        }

        public int AlterarDisciplina()
        {
            int iLinhas = 0;
            String sSQL = "";

            if (ConectaBanco())
            {
                sSQL = "update disciplina set disc_nome = '" + _disc_nome + "' " +
                        "where disc_codigo = " + _disc_codigo;

                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();

            return iLinhas;
        }

        public int ExcluirDisciplina()
        {
            int iLinhas = 0;
            String sSQL = "";

            if (ConectaBanco())
            {
                sSQL = "delete from disciplina where disc_codigo = " + _disc_codigo;
                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();
            return iLinhas;

        }

        public void RecuperarDados()
        {
            SqlDataReader drDisciplina;
            string sSQL;

            if (ConectaBanco())
            {
                sSQL = "select * from disciplina" +
                       " where disc_codigo = " + _disc_codigo;

                drDisciplina = ExecutarDataReader(sSQL);
                if (drDisciplina.HasRows)
                {
                    drDisciplina.Read();
                    _disc_codigo = Convert.ToInt32(drDisciplina["disc_codigo"]);
                    _disc_nome = Convert.ToString(drDisciplina["disc_nome"]);
                }
                drDisciplina.Close();
            }
            DesconectaBanco();
        }

        public DataSet Popula_Gridview(String pesquisa)
        {
            String sql = "";

            sql = "select * from disciplina";
            sql = sql + " where disc_nome like '%" +pesquisa+ "%' and disc_codigo != 1";
            return RetornaDS(sql);
        }
    }
}