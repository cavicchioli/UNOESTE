namespace Copa2010.CamadaApresentacao
{
    partial class frmResultadosJogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultadosJogos));
            this.grpBotoes = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grpDados = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.cbFase = new System.Windows.Forms.ComboBox();
            this.dgvJogos = new System.Windows.Forms.DataGridView();
            this.lGrupo = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lFase = new System.Windows.Forms.Label();
            this.JOG_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOG_DATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOG_HORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQU_BANDEIRA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQU_CODIGO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOG_GOLTIME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOG_GOLTIME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQU_CODIGO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQU_BANDEIRA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOG_LOCAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAS_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBotoes.SuspendLayout();
            this.grpDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBotoes
            // 
            this.grpBotoes.Controls.Add(this.btnSair);
            this.grpBotoes.Controls.Add(this.btnCancelar);
            this.grpBotoes.Controls.Add(this.btnSalvar);
            this.grpBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBotoes.Location = new System.Drawing.Point(0, 382);
            this.grpBotoes.Name = "grpBotoes";
            this.grpBotoes.Size = new System.Drawing.Size(838, 88);
            this.grpBotoes.TabIndex = 2;
            this.grpBotoes.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Image = global::Copa2010.Properties.Resources.Exit;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSair.Location = new System.Drawing.Point(761, 18);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 58);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::Copa2010.Properties.Resources.Back;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(114, 18);
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
            this.btnSalvar.Location = new System.Drawing.Point(34, 18);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 58);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // grpDados
            // 
            this.grpDados.Controls.Add(this.label3);
            this.grpDados.Controls.Add(this.label2);
            this.grpDados.Controls.Add(this.label1);
            this.grpDados.Controls.Add(this.btnListar);
            this.grpDados.Controls.Add(this.cbFase);
            this.grpDados.Controls.Add(this.dgvJogos);
            this.grpDados.Controls.Add(this.lGrupo);
            this.grpDados.Controls.Add(this.cbGrupo);
            this.grpDados.Controls.Add(this.lFase);
            this.grpDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDados.Location = new System.Drawing.Point(0, 0);
            this.grpDados.Name = "grpDados";
            this.grpDados.Size = new System.Drawing.Size(838, 381);
            this.grpDados.TabIndex = 6;
            this.grpDados.TabStop = false;
            // 
            // btnListar
            // 
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListar.Image = global::Copa2010.Properties.Resources.search_48;
            this.btnListar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnListar.Location = new System.Drawing.Point(367, 45);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(70, 70);
            this.btnListar.TabIndex = 10;
            this.btnListar.Text = "&Listar";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // cbFase
            // 
            this.cbFase.FormattingEnabled = true;
            this.cbFase.Location = new System.Drawing.Point(31, 52);
            this.cbFase.Name = "cbFase";
            this.cbFase.Size = new System.Drawing.Size(281, 21);
            this.cbFase.TabIndex = 9;
            // 
            // dgvJogos
            // 
            this.dgvJogos.AllowUserToAddRows = false;
            this.dgvJogos.AllowUserToDeleteRows = false;
            this.dgvJogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJogos.Location = new System.Drawing.Point(6, 135);
            this.dgvJogos.MultiSelect = false;
            this.dgvJogos.Name = "dgvJogos";
            this.dgvJogos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvJogos.Size = new System.Drawing.Size(826, 240);
            this.dgvJogos.TabIndex = 0;
            this.dgvJogos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvJogos_CellFormatting);
            // 
            // lGrupo
            // 
            this.lGrupo.AutoSize = true;
            this.lGrupo.Location = new System.Drawing.Point(31, 78);
            this.lGrupo.Name = "lGrupo";
            this.lGrupo.Size = new System.Drawing.Size(36, 13);
            this.lGrupo.TabIndex = 8;
            this.lGrupo.Text = "Grupo";
            // 
            // cbGrupo
            // 
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(31, 94);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(281, 21);
            this.cbGrupo.TabIndex = 7;
            // 
            // lFase
            // 
            this.lFase.AutoSize = true;
            this.lFase.Location = new System.Drawing.Point(30, 36);
            this.lFase.Name = "lFase";
            this.lFase.Size = new System.Drawing.Size(30, 13);
            this.lFase.TabIndex = 1;
            this.lFase.Text = "Fase";
            // 
            // JOG_CODIGO
            // 
            this.JOG_CODIGO.HeaderText = "Cód.";
            this.JOG_CODIGO.Name = "JOG_CODIGO";
            this.JOG_CODIGO.ReadOnly = true;
            this.JOG_CODIGO.Width = 40;
            // 
            // JOG_DATA
            // 
            this.JOG_DATA.HeaderText = "Data";
            this.JOG_DATA.Name = "JOG_DATA";
            this.JOG_DATA.ReadOnly = true;
            this.JOG_DATA.Width = 80;
            // 
            // JOG_HORA
            // 
            this.JOG_HORA.HeaderText = "Horário";
            this.JOG_HORA.Name = "JOG_HORA";
            this.JOG_HORA.ReadOnly = true;
            this.JOG_HORA.Width = 70;
            // 
            // EQU_BANDEIRA1
            // 
            this.EQU_BANDEIRA1.HeaderText = "";
            this.EQU_BANDEIRA1.Name = "EQU_BANDEIRA1";
            this.EQU_BANDEIRA1.ReadOnly = true;
            this.EQU_BANDEIRA1.Width = 50;
            // 
            // EQU_CODIGO1
            // 
            this.EQU_CODIGO1.HeaderText = "Equipe 1";
            this.EQU_CODIGO1.Name = "EQU_CODIGO1";
            this.EQU_CODIGO1.ReadOnly = true;
            this.EQU_CODIGO1.Width = 150;
            // 
            // JOG_GOLTIME1
            // 
            this.JOG_GOLTIME1.HeaderText = "Gols";
            this.JOG_GOLTIME1.Name = "JOG_GOLTIME1";
            this.JOG_GOLTIME1.Width = 60;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 20;
            // 
            // JOG_GOLTIME2
            // 
            this.JOG_GOLTIME2.HeaderText = "Gols";
            this.JOG_GOLTIME2.Name = "JOG_GOLTIME2";
            this.JOG_GOLTIME2.Width = 60;
            // 
            // EQU_CODIGO2
            // 
            this.EQU_CODIGO2.HeaderText = "Equipe 2";
            this.EQU_CODIGO2.Name = "EQU_CODIGO2";
            this.EQU_CODIGO2.ReadOnly = true;
            this.EQU_CODIGO2.Width = 150;
            // 
            // EQU_BANDEIRA2
            // 
            this.EQU_BANDEIRA2.HeaderText = "";
            this.EQU_BANDEIRA2.Name = "EQU_BANDEIRA2";
            this.EQU_BANDEIRA2.ReadOnly = true;
            this.EQU_BANDEIRA2.Width = 50;
            // 
            // JOG_LOCAL
            // 
            this.JOG_LOCAL.HeaderText = "Local";
            this.JOG_LOCAL.Name = "JOG_LOCAL";
            this.JOG_LOCAL.ReadOnly = true;
            this.JOG_LOCAL.Width = 150;
            // 
            // FAS_CODIGO
            // 
            this.FAS_CODIGO.HeaderText = "Fase";
            this.FAS_CODIGO.Name = "FAS_CODIGO";
            this.FAS_CODIGO.ReadOnly = true;
            this.FAS_CODIGO.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(534, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "* Obs: Para alterar o placar, dos jogos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(577, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "preencha a qtde de Gols ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(577, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "e Clique no botão Salvar.";
            // 
            // frmResultadosJogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 470);
            this.Controls.Add(this.grpDados);
            this.Controls.Add(this.grpBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResultadosJogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado dos Jogos";
            this.Activated += new System.EventHandler(this.frmResultadosJogos_Activated);
            this.grpBotoes.ResumeLayout(false);
            this.grpDados.ResumeLayout(false);
            this.grpDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBotoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox grpDados;
        private System.Windows.Forms.Label lGrupo;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lFase;
        private System.Windows.Forms.DataGridView dgvJogos;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_HORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQU_BANDEIRA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQU_CODIGO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_GOLTIME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_GOLTIME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQU_CODIGO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQU_BANDEIRA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOG_LOCAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAS_CODIGO;
        private System.Windows.Forms.ComboBox cbFase;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}