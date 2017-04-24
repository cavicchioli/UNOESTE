namespace appVictor
{
    partial class frmPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnLoadTeste = new System.Windows.Forms.Button();
            this.btnInicializar = new System.Windows.Forms.Button();
            this.btnLoadTreino = new System.Windows.Forms.Button();
            this.tabInformacoes = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTreino = new System.Windows.Forms.DataGridView();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvTeste = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvMatriz = new System.Windows.Forms.DataGridView();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.pnlParada = new System.Windows.Forms.GroupBox();
            this.ttbErro = new System.Windows.Forms.TextBox();
            this.ttbIteracao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlTransferencia = new System.Windows.Forms.GroupBox();
            this.rbTgHiperbolica = new System.Windows.Forms.RadioButton();
            this.rbLogistica = new System.Windows.Forms.RadioButton();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.pnlAprendizagem = new System.Windows.Forms.GroupBox();
            this.ttbAprendizagem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlNeuronios = new System.Windows.Forms.GroupBox();
            this.ttbSaida = new System.Windows.Forms.TextBox();
            this.ttbOculta = new System.Windows.Forms.TextBox();
            this.ttbEntrada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.mensagem = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabInformacoes.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreino)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeste)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).BeginInit();
            this.pnlConfig.SuspendLayout();
            this.pnlParada.SuspendLayout();
            this.pnlTransferencia.SuspendLayout();
            this.pnlAprendizagem.SuspendLayout();
            this.pnlNeuronios.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReiniciar);
            this.panel1.Controls.Add(this.btnLoadTeste);
            this.panel1.Controls.Add(this.btnInicializar);
            this.panel1.Controls.Add(this.btnLoadTreino);
            this.panel1.Location = new System.Drawing.Point(1, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 52);
            this.panel1.TabIndex = 6;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(428, 8);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(133, 34);
            this.btnReiniciar.TabIndex = 0;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnLoadTeste
            // 
            this.btnLoadTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTeste.Location = new System.Drawing.Point(289, 8);
            this.btnLoadTeste.Name = "btnLoadTeste";
            this.btnLoadTeste.Size = new System.Drawing.Size(133, 34);
            this.btnLoadTeste.TabIndex = 0;
            this.btnLoadTeste.Text = "Arquivo de Teste";
            this.btnLoadTeste.UseVisualStyleBackColor = true;
            this.btnLoadTeste.Click += new System.EventHandler(this.btnLoadTeste_Click);
            // 
            // btnInicializar
            // 
            this.btnInicializar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicializar.Location = new System.Drawing.Point(150, 8);
            this.btnInicializar.Name = "btnInicializar";
            this.btnInicializar.Size = new System.Drawing.Size(133, 34);
            this.btnInicializar.TabIndex = 0;
            this.btnInicializar.Text = "Inicializar Rede";
            this.btnInicializar.UseVisualStyleBackColor = true;
            this.btnInicializar.Click += new System.EventHandler(this.btnInicializar_Click);
            // 
            // btnLoadTreino
            // 
            this.btnLoadTreino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTreino.Location = new System.Drawing.Point(11, 8);
            this.btnLoadTreino.Name = "btnLoadTreino";
            this.btnLoadTreino.Size = new System.Drawing.Size(133, 34);
            this.btnLoadTreino.TabIndex = 0;
            this.btnLoadTreino.Text = "Arquivo de Treino";
            this.btnLoadTreino.UseVisualStyleBackColor = true;
            this.btnLoadTreino.Click += new System.EventHandler(this.btnLoadTreino_Click);
            // 
            // tabInformacoes
            // 
            this.tabInformacoes.Controls.Add(this.tabPage3);
            this.tabInformacoes.Controls.Add(this.tabPage4);
            this.tabInformacoes.Controls.Add(this.tabPage5);
            this.tabInformacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformacoes.Location = new System.Drawing.Point(-3, 393);
            this.tabInformacoes.Name = "tabInformacoes";
            this.tabInformacoes.SelectedIndex = 0;
            this.tabInformacoes.Size = new System.Drawing.Size(577, 312);
            this.tabInformacoes.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTreino);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(569, 284);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Arquivo de Treino";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvTreino
            // 
            this.dgvTreino.AllowUserToAddRows = false;
            this.dgvTreino.AllowUserToDeleteRows = false;
            this.dgvTreino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreino.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x1,
            this.x2,
            this.x3,
            this.x4,
            this.x5,
            this.x6,
            this.classe});
            this.dgvTreino.Location = new System.Drawing.Point(0, 0);
            this.dgvTreino.Name = "dgvTreino";
            this.dgvTreino.ReadOnly = true;
            this.dgvTreino.Size = new System.Drawing.Size(573, 284);
            this.dgvTreino.TabIndex = 0;
            // 
            // x1
            // 
            this.x1.HeaderText = "X1";
            this.x1.Name = "x1";
            this.x1.ReadOnly = true;
            // 
            // x2
            // 
            this.x2.HeaderText = "X2";
            this.x2.Name = "x2";
            this.x2.ReadOnly = true;
            // 
            // x3
            // 
            this.x3.HeaderText = "X3";
            this.x3.Name = "x3";
            this.x3.ReadOnly = true;
            // 
            // x4
            // 
            this.x4.HeaderText = "X4";
            this.x4.Name = "x4";
            this.x4.ReadOnly = true;
            // 
            // x5
            // 
            this.x5.HeaderText = "X5";
            this.x5.Name = "x5";
            this.x5.ReadOnly = true;
            // 
            // x6
            // 
            this.x6.HeaderText = "X6";
            this.x6.Name = "x6";
            this.x6.ReadOnly = true;
            // 
            // classe
            // 
            this.classe.HeaderText = "Classe";
            this.classe.Name = "classe";
            this.classe.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvTeste);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(569, 284);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Arquivo de Teste";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvTeste
            // 
            this.dgvTeste.AllowUserToAddRows = false;
            this.dgvTeste.AllowUserToDeleteRows = false;
            this.dgvTeste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvTeste.Location = new System.Drawing.Point(0, 0);
            this.dgvTeste.Name = "dgvTeste";
            this.dgvTeste.ReadOnly = true;
            this.dgvTeste.Size = new System.Drawing.Size(573, 284);
            this.dgvTeste.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "X3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "X4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "X5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "X6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Classe";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvMatriz);
            this.tabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(569, 284);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Matriz de Confusão";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvMatriz
            // 
            this.dgvMatriz.AllowUserToAddRows = false;
            this.dgvMatriz.AllowUserToDeleteRows = false;
            this.dgvMatriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriz.Location = new System.Drawing.Point(0, 0);
            this.dgvMatriz.Name = "dgvMatriz";
            this.dgvMatriz.ReadOnly = true;
            this.dgvMatriz.Size = new System.Drawing.Size(573, 284);
            this.dgvMatriz.TabIndex = 0;
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfig.Controls.Add(this.pnlParada);
            this.pnlConfig.Controls.Add(this.pnlTransferencia);
            this.pnlConfig.Controls.Add(this.pnlAprendizagem);
            this.pnlConfig.Controls.Add(this.pnlNeuronios);
            this.pnlConfig.Location = new System.Drawing.Point(25, 127);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(518, 220);
            this.pnlConfig.TabIndex = 8;
            // 
            // pnlParada
            // 
            this.pnlParada.Controls.Add(this.ttbErro);
            this.pnlParada.Controls.Add(this.ttbIteracao);
            this.pnlParada.Controls.Add(this.label5);
            this.pnlParada.Controls.Add(this.label6);
            this.pnlParada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlParada.Location = new System.Drawing.Point(262, 11);
            this.pnlParada.Name = "pnlParada";
            this.pnlParada.Size = new System.Drawing.Size(247, 80);
            this.pnlParada.TabIndex = 20;
            this.pnlParada.TabStop = false;
            this.pnlParada.Text = "Critério de Parada";
            // 
            // ttbErro
            // 
            this.ttbErro.Location = new System.Drawing.Point(91, 51);
            this.ttbErro.Name = "ttbErro";
            this.ttbErro.Size = new System.Drawing.Size(100, 21);
            this.ttbErro.TabIndex = 2;
            // 
            // ttbIteracao
            // 
            this.ttbIteracao.Location = new System.Drawing.Point(91, 24);
            this.ttbIteracao.Name = "ttbIteracao";
            this.ttbIteracao.Size = new System.Drawing.Size(100, 21);
            this.ttbIteracao.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Por Erro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Por Iteração:";
            // 
            // pnlTransferencia
            // 
            this.pnlTransferencia.Controls.Add(this.rbTgHiperbolica);
            this.pnlTransferencia.Controls.Add(this.rbLogistica);
            this.pnlTransferencia.Controls.Add(this.rbLinear);
            this.pnlTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTransferencia.Location = new System.Drawing.Point(262, 97);
            this.pnlTransferencia.Name = "pnlTransferencia";
            this.pnlTransferencia.Size = new System.Drawing.Size(247, 116);
            this.pnlTransferencia.TabIndex = 18;
            this.pnlTransferencia.TabStop = false;
            this.pnlTransferencia.Text = "Função de Transferência";
            // 
            // rbTgHiperbolica
            // 
            this.rbTgHiperbolica.AutoSize = true;
            this.rbTgHiperbolica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTgHiperbolica.Location = new System.Drawing.Point(12, 77);
            this.rbTgHiperbolica.Name = "rbTgHiperbolica";
            this.rbTgHiperbolica.Size = new System.Drawing.Size(143, 19);
            this.rbTgHiperbolica.TabIndex = 0;
            this.rbTgHiperbolica.TabStop = true;
            this.rbTgHiperbolica.Text = "Tangente Hiperbólica";
            this.rbTgHiperbolica.UseVisualStyleBackColor = true;
            // 
            // rbLogistica
            // 
            this.rbLogistica.AutoSize = true;
            this.rbLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLogistica.Location = new System.Drawing.Point(12, 52);
            this.rbLogistica.Name = "rbLogistica";
            this.rbLogistica.Size = new System.Drawing.Size(74, 19);
            this.rbLogistica.TabIndex = 0;
            this.rbLogistica.TabStop = true;
            this.rbLogistica.Text = "Logística";
            this.rbLogistica.UseVisualStyleBackColor = true;
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLinear.Location = new System.Drawing.Point(12, 27);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(60, 19);
            this.rbLinear.TabIndex = 0;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            // 
            // pnlAprendizagem
            // 
            this.pnlAprendizagem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlAprendizagem.Controls.Add(this.ttbAprendizagem);
            this.pnlAprendizagem.Controls.Add(this.label4);
            this.pnlAprendizagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pnlAprendizagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAprendizagem.Location = new System.Drawing.Point(9, 157);
            this.pnlAprendizagem.Name = "pnlAprendizagem";
            this.pnlAprendizagem.Size = new System.Drawing.Size(247, 56);
            this.pnlAprendizagem.TabIndex = 16;
            this.pnlAprendizagem.TabStop = false;
            this.pnlAprendizagem.Text = "Taxa de Aprendizagem";
            // 
            // ttbAprendizagem
            // 
            this.ttbAprendizagem.Location = new System.Drawing.Point(34, 27);
            this.ttbAprendizagem.Name = "ttbAprendizagem";
            this.ttbAprendizagem.Size = new System.Drawing.Size(150, 21);
            this.ttbAprendizagem.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "N:";
            // 
            // pnlNeuronios
            // 
            this.pnlNeuronios.Controls.Add(this.ttbSaida);
            this.pnlNeuronios.Controls.Add(this.ttbOculta);
            this.pnlNeuronios.Controls.Add(this.ttbEntrada);
            this.pnlNeuronios.Controls.Add(this.label3);
            this.pnlNeuronios.Controls.Add(this.label2);
            this.pnlNeuronios.Controls.Add(this.label1);
            this.pnlNeuronios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNeuronios.Location = new System.Drawing.Point(9, 11);
            this.pnlNeuronios.Name = "pnlNeuronios";
            this.pnlNeuronios.Size = new System.Drawing.Size(247, 140);
            this.pnlNeuronios.TabIndex = 17;
            this.pnlNeuronios.TabStop = false;
            this.pnlNeuronios.Text = "Número de Neurônios";
            // 
            // ttbSaida
            // 
            this.ttbSaida.Location = new System.Drawing.Point(135, 110);
            this.ttbSaida.Name = "ttbSaida";
            this.ttbSaida.Size = new System.Drawing.Size(100, 21);
            this.ttbSaida.TabIndex = 2;
            // 
            // ttbOculta
            // 
            this.ttbOculta.Location = new System.Drawing.Point(135, 73);
            this.ttbOculta.Name = "ttbOculta";
            this.ttbOculta.Size = new System.Drawing.Size(100, 21);
            this.ttbOculta.TabIndex = 2;
            // 
            // ttbEntrada
            // 
            this.ttbEntrada.Location = new System.Drawing.Point(135, 34);
            this.ttbEntrada.Name = "ttbEntrada";
            this.ttbEntrada.Size = new System.Drawing.Size(100, 21);
            this.ttbEntrada.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Camada Oculta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camada de Saída:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camada de Entrada:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 60);
            this.panel2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bebas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(29, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(505, 43);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rede Neural MLP:   Backpropagation";
            // 
            // mensagem
            // 
            this.mensagem.AutoSize = true;
            this.mensagem.Font = new System.Drawing.Font("Bebas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensagem.ForeColor = System.Drawing.Color.Blue;
            this.mensagem.Location = new System.Drawing.Point(8, 357);
            this.mensagem.Name = "mensagem";
            this.mensagem.Size = new System.Drawing.Size(0, 25);
            this.mensagem.TabIndex = 10;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 706);
            this.Controls.Add(this.mensagem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.tabInformacoes);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rede Neural MLP: Backpropagation";
            this.panel1.ResumeLayout(false);
            this.tabInformacoes.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreino)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeste)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).EndInit();
            this.pnlConfig.ResumeLayout(false);
            this.pnlParada.ResumeLayout(false);
            this.pnlParada.PerformLayout();
            this.pnlTransferencia.ResumeLayout(false);
            this.pnlTransferencia.PerformLayout();
            this.pnlAprendizagem.ResumeLayout(false);
            this.pnlAprendizagem.PerformLayout();
            this.pnlNeuronios.ResumeLayout(false);
            this.pnlNeuronios.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnLoadTeste;
        private System.Windows.Forms.Button btnInicializar;
        private System.Windows.Forms.Button btnLoadTreino;
        private System.Windows.Forms.TabControl tabInformacoes;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.GroupBox pnlParada;
        private System.Windows.Forms.TextBox ttbErro;
        private System.Windows.Forms.TextBox ttbIteracao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox pnlTransferencia;
        private System.Windows.Forms.GroupBox pnlAprendizagem;
        private System.Windows.Forms.TextBox ttbAprendizagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox pnlNeuronios;
        private System.Windows.Forms.TextBox ttbSaida;
        private System.Windows.Forms.TextBox ttbOculta;
        private System.Windows.Forms.TextBox ttbEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTreino;
        private System.Windows.Forms.DataGridView dgvTeste;
        private System.Windows.Forms.DataGridView dgvMatriz;
        private System.Windows.Forms.RadioButton rbTgHiperbolica;
        private System.Windows.Forms.RadioButton rbLogistica;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x3;
        private System.Windows.Forms.DataGridViewTextBoxColumn x4;
        private System.Windows.Forms.DataGridViewTextBoxColumn x5;
        private System.Windows.Forms.DataGridViewTextBoxColumn x6;
        private System.Windows.Forms.DataGridViewTextBoxColumn classe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label mensagem;
    }
}

