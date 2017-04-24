using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2010.CamadaLogica;

namespace Copa2010.CamadaNegocio
{
    class Jogadores
    {
        private int _jog_codigo;
        private string _jog_nome;
        private DateTime _jog_dtnascimento;
        private string _jog_posicao;
        private byte[] _jog_foto;
        private int _equ_codigo;

        public int Jog_codigo
        {
            get { return _jog_codigo; }
            set { _jog_codigo = value; }
        }

        public string Jog_nome
        {
            get { return _jog_nome; }
            set { _jog_nome = value; }
        }

        public DateTime Jog_dtnascimento
        {
            get { return _jog_dtnascimento; }
            set { _jog_dtnascimento = value; }
        }

        public string Jog_posicao
        {
            get { return _jog_posicao; }
            set { _jog_posicao = value; }
        }

        public byte[] Jog_foto
        {
            get { return _jog_foto; }
            set { _jog_foto = value; }
        }

        public int Equ_codigo
        {
            get { return _equ_codigo; }
            set { _equ_codigo = value; }
        }

        //instância do banco
        private BancoDados banco = new BancoDados();

        public Jogadores()
        {
            _jog_codigo = 0;
            _jog_nome = string.Empty;
            _jog_dtnascimento = DateTime.Now;
            _jog_posicao = string.Empty;
            _jog_foto = null;
            _equ_codigo = 0;
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
                case 1: bd.SqlCmd.CommandText = "select j.jog_codigo, j.jog_nome, j.jog_dtnascimento, j.jog_posicao, j.jog_foto, e.equ_nome from jogadores j, equipes e where e.equ_codigo = j.equ_codigo and j.jog_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select j.jog_codigo, j.jog_nome, j.jog_dtnascimento, j.jog_posicao, j.jog_foto, e.equ_nome from jogadores j, equipes e where e.equ_codigo = j.equ_codigo and j.jog_nome like '%" + valor + "%'";
                    break;
            }
            dt.Load(bd.SqlCmd.ExecuteReader());
            bd.fecharConexao();

            return dt;

        }

        //Método para localizar os dados quando o foco sai do campo código
        public bool buscarPorCodigo()
        {
            DataTable dt = new DataTable();
            dt = banco.retDataTable("select * from jogadores where jog_codigo = " + _jog_codigo);

            if (dt.Rows.Count > 0)
            {
                _jog_codigo = Convert.ToInt32(dt.Rows[0]["jog_codigo"]);
                _jog_nome = Convert.ToString(dt.Rows[0]["jog_nome"]);
                _jog_dtnascimento = Convert.ToDateTime(dt.Rows[0]["jog_dtnascimento"]);
                _jog_posicao = Convert.ToString(dt.Rows[0]["jog_posicao"]);
                _jog_foto = (byte[])dt.Rows[0]["jog_foto"];
                _equ_codigo = Convert.ToInt32(dt.Rows[0]["equ_codigo"]);

                return true;
            }
            else
                return false;
        }

        //Método para configurar a grid do Localizar
        public static DataGridView configuraGrid(DataGridView dtaGridView)
        {
            dtaGridView.Columns[0].HeaderText = "Código";
            dtaGridView.Columns[0].Width = 50;

            dtaGridView.Columns[1].HeaderText = "Nome";
            dtaGridView.Columns[1].Width = 250;

            dtaGridView.Columns[2].HeaderText = "Dt Nascimento";
            dtaGridView.Columns[2].Width = 120;

            dtaGridView.Columns[3].HeaderText = "Posição";
            dtaGridView.Columns[3].Width = 100;

            dtaGridView.Columns[4].HeaderText = "Foto";
            dtaGridView.Columns[4].Width = 70;

            dtaGridView.Columns[5].HeaderText = "Equipe";
            dtaGridView.Columns[5].Width = 150;

            return dtaGridView;
        }

        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;

            banco.SqlCmd.CommandText = "delete from jogadores where jog_codigo = " + _jog_codigo;
            if (!banco.executarComando())
                mensagem = "Erro na Exclusão !";
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;

            if (_jog_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into jogadores (jog_nome, jog_dtnascimento, jog_posicao, jog_foto, equ_codigo) values (@jog_nome, @jog_dtnascimento, @jog_posicao, @jog_foto, @equ_codigo)";
                banco.SqlCmd.Parameters.AddWithValue("@jog_nome", _jog_nome);
                banco.SqlCmd.Parameters.AddWithValue("@jog_dtnascimento", _jog_dtnascimento);
                banco.SqlCmd.Parameters.AddWithValue("@jog_posicao", _jog_posicao);
                banco.SqlCmd.Parameters.AddWithValue("@jog_foto", _jog_foto);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo", _equ_codigo);
            }
            else
            {
                banco.SqlCmd.CommandText = "update jogadores set jog_nome = @jog_nome, jog_dtnascimento = @jog_dtnascimento, jog_posicao = @jog_posicao, jog_foto = @jog_foto, equ_codigo = @equ_codigo  where jog_codigo = @jog_codigo";
                banco.SqlCmd.Parameters.AddWithValue("@jog_nome", _jog_nome);
                banco.SqlCmd.Parameters.AddWithValue("@jog_dtnascimento", _jog_dtnascimento);
                banco.SqlCmd.Parameters.AddWithValue("@jog_posicao", _jog_posicao);
                banco.SqlCmd.Parameters.AddWithValue("@jog_foto", _jog_foto);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo", _equ_codigo);
                banco.SqlCmd.Parameters.AddWithValue("@jog_codigo", _jog_codigo);
            }

            if (!banco.executarComando())
                mensagem = "Erro na gravação";

            banco.fecharConexao();
        }
    }
}
