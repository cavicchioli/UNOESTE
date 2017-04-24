namespace Copa2014.Apresentacao
{
    partial class fConsulta
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
            this.dtTimePdata2 = new System.Windows.Forms.DateTimePicker();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.dtTimePdata = new System.Windows.Forms.DateTimePicker();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblInicial = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.mtbLocaliza = new System.Windows.Forms.MaskedTextBox();
            this.grpBotoes = new System.Windows.Forms.GroupBox();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.dgvLocaliza = new System.Windows.Forms.DataGridView();
            this.tbLocaliza = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.grpBox.SuspendLayout();
            this.grpBotoes.SuspendLayout();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).BeginInit();
            this.SuspendLayout();
            // 
            // dtTimePdata2
            // 
            this.dtTimePdata2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTimePdata2.Location = new System.Drawing.Point(230, 63);
            this.dtTimePdata2.Name = "dtTimePdata2";
            this.dtTimePdata2.Size = new System.Drawing.Size(100, 20);
            this.dtTimePdata2.TabIndex = 53;
            this.dtTimePdata2.Value = new System.DateTime(2008, 11, 18, 0, 0, 0, 0);
            // 
            // cmbBox
            // 
            this.cmbBox.FormattingEnabled = true;
            this.cmbBox.Location = new System.Drawing.Point(6, 19);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(146, 21);
            this.cmbBox.TabIndex = 0;
            this.cmbBox.SelectedIndexChanged += new System.EventHandler(this.cmbBox_SelectedIndexChanged);
            this.cmbBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBox_KeyPress);
            // 
            // dtTimePdata
            // 
            this.dtTimePdata.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTimePdata.Location = new System.Drawing.Point(71, 63);
            this.dtTimePdata.Name = "dtTimePdata";
            this.dtTimePdata.Size = new System.Drawing.Size(100, 20);
            this.dtTimePdata.TabIndex = 52;
            this.dtTimePdata.Value = new System.DateTime(2008, 11, 18, 0, 0, 0, 0);
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(174, 67);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(58, 13);
            this.lblFinal.TabIndex = 56;
            this.lblFinal.Text = "Data Final:";
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Location = new System.Drawing.Point(9, 67);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(63, 13);
            this.lblInicial.TabIndex = 57;
            this.lblInicial.Text = "Data Inicial:";
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.cmbBox);
            this.grpBox.Location = new System.Drawing.Point(9, 9);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(162, 48);
            this.grpBox.TabIndex = 49;
            this.grpBox.TabStop = false;
            this.grpBox.Text = " Localiza por: ";
            // 
            // mtbLocaliza
            // 
            this.mtbLocaliza.Location = new System.Drawing.Point(9, 63);
            this.mtbLocaliza.Mask = "0000000000";
            this.mtbLocaliza.Name = "mtbLocaliza";
            this.mtbLocaliza.Size = new System.Drawing.Size(100, 20);
            this.mtbLocaliza.TabIndex = 50;
            this.mtbLocaliza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbLocaliza_KeyDown);
            // 
            // grpBotoes
            // 
            this.grpBotoes.Controls.Add(this.btnSair);
            this.grpBotoes.Controls.Add(this.btnLocalizar);
            this.grpBotoes.Location = new System.Drawing.Point(331, 4);
            this.grpBotoes.Name = "grpBotoes";
            this.grpBotoes.Size = new System.Drawing.Size(149, 79);
            this.grpBotoes.TabIndex = 54;
            this.grpBotoes.TabStop = false;
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.dgvLocaliza);
            this.grpDados.Location = new System.Drawing.Point(4, 88);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(476, 251);
            this.grpDados.TabIndex = 55;
            this.grpDados.TabStop = false;
            // 
            // dgvLocaliza
            // 
            this.dgvLocaliza.AllowUserToAddRows = false;
            this.dgvLocaliza.AllowUserToDeleteRows = false;
            this.dgvLocaliza.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvLocaliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocaliza.Location = new System.Drawing.Point(6, 19);
            this.dgvLocaliza.MultiSelect = false;
            this.dgvLocaliza.Name = "dgvLocaliza";
            this.dgvLocaliza.ReadOnly = true;
            this.dgvLocaliza.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLocaliza.Size = new System.Drawing.Size(460, 225);
            this.dgvLocaliza.TabIndex = 0;
            this.dgvLocaliza.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocaliza_CellMouseClick);
            // 
            // tbLocaliza
            // 
            this.tbLocaliza.Location = new System.Drawing.Point(8, 63);
            this.tbLocaliza.MaxLength = 40;
            this.tbLocaliza.Name = "tbLocaliza";
            this.tbLocaliza.Size = new System.Drawing.Size(257, 20);
            this.tbLocaliza.TabIndex = 51;
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Image = global::Copa2014.Properties.Resources.Exit;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSair.Location = new System.Drawing.Point(78, 10);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 58);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizar.Image = global::Copa2014.Properties.Resources.Loading;
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocalizar.Location = new System.Drawing.Point(6, 10);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(65, 58);
            this.btnLocalizar.TabIndex = 7;
            this.btnLocalizar.Text = "&Localizar";
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // fConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 344);
            this.Controls.Add(this.dtTimePdata2);
            this.Controls.Add(this.dtTimePdata);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.lblInicial);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.mtbLocaliza);
            this.Controls.Add(this.grpBotoes);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.tbLocaliza);
            this.Name = "fConsulta";
            this.Text = "fConsulta";
            this.Shown += new System.EventHandler(this.fConsulta_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fConsulta_KeyDown);
            this.grpBox.ResumeLayout(false);
            this.grpBotoes.ResumeLayout(false);
            this.grpDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtTimePdata2;
        private System.Windows.Forms.ComboBox cmbBox;
        private System.Windows.Forms.DateTimePicker dtTimePdata;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.MaskedTextBox mtbLocaliza;
        private System.Windows.Forms.GroupBox grpBotoes;
        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.DataGridView dgvLocaliza;
        private System.Windows.Forms.TextBox tbLocaliza;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnLocalizar;
    }
}