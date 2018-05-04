using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;

namespace ViewModels
{
   public class SalesChartViewModel
    {
        public List<SalesStatistics> StatistikPDB { get; set; }

        private ProductDB pdb = new ProductDB();

        public SalesChartViewModel()
        {
            StatistikPDB = pdb.GetProductSales();
        }
            
    }
}
