using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SalesStatistics
    {
        public int QuantitySold { get; set; }
        public int ExpectedSales { get; set; }
        public Product Product { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
