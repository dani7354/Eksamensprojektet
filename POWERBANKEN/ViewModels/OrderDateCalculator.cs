using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

using DataAccess;

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

        public Dictionary<DateTime, Product> OrderDatesForAllProducts(List<Product> allProducts)
        {
            Dictionary<DateTime, Product> AllProducts = new Dictionary<DateTime, Product>();
            foreach (Product product in allProducts)
            {
                StockCalculation(product, new DateTime(2018,04,25), 100);
                AllProducts.Add(StockCalculation(product, new DateTime(2018,04,25), 100),product);
            }

            return AllProducts;

        }
        //public List<SalesStatistics> CalculateProductSalesForMonth(double GrowthInPercent, List<Product> products, List<SalesStatistics> productSales)
        //{
        //    GrowthInPercent = (GrowthInPercent / 100) + 1;
        //    List<SalesStatistics> ForecastList = new List<SalesStatistics>();
        //    List<SalesStatistics> monthOftheYear = ProductDB.ReadProductSale().AsParallel().Where(x => x.PeriodStart.Month == month.Month).ToList();
        //    foreach (var stat in monthOftheYear)
        //    {
        //        int result = (int)Math.Ceiling(stat.QuantitySold * GrowthInPercent);
        //        ForecastList.Add(new SalesStatistics()
        //        {
        //            QuantitySold = stat.QuantitySold,
        //            ExpectedSales = result,
        //            PeriodStart = stat.PeriodStart.AddYears(1),
        //            PeriodEnd = stat.PeriodEnd.AddYears(1),
        //            Product = stat.Product
        //        });
        //    }
        //    return ForecastList;
        //}

        //public Dictionary<DateTime, Product> GetOrderDatesForProducts(List<Product> products, List<SalesStatistics> productsales, double growth)
        //{

        //    var futureSales = CalculateProductSalesForMonth(growth, products, productsales);
        //    return null;
        //}
    }
}
