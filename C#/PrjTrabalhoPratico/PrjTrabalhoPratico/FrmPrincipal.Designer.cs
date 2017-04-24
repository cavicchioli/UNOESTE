namespace PrjTrabalhoPratico
{
    partial class FrmPrincipal
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
            this.ltb1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxLista2 = new System.Windows.Forms.CheckBox();
            this.cbxLista1 = new System.Windows.Forms.CheckBox();
            this.ttbInsere = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMoveTopo = new System.Windows.Forms.Button();
            this.btnImportaTXT = new System.Windows.Forms.Button();
            this.btnApagaL2 = new System.Windows.Forms.Button();
            this.btnApagaL1 = new System.Windows.Forms.Button();
            this.btnGravaTXT = new System.Windows.Forms.Button();
            this.btnInsereL2 = new System.Windows.Forms.Button();
            this.btnInsereL1 = new System.Windows.Forms.Button();
            this.btnTransfL2L1 = new System.Windows.Forms.Button();
            this.btnTransfL1L2 = new System.Windows.Forms.Button();
            this.ltb2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdAbre = new System.Windows.Forms.OpenFileDialog();
            this.sfdSavar = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltb1
            // 
            this.ltb1.FormattingEnabled = true;
            this.ltb1.Location = new System.Drawing.Point(19, 80);
            this.ltb1.Name = "ltb1";
            this.ltb1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltb1.Size = new System.Drawing.Size(211, 95);
            this.ltb1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxLista2);
            this.panel1.Controls.Add(this.cbxLista1);
            this.panel1.Location = new System.Drawing.Point(573, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 95);
            this.panel1.TabIndex = 21;
            // 
            // cbxLista2
            // 
            this.cbxLista2.AutoSize = true;
            this.cbxLista2.Location = new System.Drawing.Point(20, 54);
            this.cbxLista2.Name = "cbxLista2";
            this.cbxLista2.Size = new System.Drawing.Size(57, 17);
            this.cbxLista2.TabIndex = 4;
            this.cbxLista2.Text = "Lista 2";
            this.cbxLista2.UseVisualStyleBackColor = true;
            this.cbxLista2.CheckedChanged += new System.EventHandler(this.cbxLista2_CheckedChanged);
            // 
            // cbxLista1
            // 
            this.cbxLista1.AutoSize = true;
            this.cbxLista1.Location = new System.Drawing.Point(20, 13);
            this.cbxLista1.Name = "cbxLista1";
            this.cbxLista1.Size = new System.Drawing.Size(57, 17);
            this.cbxLista1.TabIndex = 4;
            this.cbxLista1.Text = "Lista 1";
            this.cbxLista1.UseVisualStyleBackColor = true;
            this.cbxLista1.CheckedChanged += new System.EventHandler(this.cbxLista1_CheckedChanged);
            // 
            // ttbInsere
            // 
            this.ttbInsere.Location = new System.Drawing.Point(19, 35);
            this.ttbInsere.Name = "ttbInsere";
            this.ttbInsere.Size = new System.Drawing.Size(100, 20);
            this.ttbInsere.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(570, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ordenação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Victor Hugo Cavichiolli Prado / RA: 0261030370";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Item a ser Inserido";
            // 
            // btnMoveTopo
            // 
            this.btnMoveTopo.Location = new System.Drawing.Point(61, 256);
            this.btnMoveTopo.Name = "btnMoveTopo";
            this.btnMoveTopo.Size = new System.Drawing.Size(120, 24);
            this.btnMoveTopo.TabIndex = 15;
            this.btnMoveTopo.Text = "Mover p/ Topo";
            this.btnMoveTopo.UseVisualStyleBackColor = true;
            this.btnMoveTopo.Click += new System.EventHandler(this.btnMoveTopo_Click);
            // 
            // btnImportaTXT
            // 
            this.btnImportaTXT.Location = new System.Drawing.Point(573, 226);
            this.btnImportaTXT.Name = "btnImportaTXT";
            this.btnImportaTXT.Size = new System.Drawing.Size(120, 24);
            this.btnImportaTXT.TabIndex = 16;
            this.btnImportaTXT.Text = "Importa TXT";
            this.btnImportaTXT.UseVisualStyleBackColor = true;
            this.btnImportaTXT.Click += new System.EventHandler(this.btnImportaTXT_Click);
            // 
            // btnApagaL2
            // 
            this.btnApagaL2.Location = new System.Drawing.Point(358, 226);
            this.btnApagaL2.Name = "btnApagaL2";
            this.btnApagaL2.Size = new System.Drawing.Size(120, 24);
            this.btnApagaL2.TabIndex = 10;
            this.btnApagaL2.Text = "Apaga Lista 2";
            this.btnApagaL2.UseVisualStyleBackColor = true;
            this.btnApagaL2.Click += new System.EventHandler(this.btnApagaL2_Click);
            // 
            // btnApagaL1
            // 
            this.btnApagaL1.Location = new System.Drawing.Point(61, 226);
            this.btnApagaL1.Name = "btnApagaL1";
            this.btnApagaL1.Size = new System.Drawing.Size(120, 24);
            this.btnApagaL1.TabIndex = 9;
            this.btnApagaL1.Text = "Apaga Lista 1";
            this.btnApagaL1.UseVisualStyleBackColor = true;
            this.btnApagaL1.Click += new System.EventHandler(this.btnApagaL1_Click);
            // 
            // btnGravaTXT
            // 
            this.btnGravaTXT.Location = new System.Drawing.Point(573, 194);
            this.btnGravaTXT.Name = "btnGravaTXT";
            this.btnGravaTXT.Size = new System.Drawing.Size(120, 24);
            this.btnGravaTXT.TabIndex = 8;
            this.btnGravaTXT.Text = "Grava TXT";
            this.btnGravaTXT.UseVisualStyleBackColor = true;
            this.btnGravaTXT.Click += new System.EventHandler(this.btnGravaTXT_Click);
            // 
            // btnInsereL2
            // 
            this.btnInsereL2.Location = new System.Drawing.Point(358, 194);
            this.btnInsereL2.Name = "btnInsereL2";
            this.btnInsereL2.Size = new System.Drawing.Size(120, 24);
            this.btnInsereL2.TabIndex = 11;
            this.btnInsereL2.Text = "Insere Lista 2";
            this.btnInsereL2.UseVisualStyleBackColor = true;
            this.btnInsereL2.Click += new System.EventHandler(this.btnInsereL2_Click);
            // 
            // btnInsereL1
            // 
            this.btnInsereL1.Location = new System.Drawing.Point(61, 194);
            this.btnInsereL1.Name = "btnInsereL1";
            this.btnInsereL1.Size = new System.Drawing.Size(120, 24);
            this.btnInsereL1.TabIndex = 14;
            this.btnInsereL1.Text = "Insere Lista 1";
            this.btnInsereL1.UseVisualStyleBackColor = true;
            this.btnInsereL1.Click += new System.EventHandler(this.btnInsereL1_Click);
            // 
            // btnTransfL2L1
            // 
            this.btnTransfL2L1.Location = new System.Drawing.Point(256, 130);
            this.btnTransfL2L1.Name = "btnTransfL2L1";
            this.btnTransfL2L1.Size = new System.Drawing.Size(27, 23);
            this.btnTransfL2L1.TabIndex = 13;
            this.btnTransfL2L1.Text = "<";
            this.btnTransfL2L1.UseVisualStyleBackColor = true;
            this.btnTransfL2L1.Click += new System.EventHandler(this.btnTransfL2L1_Click);
            // 
            // btnTransfL1L2
            // 
            this.btnTransfL1L2.Location = new System.Drawing.Point(256, 93);
            this.btnTransfL1L2.Name = "btnTransfL1L2";
            this.btnTransfL1L2.Size = new System.Drawing.Size(27, 23);
            this.btnTransfL1L2.TabIndex = 12;
            this.btnTransfL1L2.Text = ">";
            this.btnTransfL1L2.UseVisualStyleBackColor = true;
            this.btnTransfL1L2.Click += new System.EventHandler(this.btnTransfL1L2_Click);
            // 
            // ltb2
            // 
            this.ltb2.FormattingEnabled = true;
            this.ltb2.Location = new System.Drawing.Point(311, 80);
            this.ltb2.Name = "ltb2";
            this.ltb2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltb2.Size = new System.Drawing.Size(219, 95);
            this.ltb2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Weslley Ceresa RA: 26.10.2986-0";
            // 
            // ofdAbre
            // 
            this.ofdAbre.Filter = "Arquivo Text |*txt";
            this.ofdAbre.Title = "Open File";
            // 
            // sfdSavar
            // 
            this.sfdSavar.Filter = "Arquivo Texto |*txt";
            this.sfdSavar.Title = "Save File";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 296);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ltb1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ttbInsere);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMoveTopo);
            this.Controls.Add(this.btnImportaTXT);
            this.Controls.Add(this.btnApagaL2);
            this.Controls.Add(this.btnApagaL1);
            this.Controls.Add(this.btnGravaTXT);
            this.Controls.Add(this.btnInsereL2);
            this.Controls.Add(this.btnInsereL1);
            this.Controls.Add(this.btnTransfL2L1);
            this.Controls.Add(this.btnTransfL1L2);
            this.Controls.Add(this.ltb2);
            this.Name = "FrmPrincipal";
            this.Text = "Trabalho Prático";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltb1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxLista2;
        private System.Windows.Forms.CheckBox cbxLista1;
        private System.Windows.Forms.TextBox ttbInsere;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMoveTopo;
        private System.Windows.Forms.Button btnImportaTXT;
        private System.Windows.Forms.Button btnApagaL2;
        private System.Windows.Forms.Button btnApagaL1;
        private System.Windows.Forms.Button btnGravaTXT;
        private System.Windows.Forms.Button btnInsereL2;
        private System.Windows.Forms.Button btnInsereL1;
        private System.Windows.Forms.Button btnTransfL2L1;
        private System.Windows.Forms.Button btnTransfL1L2;
        private System.Windows.Forms.ListBox ltb2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofdAbre;
        private System.Windows.Forms.SaveFileDialog sfdSavar;
    }
}

