using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebFarmacia2013
{
    public class clsClientes: clsBanco
    {
        private Int32 _codigo;
        private string _nome;
        private string _endereco;
        private string _bairro;
        private string _cidade;
        private string _estado;
        private string _cep;
        private string _celular;
        private string _telefone;
        private string _rg;
        private string _cpf;
        private string _nascimento;
        private decimal _salario;
        private string _foto;
        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private string _email;
        private string _complemento;

        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Int32 Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
       
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
       
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
      
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
     
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
    
        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
    
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
    
        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }
      
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
     
        public string Nascimento
        {
            get { return _nascimento; }
            set { _nascimento = value; }
        }
       
        public decimal Salario
        {
            get { return _salario; }
            set { _salario = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public int IncluirClientes()
        {
            int iLinhas = 0;
            string sSQL = "";

            _codigo = ProximoCodigo(); 
         
            sSQL = "INSERT INTO CLIENTES (CODIGO, NOME, ENDERECO, COMPLEMENTO, BAIRRO, " +
                " CIDADE, ESTADO, CEP, CELULAR, TELEFONE, RG, CPF, SENHA, " +
                " NASCIMENTO, EMAIL )" +
                " VALUES (" +
                _codigo + "," +
                "'" + _nome + "'," +
                "'" + _endereco + "'," +
                "'" + _complemento + "'," +
                "'" + _bairro + "'," +
                "'" + _cidade + "'," +
                "'" + _estado + "'," +
                "'" + _cep + "'," +
                "'" + _celular + "'," +
                "'" + _telefone + "'," +
                "'" + _rg + "'," +
                "'" + _cpf + "'," +
                "'" + _senha + "'," +
                "'" + _nascimento + "'," +
                "'" + _email + "')";
            iLinhas = ExecutarSQL(sSQL);
            return iLinhas;
        }

        public int AlterarClientes(int iCodigo)
        {
            int iLinhas = 0;
            string sSQL = "";

            sSQL = "UPDATE CLIENTES SET  " +
                " NOME = '" + _nome + "'," +
                " ENDERECO = '" + _endereco + "'," +
                " COMPLEMENTO = '" + _complemento + "'," +
                " BAIRRO = '" + _bairro + "'," +
                " CIDADE = '" + _cidade + "'," +
                " CEP = '" + _cep + "'," +
                " ESTADO = '" + _estado + "'," +
                " TELEFONE = '" + _telefone + "'," +
                " CELULAR = '" + _celular + "'," +
                " RG = '" + _rg + "'," +
                " CPF = '" + _cpf + "'," +
                " SENHA = '" + _senha + "'," +
                " NASCIMENTO ='" + _nascimento + "'," +
                " EMAIL = '" + _email + "'" +
                " WHERE CODIGO = " + iCodigo;
            iLinhas = ExecutarSQL(sSQL);
            return iLinhas;
        }

        public int ExcluirCliente()
        {
            int iLinhas = 0;
            string sSQL = "";

            sSQL = "DELETE FROM CLIENTES WHERE CODIGO = " + _codigo;
            iLinhas = ExecutarSQL(sSQL);
            return iLinhas;
        }

        public int RecuperaDados()
        {
            DataTable dtClientes = new DataTable();
            string sSQL = "";
            int iLinhas = 0;

            sSQL = "SELECT * FROM CLIENTES WHERE CODIGO = " + _codigo;
            dtClientes = RetornaDT(sSQL);
            if (dtClientes.Rows.Count > 0)
            {
                _nome = Convert.ToString(dtClientes.Rows[0]["NOME"]);
                _endereco = Convert.ToString(dtClientes.Rows[0]["ENDERECO"]);
                _complemento = Convert.ToString(dtClientes.Rows[0]["COMPLEMENTO"]);
                _bairro = Convert.ToString(dtClientes.Rows[0]["BAIRRO"]);
                _cidade = Convert.ToString(dtClientes.Rows[0]["CIDADE"]);
                _cep = Convert.ToString(dtClientes.Rows[0]["CEP"]);
                _estado = Convert.ToString(dtClientes.Rows[0]["ESTADO"]);
                _telefone = Convert.ToString(dtClientes.Rows[0]["TELEFONE"]);
                _celular = Convert.ToString(dtClientes.Rows[0]["CELULAR"]);
                _rg = Convert.ToString(dtClientes.Rows[0]["RG"]);
                _cpf = Convert.ToString(dtClientes.Rows[0]["CPF"]);
                _senha = Convert.ToString(dtClientes.Rows[0]["SENHA"]);
                _nascimento = Convert.ToString(dtClientes.Rows[0]["NASCIMENTO"]);
                _email = Convert.ToString(dtClientes.Rows[0]["EMAIL"]);
                iLinhas = 1;
            }
            return iLinhas; 
        }

        public int RecuperaDadosCPF()
        {
            DataTable dtClientes = new DataTable();
            string sSQL = "";
            int iLinhas = 0;

            sSQL = "SELECT * FROM CLIENTES WHERE CPF = '" + _cpf + "'";
            dtClientes = RetornaDT(sSQL);
            if (dtClientes.Rows.Count > 0)
            {
                _codigo = Convert.ToInt32(dtClientes.Rows[0]["CODIGO"]);
                _nome = Convert.ToString(dtClientes.Rows[0]["NOME"]);
                _endereco = Convert.ToString(dtClientes.Rows[0]["ENDERECO"]);
                _complemento = Convert.ToString(dtClientes.Rows[0]["COMPLEMENTO"]);
                _bairro = Convert.ToString(dtClientes.Rows[0]["BAIRRO"]);
                _cidade = Convert.ToString(dtClientes.Rows[0]["CIDADE"]);
                _cep = Convert.ToString(dtClientes.Rows[0]["CEP"]);
                _estado = Convert.ToString(dtClientes.Rows[0]["ESTADO"]);
                _telefone = Convert.ToString(dtClientes.Rows[0]["TELEFONE"]);
                _celular = Convert.ToString(dtClientes.Rows[0]["CELULAR"]);
                _rg = Convert.ToString(dtClientes.Rows[0]["RG"]);
                _cpf = Convert.ToString(dtClientes.Rows[0]["CPF"]);
                _senha = Convert.ToString(dtClientes.Rows[0]["SENHA"]);
                _nascimento = Convert.ToString(dtClientes.Rows[0]["NASCIMENTO"]);
                _email = Convert.ToString(dtClientes.Rows[0]["EMAIL"]);
                iLinhas = 1;
            }
            return iLinhas;
        }

        private Int32 ProximoCodigo()
        {
            SqlDataReader drClientes;
            string sSQL;

            sSQL = "SELECT COALESCE(MAX(CODIGO),0) AS ULTIMO FROM CLIENTES ";
            drClientes = RetornaDR(sSQL);
            if (drClientes.HasRows)
            {
                drClientes.Read();
                _codigo = Convert.ToInt32(drClientes["ULTIMO"]) + 1;  
            }
            drClientes.Close();
            DesconectaBanco();

            return _codigo;
        }
    }
}