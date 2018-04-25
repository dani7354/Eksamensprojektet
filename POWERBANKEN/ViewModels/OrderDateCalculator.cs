using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ViewModels
{
    public class OrderDateCalculator
    {
        private int _expectedSalePerDay;
        private DateTime _currentDateOfTheMonth;

        DateTime CurrentDateOfTheMonth
        {
            get
            {
                return _currentDateOfTheMonth;
            }
            set
            {
                _currentDateOfTheMonth = value;
            }
        }
        int ExpectedSalePerDay { get
            {
                return _expectedSalePerDay;
            }
            set
            {
                _expectedSalePerDay = value;
            } }
        public DateTime StockCalculation(Product product, DateTime currentDateOfTheMonth, int expectedSalePerDay)
        {
            int numberOfDaysUntilStockRunsDy = -1; //Vi minusser med en fordi at datetime klasse, starter på den 01. og vil vi have idags dato med

            while (product.StockAmount >= product.MinStock)
            {
                product.StockAmount -= expectedSalePerDay;

                numberOfDaysUntilStockRunsDy++;
            }
            DateTime RunningDryOfProducts = currentDateOfTheMonth.AddDays(numberOfDaysUntilStockRunsDy);
            DateTime OrderDate = RunningDryOfProducts.AddDays(-10);

            return OrderDate;
        }
        
    }
}
