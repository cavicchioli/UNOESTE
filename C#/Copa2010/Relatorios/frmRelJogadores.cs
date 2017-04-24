using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Copa2010.CamadaLogica;

namespace Copa2010.Relatorios
{
    public partial class frmRelJogadores : Form
    {
        private BancoDados dados = new BancoDados();
        CrystalDecisions.Shared.ConnectionInfo conexaoCrystal;
        
        public frmRelJogadores()
        {
            InitializeComponent();

            dados.PreencherCbo_Union(cbEquipe, "equipes", "equ_codigo", "equ_nome", "Todas");
            cbEquipe.SelectedValue = 0;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //Objeto com informações de conexão para as tabelas do rpt
            conexaoCrystal = new CrystalDecisions.Shared.ConnectionInfo();
            conexaoCrystal.ServerName = @"(local)\SQLEXPRESS";
            conexaoCrystal.UserID = "sa";
            conexaoCrystal.Password = "a12345z";
            conexaoCrystal.DatabaseName = "Copa2010";

            //Carregar o arquivo do rpt pArquivo
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report.Load(Application.StartupPath + @"..\..\..\Relatorios\relJogadores.rpt");

            //Alimenta os parametros
            ParameterField pEquipe;
            pEquipe = report.ParameterFields["pEquipe"];

            try
            {
                if (cbEquipe.SelectedValue.ToString().Trim() != "0")
                {
                    pEquipe.CurrentValues.AddValue(cbEquipe.GetItemText(cbEquipe.SelectedItem));
                }
                else
                {
                    pEquipe.CurrentValues.AddValue("");
                }
                
            }
            catch (Exception ex)
            {
                Console.Write("Erro: " + ex.Message.ToString());
            }

            //Informe o rpt com as informações de conexão
            CrystalDecisions.Shared.TableLogOnInfo logonInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            logonInfo.ConnectionInfo = conexaoCrystal;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = conexaoCrystal;
                table.ApplyLogOnInfo(logonInfo);
            }

            //Liga ao Visualizador
            this.crvRelJogadores.ReportSource = report;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
