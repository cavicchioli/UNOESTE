namespace Copa2014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jogadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultadoJogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaDeJogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fasesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jogadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.movimentoToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gruposToolStripMenuItem,
            this.fasesToolStripMenuItem,
            this.equipesToolStripMenuItem,
            this.jogosToolStripMenuItem,
            this.jogadoresToolStripMenuItem1});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // fasesToolStripMenuItem
            // 
            this.fasesToolStripMenuItem.Name = "fasesToolStripMenuItem";
            this.fasesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fasesToolStripMenuItem.Text = "Fases";
            this.fasesToolStripMenuItem.Click += new System.EventHandler(this.fasesToolStripMenuItem_Click);
            // 
            // equipesToolStripMenuItem
            // 
            this.equipesToolStripMenuItem.Name = "equipesToolStripMenuItem";
            this.equipesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.equipesToolStripMenuItem.Text = "Equipes";
            this.equipesToolStripMenuItem.Click += new System.EventHandler(this.equipesToolStripMenuItem_Click);
            // 
            // jogosToolStripMenuItem
            // 
            this.jogosToolStripMenuItem.Name = "jogosToolStripMenuItem";
            this.jogosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jogosToolStripMenuItem.Text = "Jogos";
            this.jogosToolStripMenuItem.Click += new System.EventHandler(this.jogosToolStripMenuItem_Click);
            // 
            // jogadoresToolStripMenuItem1
            // 
            this.jogadoresToolStripMenuItem1.Name = "jogadoresToolStripMenuItem1";
            this.jogadoresToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.jogadoresToolStripMenuItem1.Text = "Jogadores";
            this.jogadoresToolStripMenuItem1.Click += new System.EventHandler(this.jogadoresToolStripMenuItem1_Click);
            // 
            // movimentoToolStripMenuItem
            // 
            this.movimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultadoJogosToolStripMenuItem});
            this.movimentoToolStripMenuItem.Name = "movimentoToolStripMenuItem";
            this.movimentoToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.movimentoToolStripMenuItem.Text = "Movimento";
            // 
            // resultadoJogosToolStripMenuItem
            // 
            this.resultadoJogosToolStripMenuItem.Name = "resultadoJogosToolStripMenuItem";
            this.resultadoJogosToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.resultadoJogosToolStripMenuItem.Text = "Resultado Jogos";
            this.resultadoJogosToolStripMenuItem.Click += new System.EventHandler(this.resultadoJogosToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelaDeJogosToolStripMenuItem,
            this.equipesToolStripMenuItem1,
            this.fasesToolStripMenuItem1,
            this.gruposToolStripMenuItem1,
            this.jogadoresToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // tabelaDeJogosToolStripMenuItem
            // 
            this.tabelaDeJogosToolStripMenuItem.Name = "tabelaDeJogosToolStripMenuItem";
            this.tabelaDeJogosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.tabelaDeJogosToolStripMenuItem.Text = "Tabela de Jogos";
            // 
            // equipesToolStripMenuItem1
            // 
            this.equipesToolStripMenuItem1.Name = "equipesToolStripMenuItem1";
            this.equipesToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.equipesToolStripMenuItem1.Text = "Equipes";
            // 
            // fasesToolStripMenuItem1
            // 
            this.fasesToolStripMenuItem1.Name = "fasesToolStripMenuItem1";
            this.fasesToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.fasesToolStripMenuItem1.Text = "Fases";
            // 
            // gruposToolStripMenuItem1
            // 
            this.gruposToolStripMenuItem1.Name = "gruposToolStripMenuItem1";
            this.gruposToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.gruposToolStripMenuItem1.Text = "Grupos";
            this.gruposToolStripMenuItem1.Click += new System.EventHandler(this.gruposToolStripMenuItem1_Click);
            // 
            // jogadoresToolStripMenuItem
            // 
            this.jogadoresToolStripMenuItem.Name = "jogadoresToolStripMenuItem";
            this.jogadoresToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.jogadoresToolStripMenuItem.Text = "Jogadores";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Copa2014.Properties.Resources.Logotipo_2014;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Copa 2014";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaDeJogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fasesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jogadoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem movimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultadoJogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jogadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
    }
}

