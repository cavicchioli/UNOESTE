<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FecharPedido.aspx.cs" Inherits="WebFarmacia2013.FecharPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Small" Text="C.P.F.:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCPF" runat="server" Font-Names="Arial" Font-Size="Small"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Small" Text="Senha:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSEnha" runat="server" Font-Bold="True" Font-Names="Arial" 
                    Font-Size="Small"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Font-Bold="True" 
                    Text="Pesquisar" />
            </td>
        </tr>
    </table>
</asp:Content>
