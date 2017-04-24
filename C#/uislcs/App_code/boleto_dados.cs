using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class sicoob_doc
{
	#region Linha digitável e códogo de barras
	string _linhadigitavel, _codigodebarras;
	public string linhadigitavel { get { return _linhadigitavel; } set { _linhadigitavel = value; } }
	public string codigodebarras { get { return _codigodebarras; } set { _codigodebarras = value; } }
	#endregion

	string _numero, _data, _vencimento, _valor, _nossonumero, _quantidade, _parcela, _cedente_nome, _cnpj, _banco, _agencia, _codigo, _carteira, _modalidade, _aceite, _doc_especie, _moeda_especie, _local_pagamento, _instrucoes, _taxa_bancaria, _usodobanco, _sacado, _sacado_cpf, _sacado_endereco, _sacado_cidade, _sacado_cep, _sacado_uf;

	public string numero { get { return _numero; } set { _numero = value; } }
	public string data { get { return _data; } set { _data = value; } }
	public string vencimento { get { return _vencimento; } set { _vencimento = value; } }
	public string valor { get { return _valor; } set { _valor = value; } }
	public string nossonumero { get { return _nossonumero; } set { _nossonumero = value; } }
	public string quantidade { get { return _quantidade; } set { _quantidade = value; } }
	public string parcela { get { return _parcela; } set { _parcela = value; } }
	public string cedente_nome { get { return _cedente_nome; } set { _cedente_nome = value; } }
	public string cnpj { get { return _cnpj; } set { _cnpj = value; } }
	public string banco { get { return _banco; } set { _banco = value; } }
	public string agencia { get { return _agencia; } set { _agencia = value; } }
	public string codigo { get { return _codigo; } set { _codigo = value; } }
	public string carteira { get { return _carteira; } set { _carteira = value; } }
	public string modalidade { get { return _modalidade; } set { _modalidade = value; } }
	public string aceite { get { return _aceite; } set { _aceite = value; } }
	public string doc_especie { get { return _doc_especie; } set { _doc_especie = value; } }
	public string moeda_especie { get { return _moeda_especie; } set { _moeda_especie = value; } }
	public string local_pagamento { get { return _local_pagamento; } set { _local_pagamento = value; } }
	public string instrucoes { get { return _instrucoes; } set { _instrucoes = value; } }
	public string taxa_bancaria { get { return _taxa_bancaria; } set { _taxa_bancaria = value; } }
	public string usodobanco { get { return _usodobanco; } set { _usodobanco = value; } }
	public string sacado { get { return _sacado; } set { _sacado = value; } }
	public string sacado_cpf { get { return _sacado_cpf; } set { _sacado_cpf = value; } }
	public string sacado_endereco { get { return _sacado_endereco; } set { _sacado_endereco = value; } }
	public string sacado_cidade { get { return _sacado_cidade; } set { _sacado_cidade = value; } }
	public string sacado_cep { get { return _sacado_cep; } set { _sacado_cep = value; } }
	public string sacado_uf { get { return _sacado_uf; } set { _sacado_uf = value; } }

	public sicoob_doc()
	{
	}

	public sicoob_doc(bool completo, string numero, string data, string vencimento, string valor, string nossonumero, string quantidade, string parcela, string cedente_nome, string cnpj, string banco, string agencia, string codigo, string carteira, string modalidade, string aceite, string doc_especie, string moeda_especie, string local_pagamento, string instrucoes, string taxa_bancaria, string usodobanco, string sacado, string sacado_cpf, string sacado_endereco, string sacado_cidade, string sacado_cep, string sacado_uf)
	{
		if (completo)
		{
			bancoob bcb = new bancoob(carteira, agencia, modalidade, codigo, nossonumero, parcela, vencimento, valor);
			_linhadigitavel = bcb.linhadigitavel;
			_codigodebarras = bcb.codigodebarras;
		}

		_numero = numero;
		_data = data;
		_vencimento = vencimento;
		_valor = valor;
		_nossonumero = nossonumero;
		_quantidade = quantidade;
		_parcela = parcela;
		_cedente_nome = cedente_nome;
		_cnpj = cnpj;
		_banco = banco;
		_agencia = agencia;
		_codigo = codigo;
		_carteira = carteira;
		_modalidade = modalidade;
		_aceite = aceite;
		_doc_especie = doc_especie;
		_moeda_especie = moeda_especie;
		_local_pagamento = local_pagamento;
		_instrucoes = instrucoes;
		_taxa_bancaria = taxa_bancaria;
		_usodobanco = usodobanco;
		_sacado = sacado;
		_sacado_cpf = sacado_cpf;
		_sacado_endereco = sacado_endereco;
		_sacado_cidade = sacado_cidade;
		_sacado_cep = sacado_cep;
		_sacado_uf = sacado_uf;
	}
}

