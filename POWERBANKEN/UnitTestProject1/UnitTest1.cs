using System;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadFromCSVWorks() //opdateres, når læser-metoden er færdiglavet. 
        {
            CSVReader reader = new CSVReader();

            var lines = reader.ReadProductsFromCSV("productsales.csv");

            Assert.AreEqual("\"GreyLime Power Stone – Mørkeblå – 10.400 mAh\",387,P104101", lines[1]);
            Assert.AreEqual(212, lines.Count);
        }
    }
}
