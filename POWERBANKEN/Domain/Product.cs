using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Product()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public int ProductionTime { get; set; }

        public ProductType Type { get; set; }
        public Brand Brand { get; set; }

 
    }
}
