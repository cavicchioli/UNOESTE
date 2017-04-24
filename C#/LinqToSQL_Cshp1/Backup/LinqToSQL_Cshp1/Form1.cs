using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace LinqToSQL_Cshp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customerstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Table<Customer> customers = acessoLinqTabelas.GetCustomerTable();
            dataGridView1.DataSource = customers;
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table<Order> orders = acessoLinqTabelas.GetOrderTable();
            dataGridView1.DataSource = orders;
        }

        private void employessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table<Employee> emp = acessoLinqTabelas.GetEmployeeTable();
            dataGridView1.DataSource = emp;
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table<Category> cats = acessoLinqTabelas.GetCategoryTable();
            dataGridView1.DataSource = cats;
        }

        private void employeesByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order ord = acessoLinqConsultas.GetOrderById(10248);

            StringBuilder sb = new StringBuilder();
            sb.Append("Order: " + Environment.NewLine);
            sb.Append("Order ID: " + ord.OrderID + Environment.NewLine);
            sb.Append("Date Shipped: " + ord.ShippedDate + Environment.NewLine);
            sb.Append("Shipping Address: " + ord.ShipAddress + Environment.NewLine);
            sb.Append("         City: " + ord.ShipCity + Environment.NewLine);
            sb.Append("         Region: " + ord.ShipRegion + Environment.NewLine);
            sb.Append("         Country: " + ord.ShipCountry + Environment.NewLine);
            sb.Append("         Postal Code: " + ord.ShipPostalCode +
            Environment.NewLine);

            sb.Append("Shipping Name: " + ord.ShipName + Environment.NewLine);
            MessageBox.Show(sb.ToString(), "Shipping Information");
        }

        private void salesByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<acessoLinqConsultas.OrdersAndDetailsResult> oad = acessoLinqConsultas.OrdersAndDetails();
            dataGridView1.DataSource = oad;
        }

        private void employeeByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Employee emp = acessoLinqConsultas.GetEmployeeById(1);

            StringBuilder sb = new StringBuilder();
            sb.Append("Employee 1: " + Environment.NewLine);
            sb.Append("Name: " + emp.FirstName + " " + emp.LastName + Environment.NewLine);
            sb.Append("Hire Date: " + emp.HireDate + Environment.NewLine);
            sb.Append("Home Phone: " + emp.HomePhone + Environment.NewLine);

            MessageBox.Show(sb.ToString(), "Employee ID Search");
        }

        private void salesByYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(1990, 1, 1);
            DateTime end = new DateTime(2000, 1, 1);

            List<Sales_by_YearResult> result = acessoLinqStoredProcedure.SalesByYear(start, end);
            dataGridView1.DataSource = result;
        }

        private void tenMostExpensiveProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Ten_Most_Expensive_ProductsResult> result = acessoLinqStoredProcedure.TenMostExpensiveProducts();
            dataGridView1.DataSource = result;
        }

        private void atualizarOuIncluirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void excluirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

    }
}
