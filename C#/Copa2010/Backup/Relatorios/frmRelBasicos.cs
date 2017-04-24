using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Copa2010.Relatorios
{
    public partial class frmRelBasicos : Form
    {
        string relArquivo, relTitulo;
        CrystalDecisions.Shared.ConnectionInfo conexaoCrystal;

        public frmRelBasicos(string pArquivo, string pTitulo)
        {
            InitializeComponent();

            relArquivo = pArquivo;
            relTitulo = pTitulo;

            this.Text = pTitulo;

            //Objeto com informações de conexão para as tabelas do rpt
            conexaoCrystal = new CrystalDecisions.Shared.ConnectionInfo();
            conexaoCrystal.ServerName = @"(local)\SQLEXPRESS";
            conexaoCrystal.UserID = "sa";
            conexaoCrystal.Password = "a12345z";
            conexaoCrystal.DatabaseName = "Copa2010";

            //Carregar o arquivo do rpt pArquivo
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report.Load(Application.StartupPath + @"..\..\..\Relatorios\" + relArquivo);

            //Informe o rpt com as informações de conexão
            CrystalDecisions.Shared.TableLogOnInfo logonInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            logonInfo.ConnectionInfo = conexaoCrystal;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                table.LogOnInfo.ConnectionInfo = conexaoCrystal;
                table.ApplyLogOnInfo(logonInfo);
            }

            //Liga ao Visualizador
            crvRel.ReportSource = report;
        }
    }
}
