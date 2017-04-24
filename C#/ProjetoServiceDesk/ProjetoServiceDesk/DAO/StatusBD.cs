using ProjetoServiceDesk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class StatusBD : Banco
    {
        internal StatusBD() { }

        internal int Gravar(Status st)
        {
            ComandoSQL.Parameters.Clear();
            if (st.Codigo == 0) //Novo registro
                ComandoSQL.CommandText = @"insert into STATUS (sta_status, sta_ativo)
                        values(@status, @ativo)";
            else //Alteração
            {
                ComandoSQL.CommandText = @"update STATUS 
                        set sta_status = @status, sta_ativo = @ativo
                        where sta_codigo = @codigo";
                ComandoSQL.Parameters.AddWithValue("@codigo", st.Codigo);
            }
            ComandoSQL.Parameters.AddWithValue("@status", st.Descricao);
            ComandoSQL.Parameters.AddWithValue("@ativo", st.Ativo);

            return ExecutaComando(false);
        }

        internal Status Obter(int codigo, bool obterAtividades)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from STATUS
                        where sta_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                return new Status
                {
                    Codigo = codigo,
                    Descricao = dt.Rows[0]["sta_status"].ToString(),
                    Ativo = Convert.ToChar(dt.Rows[0]["sta_ativo"].ToString()),
                    Atividades = obterAtividades ? new AtividadeBD().ObterPorStatus(codigo) : null
                };
            }
            else
                return null;
        }

        internal List<Status> Obter(char status)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = "select * from STATUS ";
            if (status != 'T')
                ComandoSQL.CommandText += "where sta_ativo = @ativo";
            ComandoSQL.CommandText += " order by sta_status";
            if (status != 'T')
                ComandoSQL.Parameters.AddWithValue("@ativo", status);

            DataTable dt = ExecutaSelect();
            List<Status> dados = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                dados = new List<Status>();
                foreach (DataRow linha in dt.Rows)
                {
                    Status s = new Status
                    {
                        Codigo = Convert.ToInt32(linha["sta_codigo"].ToString()),
                        Descricao = linha["sta_status"].ToString(),
                        Ativo = Convert.ToChar(linha["sta_ativo"].ToString())
                    };
                    dados.Add(s);
                }
            }
            return dados;
        }

        internal int Excluir(int codigo)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"delete from STATUS
                        where sta_codigo = @codigo";
            ComandoSQL.Parameters.AddWithValue("@codigo", codigo);

            return ExecutaComando(false);
        }
    }
}
