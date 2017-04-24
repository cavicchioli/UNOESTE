<%@ Page Language="C#" AutoEventWireup="true" CodeFile="principal.aspx.cs" Inherits="CadastroCartoes.principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Cartões</title>

    <style type="text/css">

        .titulo
        {
             width:900px;
             margin:0 auto;
        }

        .subtitulo
        {
            width:700px;
             margin:0 auto;
        }

        .tabela-titular
        {
            width:900px;
            border:1px solid black;
            margin:0 auto;
            border-spacing:0;
            border-collapse:collapse;
        }

        .tabela-cartoes
        {
            width:700px;
            border:1px solid black;
            margin:0 auto;
            border-spacing:0;
            border-collapse:collapse;
        }

        .btn
        {
            padding-top:5px;
            width:700px;
            margin:0 auto;
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;">
        <div class="titulo">
            <h1>Cadastro de Cartões de Crédito</h1>
            <h3>Titular</h3>
        </div>
        <table border="1" class="tabela-titular">
            <tr>
                <td><strong>CPF:</strong></td>
                <td colspan="3">
                    <asp:TextBox ID="tbCPF" runat="server" MaxLength="11" Columns="15" placeholder="Somente Números"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><strong>Nome:</strong></td>
                <td colspan="3">
                    <asp:TextBox ID="tbNome" runat="server" MaxLength="200" Columns="130"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><strong>Endereço:</strong></td>
                <td colspan="3">
                    <asp:TextBox ID="tbEndereco" runat="server" MaxLength="120"  Columns="130"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><strong>Bairro:</strong></td>
                <td colspan="3">
                    <asp:TextBox ID="tbBairro" runat="server" MaxLength="50" Columns="60"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><strong>Cidade:</strong></td>
                <td>
                    <asp:TextBox ID="tbCidade" runat="server" MaxLength="100" Columns="80"></asp:TextBox>
                </td>
                <td><strong>Estado:</strong></td>
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
                <td><strong>CEP:</strong></td>
                <td>
                    <asp:TextBox ID="tbCEP" runat="server" MaxLength="9" Columns="11"></asp:TextBox>
                </td>
                <td><strong>Telefone:</strong></td>
                <td>
                    <asp:TextBox ID="tbTelefone" runat="server" MaxLength="15" Columns="15"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div class="subtitulo">
            <h3>Cartões Adicionais</h3>
        </div>
        <asp:Table id="tableCartoes" runat="server" CssClass="tabela-cartoes">
            <asp:TableRow>
                <asp:TableCell>Nome</asp:TableCell>
                <asp:TableCell ColumnSpan="4">
                    <asp:TextBox ID="tbNomeAdc" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Dt.Nascimento</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbDtNascAdc" runat="server" MaxLength="10" Columns="10"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>Tipo</asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rblParentescoAdc" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Cônjuge</asp:ListItem>
                        <asp:ListItem>Filho</asp:ListItem>
                        <asp:ListItem>Pai</asp:ListItem>
                        <asp:ListItem>Mãe</asp:ListItem>
                        <asp:ListItem>Outro</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div class="btn" style="text-align:right">
            <asp:Button ID="btnAdd" runat="server" Text="(+) Adicionar outro cartão" />
            <asp:HiddenField ID="hfQtd" runat="server" Value="1" />
        </div>
        <br />
        <div class="btn">
            <asp:Button ID="btnGravar" runat="server" Text="[ Gravar ]" OnClick="btnGravar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="[ Cancelar ]" OnClick="btnCancelar_Click" />
        </div>
        <br />
        <br />
        <div class="relatorio">
            <asp:Label ID="lbValores" runat="server" Text="" />
        </div>
    </div>
    </form>
</body>
</html>
