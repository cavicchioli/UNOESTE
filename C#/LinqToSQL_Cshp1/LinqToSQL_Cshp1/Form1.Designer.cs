namespace LinqToSQL_Cshp1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeByIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeProceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenMostExpensiveProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarOuIncluirClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem,
            this.operaçãoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(510, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelasToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.storeProceduresToolStripMenuItem});
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // tabelasToolStripMenuItem
            // 
            this.tabelasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerstoolStripMenuItem1,
            this.employessToolStripMenuItem,
            this.orderToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.productsToolStripMenuItem});
            this.tabelasToolStripMenuItem.Name = "tabelasToolStripMenuItem";
            this.tabelasToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.tabelasToolStripMenuItem.Text = "Tabelas";
            // 
            // customerstoolStripMenuItem1
            // 
            this.customerstoolStripMenuItem1.Name = "customerstoolStripMenuItem1";
            this.customerstoolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.customerstoolStripMenuItem1.Text = "Customers";
            this.customerstoolStripMenuItem1.Click += new System.EventHandler(this.customerstoolStripMenuItem1_Click);
            // 
            // employessToolStripMenuItem
            // 
            this.employessToolStripMenuItem.Name = "employessToolStripMenuItem";
            this.employessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.employessToolStripMenuItem.Text = "Employess";
            this.employessToolStripMenuItem.Click += new System.EventHandler(this.employessToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.orderToolStripMenuItem.Text = "Order";
            this.orderToolStripMenuItem.Click += new System.EventHandler(this.orderToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesByToolStripMenuItem,
            this.salesByCategoryToolStripMenuItem,
            this.employeeByIDToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // employeesByToolStripMenuItem
            // 
            this.employeesByToolStripMenuItem.Name = "employeesByToolStripMenuItem";
            this.employeesByToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.employeesByToolStripMenuItem.Text = "Orders by ID";
            this.employeesByToolStripMenuItem.Click += new System.EventHandler(this.employeesByToolStripMenuItem_Click);
            // 
            // salesByCategoryToolStripMenuItem
            // 
            this.salesByCategoryToolStripMenuItem.Name = "salesByCategoryToolStripMenuItem";
            this.salesByCategoryToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.salesByCategoryToolStripMenuItem.Text = "Orders and Details";
            this.salesByCategoryToolStripMenuItem.Click += new System.EventHandler(this.salesByCategoryToolStripMenuItem_Click);
            // 
            // employeeByIDToolStripMenuItem
            // 
            this.employeeByIDToolStripMenuItem.Name = "employeeByIDToolStripMenuItem";
            this.employeeByIDToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.employeeByIDToolStripMenuItem.Text = "Employee by ID";
            this.employeeByIDToolStripMenuItem.Click += new System.EventHandler(this.employeeByIDToolStripMenuItem_Click);
            // 
            // storeProceduresToolStripMenuItem
            // 
            this.storeProceduresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesByYearToolStripMenuItem,
            this.tenMostExpensiveProductsToolStripMenuItem});
            this.storeProceduresToolStripMenuItem.Name = "storeProceduresToolStripMenuItem";
            this.storeProceduresToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.storeProceduresToolStripMenuItem.Text = "Store Procedures";
            // 
            // salesByYearToolStripMenuItem
            // 
            this.salesByYearToolStripMenuItem.Name = "salesByYearToolStripMenuItem";
            this.salesByYearToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.salesByYearToolStripMenuItem.Text = "Sales by Year";
            this.salesByYearToolStripMenuItem.Click += new System.EventHandler(this.salesByYearToolStripMenuItem_Click);
            // 
            // tenMostExpensiveProductsToolStripMenuItem
            // 
            this.tenMostExpensiveProductsToolStripMenuItem.Name = "tenMostExpensiveProductsToolStripMenuItem";
            this.tenMostExpensiveProductsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.tenMostExpensiveProductsToolStripMenuItem.Text = "Ten Most Expensive Products";
            this.tenMostExpensiveProductsToolStripMenuItem.Click += new System.EventHandler(this.tenMostExpensiveProductsToolStripMenuItem_Click);
            // 
            // operaçãoToolStripMenuItem
            // 
            this.operaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarOuIncluirClienteToolStripMenuItem,
            this.excluirClienteToolStripMenuItem});
            this.operaçãoToolStripMenuItem.Name = "operaçãoToolStripMenuItem";
            this.operaçãoToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.operaçãoToolStripMenuItem.Text = "Movimento";
            // 
            // atualizarOuIncluirClienteToolStripMenuItem
            // 
            this.atualizarOuIncluirClienteToolStripMenuItem.Name = "atualizarOuIncluirClienteToolStripMenuItem";
            this.atualizarOuIncluirClienteToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.atualizarOuIncluirClienteToolStripMenuItem.Text = "Atualizar ou Incluir Cliente";
            this.atualizarOuIncluirClienteToolStripMenuItem.Click += new System.EventHandler(this.atualizarOuIncluirClienteToolStripMenuItem_Click);
            // 
            // excluirClienteToolStripMenuItem
            // 
            this.excluirClienteToolStripMenuItem.Name = "excluirClienteToolStripMenuItem";
            this.excluirClienteToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.excluirClienteToolStripMenuItem.Text = "Excluir Cliente";
            this.excluirClienteToolStripMenuItem.Click += new System.EventHandler(this.excluirClienteToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(510, 281);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 305);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linq to SQL ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeProceduresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarOuIncluirClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesByToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem salesByCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenMostExpensiveProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeByIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerstoolStripMenuItem1;
    }
}

