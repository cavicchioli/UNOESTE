using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.DAO;

namespace ProjetoServiceDesk.Controller
{
    public class StatusController
    {
        public StatusController() { }

        public int Gravar(Status st)
        {
            if (st.Descricao.Trim().Length > 0)
                return new StatusBD().Gravar(st);
            else
                return -1;
        }

        public Status Obter(int codigo, bool obterAtividades = true)
        {
            if (codigo > 0)
                return new StatusBD().Obter(codigo, obterAtividades);
            else
                return null;
        }

        /// <summary>
        /// Obter os Status de acordo com sua classificação
        /// </summary>
        /// <param name="status">T=Todos; S=Ativo; N=Inativos</param>
        /// <returns></returns>
        public List<Status> Obter(char status)
        {
            if (status == 'T' || status == 'S' || status == 'N')
                return new StatusBD().Obter(status);
            else
                return null;
        }

        public int Excluir(int codigo)
        {
            if (codigo > 0)
                return new StatusBD().Excluir(codigo);
            else
                return -1;
        }
    }
}
