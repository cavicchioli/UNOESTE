<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="MinhasAtividades.aspx.cs" Inherits="ExemploPosWeb.MinhasAtividades" %>
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
            <asp:Panel ID="Formulario" runat="server" ClientIDMode="Static" style="width:850px" GroupingText="<b>Minhas Atividades</b>">

                <asp:Panel ID="pnlFiltros" runat="server" GroupingText="[Opções de Filtro]">
                    <br />
                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                        <tr>
                            <td>Solicitante:<br />
                                <asp:DropDownList ID="ddlSolicitante" runat="server" AutoPostBack="True" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:150px">Status:<br />
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlDetalhes" runat="server" GroupingText="[Detalhes]" Visible="False">
                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                            <tr>
                                <td style="width:150px;font-weight:bold">ID:</td>
                                <td>
                                    <asp:Label ID="lblID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Descrição:</td>
                                <td>
                                    <asp:Label ID="lblDescricao" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Início:</td>
                                <td>
                                    <asp:Label ID="lblInicio" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Término:</td>
                                <td>
                                    <asp:Label ID="lblTermino" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Status:</td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Solicitante:</td>
                                <td>
                                    <asp:Label ID="lblSolicitante" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px;font-weight:bold;vertical-align:top">Classificação(ões):</td>
                                <td>
                                    <asp:Label ID="lblClassificacao" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="100px" OnClick="btnExcluir_Click" OnClientClick="return confirm(&quot;Deseja excluir?&quot;);" />
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Width="100px" />
                    </asp:Panel>
                </asp:Panel>
                <asp:GridView ID="gvAtividades" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvAtividades_RowDataBound" OnSelectedIndexChanged="gvAtividades_SelectedIndexChanged" DataKeyNames="Codigo">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataInicio" HeaderText="Início">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataFim" HeaderText="Término">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Solicitante" HeaderText="Solicitante">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="[+]Detalhes" ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#FFFF66" Font-Bold="True" ForeColor="Black" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>

                <br />
                Página:
                <asp:LinkButton ID="lbAnterior" runat="server" OnClick="lbAnterior_Click">&lt;&lt; Anterior</asp:LinkButton>
                <asp:DropDownList ID="ddlPagina" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPagina_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:LinkButton ID="lbProxima" runat="server" OnClick="lbProxima_Click">Próxima &gt;&gt;</asp:LinkButton>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
