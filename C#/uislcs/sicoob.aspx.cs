using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class boleto_sicoob : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string vencimento = DateTime.Now.AddMonths(1).ToShortDateString();
		sicoob_doc scd = new sicoob_doc(true, "123456", "30/08/2007", vencimento, "38,00", "226", "1", "001", "Uisleandro CS", "CNPJ", "237", "0000", "00000", "1", "01", "N", "99", "REAL", "pagável em qualquer banco até o vencimento", "Referência: compras no site meuclick.net <br />Taxa bancária: R$ 1,50 <br />- Sr. Caixa, cobrar multa de 2% após o vencimento <br />- Em caso de dúvidas entre em contato conosco: &lt;uisleandro@meuclick.net&gt;<br />- Emitido pelo sistema meuclick.net - &lt;http://www.meuclick.net&gt;<br />", "1,50", "", "Nome do Sacado", "000.000.000-00", "R. Tal casa tal, 100", "Euclides da Cunha", "48500-000", "BA");

		Literal_cedente_nome.Text = scd.cedente_nome;
		Literal_agencia_Codcedente.Text = scd.agencia + "/" + scd.codigo;
		Literal_banco_cod.Text = "756-0";
		Literal_carteira.Text = scd.carteira;
		Literal_documento_aceite.Text = scd.aceite;
		Literal_documento_data.Text = scd.data;
		Literal_documento_dataproc.Text = DateTime.Now.ToShortDateString(); // Data de Impressão || Processamento
		Literal_documento_nossonumero.Text = scd.nossonumero;
		Literal_documento_numero.Text = scd.numero;
		Literal_documento_especie.Text = scd.doc_especie;
		Literal_instrucoes.Text = scd.instrucoes;
		Literal_moeda_especie.Text = scd.moeda_especie;
		Literal_linha_digitavel.Text = scd.linhadigitavel;
		Literal_pagamento_local.Text = scd.local_pagamento;
		Literal_quantidade.Text = scd.quantidade;
		//Literal_referencia.Text = scd.referencia;
		// Sacado_Ident
		Literal_sacado_cepcidadeuf.Text = scd.sacado_cidade + " " + scd.sacado_cep + " " + scd.sacado_uf;
		Literal_sacado_cpf.Text = " - CPF: " + scd.sacado_cpf;
		Literal_sacado_endereco.Text = scd.sacado_endereco;
		Literal_sacado_nome.Text = scd.sacado;
		//Literal_taxa_bancaria.Text = scd.taxa_bancaria;
		Literal_usodobanco.Text = scd.usodobanco;
		// Boletos_Ident
		Literal_valor_documento1.Text = scd.valor;
		Literal_valor_documento2.Text = scd.valor;
		Literal_vencimento_data.Text = scd.vencimento;
		//SEGUNDA PARTE DO LAYOUT
		Literal_cedente_nome2.Text = scd.cedente_nome; ;
		Literal_agencia_Codcedente2.Text = scd.agencia + "/" + scd.codigo;
		Literal_banco_cod2.Text = "756-0";
		Literal_carteira2.Text = scd.carteira;
		Literal_documento_aceite2.Text = scd.aceite;
		Literal_documento_data2.Text = scd.data;
		Literal_documento_dataproc2.Text = DateTime.Now.ToShortDateString(); // Data de Impressão || Processamento
		Literal_documento_nossonumero2.Text = scd.nossonumero;
		Literal_documento_numero2.Text = scd.numero;
		Literal_documento_especie2.Text = scd.doc_especie;
		Literal_instrucoes2.Text = scd.instrucoes;
		Literal_moeda_especie2.Text = scd.moeda_especie;
		Literal_linha_digitavel2.Text = scd.linhadigitavel;
		Literal_pagamento_local2.Text = scd.local_pagamento;
		Literal_quantidade2.Text = scd.quantidade;
		//Literal_referencia2.Text = scd.referencia;
		// Sacado_Ident
		Literal_sacado_cepcidadeuf2.Text = scd.sacado_cidade + " " + scd.sacado_cep + " " + scd.sacado_uf;
		Literal_sacado_cpf2.Text = " - CPF: " + scd.sacado_cpf;
		Literal_sacado_endereco2.Text = scd.sacado_endereco;
		Literal_sacado_nome2.Text = scd.sacado;
		//Literal_taxa_bancaria2.Text = scd.taxa_bancaria;
		Literal_usodobanco2.Text = scd.usodobanco;
		// Boletos_Ident
		Literal_valor_documento12.Text = scd.valor;
		Literal_valor_documento22.Text = scd.valor;
		Literal_vencimento_data2.Text = scd.vencimento;

		if (Request.QueryString[""] != null)
		{
			Response.ContentType = "image/gif";
			System.Drawing.Bitmap bt = Barras.getBarras(scd.codigodebarras);
			bt.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
		}

    }
}
