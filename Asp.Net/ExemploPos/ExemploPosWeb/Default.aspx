<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExemploPosWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Formulario" runat="server" style="width:500px;" GroupingText="<b>Autenticação do Usuário</b>" ClientIDMode="Static">
            <br />
            Usuário:<br />
            <asp:TextBox ID="txtUsuario" runat="server" style="width:100%"></asp:TextBox>
            <br />
            Senha:<br />
            <asp:TextBox ID="txtSenha" runat="server" style="width:100%" TextMode="Password"></asp:TextBox>
            <br />
            <asp:CheckBox ID="cbLembrar" runat="server" Text="Lembrar meu usuário e senha" />
            <br />
            <br />
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" Width="120px" OnClick="btnEntrar_Click" />
            &nbsp;<asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </asp:Panel>
</asp:Content>
