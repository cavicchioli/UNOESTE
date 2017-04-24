namespace Copa2010.CamadaApresentacao
{
    partial class frmConsultaPadrao
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
            this.mtbLocaliza = new System.Windows.Forms.MaskedTextBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.dtTimePdata = new System.Windows.Forms.DateTimePicker();
            this.dtTimePdata2 = new System.Windows.Forms.DateTimePicker();
            this.lblInicial = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).BeginInit();
            this.grpBotoes.SuspendLayout();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLocaliza
            // 
            this.tbLocaliza.Location = new System.Drawing.Point(11, 61);
            this.tbLocaliza.MaxLength = 40;
            this.tbLocaliza.Name = "tbLocaliza";
            this.tbLocaliza.Size = new System.Drawing.Size(257, 20);
            this.tbLocaliza.TabIndex = 2;
            this.tbLocaliza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
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
            this.dgvLocaliza.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtaGridView_CellDoubleClick);
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
            this.btnSair.Image = global::Copa2010.Properties.Resources.Exit;
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
            this.btnLocalizar.Image = global::Copa2010.Properties.Resources.Loading;
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
            // mtbLocaliza
            // 
            this.mtbLocaliza.Location = new System.Drawing.Point(12, 61);
            this.mtbLocaliza.Mask = "0000000000";
            this.mtbLocaliza.Name = "mtbLocaliza";
            this.mtbLocaliza.Size = new System.Drawing.Size(100, 20);
            this.mtbLocaliza.TabIndex = 1;
            this.mtbLocaliza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.cmbBox);
            this.grpBox.Location = new System.Drawing.Point(12, 7);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(162, 48);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = " Localiza por: ";
            // 
            // cmbBox
            // 
            this.cmbBox.FormattingEnabled = true;
            this.cmbBox.Location = new System.Drawing.Point(8, 17);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(146, 21);
            this.cmbBox.TabIndex = 0;
            this.cmbBox.SelectedIndexChanged += new System.EventHandler(this.cmbBox_SelectedIndexChanged);
            this.cmbBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBox_KeyPress);
            // 
            // dtTimePdata
            // 
            this.dtTimePdata.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTimePdata.Location = new System.Drawing.Point(74, 61);
            this.dtTimePdata.Name = "dtTimePdata";
            this.dtTimePdata.Size = new System.Drawing.Size(100, 20);
            this.dtTimePdata.TabIndex = 3;
            this.dtTimePdata.Value = new System.DateTime(2008, 11, 18, 0, 0, 0, 0);
            this.dtTimePdata.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            // 
            // dtTimePdata2
            // 
            this.dtTimePdata2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTimePdata2.Location = new System.Drawing.Point(233, 61);
            this.dtTimePdata2.Name = "dtTimePdata2";
            this.dtTimePdata2.Size = new System.Drawing.Size(100, 20);
            this.dtTimePdata2.TabIndex = 4;
            this.dtTimePdata2.Value = new System.DateTime(2008, 11, 18, 0, 0, 0, 0);
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Location = new System.Drawing.Point(12, 65);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(63, 13);
            this.lblInicial.TabIndex = 48;
            this.lblInicial.Text = "Data Inicial:";
            // 
            // lblFinal
            // 
            this.lblFinal.AutoSize = true;
            this.lblFinal.Location = new System.Drawing.Point(177, 65);
            this.lblFinal.Name = "lblFinal";
            this.lblFinal.Size = new System.Drawing.Size(58, 13);
            this.lblFinal.TabIndex = 48;
            this.lblFinal.Text = "Data Final:";
            // 
            // frmConsultaPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 342);
            this.Controls.Add(this.dtTimePdata2);
            this.Controls.Add(this.dtTimePdata);
            this.Controls.Add(this.lblFinal);
            this.Controls.Add(this.lblInicial);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.mtbLocaliza);
            this.Controls.Add(this.grpBotoes);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.tbLocaliza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaPadrao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localiza";
            this.Shown += new System.EventHandler(this.frmConsulta_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaPadrao_KeyDown);
            this.grpDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocaliza)).EndInit();
            this.grpBotoes.ResumeLayout(false);
            this.grpBox.ResumeLayout(false);
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
        private System.Windows.Forms.MaskedTextBox mtbLocaliza;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.ComboBox cmbBox;
        private System.Windows.Forms.DateTimePicker dtTimePdata;
        private System.Windows.Forms.DateTimePicker dtTimePdata2;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.Label lblFinal;
    }
}