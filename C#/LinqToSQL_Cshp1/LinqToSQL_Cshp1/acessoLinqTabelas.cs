using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSQL_Cshp1
{
    class acessoLinqTabelas
    {

        /// <summary>
        /// Obtem dados da tabela Customer 
        /// </summary>
        /// <returns></returns>
        public static System.Data.Linq.Table<Customer> GetCustomerTable()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();
            return dc.GetTable<Customer>();
        }

        
        /// <summary>
        /// Obtem dados da tabela Employee 
        /// </summary>
        /// <returns></returns>
        public static System.Data.Linq.Table<Employee> GetEmployeeTable()
        {
           NorthwindDataContext dc = new
           NorthwindDataContext();
           return dc.GetTable<Employee>();
        }

        /// <summary>
        /// Obtem dados da tabela Order 
        /// </summary>
        /// <returns></returns>
        public static System.Data.Linq.Table<Order> GetOrderTable()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();
            return dc.GetTable<Order>();
        }

        /// <summary>
        /// Obtem dados da tabela Category 
        /// </summary>
        /// <returns></returns>
        public static System.Data.Linq.Table<Category> GetCategoryTable()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();
            return dc.GetTable<Category>();
        } 

        /// <summary>
        /// Obtem dados da tabela Product 
        /// </summary>
        /// <returns></returns>
        public static System.Data.Linq.Table<Product> GetProductTable()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();
            return dc.GetTable<Product>();
        }
    }
}
