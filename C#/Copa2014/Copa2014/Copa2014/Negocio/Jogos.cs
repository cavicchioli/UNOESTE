using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2014.Logica;

namespace Copa2014.Negocio
{
    class Jogos
    {
        private int _jog_codigo;
        private DateTime _jog_data;
        private string _jog_hora;
        private string _jog_local;
        private int _goltime1;
        private int _goltime2;
        private int _equ_codigo1;
        private int _equ_codigo2;
        private int _fas_codigo;

        public int Jog_codigo
        {
            get { return _jog_codigo; }
            set { _jog_codigo = value; }
        }

        public DateTime Jog_data
        {
            get { return _jog_data; }
            set { _jog_data = value; }
        }

        public string Jog_hora
        {
            get { return _jog_hora; }
            set { _jog_hora = value; }
        }

        public string Jog_local
        {
            get { return _jog_local; }
            set { _jog_local = value; }
        }

        public int Goltime1
        {
            get { return _goltime1; }
            set { _goltime1 = value; }
        }

        public int Goltime2
        {
            get { return _goltime2; }
            set { _goltime2 = value; }
        }

        public int Equ_codigo1
        {
            get { return _equ_codigo1; }
            set { _equ_codigo1 = value; }
        }

        public int Equ_codigo2
        {
            get { return _equ_codigo2; }
            set { _equ_codigo2 = value; }
        }

        public int Fas_codigo
        {
            get { return _fas_codigo; }
            set { _fas_codigo = value; }
        }

        //instância do banco
        private BancoDados banco = new BancoDados();

        public Jogos()
        {
            _jog_codigo = 0;
            _jog_data = DateTime.Now;
            _jog_hora = string.Empty;
            _jog_local = string.Empty;
            _goltime1 = 0;
            _goltime2 = 0;
            _equ_codigo1 = 0;
            _equ_codigo2 = 0;
            _fas_codigo = 0;
        }

        //Método para localizar os dados quando o foco sai do campo código
        public bool buscarPorCodigo()
        {
            banco.abrirConexao();
            banco.SqlCmd.CommandText = "select * from jogos where jog_codigo = "+_jog_codigo;
            
            DataTable dt = new DataTable();
            dt.Load(banco.SqlCmd.ExecuteReader());
            banco.fecharConexao();

            if (dt.Rows.Count > 0)
            {
                _jog_codigo = Convert.ToInt32(dt.Rows[0]["jog_codigo"]);
                _jog_data = Convert.ToDateTime(dt.Rows[0]["jog_data"]);
                _jog_hora = Convert.ToString(dt.Rows[0]["jog_hora"]);
                _jog_local = Convert.ToString(dt.Rows[0]["jog_local"]);

                if (dt.Rows[0]["jog_goltime1"].ToString() != "")
                {
                    _goltime1 = Convert.ToInt32(dt.Rows[0]["jog_goltime1"]);
                    _goltime2 = Convert.ToInt32(dt.Rows[0]["jog_goltime2"]);
                }
                else
                {
                    _goltime1 = 0;
                    _goltime2 = 0;
                }

                _equ_codigo1 = Convert.ToInt32(dt.Rows[0]["equ_codigo1"]);
                _equ_codigo2 = Convert.ToInt32(dt.Rows[0]["equ_codigo2"]);
                _fas_codigo = Convert.ToInt32(dt.Rows[0]["fas_codigo"]);

                return true;
            }
            else
                return false;
        }

