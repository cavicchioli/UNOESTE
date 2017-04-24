namespace Copa2010.CamadaApresentacao
{
    partial class frmJogos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJogos));
            this.grpBotoes = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.lEquipe2 = new System.Windows.Forms.Label();
            this.cbEquipe2 = new System.Windows.Forms.ComboBox();
            this.lEquipe1 = new System.Windows.Forms.Label();
            this.cbEquipe1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lHora = new System.Windows.Forms.Label();
            this.lData = new System.Windows.Forms.Label();
            this.mtbHora = new System.Windows.Forms.MaskedTextBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lFase = new System.Windows.Forms.Label();
            this.cbFase = new System.Windows.Forms.ComboBox();
            this.tbLocal = new System.Windows.Forms.TextBox();
            this.lLocal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBotoes.SuspendLayout();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBotoes
            // 
            this.grpBotoes.Controls.Add(this.btnSair);
            this.grpBotoes.Controls.Add(this.btnLocalizar);
            this.grpBotoes.Controls.Add(this.btnCancelar);
            this.grpBotoes.Controls.Add(this.btnSalvar);
            this.grpBotoes.Controls.Add(this.btnExcluir);
            this.grpBotoes.Controls.Add(this.btnAlterar);
            this.grpBotoes.Controls.Add(this.btnNovo);
            this.grpBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBotoes.Location = new System.Drawing.Point(0, 247);
            this.grpBotoes.Name = "grpBotoes";
            this.grpBotoes.Size = new System.Drawing.Size(513, 88);
            this.grpBotoes.TabIndex = 5;
            this.grpBotoes.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Image = global::Copa2010.Properties.Resources.Exit;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSair.Location = new System.Drawing.Point(444, 19);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 58);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalizar.Image = global::Copa2010.Properties.Resources.Loading;
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLocalizar.Location = new System.Drawing.Point(372, 19);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(65, 58);
            this.btnLocalizar.TabIndex = 5;
            this.btnLocalizar.Text = "&Localizar";
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::Copa2010.Properties.Resources.Back;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(300, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 58);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::Copa2010.Properties.Resources.Load;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalvar.Location = new System.Drawing.Point(228, 19);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 58);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::Copa2010.Properties.Resources.Delete;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.Location = new System.Drawing.Point(156, 19);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(65, 58);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Image = global::Copa2010.Properties.Resources.Modify;
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlterar.Location = new System.Drawing.Point(84, 19);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(65, 58);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::Copa2010.Properties.Resources.Add;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNovo.Location = new System.Drawing.Point(12, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(65, 58);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.lEquipe2);
            this.grpDados.Controls.Add(this.cbEquipe2);
            this.grpDados.Controls.Add(this.lEquipe1);
            this.grpDados.Controls.Add(this.cbEquipe1);
            this.grpDados.Controls.Add(this.label2);
            this.grpDados.Controls.Add(this.lHora);
            this.grpDados.Controls.Add(this.lData);
            this.grpDados.Controls.Add(this.mtbHora);
            this.grpDados.Controls.Add(this.dtpData);
            this.grpDados.Controls.Add(this.lFase);
            this.grpDados.Controls.Add(this.cbFase);
            this.grpDados.Controls.Add(this.tbLocal);
            this.grpDados.Controls.Add(this.lLocal);
            this.grpDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDados.Location = new System.Drawing.Point(0, 0);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(513, 250);
            this.grpDados.TabIndex = 6;
            this.grpDados.TabStop = false;
            // 
            // lEquipe2
            // 
            this.lEquipe2.AutoSize = true;
            this.lEquipe2.Location = new System.Drawing.Point(290, 148);
            this.lEquipe2.Name = "lEquipe2";
            this.lEquipe2.Size = new System.Drawing.Size(49, 13);
            this.lEquipe2.TabIndex = 18;
            this.lEquipe2.Text = "Equipe 2";
            // 
            // cbEquipe2
            // 
            this.cbEquipe2.FormattingEnabled = true;
            this.cbEquipe2.Location = new System.Drawing.Point(287, 164);
            this.cbEquipe2.Name = "cbEquipe2";
            this.cbEquipe2.Size = new System.Drawing.Size(199, 21);
            this.cbEquipe2.TabIndex = 6;
            // 
            // lEquipe1
            // 
            this.lEquipe1.AutoSize = true;
            this.lEquipe1.Location = new System.Drawing.Point(27, 148);
            this.lEquipe1.Name = "lEquipe1";
            this.lEquipe1.Size = new System.Drawing.Size(49, 13);
            this.lEquipe1.TabIndex = 16;
            this.lEquipe1.Text = "Equipe 1";
            // 
            // cbEquipe1
            // 
            this.cbEquipe1.FormattingEnabled = true;
            this.cbEquipe1.Location = new System.Drawing.Point(28, 165);
            this.cbEquipe1.Name = "cbEquipe1";
            this.cbEquipe1.Size = new System.Drawing.Size(199, 21);
            this.cbEquipe1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "X";
            // 
            // lHora
            // 
            this.lHora.AutoSize = true;
            this.lHora.Location = new System.Drawing.Point(372, 62);
            this.lHora.Name = "lHora";
            this.lHora.Size = new System.Drawing.Size(30, 13);
            this.lHora.TabIndex = 13;
            this.lHora.Text = "Hora";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(27, 62);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(30, 13);
            this.lData.TabIndex = 12;
            this.lData.Text = "Data";
            // 
            // mtbHora
            // 
            this.mtbHora.Location = new System.Drawing.Point(371, 78);
            this.mtbHora.Mask = "00:00";
            this.mtbHora.Name = "mtbHora";
            this.mtbHora.Size = new System.Drawing.Size(115, 20);
            this.mtbHora.TabIndex = 3;
            this.mtbHora.ValidatingType = typeof(System.DateTime);
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(27, 78);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(200, 20);
            this.dtpData.TabIndex = 2;
            // 
            // lFase
            // 
            this.lFase.AutoSize = true;
            this.lFase.Location = new System.Drawing.Point(28, 195);
            this.lFase.Name = "lFase";
            this.lFase.Size = new System.Drawing.Size(30, 13);
            this.lFase.TabIndex = 8;
            this.lFase.Text = "Fase";
            // 
            // cbFase
            // 
            this.cbFase.FormattingEnabled = true;
            this.cbFase.Location = new System.Drawing.Point(28, 211);
            this.cbFase.Name = "cbFase";
            this.cbFase.Size = new System.Drawing.Size(199, 21);
            this.cbFase.TabIndex = 7;
            // 
            // tbLocal
            // 
            this.tbLocal.Location = new System.Drawing.Point(27, 122);
            this.tbLocal.MaxLength = 30;
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Size = new System.Drawing.Size(459, 20);
            this.tbLocal.TabIndex = 4;
            // 
            // lLocal
            // 
            this.lLocal.AutoSize = true;
            this.lLocal.Location = new System.Drawing.Point(27, 106);
            this.lLocal.Name = "lLocal";
            this.lLocal.Size = new System.Drawing.Size(33, 13);
            this.lLocal.TabIndex = 1;
            this.lLocal.Text = "Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Código";
            // 
            // mtbCodigo
            // 
            this.mtbCodigo.Location = new System.Drawing.Point(27, 32);
            this.mtbCodigo.Mask = "0000";
            this.mtbCodigo.Name = "mtbCodigo";
            this.mtbCodigo.Size = new System.Drawing.Size(100, 20);
            this.mtbCodigo.TabIndex = 1;
            this.mtbCodigo.Leave += new System.EventHandler(this.mtbCodigo_Leave);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmJogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 335);
            this.Controls.Add(this.mtbCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.grpBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Jogos";
            this.Activated += new System.EventHandler(this.frmJogos_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJogos_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmJogos_KeyDown);
            this.grpBotoes.ResumeLayout(false);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBotoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label lFase;
        private System.Windows.Forms.ComboBox cbFase;
        private System.Windows.Forms.TextBox tbLocal;
        private System.Windows.Forms.Label lLocal;
        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbHora;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label lHora;
        private System.Windows.Forms.Label lData;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbEquipe2;
        private System.Windows.Forms.Label lEquipe1;
        private System.Windows.Forms.ComboBox cbEquipe1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lEquipe2;
    }
}