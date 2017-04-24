namespace Backpropagation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tcpDefinicoes = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbHiperbolica = new System.Windows.Forms.RadioButton();
            this.rdbLogistica = new System.Windows.Forms.RadioButton();
            this.rdbLinear = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIntera = new System.Windows.Forms.TextBox();
            this.txtTaxaAprende = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTreinamento = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtArquivoTreina = new System.Windows.Forms.TextBox();
            this.btnArquivoTreina = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNeuroSaida = new System.Windows.Forms.TextBox();
            this.txtNeuroOculto = new System.Windows.Forms.TextBox();
            this.txtNeuroEntrada = new System.Windows.Forms.TextBox();
            this.tcpTreinamento = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.graficoTreinamento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelTxtItera = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGraficoItera = new System.Windows.Forms.TextBox();
            this.txtGraficoAtraso = new System.Windows.Forms.TextBox();
            this.btnTreinamento = new System.Windows.Forms.Button();
            this.tcpTeste = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.dgvMatrizConfusa = new System.Windows.Forms.DataGridView();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dgvTeste = new System.Windows.Forms.DataGridView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pbTeste = new System.Windows.Forms.ProgressBar();
            this.btnTeste = new System.Windows.Forms.Button();
            this.txtArquivoTeste = new System.Windows.Forms.TextBox();
            this.btnArquivoTeste = new System.Windows.Forms.Button();
            this.openFileAmostras = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tcPrincipal.SuspendLayout();
            this.tcpDefinicoes.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreinamento)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcpTreinamento.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoTreinamento)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tcpTeste.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizConfusa)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeste)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tcpDefinicoes);
            this.tcPrincipal.Controls.Add(this.tcpTreinamento);
            this.tcPrincipal.Controls.Add(this.tcpTeste);
            this.tcPrincipal.Location = new System.Drawing.Point(10, 61);
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(770, 500);
            this.tcPrincipal.TabIndex = 0;
            // 
            // tcpDefinicoes
            // 
            this.tcpDefinicoes.Controls.Add(this.groupBox5);
            this.tcpDefinicoes.Controls.Add(this.groupBox4);
            this.tcpDefinicoes.Controls.Add(this.groupBox3);
            this.tcpDefinicoes.Controls.Add(this.groupBox2);
            this.tcpDefinicoes.Controls.Add(this.groupBox1);
            this.tcpDefinicoes.Location = new System.Drawing.Point(4, 22);
            this.tcpDefinicoes.Name = "tcpDefinicoes";
            this.tcpDefinicoes.Padding = new System.Windows.Forms.Padding(3);
            this.tcpDefinicoes.Size = new System.Drawing.Size(762, 474);
            this.tcpDefinicoes.TabIndex = 0;
            this.tcpDefinicoes.Text = "Rede - Definições";
            this.tcpDefinicoes.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbHiperbolica);
            this.groupBox5.Controls.Add(this.rdbLogistica);
            this.groupBox5.Controls.Add(this.rdbLinear);
            this.groupBox5.Location = new System.Drawing.Point(526, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Função Treinamento";
            // 
            // rdbHiperbolica
            // 
            this.rdbHiperbolica.AutoSize = true;
            this.rdbHiperbolica.Location = new System.Drawing.Point(29, 69);
            this.rdbHiperbolica.Name = "rdbHiperbolica";
            this.rdbHiperbolica.Size = new System.Drawing.Size(127, 17);
            this.rdbHiperbolica.TabIndex = 2;
            this.rdbHiperbolica.Text = "Tangente Hiperbólica";
            this.rdbHiperbolica.UseVisualStyleBackColor = true;
            // 
            // rdbLogistica
            // 
            this.rdbLogistica.AutoSize = true;
            this.rdbLogistica.Location = new System.Drawing.Point(29, 46);
            this.rdbLogistica.Name = "rdbLogistica";
            this.rdbLogistica.Size = new System.Drawing.Size(69, 17);
            this.rdbLogistica.TabIndex = 1;
            this.rdbLogistica.Text = "Logística";
            this.rdbLogistica.UseVisualStyleBackColor = true;
            // 
            // rdbLinear
            // 
            this.rdbLinear.AutoSize = true;
            this.rdbLinear.Checked = true;
            this.rdbLinear.Location = new System.Drawing.Point(29, 22);
            this.rdbLinear.Name = "rdbLinear";
            this.rdbLinear.Size = new System.Drawing.Size(54, 17);
            this.rdbLinear.TabIndex = 0;
            this.rdbLinear.TabStop = true;
            this.rdbLinear.Text = "Linear";
            this.rdbLinear.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtIntera);
            this.groupBox4.Controls.Add(this.txtTaxaAprende);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(267, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Definições Treinamento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Número de Iterações";
            // 
            // txtIntera
            // 
            this.txtIntera.Location = new System.Drawing.Point(144, 45);
            this.txtIntera.Name = "txtIntera";
            this.txtIntera.Size = new System.Drawing.Size(50, 20);
            this.txtIntera.TabIndex = 2;
            this.txtIntera.Text = "500";
            // 
            // txtTaxaAprende
            // 
            this.txtTaxaAprende.Location = new System.Drawing.Point(144, 19);
            this.txtTaxaAprende.Name = "txtTaxaAprende";
            this.txtTaxaAprende.Size = new System.Drawing.Size(50, 20);
            this.txtTaxaAprende.TabIndex = 1;
            this.txtTaxaAprende.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Taxa de Aprendizagem";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTreinamento);
            this.groupBox3.Location = new System.Drawing.Point(6, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(750, 292);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Amostras";
            // 
            // dgvTreinamento
            // 
            this.dgvTreinamento.AllowUserToAddRows = false;
            this.dgvTreinamento.AllowUserToDeleteRows = false;
            this.dgvTreinamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreinamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreinamento.Location = new System.Drawing.Point(10, 19);
            this.dgvTreinamento.Name = "dgvTreinamento";
            this.dgvTreinamento.ReadOnly = true;
            this.dgvTreinamento.Size = new System.Drawing.Size(728, 267);
            this.dgvTreinamento.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtArquivoTreina);
            this.groupBox2.Controls.Add(this.btnArquivoTreina);
            this.groupBox2.Location = new System.Drawing.Point(6, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arquivo de Dados para Treinamento";
            // 
            // txtArquivoTreina
            // 
            this.txtArquivoTreina.Location = new System.Drawing.Point(273, 21);
            this.txtArquivoTreina.Name = "txtArquivoTreina";
            this.txtArquivoTreina.ReadOnly = true;
            this.txtArquivoTreina.Size = new System.Drawing.Size(465, 20);
            this.txtArquivoTreina.TabIndex = 1;
            // 
            // btnArquivoTreina
            // 
            this.btnArquivoTreina.Location = new System.Drawing.Point(10, 19);
            this.btnArquivoTreina.Name = "btnArquivoTreina";
            this.btnArquivoTreina.Size = new System.Drawing.Size(257, 23);
            this.btnArquivoTreina.TabIndex = 0;
            this.btnArquivoTreina.Text = "Selecionar Arquivo de Dados para Treinamento";
            this.btnArquivoTreina.UseVisualStyleBackColor = true;
            this.btnArquivoTreina.Click += new System.EventHandler(this.btnArquivoTreina_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNeuroSaida);
            this.groupBox1.Controls.Add(this.txtNeuroOculto);
            this.groupBox1.Controls.Add(this.txtNeuroEntrada);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rede Neural";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Neurônios Camada Saída";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Neurônios Camada Oculta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Neurônios Camada Entrada";
            // 
            // txtNeuroSaida
            // 
            this.txtNeuroSaida.Location = new System.Drawing.Point(163, 72);
            this.txtNeuroSaida.Name = "txtNeuroSaida";
            this.txtNeuroSaida.ReadOnly = true;
            this.txtNeuroSaida.Size = new System.Drawing.Size(50, 20);
            this.txtNeuroSaida.TabIndex = 2;
            // 
            // txtNeuroOculto
            // 
            this.txtNeuroOculto.Location = new System.Drawing.Point(163, 46);
            this.txtNeuroOculto.Name = "txtNeuroOculto";
            this.txtNeuroOculto.ReadOnly = true;
            this.txtNeuroOculto.Size = new System.Drawing.Size(50, 20);
            this.txtNeuroOculto.TabIndex = 1;
            // 
            // txtNeuroEntrada
            // 
            this.txtNeuroEntrada.Location = new System.Drawing.Point(163, 20);
            this.txtNeuroEntrada.Name = "txtNeuroEntrada";
            this.txtNeuroEntrada.ReadOnly = true;
            this.txtNeuroEntrada.Size = new System.Drawing.Size(50, 20);
            this.txtNeuroEntrada.TabIndex = 0;
            // 
            // tcpTreinamento
            // 
            this.tcpTreinamento.Controls.Add(this.groupBox7);
            this.tcpTreinamento.Controls.Add(this.groupBox6);
            this.tcpTreinamento.Location = new System.Drawing.Point(4, 22);
            this.tcpTreinamento.Name = "tcpTreinamento";
            this.tcpTreinamento.Padding = new System.Windows.Forms.Padding(3);
            this.tcpTreinamento.Size = new System.Drawing.Size(762, 474);
            this.tcpTreinamento.TabIndex = 1;
            this.tcpTreinamento.Text = "Rede - Treinamento";
            this.tcpTreinamento.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.graficoTreinamento);
            this.groupBox7.Location = new System.Drawing.Point(6, 62);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(750, 406);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Gráfico - Treinamento da Rede";
            // 
            // graficoTreinamento
            // 
            chartArea2.Name = "ChartArea1";
            this.graficoTreinamento.ChartAreas.Add(chartArea2);
            this.graficoTreinamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend2.Name = "Legend1";
            this.graficoTreinamento.Legends.Add(legend2);
            this.graficoTreinamento.Location = new System.Drawing.Point(6, 19);
            this.graficoTreinamento.Name = "graficoTreinamento";
            this.graficoTreinamento.Size = new System.Drawing.Size(738, 381);
            this.graficoTreinamento.TabIndex = 0;
            this.graficoTreinamento.Text = "Treinamento";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelTxtItera);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtGraficoItera);
            this.groupBox6.Controls.Add(this.txtGraficoAtraso);
            this.groupBox6.Controls.Add(this.btnTreinamento);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(750, 50);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Treinamento";
            // 
            // labelTxtItera
            // 
            this.labelTxtItera.AutoSize = true;
            this.labelTxtItera.Location = new System.Drawing.Point(634, 24);
            this.labelTxtItera.Name = "labelTxtItera";
            this.labelTxtItera.Size = new System.Drawing.Size(46, 13);
            this.labelTxtItera.TabIndex = 4;
            this.labelTxtItera.Text = "Iteração";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Atraso";
            // 
            // txtGraficoItera
            // 
            this.txtGraficoItera.Location = new System.Drawing.Point(686, 24);
            this.txtGraficoItera.Name = "txtGraficoItera";
            this.txtGraficoItera.Size = new System.Drawing.Size(40, 20);
            this.txtGraficoItera.TabIndex = 2;
            this.txtGraficoItera.Text = "5";
            // 
            // txtGraficoAtraso
            // 
            this.txtGraficoAtraso.Location = new System.Drawing.Point(586, 24);
            this.txtGraficoAtraso.Name = "txtGraficoAtraso";
            this.txtGraficoAtraso.Size = new System.Drawing.Size(40, 20);
            this.txtGraficoAtraso.TabIndex = 1;
            this.txtGraficoAtraso.Text = "0";
            // 
            // btnTreinamento
            // 
            this.btnTreinamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreinamento.Location = new System.Drawing.Point(6, 14);
            this.btnTreinamento.Name = "btnTreinamento";
            this.btnTreinamento.Size = new System.Drawing.Size(500, 30);
            this.btnTreinamento.TabIndex = 0;
            this.btnTreinamento.Text = "INICIAR TREINAMENTO";
            this.btnTreinamento.UseVisualStyleBackColor = true;
            this.btnTreinamento.Click += new System.EventHandler(this.btnTreinamento_Click);
            // 
            // tcpTeste
            // 
            this.tcpTeste.Controls.Add(this.groupBox11);
            this.tcpTeste.Controls.Add(this.groupBox10);
            this.tcpTeste.Controls.Add(this.groupBox9);
            this.tcpTeste.Controls.Add(this.groupBox8);
            this.tcpTeste.Location = new System.Drawing.Point(4, 22);
            this.tcpTeste.Name = "tcpTeste";
            this.tcpTeste.Padding = new System.Windows.Forms.Padding(3);
            this.tcpTeste.Size = new System.Drawing.Size(762, 474);
            this.tcpTeste.TabIndex = 2;
            this.tcpTeste.Text = "Rede - Teste";
            this.tcpTeste.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.dgvMatrizConfusa);
            this.groupBox11.Location = new System.Drawing.Point(426, 277);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(330, 191);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Matriz de Confusão";
            // 
            // dgvMatrizConfusa
            // 
            this.dgvMatrizConfusa.AllowUserToAddRows = false;
            this.dgvMatrizConfusa.AllowUserToDeleteRows = false;
            this.dgvMatrizConfusa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatrizConfusa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrizConfusa.Location = new System.Drawing.Point(6, 19);
            this.dgvMatrizConfusa.Name = "dgvMatrizConfusa";
            this.dgvMatrizConfusa.ReadOnly = true;
            this.dgvMatrizConfusa.Size = new System.Drawing.Size(318, 166);
            this.dgvMatrizConfusa.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dgvResultados);
            this.groupBox10.Location = new System.Drawing.Point(426, 101);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(330, 170);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Resultados";
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(6, 20);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(318, 144);
            this.dgvResultados.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dgvTeste);
            this.groupBox9.Location = new System.Drawing.Point(6, 101);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(414, 367);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Amostras";
            // 
            // dgvTeste
            // 
            this.dgvTeste.AllowUserToAddRows = false;
            this.dgvTeste.AllowUserToDeleteRows = false;
            this.dgvTeste.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeste.Location = new System.Drawing.Point(6, 19);
            this.dgvTeste.Name = "dgvTeste";
            this.dgvTeste.ReadOnly = true;
            this.dgvTeste.Size = new System.Drawing.Size(402, 342);
            this.dgvTeste.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pbTeste);
            this.groupBox8.Controls.Add(this.btnTeste);
            this.groupBox8.Controls.Add(this.txtArquivoTeste);
            this.groupBox8.Controls.Add(this.btnArquivoTeste);
            this.groupBox8.Location = new System.Drawing.Point(6, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(750, 89);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Arquivo de Dados para Teste";
            // 
            // pbTeste
            // 
            this.pbTeste.Location = new System.Drawing.Point(274, 48);
            this.pbTeste.Name = "pbTeste";
            this.pbTeste.Size = new System.Drawing.Size(464, 29);
            this.pbTeste.TabIndex = 3;
            // 
            // btnTeste
            // 
            this.btnTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeste.Location = new System.Drawing.Point(10, 47);
            this.btnTeste.Name = "btnTeste";
            this.btnTeste.Size = new System.Drawing.Size(257, 30);
            this.btnTeste.TabIndex = 2;
            this.btnTeste.Text = "INICIAR TESTE";
            this.btnTeste.UseVisualStyleBackColor = true;
            this.btnTeste.Click += new System.EventHandler(this.btnTeste_Click);
            // 
            // txtArquivoTeste
            // 
            this.txtArquivoTeste.Location = new System.Drawing.Point(273, 21);
            this.txtArquivoTeste.Name = "txtArquivoTeste";
            this.txtArquivoTeste.ReadOnly = true;
            this.txtArquivoTeste.Size = new System.Drawing.Size(465, 20);
            this.txtArquivoTeste.TabIndex = 1;
            // 
            // btnArquivoTeste
            // 
            this.btnArquivoTeste.Location = new System.Drawing.Point(10, 19);
            this.btnArquivoTeste.Name = "btnArquivoTeste";
            this.btnArquivoTeste.Size = new System.Drawing.Size(257, 23);
            this.btnArquivoTeste.TabIndex = 0;
            this.btnArquivoTeste.Text = "Selecionar Arquivo de Dados para Teste";
            this.btnArquivoTeste.UseVisualStyleBackColor = true;
            this.btnArquivoTeste.Click += new System.EventHandler(this.btnArquivoTeste_Click);
            // 
            // openFileAmostras
            // 
            this.openFileAmostras.DefaultExt = "cvs";
            this.openFileAmostras.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            this.openFileAmostras.InitialDirectory = "@\"C:\\\"";
            this.openFileAmostras.RestoreDirectory = true;
            this.openFileAmostras.Title = "Carregar Amostras";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 45);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(687, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Desenvolvido por";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(592, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Victor Cavichiolli - RA: 0261030370";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(370, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Inteligência Artificial";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(382, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Redes Neurais";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tcPrincipal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inteligência Artificial - Trabalho Redes Neurais - MLP Back Propagatinon";
            this.tcPrincipal.ResumeLayout(false);
            this.tcpDefinicoes.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreinamento)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcpTreinamento.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graficoTreinamento)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tcpTeste.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrizConfusa)).EndInit();
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeste)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tcpDefinicoes;
        private System.Windows.Forms.TabPage tcpTreinamento;
        private System.Windows.Forms.TabPage tcpTeste;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtArquivoTreina;
        private System.Windows.Forms.Button btnArquivoTreina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNeuroSaida;
        private System.Windows.Forms.TextBox txtNeuroOculto;
        private System.Windows.Forms.TextBox txtNeuroEntrada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTreinamento;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIntera;
        private System.Windows.Forms.TextBox txtTaxaAprende;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbHiperbolica;
        private System.Windows.Forms.RadioButton rdbLogistica;
        private System.Windows.Forms.RadioButton rdbLinear;
        private System.Windows.Forms.OpenFileDialog openFileAmostras;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnTreinamento;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoTreinamento;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dgvTeste;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnTeste;
        private System.Windows.Forms.TextBox txtArquivoTeste;
        private System.Windows.Forms.Button btnArquivoTeste;
        private System.Windows.Forms.DataGridView dgvMatrizConfusa;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.ProgressBar pbTeste;
        private System.Windows.Forms.Label labelTxtItera;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGraficoItera;
        private System.Windows.Forms.TextBox txtGraficoAtraso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