        public void salvar_placar(int cod_jogo, int placar1, int placar2 , out string mensagem)
        {
            mensagem = string.Empty;

            banco.SqlCmd.CommandText = "update jogos set jog_goltime1 = @jog_goltime1, jog_goltime2 = @jog_goltime2 where jog_codigo = @jog_codigo";
            banco.SqlCmd.Parameters.AddWithValue("@jog_goltime1", placar1);
            banco.SqlCmd.Parameters.AddWithValue("@jog_goltime2", placar2);

            banco.SqlCmd.Parameters.AddWithValue("@jog_codigo", cod_jogo);

            if (!banco.executarComando())
                mensagem = "Erro na gravação";
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;

            if (_jog_codigo == 0)
            {
                //banco.SqlCmd.CommandText = "insert into jogos (jog_data, jog_hora, jog_local, jog_goltime1, jog_goltime2, equ_codigo1, equ_codigo2, fas_codigo) values (@jog_data, @jog_hora, @jog_local, @jog_goltime1, @jog_goltime2, @equ_codigo1, @equ_codigo2, @fas_codigo)";
                banco.SqlCmd.CommandText = "insert into jogos (jog_data, jog_hora, jog_local, equ_codigo1, equ_codigo2, fas_codigo) values (@jog_data, @jog_hora, @jog_local, @equ_codigo1, @equ_codigo2, @fas_codigo)";
                banco.SqlCmd.Parameters.AddWithValue("@jog_data", _jog_data);
                banco.SqlCmd.Parameters.AddWithValue("@jog_hora", _jog_hora);
                banco.SqlCmd.Parameters.AddWithValue("@jog_local", _jog_local);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo1", _equ_codigo1);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo2", _equ_codigo2);
                banco.SqlCmd.Parameters.AddWithValue("@fas_codigo", _fas_codigo);
            }
            else
            {
                //Update
                //banco.SqlCmd.CommandText = "update jogos set jog_data = @jog_data, jog_hora = @jog_hora, jog_local = @jog_local, jog_goltime1 = @jog_goltime1, jog_goltime2 = @jog_goltime2, equ_codigo1 = @equ_codigo1, equ_codigo2 = @equ_codigo2, fas_codigo = @fas_codigo where jog_codigo = @jog_codigo";
                banco.SqlCmd.CommandText = "update jogos set jog_data = @jog_data, jog_hora = @jog_hora, jog_local = @jog_local, equ_codigo1 = @equ_codigo1, equ_codigo2 = @equ_codigo2, fas_codigo = @fas_codigo where jog_codigo = @jog_codigo";
                banco.SqlCmd.Parameters.AddWithValue("@jog_data", _jog_data);
                banco.SqlCmd.Parameters.AddWithValue("@jog_hora", _jog_hora);
                banco.SqlCmd.Parameters.AddWithValue("@jog_local", _jog_local);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo1", _equ_codigo1);
                banco.SqlCmd.Parameters.AddWithValue("@equ_codigo2", _equ_codigo2);
                banco.SqlCmd.Parameters.AddWithValue("@fas_codigo", _fas_codigo);

                banco.SqlCmd.Parameters.AddWithValue("@jog_codigo", _jog_codigo);
            }
            
            if (!banco.executarComando())
                mensagem = "Erro na gravação";

        }
        
        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;

            banco.SqlCmd.CommandText = "delete from jogos where jog_codigo = " + _jog_codigo;
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
                case 1: bd.SqlCmd.CommandText = "select j.jog_codigo, j.jog_data, j.jog_hora, j.jog_local, j.jog_goltime1, j.jog_goltime2, e1.equ_nome, e2.equ_nome, f.fas_descricao from jogos j, equipes e1, equipes e2, fases f where f.fas_codigo = j.fas_codigo and e2.equ_codigo = j.equ_codigo2 and e1.equ_codigo = j.equ_codigo1 and j.jog_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select j.jog_codigo, j.jog_data, j.jog_hora, j.jog_local, j.jog_goltime1, j.jog_goltime2, e1.equ_nome, e2.equ_nome, f.fas_descricao from jogos j, equipes e1, equipes e2, fases f where f.fas_codigo = j.fas_codigo and e2.equ_codigo = j.equ_codigo2 and e1.equ_codigo = j.equ_codigo1 and ( (e1.equ_nome like '%" + valor + "%') or (e2.equ_nome like '%" + valor + "%') )";
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

            dtaGridView.Columns[1].HeaderText = "Data";
            dtaGridView.Columns[1].Width = 100;

            dtaGridView.Columns[2].HeaderText = "Hora";
            dtaGridView.Columns[2].Width = 70;

            dtaGridView.Columns[3].HeaderText = "Local";
            dtaGridView.Columns[3].Width = 150;

            dtaGridView.Columns[4].HeaderText = "Gol Time 1";
            dtaGridView.Columns[4].Width = 90;

            dtaGridView.Columns[5].HeaderText = "Gol Time 2";
            dtaGridView.Columns[5].Width = 90;

            dtaGridView.Columns[6].HeaderText = "Equipe 1";
            dtaGridView.Columns[6].Width = 200;

            dtaGridView.Columns[7].HeaderText = "Equipe 2";
            dtaGridView.Columns[7].Width = 200;

            dtaGridView.Columns[8].HeaderText = "Fase";
            dtaGridView.Columns[8].Width = 150;

            return dtaGridView;
        }
    }
}
