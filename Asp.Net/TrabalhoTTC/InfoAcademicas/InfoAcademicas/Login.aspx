<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InfoAcademicas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" runat="server" FailureText="Login ou Senha Inválido!" 
        LoginButtonText="Acessar" PasswordLabelText="Senha:" 
        PasswordRequiredErrorMessage="Senha é Requerida!" UserNameLabelText="Usuário:" 
        UserNameRequiredErrorMessage="Usuário é Requerido!">
    </asp:Login>
</asp:Content>
