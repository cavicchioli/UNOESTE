<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="NovaAtividade.aspx.cs" Inherits="ExemploPosWeb.NovaAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Formulario" runat="server" ClientIDMode="Static" style="width:750px" GroupingText="<b>Nova Atividade</b>">
                <br />
                Descrição:<br />
                <asp:TextBox ID="txtDescricao" runat="server" MaxLength="255" Rows="3" TextMode="MultiLine" Width="100%"></asp:TextBox>
                <table cellpadding="0" cellspacing="0" class="auto-style1">
                    <tr>
                        <td>Data/Hora Início:<br />
                            <asp:TextBox ID="txtDtInicio" runat="server" Columns="10" MaxLength="10"></asp:TextBox>
                            &nbsp;<asp:DropDownList ID="ddlHoraInicial" runat="server">
                            </asp:DropDownList>
                            :<asp:DropDownList ID="ddlMinutoInicial" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>Data/Hora Término:<br />
                            <asp:TextBox ID="txtDtTermino" runat="server" Columns="10" MaxLength="10"></asp:TextBox>
                            &nbsp;<asp:DropDownList ID="ddlHoraFinal" runat="server">
                            </asp:DropDownList>
                            :<asp:DropDownList ID="ddlMinutoFinal" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>Status:<br />
                            <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Descricao" DataValueField="Codigo">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                Solicitante: [ <asp:LinkButton ID="lbNovo" runat="server" OnClick="lbNovo_Click">Novo</asp:LinkButton>
                ]<asp:Panel ID="pnlNovoSolicitante" runat="server" GroupingText="[Dados do novo solicitante]" Visible="False">
                    <br />
                    E-Mail:<br />
                    <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                    <br />
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td style="width="100%">Nome:<br />
                                <asp:TextBox ID="txtNomeSolicitante" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:150px">Telefone:<br />
                                <asp:TextBox ID="txtTelefoneSolicitante" runat="server" MaxLength="20" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    Observações:<br />
                    <asp:TextBox ID="txtObservacoesSolicitante" runat="server" MaxLength="255" Rows="2" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnGravarSolicitante" runat="server" Text="Gravar" Width="100px" OnClick="btnGravarSolicitante_Click" />
                    <asp:Button ID="btnCancelarSolicitante" runat="server" Text="Cancelar" Width="100px" OnClick="btnCancelarSolicitante_Click" />
                    &nbsp;</asp:Panel>
                <br />
                <asp:DropDownList ID="ddlSolicitante" runat="server" Width="100%">
                </asp:DropDownList>
                <br />
                Classificação(ões) da Atividade:<br />&nbsp;&nbsp;<asp:DropDownList ID="ddlClassificacao" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
                <asp:GridView ID="gvClassificacoes" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="500px" OnRowDeleting="gvClassificacoes_RowDeleting">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nome" HeaderText="Classificação">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField DeleteText="Remover" ShowDeleteButton="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
                <br />
                <asp:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar" Width="100px" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
