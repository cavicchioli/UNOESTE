using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace LinqToSQL_Cshp1
{
    class acessoLinqCrud
    {

        /// <summary>
        /// Inserir ou Atualizar um registro da tabela Customer
        /// Se o ID do Cliente existir então o registro é atualizado
        /// caso contrário um novo registro será inserido na tabela
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="companyName"></param>
        /// <param name="contactName"></param>
        /// <param name="contactTitle"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="region"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        public static void InsertOrUpdateCustomer(string customerId, string companyName,
            string contactName, string contactTitle, string address, string city,
            string region, string postalCode, string country, string phone, string fax)
        {

            NorthwindDataContext dc = new NorthwindDataContext();

            var matchedCustomer = (from c in dc.GetTable<Customer>()
                                   where c.CustomerID == customerId
                                   select c).SingleOrDefault();

            if (matchedCustomer == null)
            {
                try
                {
                    // cria um novo registro customer pois o ID não existe
                    Table<Customer> customers = acessoLinqTabelas.GetCustomerTable();
                    Customer cust = new Customer();

                    cust.CustomerID = customerId;
                    cust.CompanyName = companyName;
                    cust.ContactName = contactName;
                    cust.ContactTitle = contactTitle;
                    cust.Address = address;
                    cust.City = city;
                    cust.Region = region;
                    cust.PostalCode = postalCode;
                    cust.Country = country;
                    cust.Phone = phone;
                    cust.Fax = fax;

                    customers.InsertOnSubmit(cust);
                    customers.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    matchedCustomer.CompanyName = companyName;
                    matchedCustomer.ContactName = contactName;
                    matchedCustomer.ContactTitle = contactTitle;
                    matchedCustomer.Address = address;
                    matchedCustomer.City = city;
                    matchedCustomer.Region = region;
                    matchedCustomer.PostalCode = postalCode;
                    matchedCustomer.Country = country;
                    matchedCustomer.Phone = phone;
                    matchedCustomer.Fax = fax;

                    dc.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Deleta um registro da tabela usando o ID do cliente
        /// </summary>
        /// <param name="customerID"></param>
        public static void DeleteCustomer(string customerID)
        {
            NorthwindDataContext dc = new NorthwindDataContext();

            var matchedCustomer = (from c in dc.GetTable<Customer>()
                                   where c.CustomerID == customerID
                                   select c).SingleOrDefault();
            try
            {
                dc.Customers.DeleteOnSubmit(matchedCustomer);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
