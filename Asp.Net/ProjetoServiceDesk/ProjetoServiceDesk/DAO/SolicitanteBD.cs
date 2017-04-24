using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class SolicitanteBD : Banco
    {
        internal SolicitanteBD() { }
        internal int Gravar(Solicitante sol, char acao)
        {
            ComandoSQL.Parameters.Clear();
            if (acao == 'I') //Novo registro
                ComandoSQL.CommandText = @"insert into SOLICITANTE (sol_email, sol_nome, sol_telefone, sol_observacao)
                        values(@email, @nome, @telefone, @observacao)";
            else //Alteração
                ComandoSQL.CommandText = @"update SOLICITANTE
                        set sol_nome = @nome, sol_telefone = @telefone, sol_observacao = @observacao
                        where sol_email = @email";

            ComandoSQL.Parameters.AddWithValue("@email", sol.Email);
            ComandoSQL.Parameters.AddWithValue("@nome", sol.Nome);
            ComandoSQL.Parameters.AddWithValue("@telefone", sol.Telefone);
            ComandoSQL.Parameters.AddWithValue("@observacao", sol.Observacao);

            return ExecutaComando(false);
        }

        internal List<Solicitante> Obter(int codigoFuncionario, int codigoStatus)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select distinct s.* 
                        from solicitante s, atividade a
                        where a.fun_codigo = @funcionario and 
                              a.sta_codigo = @status and 
                              a.sol_email = s.sol_email
                        order by s.sol_nome";
            ComandoSQL.Parameters.AddWithValue("@funcionario", codigoFuncionario);
            ComandoSQL.Parameters.AddWithValue("@status", codigoStatus);

            DataTable dt = ExecutaSelect();

            return RetornaSolicitantes(dt);
        }

        internal Solicitante Obter(string email, bool obterAtividades)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from SOLICITANTE
                        where sol_email = @email";
            ComandoSQL.Parameters.AddWithValue("@email", email);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                return new Solicitante
                {
                    Email = email,
                    Nome = dt.Rows[0]["sol_nome"].ToString(),
                    Telefone = dt.Rows[0]["sol_telefone"].ToString(),
                    Observacao = dt.Rows[0]["sol_observacao"].ToString(),
                    Atividades = obterAtividades ? new AtividadeBD().ObterPorSolicitante(email) : null
                };
            }
            else
                return null;
        }

        internal List<Solicitante> Obter(string palavraChave)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from SOLICITANTE 
                        where sol_nome like @palavra
                        order by sol_nome";
            ComandoSQL.Parameters.AddWithValue("@palavra", "%"+palavraChave+"%");

            DataTable dt = ExecutaSelect();

            return RetornaSolicitantes(dt);
        }

        internal List<Solicitante> Obter()
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from SOLICITANTE 
                        order by sol_nome";

            DataTable dt = ExecutaSelect();

            return RetornaSolicitantes(dt);
        }


        private List<Solicitante> RetornaSolicitantes(DataTable dt)
        {
            List<Solicitante> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = new List<Solicitante>();
                foreach (DataRow linha in dt.Rows)
                {
                    Solicitante s = new Solicitante
                    {
                        Email = linha["sol_email"].ToString(),
                        Nome = linha["sol_nome"].ToString(),
                        Telefone = linha["sol_telefone"].ToString(),
                        Observacao = linha["sol_observacao"].ToString()
                    };
                    dados.Add(s);
                }
            }
            return dados;
        }
        internal int Excluir(string email)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from SOLICITANTE
                        where sol_email = @email";
            ComandoSQL.Parameters.AddWithValue("@email", email);

            return ExecutaComando(false);
        }
    }
}
