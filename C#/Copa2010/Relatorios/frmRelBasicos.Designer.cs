namespace Copa2010.Relatorios
{
    partial class frmRelBasicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelBasicos));
            this.crvRel = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRel
            // 
            this.crvRel.ActiveViewIndex = -1;
            this.crvRel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRel.Location = new System.Drawing.Point(0, 0);
            this.crvRel.Name = "crvRel";
            this.crvRel.SelectionFormula = "";
            this.crvRel.Size = new System.Drawing.Size(591, 418);
            this.crvRel.TabIndex = 0;
            this.crvRel.ViewTimeSelectionFormula = "";
            // 
            // frmRelBasicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 418);
            this.Controls.Add(this.crvRel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelBasicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Fases";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRel;


    }
}