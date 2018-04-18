using System;
using DataAccess;
using ViewModels;
using Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        StockViewModel _stockViewModel;
        [TestInitialize]
        public void Init()
        {
            _stockViewModel = new StockViewModel();
        }


        [TestMethod]
        public void ReadFromCSVWorks() //opdateres, når læser-metoden er færdiglavet. 
        {
            int totalProducts = 211;
            CSVReader reader = new CSVReader();
            DateTime start = new DateTime(2018, 1, 1);
            DateTime end = new DateTime(2018, 4, 9);
            List<SalesStatistics> info =  reader.ReadProductsSalesInfoFromCSV("products.csv", start, end);
            Assert.AreEqual(totalProducts, info.Count);

            
        }

        [TestMethod]
        public void GetActiveProducts()
        {
            int totalActiveProducts = 31;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == true).ToList<Product>();
            Assert.AreEqual(totalActiveProducts, product.Count);
        }
        [TestMethod]
        public void GetInactiveProducts()
        {
            int totalInActiveProducts = 3;
            List<Product> product = ProductDB.GetAllProducts().Where(p => p.IsActive == false).ToList<Product>();
            Assert.AreEqual(totalInActiveProducts, product.Count);
        }
        [TestMethod]
        public void SwitchBetweenDeactivatedAndActivatedProducts()
        {
            // Aktive varer skal vises by default
            Assert.AreEqual(true, _stockViewModel.SelectedProducts.Last().IsActive);
            Assert.AreEqual(true, _stockViewModel.SelectedProducts.First().IsActive);

            // Vi beder om at få vist de inaktive varer
            _stockViewModel.ShowDeactivatedProducts();

            // Skulle nu være false.
            Assert.AreEqual(false, _stockViewModel.SelectedProducts.Last().IsActive);
            Assert.AreEqual(false, _stockViewModel.SelectedProducts.First().IsActive);
        }

    }
}
