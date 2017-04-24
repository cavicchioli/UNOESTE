using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2010.CamadaLogica;

namespace Copa2010.CamadaNegocio
{
    class Equipes
    {
        private int _equ_codigo;
        private string _equ_nome;
        private byte[] _equ_bandeira;
        private int _gru_codigo;
        
        public int Equ_codigo
        {
            get { return _equ_codigo; }
            set { _equ_codigo = value; }
        }

        public string Equ_nome
        {
            get { return _equ_nome; }
            set { _equ_nome = value; }
        }

        public byte[] Equ_bandeira
        {
            get { return _equ_bandeira; }
            set { _equ_bandeira = value; }
        }

        public int Gru_codigo
        {
            get { return _gru_codigo; }
            set { _gru_codigo = value; }
        }
        
        //instância do banco
        private BancoDados banco = new BancoDados();

        public Equipes()
        {
            _equ_codigo = 0;
            _equ_nome = string.Empty;
            _equ_bandeira = null;
            _gru_codigo = 0;
        }

        //Método para localizar os dados quando o foco sai do campo código
        public bool buscarPorCodigo()
        {
            banco.abrirConexao();
            banco.SqlCmd.CommandText = "select * from equipes where equ_codigo = "+_equ_codigo;
            
            DataTable dt = new DataTable();
            dt.Load(banco.SqlCmd.ExecuteReader());
            banco.fecharConexao();

            if (dt.Rows.Count > 0)
            {
                _equ_codigo = Convert.ToInt32(dt.Rows[0]["equ_codigo"]);
                _equ_nome = Convert.ToString(dt.Rows[0]["equ_nome"]);
                _equ_bandeira = (byte[]) dt.Rows[0]["equ_bandeira"];
                _gru_codigo = Convert.ToInt32(dt.Rows[0]["gru_codigo"]);
                return true;
            }
            else
                return false;
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;

            if (_equ_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into equipes (equ_nome, equ_bandeira, gru_codigo) values (@equ_nome, @equ_bandeira, @gru_codigo)";
                banco.SqlCmd.Parameters.AddWithValue("@equ_nome", _equ_nome);
                banco.SqlCmd.Parameters.AddWithValue("@equ_bandeira", _equ_bandeira);
                banco.SqlCmd.Parameters.AddWithValue("@gru_codigo", _gru_codigo);
            }
            else
            {
                //Update
                banco.SqlCmd.CommandText = "update equipes set equ_nome = @equ_nome, equ_bandeira = @equ_bandeira, gru_codigo = @gru_codigo where equ_codigo = @equ_codigo";
                banco.SqlCmd.Parameters.AddWithValue("@equ_nome", _equ_nome);
                banco.SqlCmd.Parameters.AddWithValue("@equ_bandeira", _equ_bandeira);
                banco.SqlCmd.Parameters.AddWithValue("@gru_codigo", _gru_codigo);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo", _equ_codigo);
            }
            
            if (!banco.executarComando())
                mensagem = "Erro na gravação";

        }
        
        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;

            banco.SqlCmd.CommandText = "delete from equipes where equ_codigo = " + _equ_codigo;
            if (!banco.executarComando())
                mensagem = "Erro na exclusão";
        }

        //Método para buscar e carregar a grid do Localizar
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

        //Método para configurar a grid do Localizar
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
