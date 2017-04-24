using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSQL_Cshp1
{
    class acessoLinqConsultas
    {
        /// <summary>
        /// Exemplo:  a cláusuala Where
        /// Retorna um funcionario onde o codigo coincinde com o valor
        /// passado na parâmetro empID
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>O único valor que coincide ou o valor padrão</returns>

        public static Employee GetEmployeeById(int empId)
        {
            NorthwindDataContext dc = new NorthwindDataContext();
            return (from e in dc.GetTable<Employee>()
                    where (e.EmployeeID == empId)
                    select e).SingleOrDefault<Employee>();
        }

        /// <summary>
        /// Exemplo:  Select para um único objeto
        /// usando a cláusula Where
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Retorna o primeiro pedido que atendo o critério definido</returns>
        public static Order GetOrderById(int orderId)
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return (from ord in dc.GetTable<Order>()
                    where (ord.OrderID == orderId)
                    select ord).SingleOrDefault<Order>();
        }

        /// <summary>
        /// Exemplo:  Select para uma lista tipada
        /// usando a cláusula Where
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<Order> GetOrdersById(int orderId)
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return (from ord in dc.GetTable<Order>()
                    where (ord.OrderID == orderId)
                    select ord).ToList<Order>();
        }

        /// <summary>
        /// Exemplo:  Retorna uma lista ordeanda
        /// Converte o valor retornado para uma Lista
        /// do tipo Employee ordenada por data de admissão
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetEmployeesByHireDate()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return (from emp in dc.GetTable<Employee>()
                    orderby emp.HireDate ascending
                    select emp).ToList<Employee>();
        }

        /// <summary>
        /// Classe usada para definir o tipo de retorno
        /// para o método - OrdersAndDetails
        /// </summary>
        public class OrdersAndDetailsResult
        {
            public System.String CustomerID
            { get; set; }
            public System.Nullable<System.DateTime> OrderDate
            { get; set; }
            public System.Nullable<System.DateTime> RequiredDate
            { get; set; }
            public System.String ShipAddress
            { get; set; }
            public System.String ShipCity
            { get; set; }
            public System.String ShipCountry
            { get; set; }
            public System.String ShipZip
            { get; set; }
            public System.String ShippedTo
            { get; set; }
            public System.Int32 OrderID
            { get; set; }
            public System.String NameOfProduct
            { get; set; }
            public System.String QtyPerUnit
            { get; set; }
            public System.Nullable<System.Decimal> Price
            { get; set; }
            public System.Int16 QtyOrdered
            { get; set; }
            public System.Single Discount
            { get; set; }
        }

        /// <summary>
        /// Exemplo:  Joins
        /// Vinculando usando a palavra-chave join
        /// O valor retornado é convertido
        /// para uma lista do tipo especificado
        /// </summary>
        /// <returns></returns>
        public static List<OrdersAndDetailsResult> OrdersAndDetails()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return (from ords in dc.GetTable<Order>()
                    join dets in dc.GetTable<Order_Detail>()
                        on ords.OrderID equals dets.OrderID
                    orderby ords.CustomerID ascending
                    select new OrdersAndDetailsResult
                    {
                        CustomerID = ords.CustomerID,
                        OrderDate = ords.OrderDate,
                        RequiredDate = ords.RequiredDate,
                        ShipAddress = ords.ShipAddress,

                        ShipCity = ords.ShipCity,
                        ShipCountry = ords.ShipCountry,
                        ShipZip = ords.ShipPostalCode,
                        ShippedTo = ords.ShipName,
                        OrderID = ords.OrderID,
                        NameOfProduct = dets.Product.ProductName,
                        QtyPerUnit = dets.Product.QuantityPerUnit,
                        Price = dets.Product.UnitPrice,
                        QtyOrdered = dets.Quantity,
                        Discount = dets.Discount
                    }
                    ).ToList<OrdersAndDetailsResult>();
        }

        /// <summary>
        /// Exemplo:  Aggregation
        /// Retorna o total sa soma dos pedidos
        /// selecionado por ID
        /// computando o preco unitário multiplicado pela quantidade
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static decimal? GetOrderValueByOrderId(int orderID)
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            var matches =
                (from od in dc.GetTable<Order_Detail>()
                 where od.OrderID == orderID
                 select od.Product.UnitPrice * od.Quantity).Sum();
            return matches;
       }

        /// <summary>
        /// Exemplo:  Usando Take para obter um número limitado
        /// de valores para exibir 
        /// E usando Skip para sequencialmente mudar para um ponto distinto
        /// com os valores retornados
        /// </summary>
        /// <param name="SkipNumber"></param>
        /// <returns></returns>
        public static List<Order> GetTopFiveOrdersById(int SkipNumber)
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return (from ord in dc.GetTable<Order>()
                    orderby ord.OrderID ascending
                    select ord).Skip(SkipNumber).Take(5).ToList<Order>();
        }
    }
}
