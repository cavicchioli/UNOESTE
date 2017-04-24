namespace PrjIntroducao
{
    partial class FrmExercicio2
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
            this.ttbNumero = new System.Windows.Forms.TextBox();
            this.btnInserirVetor = new System.Windows.Forms.Button();
            this.btnSeparar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.ltbPares = new System.Windows.Forms.ListBox();
            this.ltbImpar = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ttbNumero
            // 
            this.ttbNumero.Location = new System.Drawing.Point(12, 14);
            this.ttbNumero.Name = "ttbNumero";
            this.ttbNumero.Size = new System.Drawing.Size(170, 20);
            this.ttbNumero.TabIndex = 1;
            // 
            // btnInserirVetor
            // 
            this.btnInserirVetor.Location = new System.Drawing.Point(225, 12);
            this.btnInserirVetor.Name = "btnInserirVetor";
            this.btnInserirVetor.Size = new System.Drawing.Size(139, 23);
            this.btnInserirVetor.TabIndex = 2;
            this.btnInserirVetor.Text = "Inserir no Vetor";
            this.btnInserirVetor.UseVisualStyleBackColor = true;
            this.btnInserirVetor.Click += new System.EventHandler(this.btnInserirVetor_Click);
            // 
            // btnSeparar
            // 
            this.btnSeparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeparar.Location = new System.Drawing.Point(12, 56);
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(352, 29);
            this.btnSeparar.TabIndex = 2;
            this.btnSeparar.Text = "Separar Números";
            this.btnSeparar.UseVisualStyleBackColor = true;
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(130, 308);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(122, 23);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // ltbPares
            // 
            this.ltbPares.FormattingEnabled = true;
            this.ltbPares.Location = new System.Drawing.Point(12, 127);
            this.ltbPares.Name = "ltbPares";
            this.ltbPares.Size = new System.Drawing.Size(139, 160);
            this.ltbPares.TabIndex = 0;
            // 
            // ltbImpar
            // 
            this.ltbImpar.FormattingEnabled = true;
            this.ltbImpar.Location = new System.Drawing.Point(225, 127);
            this.ltbImpar.Name = "ltbImpar";
            this.ltbImpar.Size = new System.Drawing.Size(139, 160);
            this.ltbImpar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Números Pares";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Números Ímpares";
            // 
            // FrmExercicio2
            // 
            this.AcceptButton = this.btnInserirVetor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSeparar);
            this.Controls.Add(this.btnInserirVetor);
            this.Controls.Add(this.ttbNumero);
            this.Controls.Add(this.ltbImpar);
            this.Controls.Add(this.ltbPares);
            this.Name = "FrmExercicio2";
            this.Text = "Exercício 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ttbNumero;
        private System.Windows.Forms.Button btnInserirVetor;
        private System.Windows.Forms.Button btnSeparar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.ListBox ltbPares;
        private System.Windows.Forms.ListBox ltbImpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}