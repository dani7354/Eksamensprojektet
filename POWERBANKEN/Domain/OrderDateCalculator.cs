using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class OrderDateCalculator
    {
        //private int _expectedSalePerDay;
        //private DateTime _currentDateOfTheMonth;

        //DateTime CurrentDateOfTheMonth
        //{
        //    get
        //    {
        //        return _currentDateOfTheMonth;
        //    }
        //    set
        //    {
        //        _currentDateOfTheMonth = value;
        //    }
        //}
        //int ExpectedSalePerDay { get
        //    {
        //        return _expectedSalePerDay;
        //    }
        //    set
        //    {
        //        _expectedSalePerDay = value;
        //    } }
        public DateTime CalculateOrderDateForProduct(Product product, List<SalesStatistics> futureSalesForProduct)
        {
            DateTime currentDate = DateTime.Today;
            Product productCopy = new Product(product.Name, product.SKU, product.PurchasePrice, product.StockAmount, product.MinStock, product.Type, product.Brand,product.LeadTimeDays, product.IsActive);
            while (productCopy.StockAmount >= productCopy.MinStock)
            {
                const int YEAR_LIMIT = 3000;
                int dailySale = GetDailySaleForMonth(currentDate, futureSalesForProduct);
                productCopy.StockAmount -= dailySale;
                if(currentDate.Year < YEAR_LIMIT)
                {
                    currentDate = currentDate.AddDays(1);
                }
                else
                {
                    break;
                }
            }
            DateTime RunningDryOfProducts = currentDate;
            DateTime OrderDate = RunningDryOfProducts.AddDays(-product.LeadTimeDays);
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
            
            return dailySale;
        }

        public Dictionary<Product, DateTime> GetOrderDatesForAllProducts(List<Product> allProducts, List<SalesStatistics> productSales, double growthInPercent)
        {
            Dictionary<Product, DateTime> AllOrderDatesForProducts = new Dictionary<Product, DateTime>();
            List<SalesStatistics> futureMonthlySales = CalculateProductSalesForMonth(growthInPercent, allProducts, productSales);

            foreach (Product product in allProducts.Where(p => p.IsActive == true))
            {
                if (futureMonthlySales.Exists(s => s.Product.Equals(product)))
                {
                    List<SalesStatistics> salesForProducts = futureMonthlySales.Where(s => s.Product.Equals(product)).ToList();
                    DateTime orderDate = CalculateOrderDateForProduct(product, salesForProducts);
                    if(orderDate < DateTime.Today)
                    {
                        orderDate = DateTime.Today;
                    }
                    AllOrderDatesForProducts.Add(product, orderDate);
                }
            }
            return AllOrderDatesForProducts;
        }
        public List<SalesStatistics> CalculateProductSalesForMonth(double GrowthInPercent, List<Product> products, List<SalesStatistics> productSales)
        {
            GrowthInPercent = (GrowthInPercent / 100) + 1;
            List<SalesStatistics> ForecastList = new List<SalesStatistics>();
            foreach (var stat in productSales)
            {
                if(products.Any(p => p.Equals(stat.Product)))
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
            }
            return ForecastList;
        }
    }
}
