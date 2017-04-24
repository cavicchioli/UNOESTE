<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administracao.aspx.cs" Inherits="WebFarmacia2013.Admionistracao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" 
    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
    ForeColor="#666666" StaticSubMenuIndent="10px">
    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#E3EAEB" />
    <DynamicSelectedStyle BackColor="#1C5E55" />
    <Items>
        <asp:MenuItem Text="Cadastros" Value="Cadastros">
            <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Laboratórios" 
                Value="Laboratórios"></asp:MenuItem>
            <asp:MenuItem Text="Medicamentos" Value="Medicamentos"></asp:MenuItem>
            <asp:MenuItem Text="Apresentação" Value="Apresentação"></asp:MenuItem>
            <asp:MenuItem Text="Produtos" Value="Produtos"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Pedidos" Value="Pedidos"></asp:MenuItem>
    </Items>
    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>
</asp:Content>
