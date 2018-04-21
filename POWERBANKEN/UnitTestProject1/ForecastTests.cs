using System;
using System.Text;
using System.Collections.Generic;
using Domain;
using ViewModels;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
   
    [TestClass]
    public class ForecastTests
    {
        private DateTime start;
        private DateTime end;

        private CSVReader _reader;
        private List<SalesStatistics> statistics;

        public ForecastTests()
        {
         
        }

 

     
      
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _reader = new CSVReader();
         //   statistics = _reader.ReadProductsSalesInfoFromCSV("products.csv", start, end);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
   

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
