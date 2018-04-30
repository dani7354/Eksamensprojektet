using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModels;
using Domain;
using DataAccess;

namespace UnitTestProject1
{
    [TestClass]
    public class AddProductTest
    {
        [TestMethod]
        public void TestAddingProduct()
        {
            string sku = "T105";
            string name = "Power2000";
            double purchasePrice = 20;
            int amount = 100;
            int minAmount = 10;
            int productTypeID = 1;
            int brandID = 1;
            double leadTime = 50;
            bool isActive = true;
            ViewModels.AddProductViewModel apvm = new AddProductViewModel();

            apvm.AddAProduct(sku, name, purchasePrice, amount, minAmount, productTypeID, brandID, leadTime, isActive);

            ProductDB db = new ProductDB();
            Assert.IsTrue(db.GetAllProducts().Exists(p => p.SKU == sku));
        }
    }
}
