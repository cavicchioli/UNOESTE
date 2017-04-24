<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFarmacia2013.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <asp:Login ID="Login1" runat="server" FailureText="Login inválido." 
        LoginButtonText="Acesso ao sistema" onauthenticate="Login1_Authenticate" 
        PasswordLabelText="Senha:" PasswordRequiredErrorMessage="A senha é obrigatória" 
        RememberMeText="Lembre-me no próximo acesso" TitleText="Área restrita" 
        UserNameLabelText="Usuário:" 
        UserNameRequiredErrorMessage="Usuário é orbigatório">
    </asp:Login>
    <br />
</p>
<p>
</p>
</asp:Content>
