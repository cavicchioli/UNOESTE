using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjetoServiceDesk.Model;

namespace ProjetoServiceDesk.DAO
{
    internal class ClassificacaoBD : Banco
    {
        internal ClassificacaoBD() { }

        internal int Gravar(Classificacao cla)
        {
            ComandoSQL.Parameters.Clear();
            if (cla.Codigo == 0) //Novo registro
                ComandoSQL.CommandText = @"insert into CLASSIFICACAO (cla_nome, cla_ativa)
                        values(@nome, @ativa)";
            else //Alteração
            {
                ComandoSQL.CommandText = @"update CLASSIFICACAO 
                        set cla_nome = @nome, cla_ativa = @ativa
                        where cla_codigo = @codigo";
                ComandoSQL.Parameters.AddWithValue("@codigo", cla.Codigo);
            }
            ComandoSQL.Parameters.AddWithValue("@nome", cla.Nome);
            ComandoSQL.Parameters.AddWithValue("@ativa", cla.Ativa);

            return ExecutaComando(false);
        }

        internal Classificacao Obter(int codigo, bool obterAtividades)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from CLASSIFICACAO
                        where cla_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                return new Classificacao
                {
                    Codigo = codigo,
                    Nome = dt.Rows[0]["cla_nome"].ToString(),
                    Ativa = Convert.ToChar(dt.Rows[0]["cla_ativa"].ToString()),
                    Atividades = obterAtividades ? new AtividadeBD().ObterPorClassificacao(codigo) : null
                };
            }
            else
                return null;
        }

        internal List<Classificacao> ObterPorStatus(char status)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = "select * from CLASSIFICACAO ";
            if (status != 'T')
                ComandoSQL.CommandText += "where cla_ativa = @ativa";
            ComandoSQL.CommandText += " order by cla_nome";
            if (status != 'T')
                ComandoSQL.Parameters.AddWithValue("@ativa", status);

            DataTable dt = ExecutaSelect();
            return DevolverListaClassificacao(dt);
        }

        internal List<Classificacao> ObterPorAtividade(int codigoAtividade)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select c.cla_codigo, c.cla_nome, c.cla_ativa
                    from CLASSIFICACAO c, ATIVIDADECLASSIFICACAO ac
                    where ac.ati_codigo = @codigo and ac.cla_codigo = c.cla_codigo and c.cla_ativa = 'S'
                    order by c.cla_nome";

            ComandoSQL.Parameters.AddWithValue("@codigo", codigoAtividade);

            DataTable dt = ExecutaSelect();
            return DevolverListaClassificacao(dt);
        }

        private List<Classificacao> DevolverListaClassificacao(DataTable dt)
        {
            List<Classificacao> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = new List<Classificacao>();
                foreach (DataRow linha in dt.Rows)
                {
                    Classificacao s = new Classificacao
                    {
                        Codigo = Convert.ToInt32(linha["cla_codigo"].ToString()),
                        Nome = linha["cla_nome"].ToString(),
                        Ativa = Convert.ToChar(linha["cla_ativa"].ToString())
                    };
                    dados.Add(s);
                }
            }
            return dados;
        }

        internal int Excluir(int codigo)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from CLASSIFICACAO
                        where cla_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            return ExecutaComando(false);
        }
    }
}
