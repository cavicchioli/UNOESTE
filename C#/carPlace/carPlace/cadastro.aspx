<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="carPlace.cadastro" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 230px;
        }
        .style3
        {
            width: 145px;
        }
        .style4
        {
            width: 145px;
            height: 22px;
        }
        .style5
        {
            height: 22px;
        }
        .style7
        {
            height: 22px;
            width: 260px;
        }
        .style9
        {
            width: 145px;
            height: 2px;
        }
        .style10
        {
            width: 260px;
            height: 2px;
        }
        .style11
        {
            height: 2px;
        }
        .style14
        {
            width: 319px;
        }
        .style15
        {
            height: 22px;
            width: 319px;
        }
        .style16
        {
            height: 2px;
            width: 319px;
        }
        .style18
        {
            width: 260px;
        }
        .style19
        {
            width: 100%;
        }
        .style22
        {
            width: 239px;
        }
        .style24
        {
            width: 154px;
            height: 14px;
        }
        .style25
        {
            width: 551px;
            height: 14px;
        }
        .style26
        {
            height: 14px;
        }
        .style27
        {
            width: 551px;
        }
        .style28
        {
            width: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>

                <link rel="stylesheet" href="css/style.css"> <!--Your Styles-->
				<link rel="stylesheet" href="css/responsive.css">

                <div class="content conteiner-hv1">
                        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                            Height="617px" Width="1012px" Font-Bold="True">
                            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>
<strong>Cadastros</strong> 
</HeaderTemplate>
<ContentTemplate>
<table class="style1">
    <tr>
        <td class="style3">
            Código:</td>
        <td class="style18">
            <asp:TextBox ID="ttbCodigo" runat="server" Height="25px" Width="80px"></asp:TextBox>

            <asp:Button ID="btnPesquisar" runat="server" Font-Bold="True" Height="28px" 
                Text="Pesquisar Veículo" Width="141px" onclick="btnPesquisar_Click"></asp:Button>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Categoria:</td>
        <td class="style18">
            <asp:DropDownList ID="ddlCategoria" runat="server" Height="25px" Width="137px"><asp:ListItem>AUTOMÓVEL</asp:ListItem>
<asp:ListItem>MOTO</asp:ListItem>
<asp:ListItem>CAMINHÃO</asp:ListItem>
</asp:DropDownList>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Tipo:</td>
        <td class="style18">
            <asp:DropDownList ID="ddlTipo" runat="server" Height="25px" Width="137px"><asp:ListItem>NOVO</asp:ListItem>
<asp:ListItem>USADO</asp:ListItem>
</asp:DropDownList>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Marca:</td>
        <td class="style18">
            <asp:DropDownList ID="ddlMarca" runat="server" Height="25px" Width="137px"><asp:ListItem>ASTON MARTIN</asp:ListItem>
<asp:ListItem>AUDI</asp:ListItem>
<asp:ListItem>BENTLEY</asp:ListItem>
<asp:ListItem>BMW</asp:ListItem>
<asp:ListItem>CHEVROLET</asp:ListItem>
<asp:ListItem>CHRYSLER</asp:ListItem>
<asp:ListItem>CITROEN</asp:ListItem>
<asp:ListItem>DODGE</asp:ListItem>
<asp:ListItem>FERRARI</asp:ListItem>
<asp:ListItem>FIAT</asp:ListItem>
<asp:ListItem>FORD</asp:ListItem>
<asp:ListItem>HONDA</asp:ListItem>
<asp:ListItem>HYUNDAI</asp:ListItem>
<asp:ListItem>JAGUAR</asp:ListItem>
<asp:ListItem>JEEP</asp:ListItem>
<asp:ListItem>KIA</asp:ListItem>
<asp:ListItem>LAMBORGHINI</asp:ListItem>
<asp:ListItem>LAND ROVER</asp:ListItem>
<asp:ListItem>MASERATI</asp:ListItem>
<asp:ListItem>MERCEDES-BENZ</asp:ListItem>
<asp:ListItem>MINI</asp:ListItem>
<asp:ListItem>MITSUBISHI</asp:ListItem>
<asp:ListItem>NISSAN</asp:ListItem>
<asp:ListItem>PEUGEOT</asp:ListItem>
<asp:ListItem>PORSCHE</asp:ListItem>
<asp:ListItem>RENAULT</asp:ListItem>
<asp:ListItem>SUBARU</asp:ListItem>
<asp:ListItem>SUZUKI</asp:ListItem>
<asp:ListItem>TOYOTA</asp:ListItem>
<asp:ListItem>TROLLER</asp:ListItem>
<asp:ListItem>VOLKSWAGEN</asp:ListItem>
<asp:ListItem>VOLVO</asp:ListItem>
</asp:DropDownList>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Modelo:</td>
        <td class="style18">
            <asp:TextBox ID="ttbModelo" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style14">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="ttbModelo" ErrorMessage="Preencha o MODELO" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style4">
            Ano:</td>
        <td class="style7">
            <asp:TextBox ID="ttbAno" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style15">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="ttbAno" ErrorMessage="Preencha o ANO" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td class="style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Preço</td>
        <td class="style18">
            <asp:TextBox ID="ttbPreco" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style14">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="ttbPreco" ErrorMessage="Preença o PREÇO" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Proprietário</td>
        <td class="style18">
            <asp:TextBox ID="ttbProprietario" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style14">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="ttbProprietario" ErrorMessage="Preencha o PROPRIETARIO" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Placa:</td>
        <td class="style18">
            <asp:TextBox ID="ttbPlaca" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style14">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="ttbPlaca" ErrorMessage="Preencha a PLACA" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Cor:</td>
        <td class="style18">
            <asp:TextBox ID="ttbCor" runat="server" Height="25px" Width="160px"></asp:TextBox>

        </td>
        <td class="style14">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="ttbCor" ErrorMessage="Preencha a COR" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Observações:</td>
        <td class="style18">
            <asp:TextBox ID="ttbObservacao" runat="server" Height="78px" Width="228px" 
                TextMode="MultiLine"></asp:TextBox>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            Data de Compra:</td>
        <td class="style10">
            <asp:TextBox ID="ttbData" runat="server" Height="25px" Width="160px"></asp:TextBox>

            <cc1:CalendarExtender ID="ttbData_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="ttbData"></cc1:CalendarExtender>

        </td>
        <td class="style16">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="ttbData" ErrorMessage="Preencha a DATA DE COMPRA" 
                ValidationGroup="SALVAR"></asp:RequiredFieldValidator>
        </td>
        <td class="style11">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            Foto:</td>
        <td class="style18">
            <asp:FileUpload ID="flUpload" runat="server" Height="25px" Width="160px"></asp:FileUpload>

        </td>
        <td class="style14">
            <asp:Image ID="imgCarro" runat="server" Height="100px" Width="114px"></asp:Image>

        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            &nbsp;</td>
        <td class="style18">
            <asp:Button ID="btnEnvia" runat="server" Font-Bold="True" Height="27px" 
                Text="Enviar Foto" Width="93px" onclick="btnEnvia_Click"></asp:Button>

        </td>
        <td class="style14">
            &nbsp;</td>
        <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                  
                </td>
    </tr>
</table>
<p align="center">
    <asp:Button ID="btnNovo" runat="server" Font-Bold="True" 
        Height="47px" Text="Novo" Width="80px" onclick="btnNovo_Click" />
    <asp:Button ID="btnIncluir" runat="server" Font-Bold="True" 
        Height="47px" Text="Incluir" Width="80px" onclick="btnIncluir_Click" />
    <asp:Button ID="btnAlterar" runat="server" Font-Bold="True" 
        Height="47px" Text="Alterar" Width="80px" onclick="btnAlterar_Click" />
    <asp:Button ID="btnExcluir" runat="server" Font-Bold="True" 
        Height="47px" Text="Excluir" Width="80px" onclick="btnExcluir_Click"  />
    <asp:Button ID="btnCancelar" runat="server" Font-Bold="True" 
        Height="47px" Text="Cancelar" Width="80px" onclick="btnCancelar_Click"/>
</p>
</ContentTemplate>
</cc1:TabPanel>
                            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>
<strong>Consultas</strong>
</HeaderTemplate>
                                <ContentTemplate>
                                    <table class="style19">
                                        <tr>
                                            <td class="style28">
                                                Selecione a</td>
                                            <td class="style27">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style24">
                                                categoria:</td>
                                            <td class="style25">
                                                </td>
                                            <td class="style26">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style28">
                                                <asp:DropDownList ID="ddlPesquisa" runat="server" Height="25px" Width="137px">
                                                    <asp:ListItem>CODIGO</asp:ListItem>
                                                    <asp:ListItem>MARCA</asp:ListItem>
                                                    <asp:ListItem>MODELO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style27">
                                                <asp:TextBox ID="ttbPesquisa2" runat="server" Height="25px" Width="524px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnPesquisar2" runat="server" Height="33px" 
                                                    OnClick="btnPesquisar2_Click" Text="Pesquisar" Width="212px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="gdvVeiculos" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                        CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="374px" 
                                        onpageindexchanging="gdvVeiculos_PageIndexChanging" 
                                        OnSelectedIndexChanged="gdvVeiculos_SelectedIndexChanged" 
                                        onsorting="gdvVeiculos_Sorting" Width="793px">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" Text="Selecione" />
                                            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                            <asp:BoundField ApplyFormatInEditMode="True" DataField="Preco" 
                                                HeaderText="Preco" />
                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                            <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
                                            <asp:BoundField DataField="Ano" HeaderText="Ano" />
                                            <asp:TemplateField HeaderText="Foto" SortExpression="Foto">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="Gray" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>
                                </ContentTemplate>
</cc1:TabPanel>
                        </cc1:TabContainer>
                  
                </div>
</html>
</asp:Content>
