using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccess;

namespace ViewModels
{
    public class DifferenceInPercent
    {
        Algorithms algorithms = new Algorithms();
        CSVReader reader = new CSVReader();
        DateTime d = new DateTime(2015, 1, 1);
        public double CalculateDifference()
        {
            List<double> list = new List<double>();
            List<SalesStatistics> query = reader.ReadProductsSalesInfoFromCSV(@"C:\Users\Simon\source\repos\Eksamensprojektet\Dokumenter\Testdata\Product Sales - 2018-04-19_Jan 2017.csv").Where(x => x.QuantitySold == 31).ToList();
            foreach (var item in query)
            {
                list.Add(algorithms.DifferantialInPercent(0, item.QuantitySold));
            }
            double sum = list.Take(3).Sum();
            return sum;
        }
    }
}
