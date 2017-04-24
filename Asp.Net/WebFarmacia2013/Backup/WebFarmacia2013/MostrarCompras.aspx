<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MostrarCompras.aspx.cs" Inherits="WebFarmacia2013.MostrarCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Seu carrinho de compras:" 
            style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #000099"></asp:Label>
    </asp:Panel>
    <asp:GridView ID="gdvCarrinho" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Vertical" onrowdatabound="gdvCarrinho_RowDataBound" 
        onselectedindexchanged="gdvCarrinho_SelectedIndexChanged" PageSize="8" 
        ShowFooter="True" 
        style="font-family: Arial, Helvetica, sans-serif; font-size: small" 
        Width="100%">
        <AlternatingRowStyle BackColor="Gainsboro" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Retirar do carrinho" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="Descricao" HeaderText="Produto">
            <ItemStyle HorizontalAlign="Left" Width="65%" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade">
            <ItemStyle HorizontalAlign="Right" Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="PrecoTotal" HeaderText="Total">
            <ItemStyle HorizontalAlign="Right" Width="20%" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#99CCFF" Font-Bold="True" 
            Font-Names="Arial, helvetica, Sans-Serif" Font-Size="Small" 
            ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:ImageButton ID="imgContinuar" runat="server" 
        ImageUrl="~/Imagens/Continuar.gif" onclick="imgContinuar_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="imgFinalizar" runat="server" 
        ImageUrl="~/Imagens/FinalizarPedido.gif" onclick="imgFinalizar_Click" />
    </asp:Content>
