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
    /*VICTOR HUGO CAVICHIOLLI PRADO RA: 0261030370*/

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
            //ttbCodigo.Text = "";
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Mostrar_Dados(); //metodo
        }

        protected void Mostrar_Dados()
        {
            
            if (ttbCodigo.Text == "")
            {
                return;
            }
            int iLinhas = objVeiculos.RecuperarDados(Convert.ToInt32(ttbCodigo.Text));
                if (iLinhas > 0)
                {
                    ttbAno.Text = objVeiculos.Ano.ToString();//ano
                    ttbCor.Text = objVeiculos.Cor;//cor
                    ttbData.Text = string.Format("{0:dd/MM/yyyy}", objVeiculos.DataCompra);//data da compra
                    ttbCodigo.Text = objVeiculos.Codigo.ToString();
                    ddlMarca.SelectedIndex = objVeiculos.Marca-1;
                    ddlCategoria.SelectedIndex = objVeiculos.Categoria-1;
                    ddlTipo.SelectedIndex = objVeiculos.Tipo-1;


                    ttbModelo.Text = objVeiculos.Modelo;//modelo
                    ttbObservacao.Text = objVeiculos.Observacao;//observação
                    ttbPlaca.Text = objVeiculos.Placa;//placa
                    ttbPreco.Text = string.Format("{0:c}", objVeiculos.Preco);//preço
                    ttbProprietario.Text = objVeiculos.Proprietario;//proprietario

                    imgCarro.ImageUrl = objVeiculos.Foto;//imagem

                    Habilitar("A");
                }
                else
                {
                    Inicializar();
                    Habilitar("N");
                    objVeiculos.MostraMensagem("CARRO NÃO CADASTRADO!", Page);
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
            Limpar_Campos();
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            objVeiculos.Codigo = objVeiculos.ProximoCodigo();
            PreparaDados();
            iLinhas = objVeiculos.Incluir();
            if (iLinhas == 0)
            {
                objVeiculos.MostraMensagem("PROBLEMAS COM O CADASTRO!", Page);
            }
            else
            {
                objVeiculos.MostraMensagem("CADASTRO EFETUADO COM SUCESSO!", Page);
                ttbCodigo.Text = objVeiculos.Codigo.ToString();
            }
        }

        protected void PreparaDados()
        {
            objVeiculos.Categoria = ddlCategoria.SelectedIndex+1;//seleciona a categoria 
            objVeiculos.Marca = ddlMarca.SelectedIndex+1;//seleciona a marca
            objVeiculos.Tipo = ddlTipo.SelectedIndex+1;//seleciona o tipo
            objVeiculos.Modelo = ttbModelo.Text;//modelo
            objVeiculos.Proprietario = ttbProprietario.Text;//proprietario 
            objVeiculos.Placa = ttbPlaca.Text;//placa
            objVeiculos.Cor = ttbCor.Text;//cor
            objVeiculos.Observacao = ttbObservacao.Text;//observação
            objVeiculos.Ano = Convert.ToInt32(ttbAno.Text);//ano

            if (ttbPreco.Text != "")
            {
                sPreco = ttbPreco.Text.Replace(".", "");
                sPreco = sPreco.Replace("R$", "");
                objVeiculos.Preco = Convert.ToDecimal(sPreco);//preço
            }
            else
            {
                objVeiculos.Preco = 0;
            }

            if (ttbData.Text != "")
            {
                string sData = ttbData.Text.Substring(3, 2) + "/" +
                               ttbData.Text.Substring(0, 2) + "/" +
                               ttbData.Text.Substring(6, 4);
                objVeiculos.DataCompra = sData;
            }
            else
            {
                objVeiculos.DataCompra = null;
            }

            //prepara o nome da foto
            string sNomeFoto = string.Format("{0:D5}",
                                objVeiculos.Codigo) + ".jpg";
            imgCarro.ImageUrl = "~/Imagens/Carros/" + sNomeFoto;
            objVeiculos.Foto = imgCarro.ImageUrl;

            //guarda a foto no servidor
            string sCaminho = Server.MapPath("Imagens\\Carros") + "\\";
                flUpload.SaveAs(sCaminho + sNomeFoto);

                //Limpar_Campos();
                Habilitar("N");

            }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            PreparaDados();
            iLinhas = objVeiculos.AlterarCarros(Convert.ToInt32(ttbCodigo.Text));
            if (iLinhas == 0)
            {
                objVeiculos.MostraMensagem("PROBLEMAS COM A ALTERAÇÃO!", Page);
            }
            else
            {
                objVeiculos.MostraMensagem("CADASTRO ALTERADO COM SUCESSO!", Page);
                Limpar_Campos();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int iLinhas = 0;
            iLinhas = objVeiculos.Excluir(Convert.ToInt32(ttbCodigo.Text));

            if (iLinhas == 0)
            {
                objVeiculos.MostraMensagem("PROBLEMAS COM A EXCLUSÃO!", Page);
            }
            else
            {
                objVeiculos.MostraMensagem("EXCLUIDO COM SUCESSO!", Page);
                    Limpar_Campos();
                    Habilitar("N");
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

        protected void gdvVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //coloca o código selecionado na tela
            ttbCodigo.Text = gdvVeiculos.SelectedRow.Cells[1].Text;
            //volta para a aba dados
            TabContainer1.ActiveTabIndex = 0;

            Mostrar_Dados(); 
        }

        protected void gdvVeiculos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvVeiculos.PageIndex = e.NewPageIndex;
            Popular_GridView(); 
        }
    }
 

}