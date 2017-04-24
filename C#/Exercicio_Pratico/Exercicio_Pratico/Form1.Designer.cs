namespace Exercicio_Pratico
{
    partial class Form1
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
            this.ttbEntrada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lista1 = new System.Windows.Forms.ListBox();
            this.lista2 = new System.Windows.Forms.ListBox();
            this.btnMandaLista2 = new System.Windows.Forms.Button();
            this.btnMandaLista1 = new System.Windows.Forms.Button();
            this.btnInsereLista1 = new System.Windows.Forms.Button();
            this.btnApagaLista1 = new System.Windows.Forms.Button();
            this.btnMoveTopo = new System.Windows.Forms.Button();
            this.btnInsereLista2 = new System.Windows.Forms.Button();
            this.btnApagaLista2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ccbLista2 = new System.Windows.Forms.CheckBox();
            this.ccbLista1 = new System.Windows.Forms.CheckBox();
            this.btnGrava = new System.Windows.Forms.Button();
            this.btnImporta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttbEntrada
            // 
            this.ttbEntrada.Location = new System.Drawing.Point(26, 36);
            this.ttbEntrada.Name = "ttbEntrada";
            this.ttbEntrada.Size = new System.Drawing.Size(100, 20);
            this.ttbEntrada.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item a ser Inserido";
            // 
            // lista1
            // 
            this.lista1.FormattingEnabled = true;
            this.lista1.Location = new System.Drawing.Point(26, 89);
            this.lista1.Name = "lista1";
            this.lista1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lista1.Size = new System.Drawing.Size(121, 108);
            this.lista1.TabIndex = 2;
            // 
            // lista2
            // 
            this.lista2.FormattingEnabled = true;
            this.lista2.Location = new System.Drawing.Point(193, 89);
            this.lista2.Name = "lista2";
            this.lista2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lista2.Size = new System.Drawing.Size(128, 108);
            this.lista2.TabIndex = 3;
            // 
            // btnMandaLista2
            // 
            this.btnMandaLista2.Location = new System.Drawing.Point(154, 121);
            this.btnMandaLista2.Name = "btnMandaLista2";
            this.btnMandaLista2.Size = new System.Drawing.Size(33, 23);
            this.btnMandaLista2.TabIndex = 4;
            this.btnMandaLista2.Text = ">";
            this.btnMandaLista2.UseVisualStyleBackColor = true;
            this.btnMandaLista2.Click += new System.EventHandler(this.btnMandaLista2_Click);
            // 
            // btnMandaLista1
            // 
            this.btnMandaLista1.Location = new System.Drawing.Point(154, 151);
            this.btnMandaLista1.Name = "btnMandaLista1";
            this.btnMandaLista1.Size = new System.Drawing.Size(33, 23);
            this.btnMandaLista1.TabIndex = 5;
            this.btnMandaLista1.Text = "<";
            this.btnMandaLista1.UseVisualStyleBackColor = true;
            this.btnMandaLista1.Click += new System.EventHandler(this.btnMandaLista1_Click);
            // 
            // btnInsereLista1
            // 
            this.btnInsereLista1.Location = new System.Drawing.Point(26, 203);
            this.btnInsereLista1.Name = "btnInsereLista1";
            this.btnInsereLista1.Size = new System.Drawing.Size(121, 29);
            this.btnInsereLista1.TabIndex = 6;
            this.btnInsereLista1.Text = "Insere Lista 1";
            this.btnInsereLista1.UseVisualStyleBackColor = true;
            this.btnInsereLista1.Click += new System.EventHandler(this.btnInsereLista1_Click);
            // 
            // btnApagaLista1
            // 
            this.btnApagaLista1.Location = new System.Drawing.Point(26, 238);
            this.btnApagaLista1.Name = "btnApagaLista1";
            this.btnApagaLista1.Size = new System.Drawing.Size(121, 29);
            this.btnApagaLista1.TabIndex = 7;
            this.btnApagaLista1.Text = "Apaga Lista 1";
            this.btnApagaLista1.UseVisualStyleBackColor = true;
            this.btnApagaLista1.Click += new System.EventHandler(this.btnApagaLista1_Click);
            // 
            // btnMoveTopo
            // 
            this.btnMoveTopo.Location = new System.Drawing.Point(26, 273);
            this.btnMoveTopo.Name = "btnMoveTopo";
            this.btnMoveTopo.Size = new System.Drawing.Size(121, 22);
            this.btnMoveTopo.TabIndex = 8;
            this.btnMoveTopo.Text = "Move p/ Topo";
            this.btnMoveTopo.UseVisualStyleBackColor = true;
            this.btnMoveTopo.Click += new System.EventHandler(this.btnMoveTopo_Click);
            // 
            // btnInsereLista2
            // 
            this.btnInsereLista2.Location = new System.Drawing.Point(193, 203);
            this.btnInsereLista2.Name = "btnInsereLista2";
            this.btnInsereLista2.Size = new System.Drawing.Size(128, 29);
            this.btnInsereLista2.TabIndex = 9;
            this.btnInsereLista2.Text = "Insere Lista 2";
            this.btnInsereLista2.UseVisualStyleBackColor = true;
            this.btnInsereLista2.Click += new System.EventHandler(this.btnInsereLista2_Click);
            // 
            // btnApagaLista2
            // 
            this.btnApagaLista2.Location = new System.Drawing.Point(193, 239);
            this.btnApagaLista2.Name = "btnApagaLista2";
            this.btnApagaLista2.Size = new System.Drawing.Size(128, 28);
            this.btnApagaLista2.TabIndex = 10;
            this.btnApagaLista2.Text = "Apaga Lista 2";
            this.btnApagaLista2.UseVisualStyleBackColor = true;
            this.btnApagaLista2.Click += new System.EventHandler(this.btnApagaLista2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ccbLista2);
            this.groupBox1.Controls.Add(this.ccbLista1);
            this.groupBox1.Location = new System.Drawing.Point(365, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 108);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insere Ordenado";
            // 
            // ccbLista2
            // 
            this.ccbLista2.AutoSize = true;
            this.ccbLista2.Location = new System.Drawing.Point(19, 62);
            this.ccbLista2.Name = "ccbLista2";
            this.ccbLista2.Size = new System.Drawing.Size(57, 17);
            this.ccbLista2.TabIndex = 1;
            this.ccbLista2.Text = "Lista 2";
            this.ccbLista2.UseVisualStyleBackColor = true;
            this.ccbLista2.CheckedChanged += new System.EventHandler(this.ccbLista2_CheckedChanged);
            // 
            // ccbLista1
            // 
            this.ccbLista1.AutoSize = true;
            this.ccbLista1.Location = new System.Drawing.Point(19, 32);
            this.ccbLista1.Name = "ccbLista1";
            this.ccbLista1.Size = new System.Drawing.Size(57, 17);
            this.ccbLista1.TabIndex = 0;
            this.ccbLista1.Text = "Lista 1";
            this.ccbLista1.UseVisualStyleBackColor = true;
            this.ccbLista1.CheckedChanged += new System.EventHandler(this.ccbLista1_CheckedChanged);
            // 
            // btnGrava
            // 
            this.btnGrava.Location = new System.Drawing.Point(419, 204);
            this.btnGrava.Name = "btnGrava";
            this.btnGrava.Size = new System.Drawing.Size(106, 28);
            this.btnGrava.TabIndex = 12;
            this.btnGrava.Text = "Grava Txt";
            this.btnGrava.UseVisualStyleBackColor = true;
            this.btnGrava.Click += new System.EventHandler(this.btnGrava_Click);
            // 
            // btnImporta
            // 
            this.btnImporta.Location = new System.Drawing.Point(398, 239);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(126, 40);
            this.btnImporta.TabIndex = 13;
            this.btnImporta.Text = "Importa Txt";
            this.btnImporta.UseVisualStyleBackColor = true;
            this.btnImporta.Click += new System.EventHandler(this.btnImporta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Weslley Ceresa RA: 26.10.2986-0 Turma A1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 316);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImporta);
            this.Controls.Add(this.btnGrava);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApagaLista2);
            this.Controls.Add(this.btnInsereLista2);
            this.Controls.Add(this.btnMoveTopo);
            this.Controls.Add(this.btnApagaLista1);
            this.Controls.Add(this.btnInsereLista1);
            this.Controls.Add(this.btnMandaLista1);
            this.Controls.Add(this.btnMandaLista2);
            this.Controls.Add(this.lista2);
            this.Controls.Add(this.lista1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ttbEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ttbEntrada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lista1;
        private System.Windows.Forms.ListBox lista2;
        private System.Windows.Forms.Button btnMandaLista2;
        private System.Windows.Forms.Button btnMandaLista1;
        private System.Windows.Forms.Button btnInsereLista1;
        private System.Windows.Forms.Button btnApagaLista1;
        private System.Windows.Forms.Button btnMoveTopo;
        private System.Windows.Forms.Button btnInsereLista2;
        private System.Windows.Forms.Button btnApagaLista2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ccbLista2;
        private System.Windows.Forms.CheckBox ccbLista1;
        private System.Windows.Forms.Button btnGrava;
        private System.Windows.Forms.Button btnImporta;
        private System.Windows.Forms.Label label2;
    }
}

