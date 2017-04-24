namespace Copa2014.Apresentacao
{
    partial class fConsultaFases
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
            this.tbLocaliza = new System.Windows.Forms.TextBox();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.dgvLocaliza = new System.Windows.Forms.DataGridView();
            this.grpBotoes = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).BeginInit();
            this.grpBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLocaliza
            // 
            this.tbLocaliza.Location = new System.Drawing.Point(15, 60);
            this.tbLocaliza.MaxLength = 40;
            this.tbLocaliza.Name = "tbLocaliza";
            this.tbLocaliza.Size = new System.Drawing.Size(313, 20);
            this.tbLocaliza.TabIndex = 2;
            this.tbLocaliza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLocaliza_KeyDown);
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.dgvLocaliza);
            this.grpDados.Location = new System.Drawing.Point(7, 86);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(476, 251);
            this.grpDados.TabIndex = 5;
            this.grpDados.TabStop = false;
            // 
            // dgvLocaliza
            // 
            this.dgvLocaliza.AllowUserToAddRows = false;
            this.dgvLocaliza.AllowUserToDeleteRows = false;
            this.dgvLocaliza.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvLocaliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocaliza.Location = new System.Drawing.Point(8, 16);
            this.dgvLocaliza.MultiSelect = false;
            this.dgvLocaliza.Name = "dgvLocaliza";
            this.dgvLocaliza.ReadOnly = true;
            this.dgvLocaliza.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLocaliza.Size = new System.Drawing.Size(460, 225);
            this.dgvLocaliza.TabIndex = 0;
            this.dgvLocaliza.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocaliza_CellDoubleClick);
            // 
            // grpBotoes
            // 
            this.grpBotoes.Controls.Add(this.btnSair);
            this.grpBotoes.Controls.Add(this.btnLocalizar);
            this.grpBotoes.Location = new System.Drawing.Point(334, 2);
            this.grpBotoes.Name = "grpBotoes";
            this.grpBotoes.Size = new System.Drawing.Size(149, 79);
            this.grpBotoes.TabIndex = 4;
            this.grpBotoes.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Image = global::Copa2014.Properties.Resources.Exit;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSair.Location = new System.Drawing.Point(77, 15);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 58);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalizar.Image = global::Copa2014.Properties.Resources.Loading;
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocalizar.Location = new System.Drawing.Point(6, 15);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(65, 58);
            this.btnLocalizar.TabIndex = 0;
            this.btnLocalizar.Text = "&Localizar";
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // fConsultaFases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 342);
            this.Controls.Add(this.grpBotoes);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.tbLocaliza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fConsultaFases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localiza Fases";
            this.grpDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).EndInit();
            this.grpBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLocaliza;
        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.DataGridView dgvLocaliza;
        private System.Windows.Forms.GroupBox grpBotoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnLocalizar;
    }
}