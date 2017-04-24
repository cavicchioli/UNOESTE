using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.DAO;

namespace ProjetoServiceDesk.Controller
{
    public class FuncionarioController
    {
        FuncionarioBD bd = new FuncionarioBD();

        public Funcionario Autenticar(int codigo, string senha)
        {
            if (codigo > 0 && senha.Trim().Length > 0)
                return new FuncionarioBD().Autenticar(codigo, senha);
            else
                return null;
        }
        public FuncionarioController() { }

        /// <summary>
        /// Contratar um funcionario
        /// </summary>
        /// <param name="func">Objeto funcionario a ser contratado</param>
        /// <returns>Retorna um valor inteiro indicando o sucesso ou não da operação</returns>
        public int Gravar(Funcionario func)
        {
            if (func.Nome.Trim().Length >= 3 &&
                func.Ativo == 'S')
            {
                return bd.Gravar(func);
            }
            else
                return -1;
        }

        public List<Funcionario> Obter(char ativo = 'S')
        {
            if (ativo == 'S' || ativo == 'N')
                return bd.Obter("",ativo);
            else
                return null;
        }

        public List<Funcionario> ObterTodos()
        {
            return new FuncionarioBD().ObterTodos();
        }

        public Funcionario Obter(int codigoFuncionario, bool buscarAtividades = true)
        {
            /*
            if (codigoFuncionario > 0)
                return bd.Obter(codigoFuncionario);
            else
                return null;
            */

            return codigoFuncionario > 0 ? bd.Obter(codigoFuncionario, buscarAtividades) : null;
        }

        public int Demitir(int codigoFuncionario)
        {
            return bd.Demitir(codigoFuncionario);
        }
    }
}
