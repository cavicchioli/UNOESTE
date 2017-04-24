using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace carPlace
{
    public partial class cadastro : System.Web.UI.Page
    {
        //declaração do banco de dados
        int iLinhas = 0;
        clsVeiculos objVeiculos = new clsVeiculos();
        string sDataCompra = "";
        string sPreco = "0";

        //o cursor fica posicionado no campo codigo
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == true)
            {
                Session["post"] = "S";
            }
            else
            {
                Inicializar();
                ttbCodigo.Focus();
            }
        }


        protected void Inicializar()
        {   
            //Campos cadastro
            ttbAno.Enabled = false;
            ttbCodigo.Enabled = false;
            ttbCor.Enabled = false;
            ttbData.Enabled = false;
            ttbModelo.Enabled = false;
            ttbObservacao.Enabled = false;
            ttbPlaca.Enabled = false;
            ttbPreco.Enabled = false;
            ttbProprietario.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlMarca.Enabled = false;
            ddlTipo.Enabled = false;
            flUpload.Enabled = false;


            //Botoes
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEnvia.Enabled = false;
            btnExcluir.Enabled = false;
            btnIncluir.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = false;

            Habilitar("N");
             

        }

        protected void Habilitar(string acao) // I,A, N,V
        {
            //Campos cadastro
            ttbAno.Enabled = "IA".IndexOf(acao) >= 0;
            ttbCodigo.Enabled = "IA".IndexOf(acao) >= 0;
            ttbCor.Enabled = "IA".IndexOf(acao) >= 0;
            ttbData.Enabled = "IA".IndexOf(acao) >= 0;
            ttbModelo.Enabled = "IA".IndexOf(acao) >= 0;
            ttbObservacao.Enabled = "IA".IndexOf(acao) >= 0;
            ttbPlaca.Enabled = "IA".IndexOf(acao) >= 0;
            ttbPreco.Enabled = "IA".IndexOf(acao) >= 0;
            ttbProprietario.Enabled = "IA".IndexOf(acao) >= 0;
            ddlCategoria.Enabled = "IA".IndexOf(acao) >= 0;
            ddlMarca.Enabled = "IA".IndexOf(acao) >= 0;
            ddlTipo.Enabled = "IA".IndexOf(acao) >= 0;
            flUpload.Enabled = "IA".IndexOf(acao) >= 0;

            btnPesquisar.Enabled = acao == "N";
            ttbCodigo.Enabled = acao == "N";
            btnNovo.Enabled = acao == "N";
            btnAlterar.Enabled = acao == "A";
            btnExcluir.Enabled = acao == "A";
            btnIncluir.Enabled = "I".IndexOf(acao) >= 0;
            btnCancelar.Enabled = "IA".IndexOf(acao) >= 0;
            btnEnvia.Enabled = "IA".IndexOf(acao) >= 0;
          
        }

        //Limpar Campos - método
        protected void Limpar_Campos()
        {
            ddlCategoria.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            ddlTipo.SelectedIndex = 0;
            ttbAno.Text = "";
            ttbCor.Text = "";
            ttbData.Text = "";
            ttbModelo.Text = "";
            ttbObservacao.Text = "";
            ttbPlaca.Text = "";
            ttbPreco.Text = "";
            ttbProprietario.Text = "";
            imgCarro.ImageUrl = "";
            ttbCodigo.Text = "";
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Mostrar_Dados(); //metodo
        }

        protected void Mostrar_Dados()
        {
            bool bRetorno = false;
            if (ttbCodigo.Text != "")
            {
                int codigo = Convert.ToInt32(ttbCodigo.Text);
                bRetorno = objVeiculos.RecuperarDados(codigo);//pega o codigo

                if (bRetorno == true)//se for verdadeiro
                {

                    ttbAno.Text = objVeiculos.Ano.ToString();//ano
                    ttbCor.Text = objVeiculos.Cor.ToString();//cor
                    ttbData.Text = objVeiculos.DataCompra.ToString();//data da compra
                    ttbCodigo.Text = codigo.ToString();
                    ddlMarca.SelectedIndex = objVeiculos.Marca-1;
                    ddlCategoria.SelectedIndex = objVeiculos.Categoria-1;
                    ddlTipo.SelectedIndex = objVeiculos.Tipo-1;


                    ttbModelo.Text = objVeiculos.Modelo.ToString();//modelo
                    ttbObservacao.Text = objVeiculos.Observacao.ToString();//observação
                    ttbPlaca.Text = objVeiculos.Placa.ToString();//placa
                    //ttbPreco.Text = objVeiculos.Preco.ToString();//preço
                    ttbPreco.Text = string.Format("{0:c}", objVeiculos.Preco);//preço
                    ttbProprietario.Text = objVeiculos.Proprietario.ToString();//proprietario

                    imgCarro.ImageUrl = objVeiculos.Foto.ToString();//imagem

                    Habilitar("A");
                }
                else
                {
                    Inicializar();
                    Habilitar("N");
                    objVeiculos.MostraMensagem("CARRO NÃO CADASTRADO!", Page);
                }
            }
        }

        protected void btnEnvia_Click(object sender, EventArgs e)
        {
            string sCaminho = "", sNomeFoto = "";
            Int32 iCodigo = Convert.ToInt32(ttbCodigo.Text);

            if (flUpload.HasFile)
            {
                sCaminho = Server.MapPath("\\carros\\" + ttbCodigo.Text + ".jpg");
                flUpload.SaveAs(sCaminho);

                //miniatura da foto
                int iLargura, iAltura;
                System.Drawing.Image miniatura =
                    System.Drawing.Image.FromFile(sCaminho);

                iLargura = Convert.ToInt32(miniatura.Width * 0.2);
                iAltura = Convert.ToInt32(miniatura.Height * 0.2);

                miniatura =
                    miniatura.GetThumbnailImage(iLargura, iAltura,
                    new System.Drawing.Image.GetThumbnailImageAbort(Retorno),
                    IntPtr.Zero);

                sNomeFoto = string.Format("{0:D5}", iCodigo) + "mini.jpg";
                flUpload.SaveAs(sCaminho + sNomeFoto);
                imgCarro.ImageUrl = "~/carros/" + sNomeFoto;
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Habilitar("I");
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            Int32 iCodigo = objVeiculos.ProximoCodigo();


            objVeiculos.Categoria = ddlCategoria.SelectedIndex+1;//seleciona a categoria 
            objVeiculos.Marca = ddlMarca.SelectedIndex+1;//seleciona a marca
            objVeiculos.Tipo = ddlTipo.SelectedIndex+1;//seleciona o tipo
            objVeiculos.Modelo = ttbModelo.Text;//modelo
            objVeiculos.Ano = Convert.ToInt32(ttbAno.Text);//ano
            objVeiculos.Preco = Convert.ToDecimal(ttbPreco.Text);//preço
            objVeiculos.Proprietario = ttbProprietario.Text;//proprietario
            objVeiculos.Placa = ttbPlaca.Text;//placa
            objVeiculos.Cor = ttbCor.Text;//cor
            objVeiculos.Observacao = ttbObservacao.Text;//observação
            objVeiculos.DataCompra = ttbData.Text;//veiculo
            objVeiculos.Codigo = iCodigo;

            objVeiculos.Foto = "";
            int iLinhas = objVeiculos.Incluir();
            if (iLinhas == 0)
            {
                //se escolheu uma foto
                if (flUpload.HasFile == true)
                {
                    Envia_Foto();//metodo enviar foto

                    //caminho das fotos
                    objVeiculos.Foto = "\\carros\\" +
                            string.Format("{0:D5}", ttbCodigo.Text) + ".jpg";
                    // objVeiculos.Alterar(objVeiculos.Codigo);
                }
                objVeiculos.MostraMensagem("PROBLEMAS COM O CADASTRO!", Page);
            }
            else
            {
                ttbCodigo.Text = Convert.ToString(iCodigo);
                objVeiculos.MostraMensagem("CADASTRO EFETUADO COM SUCESSO!", Page);
                Limpar_Campos();
                Habilitar("N");

            }

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            //string sFoto = "carros\\"+ txtCodigo.Text  ;

            Trata_Preco_Data(); //metodo

            objVeiculos.Categoria = ddlCategoria.SelectedIndex+1;//categoria
            objVeiculos.Marca = ddlMarca.SelectedIndex+1;//marca
            objVeiculos.Tipo = ddlTipo.SelectedIndex+1;//tipo
            objVeiculos.Modelo = ttbModelo.Text;////modelo
            objVeiculos.Ano = Convert.ToInt32(ttbAno.Text); //ano do veiculo
            objVeiculos.Preco = Convert.ToDecimal(sPreco);//preco
            objVeiculos.Proprietario = ttbProprietario.Text;//propietario
            objVeiculos.Placa = ttbPlaca.Text;//placa
            objVeiculos.Cor = ttbCor.Text;//cor
            objVeiculos.Observacao = ttbObservacao.Text;//observação
            objVeiculos.DataCompra = ttbData.Text;//data da compra


            //se escolheu uma foto
            if (flUpload.HasFile == true)
            {
                Envia_Foto();
                objVeiculos.Foto = "\\carros\\" +
                        string.Format("{0:D5}", ttbCodigo.Text) + ".jpg";
            }

            iLinhas = objVeiculos.AlterarCarros(Convert.ToInt32(ttbCodigo.Text));
            //verifica
            if (iLinhas > 0)
            {
                objVeiculos.MostraMensagem("CADASTRO ALTERADO COM SUCESSO!", Page);
                Limpar_Campos();
            }
            else
            {
                objVeiculos.MostraMensagem("PROBLEMAS COM A ALTERAÇÃO!", Page);
            }

            btnAlterar.Enabled = false;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ttbCodigo.Text != "")
            {
                objVeiculos.Codigo = Convert.ToInt32(ttbCodigo.Text);
                iLinhas = objVeiculos.Excluir(Convert.ToInt32(ttbCodigo.Text));
                if (iLinhas > 0)
                {
                    objVeiculos.MostraMensagem("EXCLUIDO COM SUCESSO!", Page);
                    Limpar_Campos();
                    Habilitar("N");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar_Campos();
            Habilitar("N");
        }

        //metodo de enviar foto  ---igual do professor 
        protected void Envia_Foto()
        {
            string sCaminho, sNomeFoto;
            Int32 iCodigo = Convert.ToInt32(ttbCodigo.Text);

            sNomeFoto = string.Format("{0:D5}", iCodigo) + ".jpg";
            sCaminho = Server.MapPath("carros") + "\\";

            flUpload.SaveAs(sCaminho + sNomeFoto);
            imgCarro.ImageUrl = "~/carros/" + sNomeFoto;
        }

        //tratar do preço e data da compra
        protected void Trata_Preco_Data()
        {
            if (ttbPreco.Text != "")
            {
                sPreco = ttbPreco.Text.Replace(",", ".");
                sPreco = sPreco.Replace("R$", "");
            }

            //data no SQL segue o padrão MM/DD/YYYY
            if (ttbData.Text != "")
            {
                sDataCompra = ttbData.Text.Substring(3, 2) + "/" +
                              ttbData.Text.Substring(0, 2) + "/" +
                              ttbData.Text.Substring(6, 4);

                sDataCompra = ttbData.Text.Substring(0, 10);
            }
        }

        protected bool Retorno()
        {
            return false;
        }

        //popular a grid
        protected void Popular_GridView()
        {
            //DataTable dsVeiculos = new DataTable();
            DataSet dsVeiculos = new DataSet();
            string sOrdem = "";

            if (Session["ORDEM"] != null)
            {
                sOrdem = Session["ORDEM"].ToString();
            }

            dsVeiculos = objVeiculos.RetornaVeiculos(ttbPesquisa2.Text, sOrdem, (ddlPesquisa.SelectedIndex).ToString());
            gdvVeiculos.DataSource = dsVeiculos;
            gdvVeiculos.DataBind();

          


        }

        //botão pesquisar   - chama o popular         
        protected void btnPesquisar2_Click(object sender, EventArgs e)
        {
            Popular_GridView();
        }

        //ordem
        protected void gdvVeiculos_Sorting(object sender, GridViewSortEventArgs e)
        {
            //ORDEM ==> CODIGO, NOME, CIDADE, SALARIO
            //DIRECAO ==> ASC OU DESC
            if (Session["ORDEM"] != null)
            {
                if (Session["DIRECAO"] != null)
                {
                    if (Session["DIRECAO"] == "A")
                    {
                        Session["DIRECAO"] = "D";
                        e.SortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        Session["DIRECAO"] = "A";
                        e.SortDirection = SortDirection.Ascending;
                    }
                }
                else//se não escolheu a direção ainda assumir ASC
                {
                    Session["DIRECAO"] = "A";
                    e.SortDirection = SortDirection.Ascending;
                }
            }
            //verifica a coluna do grid que foi escolhida para o sort
            switch (e.SortExpression.ToString())
            {
                case "Marca":
                    Session["ORDEM"] = "ORDER BY MARCA";
                    break;
                case "Modelo":
                    Session["ORDEM"] = "ORDER BY MODELO";
                    break;
                case "Ano":
                    Session["ORDEM"] = "ORDER BY ANO";
                    break;
                case "Preco":
                    Session["ORDEM"] = "ORDER BY PRECO";
                    break;
            }

            if (Session["DIRECAO"] == "A")
            {
                Session["ORDEM"] = Session["ORDEM"] + " ASC";
            }
            else
            {
                Session["ORDEM"] = Session["ORDEM"] + " DESC";
            }

            Popular_GridView();
        }

        //igual do professor
        protected void gdvVeiculos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvVeiculos.PageIndex = e.NewPageIndex;
            Popular_GridView();

        }

        protected void gdvVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //obtem o código da linha selecionada
            ttbCodigo.Text = gdvVeiculos.SelectedRow.Cells[1].Text;
            //volta para a aba clientes
            TabContainer1.ActiveTabIndex = 0;

            Mostrar_Dados();
        }
   
    }
 

}