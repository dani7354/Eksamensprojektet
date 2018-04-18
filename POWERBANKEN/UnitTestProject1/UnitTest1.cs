using System;
using DataAccess;
using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestCleanup]
        public void CleanUp()
        {

        }


        [TestMethod]
        public void ReadFromCSVWorks() //opdateres, når læser-metoden er færdiglavet. 
        {
            int totalProducts = 211;
            CSVReader reader = new CSVReader();
            DateTime start = new DateTime(2018, 1, 1);
            DateTime end = new DateTime(2018, 4, 9);
            List<Statistic> info =  reader.ReadProductsSalesInfoFromCSV("products.csv", start, end);
            Assert.AreEqual(totalProducts, info.Count);

            
        }

        [TestMethod]
        public void GetActiveProducts()
        {
            int totalActiveProducts = 33;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == true).ToList<Product>();

            //Assert.AreEqual(3, product.Count);
            
            Assert.AreEqual(totalActiveProducts, product.Count);
           // Assert.AreEqual(5, product0].ID);
        }
        [TestMethod]
        public void GetInactiveProducts()
        {
            int totalInActiveProducts = 1;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == false).ToList<Product>();

            //Assert.AreEqual(3, product.Count);

            Assert.AreEqual(totalInActiveProducts, product.Count);
            // Assert.AreEqual(5, product0].ID);
        }

    }
}
