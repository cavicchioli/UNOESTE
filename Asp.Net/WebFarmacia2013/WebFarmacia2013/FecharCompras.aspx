<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FecharCompras.aspx.cs" Inherits="WebFarmacia2013.FecharCompras" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            color: #003399;
        }
        .style3
        {
            width: 319px;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            color: #000099;
        }
        .style5
        {
            width: 319px;
            font-weight: bold;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            color: #000099;
        }
        .style7
        {
            color: #003399;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="style2" Text="C.P.F.:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCPF" runat="server" CssClass="style2"></asp:TextBox>
                <cc1:MaskedEditExtender ID="txtCPF_MaskedEditExtender" runat="server" 
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                    Mask="999-999-999-99" TargetControlID="txtCPF">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="style2" Text="Senha:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="style2" TextMode="Password"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtSenha_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtSenha" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnPesquisar" runat="server" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: small; font-weight: 700" 
                    Text="Pesquisar" CssClass="style7" onclick="btnPesquisar_Click" />
            </td>
        </tr>
    </table>
    <br />


    <table class="style1">
        <tr>
            <td class="style5">
                <asp:Label ID="Label5" runat="server" CssClass="style4" Text="Nome:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtNome" runat="server" Columns="50" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label6" runat="server" CssClass="style4" Text="Endereço:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtEndereco" runat="server" Columns="50" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label7" runat="server" CssClass="style4" Text="Bairro:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtBairro" runat="server" Columns="50" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label8" runat="server" CssClass="style4" Text="Cidade:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtCidade" runat="server" Columns="50" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label9" runat="server" CssClass="style4" Text="Estado:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtEstado" runat="server" Columns="2" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label10" runat="server" CssClass="style4" Text="C.E.P.:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtCEP" runat="server" Columns="10" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label11" runat="server" CssClass="style4" Text="R.G."></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtRG" runat="server" Columns="15" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label12" runat="server" CssClass="style4" Text="Telefone:"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtFone" runat="server" Columns="15" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label13" runat="server" CssClass="style4" Text="Celular"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtCelular" runat="server" Columns="15" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label14" runat="server" CssClass="style4" Text="Email"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtEmail" runat="server" Columns="60" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label15" runat="server" CssClass="style4" 
                    Text="Data de nascimento"></asp:Label>
            </td>
            <td align=left>
                <asp:TextBox ID="txtNascimento" runat="server" Columns="10" CssClass="style6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="btnAtualizar" runat="server" CssClass="style6" 
                    Text="Atualizar dados" Enabled="False" onclick="btnAtualizar_Click" />
            </td>
            <td align=left>
                <asp:Button ID="btnReenviar" runat="server" CssClass="style6" 
                    Text="Reenviar senha" Enabled="False" onclick="btnReenviar_Click" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnFechar" runat="server" Enabled="False" 
        onclick="btnFechar_Click" 
        style="font-family: Arial, Helvetica, sans-serif; font-weight: 700; font-size: small; color: #000099" 
        Text="Fechar pedido" />
    <br />


</asp:Content>
