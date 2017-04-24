using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace carPlace
{
    public class clsVeiculos: clsBancoSQL 
    {

    private Int32 categoria;
    private Int32 tipo;
    private Int32 ano;
    private Int32 codigo;
    private decimal preco;
    private String proprietario;
    private String placa;
    private String cor;
    private String observacao;
    private String dataCompra;
    private String foto;
    private Int32 marca;
    private String modelo;
    
        //categoria
    public Int32 Categoria
    {
         get { return categoria; }
         set { categoria = value; }
    }

        //tipo   
    public Int32 Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

        //ano
    public Int32 Ano
    {
        get { return ano; }
        set { ano = value; }
    }

        //preco
    public decimal Preco
    {
        get { return preco; }
        set { preco = value; }
    }

        //proprietario
    public String Proprietario
    {
        get { return proprietario; }
        set { proprietario = value; }
    }

        //placa
   public String Placa
   {
       get { return placa; }
       set { placa = value; }
   }

        //cor
   public String Cor
   {
       get { return cor; }
       set { cor = value; }
   }

        //observação
   public String Observacao
   {
       get { return observacao; }
       set { observacao = value; }
   }

        //data da compra
   public String DataCompra
   {
       get { return dataCompra; }
       set { dataCompra = value; }
   }

        //foto
   public String Foto
  {
    get { return foto; }
    set { foto = value; }
  }

        //codigo
   public Int32 Codigo
 {
   get { return codigo; }
   set { codigo = value; }
 }
   public Int32 Marca
   {
       get { return marca; }
       set { marca = value; }
   }

   public String Modelo
   {
       get { return modelo; }
       set { modelo = value; }
   }

//incluir veiculos 
   public int Incluir()
   {
       int iLinhas = 0;
       String sSQL = "";


       sSQL = "INSERT INTO VEICULO (CODIGO, CATEGORIA, MARCA, TIPO, MODELO, ANO, PRECO, PROPRIETARIO, PLACA, COR, OBSERVACOES, DATAAQUISICAO, FOTO) VALUES(";
       sSQL = sSQL + codigo + ",";
       sSQL = sSQL + "'" + categoria + "',";
       sSQL = sSQL + "'" + marca + "',";
       sSQL = sSQL + "'" + tipo + "',";
       sSQL = sSQL + "'" + modelo + "',";
       sSQL = sSQL + "'" + ano + "',";
       sSQL = sSQL + preco.ToString().Replace(",", ".") + ",";
       sSQL = sSQL + "'" + proprietario + "',";
       sSQL = sSQL + "'" + placa + "',";
       sSQL = sSQL + "'" + cor + "',";
       sSQL = sSQL + "'" + observacao + "',";
       sSQL = sSQL + "'" + dataCompra + "',";
       sSQL = sSQL + "'" + foto + "')";
       iLinhas = ExecutarSQL(sSQL);

       return iLinhas;
   }

        //proximo codigo
        public Int32 ProximoCodigo()
        {
            SqlDataReader drReader;
            String sSQL = "";

            sSQL = "SELECT COALESCE(MAX(CODIGO),0) AS ULTIMO FROM VEICULO ";
            drReader = ExecutarDataReader(sSQL);
            if (drReader.HasRows)
            {
                drReader.Read();
                codigo = Convert.ToInt32(drReader["ULTIMO"]) + 1;
            }
            drReader.Close();
            DesconectaBanco();

            return codigo;
        }

        //alterar dados
        public int AlterarCarros(Int32 iCodigo)
        {
            int iLinhas = 0;
            String sSQL = "";

            sSQL = "UPDATE VEICULO SET CATEGORIA ='" + categoria + "'," ;
            sSQL = sSQL + " MARCA ='" + marca + "',";
            sSQL = sSQL + " TIPO ='" + tipo + "',";
            sSQL = sSQL + " MODELO ='" + modelo + "',";
            sSQL = sSQL + " ANO ='" + ano + "',";
            sSQL = sSQL + " PRECO =" + preco.ToString().Replace(",", ".") + ",";
            sSQL = sSQL + " PROPRIETARIO ='" + proprietario + "',";
            sSQL = sSQL + " PLACA ='" + placa + "',";
            sSQL = sSQL + " COR ='" + cor+ "',";
            sSQL = sSQL + " OBSERVACOES ='" + observacao + "',";
            sSQL = sSQL + " DATAAQUISICAO ='" + dataCompra + "',";
            sSQL = sSQL + " FOTO='" + foto + "'";
            sSQL = sSQL + " WHERE CODIGO = " + iCodigo;
            iLinhas = ExecutarSQL(sSQL);

            return iLinhas;
        }

        //excluir dados
        public int Excluir (Int32 iCodigo)
        {
            int iLinhas =0;
            String sSQL = "";

            sSQL = "DELETE FROM VEICULO WHERE CODIGO =" + iCodigo;
            iLinhas = ExecutarSQL (sSQL);

            return iLinhas;
        }

        //recuperar dados cadastrados
        public int RecuperarDados(Int32 iCodigo) 
        {
            int iLinhas = 0;
            DataTable dtVeiculos = new DataTable();
            String sSQL = "SELECT * FROM VEICULO WHERE CODIGO = " + iCodigo;
            dtVeiculos = RetornaDT(sSQL);

            if (dtVeiculos.Rows.Count > 0)
            {
                codigo = Convert.ToInt32(dtVeiculos.Rows[0]["CODIGO"]);
                categoria = Convert.ToInt32(dtVeiculos.Rows[0]["CATEGORIA"]);
                marca = Convert.ToInt32(dtVeiculos.Rows[0]["MARCA"]);
                tipo = Convert.ToInt32(dtVeiculos.Rows[0]["TIPO"]);
                modelo = Convert.ToString(dtVeiculos.Rows[0]["MODELO"]);
                ano = Convert.ToInt32(dtVeiculos.Rows[0]["ANO"]);
                preco = Convert.ToDecimal(dtVeiculos.Rows[0]["PRECO"]);
                proprietario = Convert.ToString(dtVeiculos.Rows[0]["PROPRIETARIO"]);
                placa = Convert.ToString(dtVeiculos.Rows[0]["PLACA"]);
                cor = Convert.ToString(dtVeiculos.Rows[0]["COR"]);
                observacao = Convert.ToString(dtVeiculos.Rows[0]["OBSERVACOES"]);
                dataCompra = Convert.ToString(dtVeiculos.Rows[0]["DATAAQUISICAO"]);
                foto = Convert.ToString(dtVeiculos.Rows[0]["FOTO"]);
                iLinhas = dtVeiculos.Rows.Count;
            }
            return iLinhas;
        }

        public DataSet RetornaVeiculos(string sParametro, string sOrdem, string sCriterio)
        {
            //DataTable dsVeiculos = new DataTable();
            DataSet dsVeiculos = new DataSet();

            string SQL = "select v.codigo, v.modelo, mar.descricao, v.ano, v.preco, v.foto ";
            SQL += "from veiculo v ";
            SQL += "inner join marca mar on v.marca = mar.codigo ";
            SQL += "where ";

            if (sCriterio == "0")
            {
                SQL += "v.codigo = " + sParametro;
            }
            else
                if (sCriterio == "1")
                {
                    SQL += "v.ano =" + sParametro;
                }
                else
                    if (sCriterio == "2")
                    {
                        SQL += "mar.descricao LIKE '%" + sParametro + "%'";
                    }
                    else
                        {
                            SQL += "v.modelo LIKE '%" + sParametro + "%'";
                        }
                        dsVeiculos = RetornaDS(SQL);
                        return dsVeiculos;
        }
    }
}