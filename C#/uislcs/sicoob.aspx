<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sicoob.aspx.cs"
 Inherits="boleto_sicoob" Title="Boleto Meuclick.Net" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>Boleto meuclick.net</title>
 <link rel="shortcut icon" href="~/Favicon.ico" runat="server" type="image/x-icon" />
<style type="text/css">
body {margin: 0; padding: 0; text-align: center; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 0.7em;}
table{text-align: left; width: 666px;}
.texto1, .texto3{font: bold 15px Arial; color: #000080;}
.texto2{font: 9px 'Arial Narrow'; color: #000080; text-transform: none;}
.texto3{font: 10px Arial; color: #000000; text-transform: uppercase;}
.texto3 td{padding-left:10px; border-bottom: solid 1px #000000;}
.l{border-left: none;}
td{border-left: solid 1px #000000;}
.texto1 td{border-bottom: solid 1px #000000;}
</style>
</head>
<body style="background-image: none; background-color: #ffffff; color:#000000;">
    <form id="form1" runat="server">
    <div style="text-align: left; width: 666px;">
<b>Instruções:</b>
<ul style="list-style-type:decimal; text-align:justify;">
	<li>Imprima em impressora jato de tinta (ink jet) ou laser em qualidade normal ou alta Não use modo econômico. Por favor, configure a margens esquerda e direita para 17 mm</li>
	<li>Utilize folha A4 (210 x 297 mm) ou Carta (216 x 279 mm) e margens mínimas à esquerda e à direita do formulário.</li>
	<li>Corte na linha indicada. Não rasure, risque, fure ou dobre a região onde se encontra o código de barras.</li>
</ul>
</div>
		<table cellpadding="0" cellspacing="0">
			<tr>
				<td class="texto2" style="border-bottom: 1px dashed #000080; border-left:none;">Corte na linha pontilhada
				</td>
			</tr>
		</table>
		<br />
		<table cellspacing="0px">
			<tr class="texto1">
				<td class="l">
					<img alt="756" src="img/756.jpg" /></td>
				<td>
					<asp:Literal ID="Literal_banco_cod" runat="server" Text="756-0" />
					</td>
					<td>
					&#160;<asp:Literal ID="Literal_linha_digitavel" runat="server" Text="75691.30359 02004.572109 00000.180018 1 29150000254850" />
					
					</td>
			</tr>
		</table>
		<table cellspacing="0" cellpadding="0" id="TABLE1">
			<tr class="texto2">
				<td style="width: 469px;" class="l">
					Local de pagamento</td>
				<td style="width: 189px; background-color: #ffd700;" >
					Vencimento</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_pagamento_local" runat="server" Text="pagável em qualquer banco até o vencimento" /></td>
				<td style="background-color: #ffd700">
					<asp:Literal ID="Literal_vencimento_data" runat="server" Text="vencimento" /></td>
			</tr>
			<tr class="texto2">
				<td style="width: 469px;" class="l">
					Cedente</td>
				<td style="width: 189px;">
					Agência/Código cedente</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_cedente_nome" runat="server" Text="uisleandro costa dos santos" /></td>
				<td>
					<asp:Literal ID="Literal_agencia_Codcedente" runat="server" Text="3024/6715-6" /></td>
			</tr>
		</table>
		<table cellspacing="0px">
			<tr class="texto2">
				<td style="width: 72px" class="l">
					Data do docto.</td>
				<td>
					Nº documento
				</td>
				<td style="width: 60px">
					Espécie doc.
				</td>
				<td style="width: 60px">
					Aceite
				</td>
				<td style="width: 90px">
					Data process.
				</td>
				<td style="width: 189px">
					Nosso número
				</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_documento_data" runat="server" Text="datadoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_numero" runat="server" Text="numdoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_especie" runat="server" Text="especdoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_aceite" runat="server" Text="n" /></td>
				<td>
					<asp:Literal ID="Literal_documento_dataproc" runat="server" Text="dataproc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_nossonumero" runat="server" Text="nossonumero" /></td>
			</tr>
		</table>
		<table cellspacing="0px">
			<tr class="texto2">
				<td style="width: 72px" class="l">
					Uso do banco.</td>
				<td style="width: 75px">
					Carteira</td>
				<td style="width: 90px">
					Espécie Moeda</td>
				<td>
					Quantidade</td>
				<td style="width: 90px">
					Valor Doc
				</td>
				<td style="width: 189px; background-color: #ffd700;">
					( = ) Valor documento</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					&#160;<asp:Literal ID="Literal_usodobanco" runat="server" Text="." /></td>
				<td>
					<asp:Literal ID="Literal_carteira" runat="server" Text="001-002" /></td>
				<td>
					<asp:Literal ID="Literal_moeda_especie" runat="server" Text="REAL" /></td>
				<td>
					<asp:Literal ID="Literal_quantidade" runat="server" Text="1" /></td>
				<td>
					<asp:Literal ID="Literal_valor_documento1" runat="server" Text="valordoc1" /></td>
				<td style="background-color: #ffd700">
					<asp:Literal ID="Literal_valor_documento2" runat="server" Text="valordoc2" /></td>
			</tr>
		</table>
		<table cellspacing="0" cellpadding="0" id="TABLE2">
			<tr>
			<td style="width: 475px; border-bottom: solid 1px #000000;" rowspan="10" valign="top" class="l">
				<span class="texto2">Instruções (Texto de responsabilidade do Cedente)</span><br />
				<div style="margin: 4px;">
				<asp:Literal ID="Literal_instrucoes" runat="server" Text="" />
				</div></td>
				<td class="texto2" style="width: 181px;">
					( - ) Desconto/ abatimento</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">&#160;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( - ) Outras Deduções</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">&#160;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( + ) Mora/ multa</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">&#160;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( + ) Outros acréscimos</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">&#160;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( = ) Valor cobrado</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">&#160;</td>
			</tr>
			<tr class="texto3">
			<td valign="top" class="l" colspan="2" style="padding-left: 0px;">
				<span class="texto2">sacado: </span><asp:Literal ID="Literal_sacado_nome" runat="server" Text="nome do sacado" /> <asp:Literal ID="Literal_sacado_cpf" runat="server" Text="CPF" />
				<div style="padding-left: 28px;">
				<asp:Literal ID="Literal_sacado_endereco" runat="server" Text="endereço" /><br />
				<asp:Literal ID="Literal_sacado_cepcidadeuf" runat="server" Text="cidade cep uf" /><br />
				</div>
			</td>
			</tr>
			<tr>
				<td class="l" colspan="2" style="padding-top: 2px; padding-left: 5px; border: none; text-align: right;"
					valign="top"><div class="texto2" style="width: 38%; text-align: center; float: right;">
						Autenticação mecânica</div>
				</td>
			</tr>
		</table>
		<table cellpadding="0" cellspacing="0">
			<tr>
				<td class="texto2" style="border-bottom: 1px dashed #000080; border-left:none; height: 14px;">
					Corte na linha pontilhada
				</td>
			</tr>
		</table>
		<br />
		<table cellspacing="0px">
			<tr class="texto1">
				<td class="l">
					<img alt="756" src="img/756.jpg" /></td>
				<td>
					<asp:Literal ID="Literal_banco_cod2" runat="server" Text="756-0" />
				</td>
				<td>
					&nbsp;<asp:Literal ID="Literal_linha_digitavel2" runat="server" Text="75691.30359 02004.572109 00000.180018 1 29150000254850" />
				</td>
			</tr>
		</table>
		<table cellspacing="0" cellpadding="0" id="Table3">
			<tr class="texto2">
				<td style="width: 469px;" class="l">
					Local de pagamento</td>
				<td style="width: 189px; background-color: #ffd700;" >
					Vencimento</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_pagamento_local2" runat="server" Text="pagável em qualquer banco até o vencimento" /></td>
				<td style="background-color: #ffd700">
					<asp:Literal ID="Literal_vencimento_data2" runat="server" Text="vencimento" /></td>
			</tr>
			<tr class="texto2">
				<td style="width: 469px;" class="l">
					Cedente</td>
				<td style="width: 189px;">
					Agência/Código cedente</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_cedente_nome2" runat="server" Text="uisleandro costa dos santos" /></td>
				<td>
					<asp:Literal ID="Literal_agencia_Codcedente2" runat="server" Text="3024/6715-6" /></td>
			</tr>
		</table>
		<table cellspacing="0px">
			<tr class="texto2">
				<td style="width: 72px" class="l">
					Data do docto.</td>
				<td>
					Nº documento
				</td>
				<td style="width: 60px">
					Espécie doc.
				</td>
				<td style="width: 60px">
					Aceite
				</td>
				<td style="width: 90px">
					Data process.
				</td>
				<td style="width: 189px">
					Nosso número
				</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					<asp:Literal ID="Literal_documento_data2" runat="server" Text="datadoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_numero2" runat="server" Text="numdoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_especie2" runat="server" Text="especdoc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_aceite2" runat="server" Text="n" /></td>
				<td>
					<asp:Literal ID="Literal_documento_dataproc2" runat="server" Text="dataproc" /></td>
				<td>
					<asp:Literal ID="Literal_documento_nossonumero2" runat="server" Text="nossonumero" /></td>
			</tr>
		</table>
		<table cellspacing="0px">
			<tr class="texto2">
				<td style="width: 72px" class="l">
					Uso do banco.</td>
				<td style="width: 75px">
					Carteira</td>
				<td style="width: 90px">
					Espécie Moeda</td>
				<td>
					Quantidade</td>
				<td style="width: 90px">
					Valor Doc
				</td>
				<td style="width: 189px; background-color: #ffd700;">
					( = ) Valor documento</td>
			</tr>
			<tr class="texto3">
				<td class="l">
					&nbsp;<asp:Literal ID="Literal_usodobanco2" runat="server" Text="." /></td>
				<td>
					<asp:Literal ID="Literal_carteira2" runat="server" Text="001-002" /></td>
				<td>
					<asp:Literal ID="Literal_moeda_especie2" runat="server" Text="REAL" /></td>
				<td>
					<asp:Literal ID="Literal_quantidade2" runat="server" Text="1" /></td>
				<td>
					<asp:Literal ID="Literal_valor_documento12" runat="server" Text="valordoc1" /></td>
				<td style="background-color: #ffd700">
					<asp:Literal ID="Literal_valor_documento22" runat="server" Text="valordoc2" /></td>
			</tr>
		</table>
		<table cellspacing="0" cellpadding="0" id="Table4">
			<tr>
				<td style="width: 475px; border-bottom: solid 1px #000000;" rowspan="10" valign="top" class="l">
					<span class="texto2">Instruções (Texto de responsabilidade do Cedente)</span><br />
					<div style="margin: 4px;">
					<asp:Literal ID="Literal_instrucoes2" runat="server" Text="Instruções" />
					</div>
				</td>
				<td class="texto2" style="width: 181px;">
					( - ) Desconto/ abatimento</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">
					&nbsp;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( - ) Outras Deduções</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">
					&nbsp;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( + ) Mora/ multa</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">
					&nbsp;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( + ) Outros acréscimos</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">
					&nbsp;</td>
			</tr>
			<tr>
				<td class="texto2" style="width: 181px">
					( = ) Valor cobrado</td>
			</tr>
			<tr class="texto3">
				<td style="width: 181px">
					&nbsp;</td>
			</tr>
			<tr class="texto3">
				<td valign="top" class="l" colspan="2" style="padding-left: 0px;">
					<span class="texto2">sacado: </span>
					<asp:Literal ID="Literal_sacado_nome2" runat="server" Text="nome do sacado" />
					<asp:Literal ID="Literal_sacado_cpf2" runat="server" Text="CPF" />
					<div style="padding-left: 28px;">
						<asp:Literal ID="Literal_sacado_endereco2" runat="server" Text="endereço" /><br />
						<asp:Literal ID="Literal_sacado_cepcidadeuf2" runat="server" Text="cidade cep uf" /><br />
					</div>
				</td>
			</tr>
			<tr>
				<td class="l" colspan="2" style="padding-top: 2px; padding-left: 5px; border: none; text-align: right;"
					valign="top">
					<img alt="código de barras" height="50" src="?=" style="float: left" width="405" />
					<div class="texto2" style="width: 38%; text-align: center; float: right;">
						Autenticação mecânica</div>
				</td>
			</tr>
		</table>
		<br />
				<table cellpadding="0" cellspacing="0">
			<tr>
				<td class="texto2" style="border-bottom: 1px dashed #000080; border-left:none; height: 15px;">&#160;
				</td>
			</tr>
		</table>
    </form>
</body>
</html>
