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
        Product p1 = new Product("Anker 2000", "AS34LK", 230, 70, 10, new ProductType("PowerBank"), new Brand("Anker"),20, true);
        Product p2 = new Product("Anker 3000", "AS76LK", 400, 300, 30, new ProductType("PowerBank"), new Brand("Anker"),20, true);
        Product p3 = new Product("Anker 9000", "JKFGLK", 700, 100, 5, new ProductType("PowerBank"), new Brand("Anker"),20, true);

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
                    QuantitySold = 20- i,
                    Product = p2
                };
                p3stat[i] = new SalesStatistics()
                {
                    PeriodStart = new DateTime(2017, i+1, 1),
                    PeriodEnd = new DateTime(2017, i+1, DaysInMonth - 1),
                    QuantitySold = 30 - i,
                    Product = p3
                };

            }
           // Gemmer testdata i databasen
            dataStorage.InsertProductSale(p1stat.ToList());
            dataStorage.InsertProductSale(p2stat.ToList());
            dataStorage.InsertProductSale(p3stat.ToList());
            dataStorage.UpdateProducts(new List<Product>() { p1, p2, p3 });
        }
        [TestMethod]
        public void CalculationWorksWithSalesForEveryMonth()
        {
            OrderDateCalculator calc = new OrderDateCalculator();
            var result  = calc.OrderDatesForAllProducts(dataStorage.GetAllProducts(), dataStorage.GetProductSales(), 30.23);
    

            Assert.AreEqual(3, calc);
            Assert.AreEqual(new DateTime(2018, 5, 13), result.First().Key);
            Assert.AreEqual(new DateTime(2018, 5, 13), result.Last().Key);
            


        }
    }
}
