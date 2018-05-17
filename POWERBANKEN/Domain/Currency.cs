using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Currency
    {
        public Currency(string name, double exchangeRateDKK)
        {
            Name = name;
            ExchangeRateDKK = exchangeRateDKK;
        }
        public string Name { get; private set; }
        public double ExchangeRateDKK { get; private set; }

    }
}
