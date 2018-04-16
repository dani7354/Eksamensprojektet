using System;
namespace Udkast_til_algoritme
{
    public class SalesPeriodInfo
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public double GrowthInPercent { get; set; }
        public int QuantitySold { get; set; }
    }
}
