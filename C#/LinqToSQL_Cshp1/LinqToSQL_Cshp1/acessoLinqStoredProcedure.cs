using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToSQL_Cshp1
{
    class acessoLinqStoredProcedure
    {
        /// <summary>
        /// Stored Procedure:  Sales By Year
        /// </summary>
        /// <param name="beginningYear"></param>
        /// <param name="endingYear"></param>
        /// <returns></returns>
        public static List<Sales_by_YearResult> SalesByYear(DateTime? beginningYear,
        DateTime? endingYear)
       {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return dc.Sales_by_Year(beginningYear,
            endingYear).ToList<Sales_by_YearResult>();
        }

        /// <summary>
        /// Stored Procedure:  Ten Most Expenisve Products
        /// </summary>
        /// <returns></returns>
        public static List<Ten_Most_Expensive_ProductsResult>
        TenMostExpensiveProducts()
        {
            NorthwindDataContext dc = new
            NorthwindDataContext();

            return dc.Ten_Most_Expensive_Products().ToList<
            Ten_Most_Expensive_ProductsResult>();
        } 
    }
}
