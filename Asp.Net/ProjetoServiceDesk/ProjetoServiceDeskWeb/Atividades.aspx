<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="Atividades.aspx.cs" Inherits="ProjetoServiceDeskWeb.Atividades" %>
<%@ Register src="ucSolicitante.ascx" tagname="ucSolicitante" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Formulario" runat="server" style="width:850px;" GroupingText="<b>Atividades</b>" ClientIDMode="Static">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:CheckBox ID="cbFiltrar" runat="server" Text="Visualizar apenas suas atividades" AutoPostBack="True" Checked="True" />
                <br />
                <asp:Panel ID="pnlNova" runat="server" GroupingText="[ Nova ]">
                    Descrição:<br />
                    <asp:TextBox ID="txtDescricao" runat="server" Width="100%"></asp:TextBox>
                    <br />
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td>Solicitante:<br />
                                <asp:DropDownList ID="ddlSolicitante" runat="server">
                                </asp:DropDownList>
                                &nbsp;<asp:ImageButton ID="btnNovoSolicitante" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Imagens/novo.png" Width="24px" OnClick="btnNovoSolicitante_Click" ToolTip="Adicionar Solicitante" />
                            </td>
                            <td>Data Início:<br />
                                <asp:TextBox ID="txtDataInicio" runat="server"></asp:TextBox>
                            </td>
                            <td>Data Final:<br />
                                <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
                            </td>
                            <td>Status:<br />
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" Width="110px" OnClick="btnGravar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="110px" OnClick="btnCancelar_Click" />
                </asp:Panel>
                &nbsp;<asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Panel ID="pnlSolicitante" runat="server" GroupingText="[ Novo Solicitante ]" Visible="False">
                    <uc1:ucSolicitante ID="ucSol" runat="server" />
                    <br />
                    <asp:Button ID="btnGravarSolicitante" runat="server" OnClick="btnGravarSolicitante_Click" Text="Gravar" Width="100px" />
                    <asp:Button ID="btnCancelarSolicitante" runat="server" OnClick="btnCancelarSolicitante_Click" Text="Cancelar" Width="100px" />
                    &nbsp;<asp:Label ID="lblMensagemSolicitante" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>
                <br />
                <asp:GridView ID="gvAtividades" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataKeyNames="Codigo" OnRowCommand="gvAtividades_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="ID" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                        <asp:BoundField DataField="DataInicio" HeaderText="Início" />
                        <asp:BoundField DataField="DataFim" HeaderText="Final" />
                        <asp:BoundField DataField="Status.Descricao" HeaderText="Situação" />
                        <asp:BoundField DataField="Solicitante.Nome" HeaderText="Solicitante" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Finalizar" CommandArgument='<%# Eval("Codigo") %>' ImageUrl="~/Imagens/check.png" Text="" ToolTip="Finalizar Atividade" />
                            </ItemTemplate>
                            <ControlStyle Width="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="false" CommandName="Editar" CommandArgument='<%# Eval("Codigo") %>' ImageUrl="~/Imagens/editar.png" Text="" ToolTip="Alterar Atividade" />
                            </ItemTemplate>
                            <ControlStyle Width="24px" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Excluir" CommandArgument='<%# Eval("Codigo") %>' ImageUrl="~/Imagens/excluir.png" OnClientClick="return confirm(&quot;Confirma a exclusão desta atividade?&quot;);" Text="" ToolTip="Excluir Atividade" />
                            </ItemTemplate>
                            <ControlStyle Width="24px" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
     </asp:Panel>
</asp:Content>
