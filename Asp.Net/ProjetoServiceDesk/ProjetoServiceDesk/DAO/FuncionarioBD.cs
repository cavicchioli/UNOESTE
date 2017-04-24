using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class FuncionarioBD : Banco
    {
        internal FuncionarioBD() { }

        internal Funcionario Autenticar(int codigo, string senha)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from FUNCIONARIO
                    where fun_codigo = @codigo and fun_senha = @senha";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);
            ComandoSQL.Parameters.AddWithValue("@senha", senha);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                Funcionario f = new Funcionario();
                f.Codigo = Convert.ToInt32(dt.Rows[0]["fun_codigo"]);
                f.Nome = dt.Rows[0]["fun_nome"].ToString();
                f.DataContratacao = Convert.ToDateTime(dt.Rows[0]["fun_dtcontratacao"]);
                if (dt.Rows[0]["fun_dtdemissao"] == DBNull.Value)
                    f.DataDemissao = null;
                else
                    f.DataDemissao = Convert.ToDateTime(dt.Rows[0]["fun_dtdemissao"]);
                f.Ativo = Convert.ToChar(dt.Rows[0]["fun_ativo"]);
                f.Senha = dt.Rows[0]["fun_senha"].ToString();
                f.Tipo = Convert.ToChar(dt.Rows[0]["fun_tipo"]);

                return f;
            }
            else
                return null;
        }

        internal int Gravar(Funcionario func)
        {
            ComandoSQL.Parameters.Clear();
            if (func.Codigo == 0) //Novo registro
            ComandoSQL.CommandText = @"insert into Funcionario 
                    (fun_nome, fun_dtcontratacao, fun_ativo, fun_senha, fun_tipo)
                    values (@nome, @datacontratacao, @ativo, @senha, @tipo)";
            else //Alteração
            {
                ComandoSQL.CommandText = @"update FUNCIONARIO
                    set fun_nome = @nome, fun_dtcontratacao = @datacontratacao, fun_dtdemissao = @datademissao, 
                        fun_ativo = @ativo, fun_senha = @senha, fun_tipo = @tipo
                        where fun_codigo = @codigo";
                ComandoSQL.Parameters.AddWithValue("@codigo", func.Codigo);
                if (func.DataDemissao == null)
                    ComandoSQL.Parameters.AddWithValue("@datademissao", DBNull.Value);
                else
                    ComandoSQL.Parameters.AddWithValue("@datademissao", func.DataDemissao);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", func.Nome);
            ComandoSQL.Parameters.AddWithValue("@datacontratacao", func.DataContratacao);
            ComandoSQL.Parameters.AddWithValue("@ativo", func.Ativo);
            ComandoSQL.Parameters.AddWithValue("@senha", func.Senha);
            ComandoSQL.Parameters.AddWithValue("@tipo", func.Tipo);

            return ExecutaComando(false);
        }

        internal List<Funcionario> Obter(string palavraChave, char ativo)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select fun_codigo, fun_nome, fun_dtcontratacao, fun_dtdemissao, fun_ativo, fun_senha, fun_ativo, fun_tipo
                        from Funcionario
                        where fun_ativo = @ativo and fun_nome like @palavra order by fun_nome";
            ComandoSQL.Parameters.AddWithValue("@ativo", ativo);
            ComandoSQL.Parameters.AddWithValue("@palavra", "%"+palavraChave+"%");

            DataTable dt = ExecutaSelect();
            return DevolverLista(dt);
            
        }

        internal List<Funcionario> ObterTodos()
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from funcionario order by fun_nome";

            DataTable dt = ExecutaSelect();
            return DevolverLista(dt);
        }

        private List<Funcionario> DevolverLista(DataTable dt)
        {
            List<Funcionario> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = new List<Funcionario>();
                foreach (DataRow linha in dt.Rows)
                {
                    Funcionario f = new Funcionario();
                    f.Codigo = Convert.ToInt32(linha["fun_codigo"]);
                    f.Nome = linha["fun_nome"].ToString();
                    f.DataContratacao = Convert.ToDateTime(linha["fun_dtcontratacao"]);
                    if (linha["fun_dtdemissao"] == DBNull.Value)
                        f.DataDemissao = null;
                    else
                        f.DataDemissao = Convert.ToDateTime(linha["fun_dtdemissao"]);
                    f.Ativo = Convert.ToChar(linha["fun_ativo"]);
                    f.Senha = linha["fun_senha"].ToString();
                    f.Tipo = Convert.ToChar(linha["fun_tipo"]);

                    dados.Add(f);
                }
            }
            return dados;
        }

        internal int Demitir(int codigoFuncionario)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"update Funcionario set fun_ativo = 'N',
                    fun_dtdemissao = @data where fun_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@data", DateTime.Now);
            ComandoSQL.Parameters.AddWithValue("@codigo", codigoFuncionario);

            return ExecutaComando(false);
        }

        internal Funcionario Obter(int codigoFuncionario, bool buscarAtividades)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select fun_codigo, fun_nome, fun_dtcontratacao, fun_dtdemissao, fun_ativo, fun_senha, fun_ativo, fun_tipo
                        from Funcionario
                        where fun_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigoFuncionario);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                Funcionario f = new Funcionario();
                f.Codigo = Convert.ToInt32(dt.Rows[0]["fun_codigo"]);
                f.Nome = dt.Rows[0]["fun_nome"].ToString();
                f.DataContratacao = Convert.ToDateTime(dt.Rows[0]["fun_dtcontratacao"]);
                if (dt.Rows[0]["fun_dtdemissao"] == DBNull.Value)
                    f.DataDemissao = null;
                else
                    f.DataDemissao = Convert.ToDateTime(dt.Rows[0]["fun_dtdemissao"]);
                f.Ativo = Convert.ToChar(dt.Rows[0]["fun_ativo"]);
                f.Senha = dt.Rows[0]["fun_senha"].ToString();
                f.Tipo = Convert.ToChar(dt.Rows[0]["fun_tipo"]);

                if (buscarAtividades)
                    f.Atividades = new AtividadeBD().ObterPorFuncionario(f.Codigo);
                else
                    f.Atividades = null;

                return f;
            }
            else
                return null;
        }
    }
}
