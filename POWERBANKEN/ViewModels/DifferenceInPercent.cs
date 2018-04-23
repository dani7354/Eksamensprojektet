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
        public List<double> CalculateDifference()
        {
            List<double> list = new List<double>();
            //foreach (var item in query)
            //{
            //    list.Add(algorithms.DifferantialInPercent(0, item.QuantitySold));
            //}
            return list;
        }
    }
}
