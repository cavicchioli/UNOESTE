using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InfoAcademicas
{
    public class clsDiscAluno: clsBanco
    {
        private int _disc_codigo;
        private int _aluno_ra;
        private float _nota1b;
        private float _nota2b;
        private String _turma;
        private char _semestre;

        public int Disc_codigo
        {
            get { return _disc_codigo; }
            set { _disc_codigo = value; }
        }

        public int Aluno_ra
        {
            get { return _aluno_ra; }
            set { _aluno_ra = value; }
        }

        public float Nota1b
        {
            get { return _nota1b; }
            set { _nota1b = value; }
        }

        public float Nota2b
        {
            get { return _nota2b; }
            set { _nota2b = value; }
        }

        public String Turma
        {
            get { return _turma; }
            set { _turma = value; }
        }

        public char Semestre
        {
            get { return _semestre; }
            set { _semestre = value; }
        }
        
        public int IncluirDiscAluno()
        {
            int iLinhas = 0;
            String sSQL = "";
            float min2b=0,media=0,exame=0,minexame=0,mediafinal=0;
            String situacao = "Cursando";
            if(_nota2b == 0) //se não preenchido a nota do 2ºB
                min2b = 12 - _nota1b;           //mínimo da nota do 2ºB
            else//se preenchido a nota do 2ºB                                     
            {
                media = (_nota1b + _nota2b)/2;  //media feita
                if(media < 6)                   //se media for menor que 6.0
                {
                    minexame = 10 - media;      //mínima nota para o exema 
                }
                else
                {
                    situacao = "Aprovado";
                    mediafinal = media;
                }
            }
            
            try
            {
                if (ConectaBanco())
                {
                    sSQL = "insert into disciplina_aluno(disc_codigo,aluno_ra,"+
                    "discAluno_turma,discAluno_semestre,discAluno_nota1b,discAluno_nota2b,discAluno_min2b,"+
                    "discAluno_media,discAluno_exame,discAluno_minexame,discAluno_mediafinal,"+
                    "discAluno_situacao)"+
                    " values("+
                    ""+_disc_codigo+","+
                    ""+_aluno_ra+","+
                    "'"+_turma+"',"+
                    "'"+_semestre+"',"+
                    ""+_nota1b+","+
                    ""+_nota2b+","+
                    ""+min2b+","+
                    ""+media+","+
                    ""+exame+","+
                    ""+minexame+","+
                    ""+mediafinal+","+
                    "'"+situacao+"')";

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

        public int AlterarDiscAluno()
        {
            int iLinhas = 0;
            String sSQL = "";
            float min2b = 0, media = 0, exame = 0, minexame = 0, mediafinal = 0;
            String situacao = "Cursando";
            if (_nota2b == 0 ) //se não preenchido a nota do 2ºB
                min2b = 12 - _nota1b;           //mínimo da nota do 2ºB
            else//se preenchido a nota do 2ºB                                     
            {
                media = (_nota1b + _nota2b) / 2;  //media feita
                if (media < 6)                   //se media for menor que 6.0
                {
                    minexame = 10 - media;      //mínima nota para o exema 
                }
                else
                {
                    situacao = "Aprovado";
                    mediafinal = media;
                }
            }

            try
            {
                if (ConectaBanco())
                {
                    sSQL = "update disciplina_aluno set " +
                        "discAluno_turma = '" + _turma + "'," +
                        "discAluno_semestre = '" + _semestre + "'," +
                        "discAluno_nota1b = " + _nota1b + "," +
                        "disAluno_nota2b = " + _nota2b + "," +
                        "discAluno_min2b = " + min2b + "," +
                        "discAluno_media = " + media + "," +
                        "discAluno_exame = " + exame + "," +
                        "discAluno_minexame = " + minexame + "," +
                        "discAluno_mediafinal = " + mediafinal + "," +
                        "disCAluno_situacao = '" + situacao + "' " +
                        "where disc_codigo = " + _disc_codigo + " " +
                        "and aluno_ra = " + _aluno_ra;
                    
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

        public int ExcluirDiscAluno()
        {
            int iLinhas = 0;

            if (ConectaBanco())
            {
                sSQL = "delete from disciplina_aluno " +
                "where disc_codigo = " + _disc_codigo + " and " +
                "aluno_ra = " + _aluno_ra;
                iLinhas = ExecutarSQL(sSQL);
            }
            DesconectaBanco();
            return iLinhas;
        }

        public String PegaDisc_Codigo(String descricao)
        {
            SqlDataReader dataReader; 
            String sql = "";
            sql = "select disc_codigo from disciplina ";
            sql = sql + "where disc_nome = '" + descricao + "'";
            dataReader = ExecutarDataReader(sql);
            if (dataReader.HasRows)
            {
                dataReader.Read();
                descricao = Convert.ToString(dataReader["disc_codigo"]);
            }
            else
                descricao = "";
            dataReader.Close();
            DesconectaBanco();
            return descricao;
        }

        public String PegaAluno_RA(String descricao)
        {
            SqlDataReader dataReader;
            String sql = "";
            sql = "select aluno_ra from aluno ";
            sql = sql + "where aluno_nome = '" + descricao + "'";
            dataReader = ExecutarDataReader(sql);
            if (dataReader.HasRows)
            {
                dataReader.Read();
                descricao = Convert.ToString(dataReader["aluno_ra"]);
            }
            else
                descricao = "";
            dataReader.Close();
            DesconectaBanco();
            return descricao;
        }

        public void RecuperarDados()
        {
            SqlDataReader drDiscAluno;
            string sSQL;

            if (ConectaBanco())
            {
                sSQL = "select disc_codigo,aluno_ra,discAluno_nota1b,"+
                       "discAluno_nota2b,discAluno_turma,discAluno_semestre from disciplina_aluno " +
                       "where disc_codigo = " + _disc_codigo + " and " +
                       "aluno_ra = " + _aluno_ra;
  
                drDiscAluno = ExecutarDataReader(sSQL);
                if (drDiscAluno.HasRows)
                {
                    drDiscAluno.Read();
                    _disc_codigo = Convert.ToInt32(drDiscAluno["disc_codigo"]);
                    _aluno_ra = Convert.ToInt32(drDiscAluno["aluno_ra"]);
                    _nota1b = Convert.ToSingle(drDiscAluno["disc_codigo"]);
                    _nota2b = Convert.ToSingle(drDiscAluno["aluno_ra"]);
                    _turma = Convert.ToString(drDiscAluno["discAluno_turma"]);
                    _semestre = Convert.ToChar(drDiscAluno["discAluno_semestre"]);
                }
                drDiscAluno.Close();
            }
            DesconectaBanco();
        }

        public DataSet Popula_Gridview(String pesquisa)
        {
            String sql = "";
            sql = "select disc_nome,aluno_nome,discAluno_nota1b,"+
                "discAluno_nota2b,discAluno_min2b,discAluno_exame "+
                "from disciplina_aluno as DA inner join disciplina as D "+
                "on DA.disc_codigo = D.disc_codigo inner join aluno as A "+
                "on DA.aluno_ra = A.aluno_ra "+
                "where disc_nome like '%"+pesquisa+"%'";
            return RetornaDS(sql);
        }
    }
}