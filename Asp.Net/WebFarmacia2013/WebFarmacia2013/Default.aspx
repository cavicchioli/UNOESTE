<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFarmacia2013.Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            color: #000099;
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td width=70%>
                <asp:TextBox ID="txtPesquisa" runat="server" Height="16px" Columns="60"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtPesquisa_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtPesquisa" 
                    WatermarkText="Digite o nome do produto">
                </cc1:TextBoxWatermarkExtender>
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
                    onclick="btnPesquisar_Click" />

                <br />
                <asp:GridView ID="gdvProdutos" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Vertical" PageSize="6" Width="100%" 
                    onselectedindexchanged="gdvProdutos_SelectedIndexChanged" 
                    onpageindexchanging="gdvProdutos_PageIndexChanging" 
                    onsorting="gdvProdutos_Sorting">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" SelectText="Selecione" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" 
                            SortExpression="DESCRICAO">
                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Preco" HeaderText="Preço" DataFormatString="{0:c}">
                        <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Estoque" HeaderText="Estoque">
                        <ItemStyle Width="7%" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("FOTO") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FOTO") %>' />
                            </ItemTemplate>
                            <ControlStyle Height="40px" Width="40px" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </td>
            <td width="30%">
                <asp:Panel ID="Panel2" runat="server" Height="367px" Width="200px">
                    <strong>
                    <asp:ImageButton ID="imgCarrinho" runat="server" CssClass="style2" 
                        ImageUrl="~/Imagens/MostrarCompras.gif" onclick="imgCarrinho_Click" />
                    <br class="style2" />
                    <asp:Label ID="Label3" runat="server" CssClass="style2" 
                        Text="Detalhes do produto:"></asp:Label>
                    <br class="style2" />
                    <asp:Label ID="lblLaboratorio" runat="server" CssClass="style2" 
                        Text="Laboratorio:"></asp:Label>
                    <br class="style2" />
                    <asp:Label ID="lblMedicamento" runat="server" CssClass="style2" 
                        Text="Medicamento:"></asp:Label>
                    <br class="style2" />
                    <asp:Label ID="lblPreco" runat="server" CssClass="style2" Text="Preço:"></asp:Label>
                    <br class="style2" />
                    <asp:Label ID="Label4" runat="server" CssClass="style2" Text="Quantidade:"></asp:Label>
                    <asp:TextBox ID="txtQtd" runat="server" CssClass="style2" Height="23px" 
                        Width="18px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtQtd_FilteredTextBoxExtender" runat="server" 
                        Enabled="True" TargetControlID="txtQtd" ValidChars="0123456789">
                    </cc1:FilteredTextBoxExtender>
                    <br class="style2" />
                    <asp:Image ID="Image2" runat="server" CssClass="style2" Height="133px" 
                        Width="154px" />
                    <br class="style2" />
                    <asp:ImageButton ID="imgComprar" runat="server" CssClass="style2" 
                        ImageUrl="~/Imagens/CarrinhoComprar.gif" onclick="imgComprar_Click" />
                    <br />
                    </strong>
                    <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblCodLab" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="lblCodMed" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblCodApr" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblPreco2" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEstoque" runat="server" Visible="False"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
