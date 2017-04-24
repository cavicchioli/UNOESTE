using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Copa2014.Logica;

namespace Copa2014.Negocio
{
    class Equipes
    {
        private int _codigo;
        private string _descricao;
        private int _grupo;
        private byte[] _imagem;

        //instância do banco
        private BancoDados banco = new BancoDados();
        
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public int Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        public byte[] Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public Equipes()
        {
            _codigo = 0;
            _descricao = string.Empty;
            _grupo = 0;
            _imagem = null;
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;

            if (_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into equipes (equ_nome, equ_bandeira, gru_codigo) values (@nome, @bandeira, @grupo)";
                banco.SqlCmd.Parameters.AddWithValue("@nome", _descricao);
                banco.SqlCmd.Parameters.AddWithValue("@bandeira",_imagem);
                banco.SqlCmd.Parameters.AddWithValue("@grupo", _grupo);
            }
            else
            {
                banco.SqlCmd.CommandText = "update equipes set equ_nome = @nome, equ_bandeira = @bandeira, gru_codigo = @grupo  where equ_codigo = @codigo";
                banco.SqlCmd.Parameters.AddWithValue("@nome", _descricao);
                banco.SqlCmd.Parameters.AddWithValue("@bandeira", _imagem);
                banco.SqlCmd.Parameters.AddWithValue("@grupo", _grupo);
                banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);
            }
            
            if (!banco.executarComando())
                mensagem = "Erro na gravação";            
        }

        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;
            
            banco.SqlCmd.CommandText = "delete from equipes where equ_codigo = @codigo";
            banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);
            if (!banco.executarComando())
                mensagem = "Erro na exclusão";
        }

        /// <summary>
        /// Método para localizar os dados quando o foco sai do campo código
        /// </summary>
        /// <returns></returns>
        public bool buscarPorCodigo()
        {
            banco.abrirConexao();
            banco.SqlCmd.CommandText = "select * from equipes where equ_codigo = @codigo";
            banco.SqlCmd.Parameters.AddWithValue("@codigo", _codigo);

            DataTable dt = new DataTable();
            dt.Load(banco.SqlCmd.ExecuteReader());
            banco.fecharConexao();

            if (dt.Rows.Count > 0)
            {
                _codigo = Convert.ToInt32(dt.Rows[0]["equ_codigo"]);
                _descricao = Convert.ToString(dt.Rows[0]["equ_nome"]);
                _grupo = Convert.ToInt32(dt.Rows[0]["gru_codigo"]);
                //_imagem = Convert.ToByte(dt.Rows[0]["equ_bandeira"]);
                return true;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Método para buscar e carregar a grid do Localizar
        /// </summary>
        /// <param name="termoBusca">String pesquisada</param>
        /// <returns></returns>
        /// 
        public static DataTable buscarDados(string valor, int tipo)
        {
            BancoDados bd = new BancoDados(); //db existe aqui porque buscarDados é um método static,
            DataTable dt = new DataTable();

            bd.abrirConexao();
            //ele não pode acessar a variável de instância banco.
            switch (tipo)
            {
                case 1: bd.SqlCmd.CommandText = "select equ_codigo, equ_nome, equ_bandeira, gru_codigo from equipes where equ_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select equ_codigo, equ_nome, equ_bandeira, gru_codigo from equipes where equ_nome like '%" + valor + "%'";
                    break;
            }
            dt.Load(bd.SqlCmd.ExecuteReader());
            bd.fecharConexao();

            return dt;
        }

        /// <summary>
        /// Método para configurar a grid do Localizar
        /// </summary>
        /// <param name="dtaGridView">DataGridView</param>
        /// <returns></returns>

        public static DataGridView configuraGrid(DataGridView dtaGridView)
        {
            dtaGridView.Columns[0].HeaderText = "Código";
            dtaGridView.Columns[0].Width = 50;
            dtaGridView.Columns[1].HeaderText = "Nome";
            dtaGridView.Columns[1].Width = 200;
            dtaGridView.Columns[2].HeaderText = "Bandeira";
            dtaGridView.Columns[2].Width = 70;
            dtaGridView.Columns[3].HeaderText = "Grupo";
            dtaGridView.Columns[3].Width = 50;
            return dtaGridView;
        }
    }
}
