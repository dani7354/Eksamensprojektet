using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class CurrencyApiAccess
    {
        public List<Currency> Currencies { get; private set; }
        public CurrencyApiAccess()
        {
            Currencies = new List<Currency>();
            ReadFromApi();
           
        }

        public void ReadFromApi()
        {
            Currencies.Add(new Currency("DKK", 100));
            Currencies.Add(new Currency("USD", 600));
            Currencies.Add(new Currency("EUR", 750));
        }
        

        
    }
}
