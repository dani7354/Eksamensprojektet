using System;
using System.Text;
using System.Collections.Generic;
using Domain;
using ViewModels;
using System.Linq;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
   
    [TestClass]
    public class ForecastTests
    {
 
        // Metode som skal testes.
        private Dictionary<DateTime, Product> CalculateOrderDate(List<SalesStatistics> salesStatistics, double pGrowth, DateTime periodStart, DateTime periodEnd)
        {
            Dictionary<DateTime, Product> orderdatesForProducts = new Dictionary<DateTime, Product>();
            foreach (SalesStatistics stat in salesStatistics)
            {
                int previousPeriodDays = (stat.End - stat.Start).Days;
                double dailyQuantitySold = stat.QuantiySold / previousPeriodDays;

                int futurePeriodDays = (periodEnd - periodStart).Days;
                double expectedDailySales = ((dailyQuantitySold / 100) * pGrowth) + dailyQuantitySold;
                int expectedDailySalesRounded = (int)Math.Ceiling(expectedDailySales); // Vi er interesseret i at have hele tal, og vi runder op for en sikkerhds skyld!

                if(expectedDailySales == 0)
                {
                    throw new Exception("Der sælges for lidt af denne vare til, at man kan beregne dagligt salg!");
                }

                // Udregnes med udgangspunkt i en lineær sammenhæng 
                double daysBeforeOutOfStock = (stat.Product.StockAmount -  stat.Product.MinStock) / expectedDailySalesRounded;
                DateTime OutOfStockDay = periodStart.AddDays((int)daysBeforeOutOfStock);  

                DateTime SuggestedOrderDate = OutOfStockDay.AddHours(-stat.Product.ProductionTimeInHours);
                orderdatesForProducts.Add(SuggestedOrderDate, stat.Product);
            }
            return orderdatesForProducts;
        }

        Product p1;
        Product p2;
        Product p3;

        SalesStatistics s1;
        SalesStatistics s2;
        SalesStatistics s3;




        [TestInitialize()]
        public void MyTestInitialize()
        {
            p1 = new Product(1, "Anker 2000", "AR45L64", 199.45, 70, 20, 200, 48, new ProductType("PowerBank"), new Brand("Anker"), true);
            p2 = new Product(2, "Anker 3000", "UL45L64", 300, 11, 10, 300, 24, new ProductType("PowerBank"), new Brand("Anker"), true);
            p3 = new Product(1, "Noname 4000", "AJH5L64", 19.43, 140, 20, 500, 72, new ProductType("Noget andet"), new Brand("NoName"), true);

            s1 = new SalesStatistics()
            {
                Start = new DateTime(2018, 1, 1),
                End = new DateTime(2018, 4, 19),
                Product = p1,
                QuantiySold = 120
            };
            s2 = new SalesStatistics()
            {
                Start = new DateTime(2018, 1, 1),
                End = new DateTime(2018, 4, 19),
                Product = p2,
                QuantiySold = 500
            };
            s3 = new SalesStatistics()
            {
                Start = new DateTime(2018, 1, 1),
                End = new DateTime(2018, 4, 19),
                Product = p3,
                QuantiySold = 400
            };

        }

        [TestMethod]
        public void SeeSuggestedOrderDateForProducts()
        {
            List<SalesStatistics> salesStatistics = new List<SalesStatistics>(){s1, s2, s3};

            DateTime newPeriodStart = new DateTime(2018, 5, 1);
            DateTime newPeriodEnd = new DateTime(2018, 10, 1);

            double ExpGrowthPercent = 30.50;

            Dictionary<DateTime, Product> result = CalculateOrderDate(salesStatistics, ExpGrowthPercent, newPeriodStart, newPeriodEnd);

            Assert.AreEqual("", result.Last().Key.ToString("dd-MM-yyyy"));
            Assert.AreEqual("", result.First().Key.ToString("dd-MM-yyyy"));



        }
    }
}
