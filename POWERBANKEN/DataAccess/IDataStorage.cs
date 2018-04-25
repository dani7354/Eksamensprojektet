using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataStorage
    {
        List<Product> GetAllProducts();
        void UpdateProducts(List<Product> products);
        void InsertProductSale(List<SalesStatistics> pProductSales);
        List<SalesStatistics> GetProductSales();


    }
}
