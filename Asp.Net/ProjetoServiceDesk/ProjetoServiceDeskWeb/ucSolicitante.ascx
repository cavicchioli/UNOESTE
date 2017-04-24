<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSolicitante.ascx.cs" Inherits="ProjetoServiceDeskWeb.ucSolicitante" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

    E-Mail:<br />
    <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td style="width: 80%">Nome:<br />
                <asp:TextBox ID="txtNome" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 20%">Telefone:<br />
                <asp:TextBox ID="txtTelefone" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
    Observação:<br />
    <asp:TextBox ID="txtObservacao" runat="server" Rows="3" TextMode="MultiLine" Width="100%"></asp:TextBox>

