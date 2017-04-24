using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class AtividadeBD : Banco
    {
        internal AtividadeBD() { }

        internal List<Atividade> ObterAbertas()
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from Atividade
                        where ati_dtfim is null";
            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterFechadas()
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from Atividade
                        where ati_dtfim is not null";
            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterPorFuncionario(int codigoFuncionario)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select *
                    from Atividade
                    where fun_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigoFuncionario);

            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterPorStatus(int codigoStatus)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select *  
                    from Atividade
                    where sta_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigoStatus);

            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterPorSolicitante(string emailSolicitante)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select *  
                    from Atividade
                    where sol_email = @email";
            ComandoSQL.Parameters.AddWithValue("@email", emailSolicitante);

            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterPorClassificacao(int codigoClassificacao)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select *  
                    from Atividade a, AtividadeClassificacao ac
                    where ac.cla_codigo = @codigo and ac.ati_codigo = a.ati_codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigoClassificacao);

            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        internal List<Atividade> ObterSolicitanteFuncionario(string emailSolicitante, int codigoFuncionario, int codigoStatus)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select a.* 
                        from atividade a
                        where a.fun_codigo = @funcionario and 
                              a.sta_codigo = @status and 
                              a.sol_email = @solicitante
                        order by a.ati_dtinicio desc";
            ComandoSQL.Parameters.AddWithValue("@funcionario",codigoFuncionario);
            ComandoSQL.Parameters.AddWithValue("@status", codigoStatus);
            ComandoSQL.Parameters.AddWithValue("@solicitante", emailSolicitante);

            DataTable dt = ExecutaSelect();
            return DevolverListaAtividades(dt);
        }

        private List<Atividade> DevolverListaAtividades(DataTable dt)
        {
            List<Atividade> dados = null;

            if (dt != null && dt.Rows.Count > 0)
            {
                ClassificacaoBD cl = new ClassificacaoBD();
                StatusBD st = new StatusBD();
                SolicitanteBD so = new SolicitanteBD();
                FuncionarioBD fu = new FuncionarioBD();

                dados = new List<Atividade>();
                foreach (DataRow linha in dt.Rows)
                {
                    Atividade a = new Atividade();
                    a.Codigo = Convert.ToInt32(linha["ati_codigo"]);
                    a.Descricao = linha["ati_descricao"].ToString();
                    a.DataInicio = Convert.ToDateTime(linha["ati_dtinicio"]);
                    if (linha["ati_dtfim"] == DBNull.Value)
                        a.DataFim = null;
                    else
                        a.DataFim = Convert.ToDateTime(linha["ati_dtfim"]);
                    a.CodigoFuncionario = Convert.ToInt32(linha["fun_codigo"].ToString());

                    a.EmailSolicitante = dt.Rows[0]["sol_email"].ToString();
                    a.CodigoStatus = Convert.ToInt32(dt.Rows[0]["sta_codigo"]);

                    a.Classificacoes = cl.ObterPorAtividade(a.Codigo);
                    a.Status = st.Obter(Convert.ToInt32(linha["sta_codigo"]), false);
                    a.Solicitante = so.Obter(linha["sol_email"].ToString(), false);
                    a.Funcionario = fu.Obter(Convert.ToInt32(linha["fun_codigo"].ToString()), false);
                    
                    dados.Add(a);
                }
            }
            return dados;
        }

        internal Atividade Obter(int codigo)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select *
                    from Atividade
                    where ati_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                ClassificacaoBD cl = new ClassificacaoBD();
                StatusBD st = new StatusBD();
                SolicitanteBD so = new SolicitanteBD();
                FuncionarioBD fu = new FuncionarioBD();

                Atividade a = new Atividade();
                a.Codigo = Convert.ToInt32(dt.Rows[0]["ati_codigo"]);
                a.Descricao = dt.Rows[0]["ati_descricao"].ToString();
                a.DataInicio = Convert.ToDateTime(dt.Rows[0]["ati_dtinicio"]);
                if (dt.Rows[0]["ati_dtfim"] == DBNull.Value)
                    a.DataFim = null;
                else
                    a.DataFim = Convert.ToDateTime(dt.Rows[0]["ati_dtfim"]);
                a.CodigoFuncionario = Convert.ToInt32(dt.Rows[0]["fun_codigo"].ToString());
                a.EmailSolicitante = dt.Rows[0]["sol_email"].ToString();
                a.CodigoStatus = Convert.ToInt32(dt.Rows[0]["sta_codigo"]);

                a.Classificacoes = cl.ObterPorAtividade(a.Codigo);
                a.Status = st.Obter(Convert.ToInt32(dt.Rows[0]["sta_codigo"]), false);
                a.Solicitante = so.Obter(dt.Rows[0]["sol_email"].ToString(), false);
                a.Funcionario = fu.Obter(Convert.ToInt32(dt.Rows[0]["fun_codigo"].ToString()), false);

                

                return a;
            }
            else
                return null;
        }


        internal int Gravar(Atividade ati)
        {
            ComandoSQL.Parameters.Clear();
            if (ati.Codigo == 0) //Novo registro
                ComandoSQL.CommandText = @"insert into ATIVIDADE (ati_descricao, ati_dtinicio, fun_codigo, sta_codigo, sol_email)
                        values (@descricao, @datainicio, @funcionario, @status, @solicitante)";
            else //Alteração
            {
                ComandoSQL.CommandText = @"update ATIVIDADE set ati_descricao = @descricao, ati_dtinicio = @datainicio, 
                        ati_dtfim = @datafim, fun_codigo = @funcionario, sta_codigo = @status, sol_email = @solicitante
                        where ati_codigo = @codigo";
                ComandoSQL.Parameters.AddWithValue("@codigo", ati.Codigo);
                if (ati.DataFim == null)
                    ComandoSQL.Parameters.AddWithValue("@datafim", DBNull.Value);
                else
                    ComandoSQL.Parameters.AddWithValue("@datafim", ati.DataFim);
            }
            ComandoSQL.Parameters.AddWithValue("@descricao", ati.Descricao);
            ComandoSQL.Parameters.AddWithValue("@datainicio", ati.DataInicio);
            ComandoSQL.Parameters.AddWithValue("@funcionario", ati.CodigoFuncionario);
            ComandoSQL.Parameters.AddWithValue("@status", ati.CodigoStatus);
            ComandoSQL.Parameters.AddWithValue("@solicitante", ati.EmailSolicitante);

            return ExecutaComando(false);
        }

        internal int Excluir(int codigo)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from ATIVIDADECLASSIFICACAO where ati_codigo = @codigo;
                                       delete from ATIVIDADE where ati_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            return ExecutaComando(true);
        }
    }
}
