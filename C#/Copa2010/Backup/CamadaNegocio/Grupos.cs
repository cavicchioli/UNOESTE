using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Copa2010.CamadaLogica;

namespace Copa2010.CamadaNegocio
{
    class Grupos
    {
        private int _gru_codigo;
        private string _gru_descricao;
        //instância do banco
        private BancoDados banco = new BancoDados();
        
        public int Gru_codigo
        {
            get { return _gru_codigo; }
            set { _gru_codigo = value; }
        }

        public string Gru_descricao
        {
            get { return _gru_descricao; }
            set { _gru_descricao = value; }
        }
                     
        public Grupos()
        {
            _gru_codigo = 0;
            _gru_descricao = string.Empty;
        }

        //Método para localizar os dados quando o foco sai do campo código
        public bool buscarPorCodigo()
        {
            banco.abrirConexao();
            banco.SqlCmd.CommandText = "select * from grupos where gru_codigo = "+_gru_codigo;
            
            DataTable dt = new DataTable();
            dt.Load(banco.SqlCmd.ExecuteReader());
            banco.fecharConexao();

            if (dt.Rows.Count > 0)
            {
                _gru_codigo = Convert.ToInt32(dt.Rows[0]["gru_codigo"]);
                _gru_descricao = Convert.ToString(dt.Rows[0]["gru_descricao"]);
                return true;
            }
            else
                return false;
        }

        public void salvar(out string mensagem)
        {
            mensagem = string.Empty;
            int retornoQualquer;

            if (_gru_codigo == 0)
            {
                banco.SqlCmd.CommandText = "insert into grupos (gru_descricao) values (@gru_descricao)";
                banco.SqlCmd.Parameters.AddWithValue("@gru_descricao", _gru_descricao);
            }
            else
            {
                banco.SqlCmd.CommandText = "update grupos set gru_descricao = @gru_descricao where gru_codigo = @gru_codigo";
                banco.SqlCmd.Parameters.AddWithValue("@gru_descricao", _gru_descricao);
                banco.SqlCmd.Parameters.AddWithValue("@gru_codigo", _gru_codigo);
                //banco.SqlCmd.Parameters.AddWithValue("@gru_xxxx", DBNull.Value);
            }
            
            if (!banco.executarComando())
                mensagem = "Erro na gravação";

            //Exemplo com transação
            /*
            banco.AutoConexao = false;
            banco.iniciarTransacao();
            
            banco.executarComando();
            
            banco.SqlCmd.CommandText = "select max(gru_codigo) from grupos";
            retornoQualquer = Convert.ToInt32(banco.SqlCmd.ExecuteScalar());
            mensagem = retornoQualquer.ToString();

            if (!banco.commitTransacao())
            {
                banco.rollbackTransacao();
                mensagem = "";
            }
            */
            
            banco.fecharConexao();
            
        }

        public void excluir(out string mensagem)
        {
            mensagem = string.Empty;
            
            banco.SqlCmd.CommandText = "delete from grupos where gru_codigo = "+_gru_codigo;
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
                case 1: bd.SqlCmd.CommandText = "select gru_codigo, gru_descricao from grupos where gru_codigo = " + Convert.ToInt32(valor);
                    break;
                case 2: bd.SqlCmd.CommandText = "select gru_codigo, gru_descricao from grupos where gru_descricao like '%" + valor + "%'";
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
            dtaGridView.Columns[1].HeaderText = "Descrição";
            dtaGridView.Columns[1].Width = 290;
            return dtaGridView;
        }
    }
}
