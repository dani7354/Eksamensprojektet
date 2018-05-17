using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Algorithms
    {
        private int _expectedSale;
        private int _actualSale;
        public int ExpectedSale
        {
            get { return ExpectedSale1; }
            set { ExpectedSale1 = value; }
        }
        public int ActualSale
        {
            get { return _actualSale; }
            set { _actualSale = value; }
        }

        public int ExpectedSale1 { get => _expectedSale; set => _expectedSale = value; }

        public double DifferantialInPercent(int expectedSale, int actualSale)
        {
            ExpectedSale = expectedSale;
            ActualSale = actualSale;
            double result = ((ActualSale - ExpectedSale) / expectedSale) * 100;
            return result;
        }
    }
}
