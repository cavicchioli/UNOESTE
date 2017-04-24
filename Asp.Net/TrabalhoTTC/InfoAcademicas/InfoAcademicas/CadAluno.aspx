<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadAluno.aspx.cs" Inherits="InfoAcademicas.CadAluno" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 48px;
        }
        .style3
        {
            width: 386px;
        }
        .style4
        {
        }
        .style5
        {
            width: 279px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
        Cadastro de alunos</h2>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="216px" Width="902px">
        <cc1:TabPanel runat="server" HeaderText="Dados" ID="TabPanel1">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style5">
                            <asp:Label ID="Label4" runat="server" Text="Foto:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="375px"></asp:TextBox>
                        </td>
                        <td align="center" class="style5" rowspan="3">
                            <asp:Image ID="imgFoto" runat="server" Width="70px" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label3" runat="server" Text="E-mail:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="375px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style4" colspan="2">
                            <asp:FileUpload ID="FileUpload" runat="server" Width="219px" />
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                                onclick="btnEnviar_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <div align="center">
                <table width="100%">
                        <tr>
                            <td width="20%" bgcolor="#435463" >
                                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" BackColor="#435463" 
                                    BorderColor="#435463" BorderStyle="Dotted" ForeColor="#C6CBB2" 
                                    onclick="btnSalvar_Click"/>
                            </td>
                            <td width="20%" bgcolor="#435463" >
                                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Enabled="False" 
                                    BackColor="#435463" BorderColor="#435463" BorderStyle="Dotted" 
                                    ForeColor="#C6CBB2" onclick="btnAlterar_Click"/>
                                <cc1:ConfirmButtonExtender ID="btnAlterar_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirma a alteração ?" Enabled="True" 
                                    TargetControlID="btnAlterar">
                                </cc1:ConfirmButtonExtender>
                            </td>
                            <td width="20%" bgcolor="#435463" >
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Enabled="False" 
                                    BackColor="#435463" BorderColor="#435463" BorderStyle="Dotted" 
                                    ForeColor="#C6CBB2" onclick="btnExcluir_Click"/>
                                <cc1:ConfirmButtonExtender ID="btnExcluir_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirma a exclusão ?" Enabled="True" TargetControlID="btnExcluir">
                                </cc1:ConfirmButtonExtender>
                            </td>
                            <td width="20%" bgcolor="#435463" >
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#435463" 
                                    BorderColor="#435463" BorderStyle="Dotted" ForeColor="#C6CBB2" 
                                    onclick="btnCancelar_Click"/>
                            </td>
                        </tr>
                    </table>
                    </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Pesquisa">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Informe o Nome:"></asp:Label>
                <asp:TextBox ID="txtPesquisa" runat="server" Width="302px"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
                    onclick="btnPesquisar_Click" />
                <asp:GridView ID="gdwAlunos" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" PageSize="3" Width="875px" 
                    onpageindexchanging="gdwAlunos_PageIndexChanging" 
                    onselectedindexchanged="gdwAlunos_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="aluno_ra" HeaderText="R.A.">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="aluno_nome" HeaderText="Nome">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="aluno_email" HeaderText="E-mail">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Foto">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("aluno_foto") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("aluno_foto") %>' />
                            </ItemTemplate>
                            <ControlStyle Height="50px" Width="40px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Justify" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
</asp:Content>
