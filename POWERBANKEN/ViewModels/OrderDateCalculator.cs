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
        public DateTime StockCalculation(Product product, List<SalesStatistics> futureSalesForProduct)
        {
         //   int numberOfDaysUntilStockRunsDy = -1; //Vi minusser med en fordi at datetime klasse, starter på den 01. og vil vi have idags dato med

            DateTime currentDate = DateTime.Today;
            Product productCopy = new Product(product.ID, product.Name, product.SKU, product.PurchasePrice, product.StockAmount, product.MinStock, product.Type, product.Brand, product.IsActive);
            while (productCopy.StockAmount >= productCopy.MinStock)
            {
                int dailySale = GetDailySaleForMonth(currentDate, futureSalesForProduct);
                productCopy.StockAmount -= dailySale;
                currentDate = currentDate.AddDays(1);
            }
            DateTime RunningDryOfProducts = currentDate;
            DateTime OrderDate = RunningDryOfProducts.AddDays(product.LeadTimeDays);

            return OrderDate;
        }

        private int GetDailySaleForMonth(DateTime currentDate, List<SalesStatistics> futureSalesForProduct)
        {
            int dailySale = 0;
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            if (futureSalesForProduct.Exists(s => s.PeriodEnd.Month.Equals(currentDate.Month)))
            {
                SalesStatistics productSalesForMonth = futureSalesForProduct.Where(s => s.PeriodEnd.Month.Equals(currentDate.Month)).Single();
                dailySale = productSalesForMonth.ExpectedSales / daysInMonth;
            }
            else
            {
                dailySale =  futureSalesForProduct.First().ExpectedSales / daysInMonth; //bør nok laves om
            }
            return dailySale;
        }

        public Dictionary<DateTime, Product> OrderDatesForAllProducts(List<Product> allProducts, List<SalesStatistics> productSales, double growthInPercent)
        {
            Dictionary<DateTime, Product> AllOrderDatesForProducts = new Dictionary<DateTime, Product>();
            List<SalesStatistics> futureMonthlySales = CalculateProductSalesForMonth(growthInPercent, allProducts, productSales);

            foreach (Product product in allProducts)
            {
                if (futureMonthlySales.Exists(s => s.Product.Equals(product)))
                {
                    List<SalesStatistics> salesForProducts = futureMonthlySales.Where(s => s.Product.Equals(product)).ToList();
                    AllOrderDatesForProducts.Add(StockCalculation(product, salesForProducts), product);

                }
            }
            return AllOrderDatesForProducts;
        }
        public List<SalesStatistics> CalculateProductSalesForMonth(double GrowthInPercent, List<Product> products, List<SalesStatistics> productSales)
        {
            GrowthInPercent = (GrowthInPercent / 100) + 1;
            List<SalesStatistics> ForecastList = new List<SalesStatistics>();
            foreach (var stat in productSales.Where(p => products.Contains(p.Product)))
            {
                int result = (int)Math.Ceiling(stat.QuantitySold * GrowthInPercent);
                ForecastList.Add(new SalesStatistics()
                {
                    QuantitySold = stat.QuantitySold,
                    ExpectedSales = result,
                    PeriodStart = stat.PeriodStart.AddYears(1),
                    PeriodEnd = stat.PeriodEnd.AddYears(1),
                    Product = stat.Product
                });
            }
            return ForecastList;
        }

       
    }
}