public partial class sicoob_acesso
{ //uislcs: não foi testado ainda!

	public static sicoob_doc select_boleto()
	{
		sicoob_doc res;
		using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
		{
			conn.Open();
			using (SqlCommand cmd = new SqlCommand("select_boleto", conn))
			{
				SqlDataReader rdr = cmd.ExecuteReader();
				rdr.Read();
                //uislcs: se o primerio argumento for verdadeiro vai executar a rotina para gerar o código de barras e a linha digitável
				res = new sicoob_doc(true, rdr["numero"].ToString(), rdr["data"].ToString(), rdr["vencimento"].ToString(), rdr["valor"].ToString(), rdr["nossonumero"].ToString(), rdr["quantidade"].ToString(), rdr["parcela"].ToString(), rdr["cedente_nome"].ToString(), rdr["cnpj"].ToString(), rdr["banco"].ToString(), rdr["agencia"].ToString(), rdr["codigo"].ToString(), rdr["carteira"].ToString(), rdr["modalidade"].ToString(), rdr["aceite"].ToString(), rdr["doc_especie"].ToString(), rdr["moeda_especie"].ToString(), rdr["local_pagamento"].ToString(), rdr["instrucoes"].ToString(), rdr["taxa_bancaria"].ToString(), rdr["usodobanco"].ToString(), rdr["sacado"].ToString(), rdr["sacado_cpf"].ToString(), rdr["sacado_endereco"].ToString(), rdr["sacado_cidade"].ToString(), rdr["sacado_cep"].ToString(), rdr["sacado_uf"].ToString());
				rdr.Close();
				return res;
			}
			conn.Close();
		}
	}

	public static List<sicoob_doc> listar_boletos()
	{
		using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString))
		{
			List<sicoob_doc> coll = new List<sicoob_doc>();
			conn.Open();
			using (SqlCommand cmd = new SqlCommand("listar_boletos", conn))
			{
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
                    //uislcs: se o primerio argumento for verdadeiro vai executar a rotina para gerar o código de barras e a linha digitável
					coll.Add(new sicoob_doc(false, rdr["numero"].ToString(), rdr["data"].ToString(), rdr["vencimento"].ToString(), rdr["valor"].ToString(), rdr["nossonumero"].ToString(), rdr["quantidade"].ToString(), rdr["parcela"].ToString(), rdr["cedente_nome"].ToString(), rdr["cnpj"].ToString(), rdr["banco"].ToString(), rdr["agencia"].ToString(), rdr["codigo"].ToString(), rdr["carteira"].ToString(), rdr["modalidade"].ToString(), rdr["aceite"].ToString(), rdr["doc_especie"].ToString(), rdr["moeda_especie"].ToString(), rdr["local_pagamento"].ToString(), rdr["instrucoes"].ToString(), rdr["taxa_bancaria"].ToString(), rdr["usodobanco"].ToString(), rdr["sacado"].ToString(), rdr["sacado_cpf"].ToString(), rdr["sacado_endereco"].ToString(), rdr["sacado_cidade"].ToString(), rdr["sacado_cep"].ToString(), rdr["sacado_uf"].ToString()));
				}
				rdr.Close();
				return coll;
			}
			conn.Close();
		}
	}

}