using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using DataAccess;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductForecastViewModel
    {
        private CSVReader _csvReader;
        private SalesStatistics _statsForProduct;
        public DateTime periodStart { get; set; }
        public DateTime periodEnd { get; set; }
        public double expGrowth { get; set; }
        public ProductForecastViewModel()
        {
            _csvReader = new CSVReader();
        }


       
    }
}
