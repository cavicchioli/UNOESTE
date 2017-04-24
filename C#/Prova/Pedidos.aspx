<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Prova.Pedidos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style1
        {
            width: 100%;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: small;
            color: #000099;
            width: 22px;
        }
        .style8
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            color: #000099;
        }
        .style7
        {
            font-size: small;
            color: #000099;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong>
    <asp:GridView ID="gdvProdutos" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="style3" 
        GridLines="Vertical" PageSize="5" Width="100%" 
            onpageindexchanging="gdvProdutos_PageIndexChanging" 
            onselectedindexchanged="gdvProdutos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Selecionar" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="descricao" HeaderText="Descrição">
            <ItemStyle Width="50%" />
            </asp:BoundField>
            <asp:BoundField DataField="Preco" HeaderText="Preço">
            <ItemStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Estoque" HeaderText="Estoque">
            <ItemStyle Width="20%" />
            </asp:BoundField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Foto") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Foto") %>' />
                </ItemTemplate>
                <ControlStyle Height="50px" Width="50px" />
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
        </strong>
    
    </div>
    <br />
    <table border="1" class="style1">
        <tr>
            <td class="style6" width="15%">
                <strong>
                <asp:Label ID="Label1" runat="server" CssClass="style8" Text="Código"></asp:Label>
                </strong>
            </td>
            <td width="55%">
                <strong>
                <asp:Label ID="Label2" runat="server" CssClass="style8" Text="Descrição"></asp:Label>
                </strong>
            </td>
            <td width="10%">
                <strong>
                <asp:Label ID="Label3" runat="server" CssClass="style8" Text="Preço"></asp:Label>
                </strong>
            </td>
            <td width="10%">
                <strong>
                <asp:Label ID="Label4" runat="server" CssClass="style8" Text="Qtde."></asp:Label>
                </strong>
            </td>
            <td class="style7" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" width="15%">
                <asp:Label ID="lblCodigo" runat="server" CssClass="style7">Código</asp:Label>
            </td>
            <td class="style5" width="55%">
                <asp:Label ID="lblDescricao" runat="server" CssClass="style7">Descrição</asp:Label>
            </td>
            <td class="style5" width="10%">
                <asp:Label ID="lblPreco" runat="server" CssClass="style7">Preço</asp:Label>
            </td>
            <td class="style2" width="10%">
                <asp:TextBox ID="txtQtd" runat="server" Columns="1" CssClass="style6"></asp:TextBox>
            </td>
            <td class="style2" width="10%">
                <asp:Button ID="btnIncluir" runat="server" CssClass="style6" Text="+" 
                    onclick="btnIncluir_Click" />
            </td>
        </tr>
    </table>
    <br />




    <asp:GridView ID="gdvPedidos" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" 
        style="font-family: Arial, Helvetica, sans-serif; font-size: small" 
        Width="100%" AllowPaging="True" 
        onpageindexchanging="gdvPedidos_PageIndexChanging" 
        onselectedindexchanged="gdvPedidos_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Retirar do carrinho" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="NUMPEDIDO" HeaderText="Pedido nº" />
            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
            <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade" />
            <asp:BoundField DataField="VALORTOTAL" HeaderText="Valor total" />
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
    </form>
</body>
</html>
