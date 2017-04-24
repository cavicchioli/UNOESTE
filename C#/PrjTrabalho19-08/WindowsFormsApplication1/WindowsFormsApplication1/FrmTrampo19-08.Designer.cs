namespace WindowsFormsApplication1
{
    partial class FrmTrabalhoPratico
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
            this.btnTransfL1L2 = new System.Windows.Forms.Button();
            this.ttbInsere = new System.Windows.Forms.TextBox();
            this.cbxLista1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxLista2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ltb2 = new System.Windows.Forms.ListBox();
            this.btnInsereL1 = new System.Windows.Forms.Button();
            this.btnTransfL2L1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApagaL1 = new System.Windows.Forms.Button();
            this.btnMoveTopo = new System.Windows.Forms.Button();
            this.btnInsereL2 = new System.Windows.Forms.Button();
            this.btnApagaL2 = new System.Windows.Forms.Button();
            this.btnGravaTXT = new System.Windows.Forms.Button();
            this.btnImportaTXT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ltb1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTransfL1L2
            // 
            this.btnTransfL1L2.Location = new System.Drawing.Point(147, 83);
            this.btnTransfL1L2.Name = "btnTransfL1L2";
            this.btnTransfL1L2.Size = new System.Drawing.Size(27, 23);
            this.btnTransfL1L2.TabIndex = 1;
            this.btnTransfL1L2.Text = ">";
            this.btnTransfL1L2.UseVisualStyleBackColor = true;
            this.btnTransfL1L2.Click += new System.EventHandler(this.btnTransfL1L2_Click);
            // 
            // ttbInsere
            // 
            this.ttbInsere.Location = new System.Drawing.Point(123, 25);
            this.ttbInsere.Name = "ttbInsere";
            this.ttbInsere.Size = new System.Drawing.Size(100, 20);
            this.ttbInsere.TabIndex = 3;
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
            this.cbxLista1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxLista2);
            this.panel1.Controls.Add(this.cbxLista1);
            this.panel1.Location = new System.Drawing.Point(363, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 95);
            this.panel1.TabIndex = 5;
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
            this.cbxLista2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item a ser Inserido";
            // 
            // ltb2
            // 
            this.ltb2.FormattingEnabled = true;
            this.ltb2.Location = new System.Drawing.Point(191, 70);
            this.ltb2.Name = "ltb2";
            this.ltb2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltb2.Size = new System.Drawing.Size(120, 95);
            this.ltb2.TabIndex = 0;
            // 
            // btnInsereL1
            // 
            this.btnInsereL1.Location = new System.Drawing.Point(12, 184);
            this.btnInsereL1.Name = "btnInsereL1";
            this.btnInsereL1.Size = new System.Drawing.Size(120, 24);
            this.btnInsereL1.TabIndex = 1;
            this.btnInsereL1.Text = "Insere Lista 1";
            this.btnInsereL1.UseVisualStyleBackColor = true;
            this.btnInsereL1.Click += new System.EventHandler(this.btnInsereL1_Click);
            // 
            // btnTransfL2L1
            // 
            this.btnTransfL2L1.Location = new System.Drawing.Point(147, 124);
            this.btnTransfL2L1.Name = "btnTransfL2L1";
            this.btnTransfL2L1.Size = new System.Drawing.Size(27, 23);
            this.btnTransfL2L1.TabIndex = 1;
            this.btnTransfL2L1.Text = "<";
            this.btnTransfL2L1.UseVisualStyleBackColor = true;
            this.btnTransfL2L1.Click += new System.EventHandler(this.btnTransfL2L1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ordenação";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnApagaL1
            // 
            this.btnApagaL1.Location = new System.Drawing.Point(12, 216);
            this.btnApagaL1.Name = "btnApagaL1";
            this.btnApagaL1.Size = new System.Drawing.Size(120, 24);
            this.btnApagaL1.TabIndex = 1;
            this.btnApagaL1.Text = "Apaga Lista 1";
            this.btnApagaL1.UseVisualStyleBackColor = true;
            this.btnApagaL1.Click += new System.EventHandler(this.btnApagaL1_Click);
            // 
            // btnMoveTopo
            // 
            this.btnMoveTopo.Location = new System.Drawing.Point(12, 246);
            this.btnMoveTopo.Name = "btnMoveTopo";
            this.btnMoveTopo.Size = new System.Drawing.Size(120, 24);
            this.btnMoveTopo.TabIndex = 1;
            this.btnMoveTopo.Text = "Mover p/ Topo";
            this.btnMoveTopo.UseVisualStyleBackColor = true;
            this.btnMoveTopo.Click += new System.EventHandler(this.btnMoveTopo_Click);
            // 
            // btnInsereL2
            // 
            this.btnInsereL2.Location = new System.Drawing.Point(191, 184);
            this.btnInsereL2.Name = "btnInsereL2";
            this.btnInsereL2.Size = new System.Drawing.Size(120, 24);
            this.btnInsereL2.TabIndex = 1;
            this.btnInsereL2.Text = "Insere Lista 2";
            this.btnInsereL2.UseVisualStyleBackColor = true;
            this.btnInsereL2.Click += new System.EventHandler(this.btnInsereL2_Click);
            // 
            // btnApagaL2
            // 
            this.btnApagaL2.Location = new System.Drawing.Point(191, 216);
            this.btnApagaL2.Name = "btnApagaL2";
            this.btnApagaL2.Size = new System.Drawing.Size(120, 24);
            this.btnApagaL2.TabIndex = 1;
            this.btnApagaL2.Text = "Apaga Lista 2";
            this.btnApagaL2.UseVisualStyleBackColor = true;
            // 
            // btnGravaTXT
            // 
            this.btnGravaTXT.Location = new System.Drawing.Point(363, 184);
            this.btnGravaTXT.Name = "btnGravaTXT";
            this.btnGravaTXT.Size = new System.Drawing.Size(120, 24);
            this.btnGravaTXT.TabIndex = 1;
            this.btnGravaTXT.Text = "Grava TXT";
            this.btnGravaTXT.UseVisualStyleBackColor = true;
            // 
            // btnImportaTXT
            // 
            this.btnImportaTXT.Location = new System.Drawing.Point(363, 216);
            this.btnImportaTXT.Name = "btnImportaTXT";
            this.btnImportaTXT.Size = new System.Drawing.Size(120, 24);
            this.btnImportaTXT.TabIndex = 1;
            this.btnImportaTXT.Text = "Importa TXT";
            this.btnImportaTXT.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Victor Hugo Cavichiolli Prado / RA: 0261030370";
            // 
            // ltb1
            // 
            this.ltb1.FormattingEnabled = true;
            this.ltb1.Location = new System.Drawing.Point(12, 70);
            this.ltb1.Name = "ltb1";
            this.ltb1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ltb1.Size = new System.Drawing.Size(120, 95);
            this.ltb1.TabIndex = 6;
            // 
            // FrmTrabalhoPratico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 287);
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
            this.Name = "FrmTrabalhoPratico";
            this.Text = "Trabalho Prático";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTransfL1L2;
        private System.Windows.Forms.TextBox ttbInsere;
        private System.Windows.Forms.CheckBox cbxLista1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ltb2;
        private System.Windows.Forms.Button btnInsereL1;
        private System.Windows.Forms.Button btnTransfL2L1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxLista2;
        private System.Windows.Forms.Button btnApagaL1;
        private System.Windows.Forms.Button btnMoveTopo;
        private System.Windows.Forms.Button btnInsereL2;
        private System.Windows.Forms.Button btnApagaL2;
        private System.Windows.Forms.Button btnGravaTXT;
        private System.Windows.Forms.Button btnImportaTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ltb1;
    }
}

