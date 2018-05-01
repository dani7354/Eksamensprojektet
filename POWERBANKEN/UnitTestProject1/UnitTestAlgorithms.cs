using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Domain;
using System.Linq;
using System.Collections.Generic;
using ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestAlgorithms
    {
        IDataStorage dataStorage;
        Random rnd = new Random();
        Product p1 = new Product("Anker 2000", "AS34LK", 230, 70, 10, new ProductType("PowerBank"), new Brand("Anker"),20, true); // har tilhørende salgsdata.
        Product p2 = new Product("Anker 3000", "AS76LK", 400, 300, 30, new ProductType("PowerBank"), new Brand("Anker"),20, true); // har tilhørende salgsdata.
        Product p3 = new Product("Anker 9000", "JKFGLK", 700, 100, 5, new ProductType("PowerBank"), new Brand("Anker"),20, true); // har tilhørende salgsdata.
        Product p4 = new Product("Anker 10000", "FG34LK", 200, 40, 5, new ProductType("PowerBank"), new Brand("Anker"), 20, true); // uden tilhørende salgsdata.

        SalesStatistics[] p1stat = new SalesStatistics[12];
        SalesStatistics[] p2stat = new SalesStatistics[12];
        SalesStatistics[] p3stat = new SalesStatistics[12];
        [TestInitialize]
        public void Init()
        {
            p1.LeadTimeDays = 14;
            p2.LeadTimeDays = 30;
            p3.LeadTimeDays = 7;
            dataStorage = TestDB.Instance;


            for (int i = 0; i < p1stat.Length; i++)
            {
                int DaysInMonth = DateTime.DaysInMonth(2017, i+1);
                p1stat[i] = new SalesStatistics()
                {
                    PeriodStart = new DateTime(2017, i+1, 1),
                    PeriodEnd = new DateTime(2017, i+1, DaysInMonth - 1),
                    QuantitySold = 50,
                    Product = p1
                };
                p2stat[i] = new SalesStatistics()
                {
                    PeriodStart = new DateTime(2017, i+1, 1),
                    PeriodEnd = new DateTime(2017, i+1, DaysInMonth - 1),
                    QuantitySold = 20,
                    Product = p2
                };
                p3stat[i] = new SalesStatistics()
                {
                    PeriodStart = new DateTime(2017, i+1, 1),
                    PeriodEnd = new DateTime(2017, i+1, DaysInMonth - 1),
                    QuantitySold = 30,
                    Product = p3
                };

            }
           // Gemmer testdata i databasen
            dataStorage.InsertProductSale(p1stat.ToList());
            dataStorage.InsertProductSale(p2stat.ToList());
            dataStorage.InsertProductSale(p3stat.ToList());
            dataStorage.InsertProduct(p1);
            dataStorage.InsertProduct(p2);
            dataStorage.InsertProduct(p3);
            dataStorage.InsertProduct(p4);
        }
        [TestMethod]
        public void OrderDateCalc_WorksWithSalesForEveryMonth()
        {
            OrderDateCalculator calc = new OrderDateCalculator();
            double expGrowth = 30.00;
            Dictionary<Product, DateTime> result  = calc.GetOrderDatesForAllProducts(dataStorage.GetAllProducts(), dataStorage.GetProductSales(), expGrowth);
            Assert.AreEqual(3, result.Count);
            // Forventede resultater udregnet på forhånd. 
            Assert.AreEqual(DateTime.Today.AddDays(17), result.First().Value); 
            Assert.AreEqual(DateTime.Today.AddDays(89), result.Last().Value);
        }
        [TestMethod]
        public void OrderDateCalc_IgnoreProductsWithNoSalesData()
        {
            OrderDateCalculator calc = new OrderDateCalculator();
            double expGrowth = 20;
            var result = calc.GetOrderDatesForAllProducts(dataStorage.GetAllProducts(), dataStorage.GetProductSales(), expGrowth);
            Assert.IsFalse(result.ContainsKey(p4));
        }
     

    }
}
