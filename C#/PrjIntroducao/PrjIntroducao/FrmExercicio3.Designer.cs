namespace PrjIntroducao
{
    partial class FrmExercicio3
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
            this.btnInserirPalavra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ttbPalavra = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnDescarrecar = new System.Windows.Forms.Button();
            this.ltbPalavras = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnInserirPalavra
            // 
            this.btnInserirPalavra.Location = new System.Drawing.Point(209, 12);
            this.btnInserirPalavra.Name = "btnInserirPalavra";
            this.btnInserirPalavra.Size = new System.Drawing.Size(125, 23);
            this.btnInserirPalavra.TabIndex = 0;
            this.btnInserirPalavra.Text = "Inserir palavra no Vetor";
            this.btnInserirPalavra.UseVisualStyleBackColor = true;
            this.btnInserirPalavra.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ttbPalavra
            // 
            this.ttbPalavra.Location = new System.Drawing.Point(12, 12);
            this.ttbPalavra.Name = "ttbPalavra";
            this.ttbPalavra.Size = new System.Drawing.Size(191, 20);
            this.ttbPalavra.TabIndex = 2;
            this.ttbPalavra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(72, 98);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(114, 24);
            this.btnLimpar.TabIndex = 0;
            this.btnLimpar.Text = "Limpar >>";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnDescarrecar
            // 
            this.btnDescarrecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescarrecar.Location = new System.Drawing.Point(12, 51);
            this.btnDescarrecar.Name = "btnDescarrecar";
            this.btnDescarrecar.Size = new System.Drawing.Size(174, 32);
            this.btnDescarrecar.TabIndex = 0;
            this.btnDescarrecar.Text = "Descarregar no Vetor >>";
            this.btnDescarrecar.UseVisualStyleBackColor = true;
            this.btnDescarrecar.Click += new System.EventHandler(this.btnDescarrecar_Click);
            // 
            // ltbPalavras
            // 
            this.ltbPalavras.FormattingEnabled = true;
            this.ltbPalavras.Location = new System.Drawing.Point(192, 51);
            this.ltbPalavras.Name = "ltbPalavras";
            this.ltbPalavras.Size = new System.Drawing.Size(142, 147);
            this.ltbPalavras.TabIndex = 3;
            // 
            // FrmExercicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 209);
            this.Controls.Add(this.ltbPalavras);
            this.Controls.Add(this.ttbPalavra);
            this.Controls.Add(this.btnDescarrecar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnInserirPalavra);
            this.Name = "FrmExercicio3";
            this.Text = "FrmExercicio3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInserirPalavra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ttbPalavra;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDescarrecar;
        private System.Windows.Forms.ListBox ltbPalavras;
    }
}