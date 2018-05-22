using Domain;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
namespace DataAccess
{
    public class CurrencyHttpAccess
    {
        private List<string> _currencyNames;
        private List<Currency> _currency;
        private const string FILE_ADDRESS = "http://borsen.dk/kurser/valuta/dkk.html";
        private const string FILE_NAME = "currencyData.html";
      
        public CurrencyHttpAccess(){}
        public List<Currency> GetCurrencies()
        {
            ReadCurrenciesFromFile();
            return _currency;
        }

        private void DownloadFile()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(FILE_ADDRESS, FILE_NAME);
            }
        }
        private void InitLists()
        {
            _currencyNames = new List<string>()
            {
                "EUR - Euro",
                "GBP - Britiske pund",
                "USD - US-dollar",
                "CNY - Kinesiske Yuan Renminbi"
            };
            _currency = new List<Currency>()
            {
                new Currency("DKK - Danske kroner", 1.00)
            };
        }

        private void ReadCurrenciesFromFile()
        {
            DownloadFile();
            InitLists();
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            using (StreamReader reader = new StreamReader(FILE_NAME, encoding))
            {
                string temp;
                while (reader.EndOfStream == false)
                {
                    temp = reader.ReadLine();

                    if (_currencyNames.Any(z => temp.Trim().Contains(z)))
                    {
                        const string STRING_IN_FRONT_OF_PRICE = "PRICE&quot;:&quot;";
                        const string STRING_BEHIND_PRICE = "&quot;,&quot;BID";

                        string name = _currencyNames.Find(c => temp.Trim().Contains(c));

                        while (!temp.Contains(STRING_IN_FRONT_OF_PRICE))
                        {
                            temp = reader.ReadLine();
                        }
                        int priceStartIndex = temp.Trim().IndexOf(STRING_IN_FRONT_OF_PRICE) + STRING_IN_FRONT_OF_PRICE.Length ;
                        int priceEndIndex = temp.Trim().IndexOf(STRING_BEHIND_PRICE);
                 
                        string price = temp.Trim().Substring(priceStartIndex, priceEndIndex - priceStartIndex);
                        double.TryParse(price, out double newPrice);

                        _currency.Add(new Currency(name, newPrice));
                       _currencyNames.Remove(name);
                    }

                }
      
            }
        }
        

        
    }
}
