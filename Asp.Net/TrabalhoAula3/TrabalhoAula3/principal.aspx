<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="TrabalhoAula3.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;">
        <div style="width:600px;margin:0 auto;">
            <h2>Cadastro de Cartões de Crédito</h2>
            <h3>Titular</h3>
        </div>
        <table id="tabelaFixa" runat="server" border="1" style="width:600px;border:1px solid black;margin:0 auto;border-spacing:0;border-collapse:collapse;">
            <tr>
                <td>CPF</td>
                <td colspan="3">
                    <asp:TextBox ID="tbCPF" runat="server" MaxLength="11" Columns="13" ToolTip="Somente Números"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Nome</td>
                <td colspan="3">
                    <asp:TextBox ID="tbNome" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Endereço</td>
                <td colspan="3">
                    <asp:TextBox ID="tbEndereco" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Bairro</td>
                <td colspan="3">
                    <asp:TextBox ID="tbBairro" runat="server" MaxLength="20" Columns="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Cidade</td>
                <td>
                    <asp:TextBox ID="tbCidade" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                </td>
                <td>Estado</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEstado">
                        <asp:ListItem>AC</asp:ListItem>
                        <asp:ListItem>AL</asp:ListItem>
                        <asp:ListItem>AM</asp:ListItem>
                        <asp:ListItem>AP</asp:ListItem>
                        <asp:ListItem>BA</asp:ListItem>
                        <asp:ListItem>CE</asp:ListItem>
                        <asp:ListItem>DF</asp:ListItem>
                        <asp:ListItem>ES</asp:ListItem>
                        <asp:ListItem>GO</asp:ListItem>
                        <asp:ListItem>MA</asp:ListItem>
                        <asp:ListItem>MG</asp:ListItem>
                        <asp:ListItem>MS</asp:ListItem>
                        <asp:ListItem>MT</asp:ListItem>
                        <asp:ListItem>PA</asp:ListItem>
                        <asp:ListItem>PB</asp:ListItem>
                        <asp:ListItem>PE</asp:ListItem>
                        <asp:ListItem>PI</asp:ListItem>
                        <asp:ListItem>PR</asp:ListItem>
                        <asp:ListItem>RJ</asp:ListItem>
                        <asp:ListItem>RN</asp:ListItem>
                        <asp:ListItem>RO</asp:ListItem>
                        <asp:ListItem>RR</asp:ListItem>
                        <asp:ListItem>RS</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>SE</asp:ListItem>
                        <asp:ListItem>SP</asp:ListItem>
                        <asp:ListItem>TO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>CEP</td>
                <td>
                    <asp:TextBox ID="tbCEP" runat="server" MaxLength="9" Columns="11"></asp:TextBox>
                </td>
                <td>Telefone</td>
                <td>
                    <asp:TextBox ID="tbTelefone" runat="server" MaxLength="15" Columns="15"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div style="width:600px;margin:0 auto;">
            <h3>Cartões Adicionais</h3>
        </div>
        <asp:Table id="tabelaAdicionais" runat="server" BorderWidth="1" style="width:600px;border:1px solid black;margin:0 auto;border-spacing:0;border-collapse:collapse;">
            <asp:TableRow>
                <asp:TableCell>Nome</asp:TableCell>
                <asp:TableCell ColumnSpan="4">
                    <asp:TextBox ID="tbNomeAdicional1" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Dt.Nascimento</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbDtNascimento1" runat="server" MaxLength="10" Columns="10"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>Tipo</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rblQuantidade1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Cônjuge</asp:ListItem>
                        <asp:ListItem>Filho</asp:ListItem>
                        <asp:ListItem>Pai</asp:ListItem>
                        <asp:ListItem>Mãe</asp:ListItem>
                        <asp:ListItem>Outro</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div style="width:600px;margin:0 auto;text-align:right;">
            <asp:HiddenField ID="hfQtdAdicionais" runat="server" Value="1" />
            <asp:Button ID="btnAddCartao" runat="server" Text="(+) Adicionar outro cartão" CommandArgument="1" />
        </div>
        <br />
        <div style="width:600px;margin:0 auto;">
            <asp:Button ID="btnGravar" runat="server" Text="[ Gravar ]" OnClick="btnGravar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="[ Cancelar ]" OnClick="btnCancelar_Click" />
        </div>
    </div>
    </form>
</body>
</html>
