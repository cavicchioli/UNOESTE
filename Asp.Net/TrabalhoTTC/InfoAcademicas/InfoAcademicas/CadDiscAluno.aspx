<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadDiscAluno.aspx.cs" Inherits="InfoAcademicas.CadDiscAluno" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 74px;
        }
        .style3
        {
            width: 43px;
        }
        .style4
        {
            width: 67px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cadatro de Alunos Por Disciplina</h2>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Height="250px" Width="911px">
        <cc1:TabPanel runat="server" HeaderText="Dados" ID="TabPanel1">
            <ContentTemplate><table class="style1"><tr><td class="style2">&nbsp;</td><td class="style3">&nbsp;</td><td class="style4">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="style2"><asp:Label ID="Label1" runat="server" Text="Disciplina:"></asp:Label></td><td class="style3"><asp:DropDownList ID="ddlDisciplina" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="disc_nome" 
                                DataValueField="disc_codigo" Width="397px"></asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                SelectCommand="SELECT * FROM [disciplina] ORDER BY [disc_codigo]"></asp:SqlDataSource></td><td class="style4"><asp:Label ID="Label6" runat="server" Text="Turma:"></asp:Label></td><td><asp:TextBox ID="txtTurma" runat="server" Width="58px"></asp:TextBox></td></tr><tr><td class="style2"><asp:Label ID="Label2" runat="server" Text="Aluno:"></asp:Label></td><td class="style3"><asp:DropDownList ID="ddlAluno" runat="server" DataSourceID="SqlDataSource2" 
                                DataTextField="aluno_nome" DataValueField="aluno_ra" Width="397px"></asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                
                                SelectCommand="SELECT [aluno_ra], [aluno_nome] FROM [aluno] ORDER BY [aluno_ra]"></asp:SqlDataSource></td><td class="style4"><asp:Label ID="Label7" runat="server" Text="Semestre:"></asp:Label></td><td><asp:TextBox ID="txtSemestre" runat="server" Width="58px"></asp:TextBox></td></tr><tr><td class="style2"><asp:Label ID="Label3" runat="server" Text="Notas:"></asp:Label></td><td class="style3">&nbsp;</td><td class="style4">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="style2"><asp:Label ID="Label4" runat="server" Text="1ºB:"></asp:Label></td><td class="style3"><asp:TextBox ID="txtNota1b" runat="server" Width="58px"></asp:TextBox></td><td class="style4">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="style2"><asp:Label ID="Label5" runat="server" Text="2ºB:"></asp:Label></td><td class="style3"><asp:TextBox ID="txtNota2b" runat="server" Width="58px"></asp:TextBox></td><td class="style4">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="style2">&nbsp;</td><td class="style3">&nbsp;</td><td class="style4">&nbsp;</td><td>&nbsp;</td></tr></table><div align="center"><table width="100%"><tr><td width="20%" bgcolor="#435463" ><asp:Button ID="btnSalvar" runat="server" Text="Salvar" BackColor="#435463" 
                                    BorderColor="#435463" BorderStyle="Dotted" ForeColor="#C6CBB2" 
                                    onclick="btnSalvar_Click" /></td><td width="20%" bgcolor="#435463" ><asp:Button ID="btnAlterar" runat="server" Text="Alterar" Enabled="False" 
                                    BackColor="#435463" BorderColor="#435463" BorderStyle="Dotted" 
                                    ForeColor="#C6CBB2" onclick="btnAlterar_Click"/><cc1:ConfirmButtonExtender ID="btnAlterar_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirma a alteração ?" Enabled="True" 
                                    TargetControlID="btnAlterar"></cc1:ConfirmButtonExtender></td><td width="20%" bgcolor="#435463" ><asp:Button ID="btnExcluir" runat="server" Text="Excluir" Enabled="False" 
                                    BackColor="#435463" BorderColor="#435463" BorderStyle="Dotted" 
                                    ForeColor="#C6CBB2" onclick="btnExcluir_Click"/><cc1:ConfirmButtonExtender ID="btnExcluir_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirma a exclusão ?" Enabled="True" TargetControlID="btnExcluir"></cc1:ConfirmButtonExtender></td><td width="20%" bgcolor="#435463" ><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" BackColor="#435463" 
                                    BorderColor="#435463" BorderStyle="Dotted" ForeColor="#C6CBB2" 
                                    onclick="btnCancelar_Click"/></td></tr></table></div></ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Pesquisa">
            <HeaderTemplate>Pesquisa</HeaderTemplate>
            <ContentTemplate><asp:Label ID="Label10" runat="server" Text="Descrição:"></asp:Label><asp:TextBox ID="txtPesquisa" runat="server" Width="389px"></asp:TextBox><asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
                    onclick="btnPesquisar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" Text="Por:"></asp:Label>&nbsp;&nbsp; <asp:RadioButton ID="rdbPorDisciplina" runat="server" Text="Disciplina" /><asp:RadioButton ID="rdbPorAluno" runat="server" Text="Aluno" /><asp:GridView ID="gdwDiscAluno" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="901px" 
                    AllowPaging="True" PageSize="5" 
                    onpageindexchanging="gdwDiscAluno_PageIndexChanging" 
                    onselectedindexchanged="gdwDiscAluno_SelectedIndexChanged"><AlternatingRowStyle BackColor="White" ForeColor="#284775" /><Columns><asp:CommandField ButtonType="Button" ShowSelectButton="True" /><asp:BoundField DataField="disc_nome" HeaderText="Disciplina" 
                            ApplyFormatInEditMode="True"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField HeaderText="Aluno" DataField="aluno_nome"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="discAluno_nota1b" HeaderText="1ºB"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="discAluno_nota2b" HeaderText="2ºB"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="discAluno_min2b" HeaderText="Min. 2ºB"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="discAluno_exame" HeaderText="Exame"><HeaderStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField></Columns><EditRowStyle BackColor="#999999" /><FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#F7F6F3" ForeColor="#333333" /><SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" /><SortedAscendingCellStyle BackColor="#E9E7E2" /><SortedAscendingHeaderStyle BackColor="#506C8C" /><SortedDescendingCellStyle BackColor="#FFFDF8" /><SortedDescendingHeaderStyle BackColor="#6F8DAE" /></asp:GridView></ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>
