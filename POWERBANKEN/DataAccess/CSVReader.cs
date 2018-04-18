
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using Domain;
using System.IO;

namespace DataAccess
{
    public class CSVReader
    {
        private Encoding _readerEncoding;
        public CSVReader()
        {
            _readerEncoding = Encoding.GetEncoding("UTF-8");
        }
        public List<SalesStatistics> ReadProductsSalesInfoFromCSV(string pFilePath, DateTime periodStart, DateTime periodEnd)
        {
            List<SalesStatistics> productSalesStaticstic = new List<SalesStatistics>();
            using (StreamReader reader = new StreamReader(pFilePath, _readerEncoding))
            {
                reader.ReadLine(); // Skipping the first line. 
                while (reader.EndOfStream == false)
                {
                    string[] tuple = reader.ReadLine().Split(',');
                    SalesStatistics prodStat = new SalesStatistics();
                    prodStat.Start = periodStart;
                    prodStat.End = periodEnd;
                    bool quantityFound = false;
                    int counter = 0;
                    while (!quantityFound || counter < 3)
                    {      
                        if (IsNumber(tuple[counter]))
                        {
                            prodStat.QuantiySold = Convert.ToInt32(tuple[counter]);
                            quantityFound = true;
                        }
                        counter++;
                    }
                    productSalesStaticstic.Add(prodStat);
                }

            }
            return productSalesStaticstic;
        }
        private bool IsNumber(string s)
        {
            int n;
            return int.TryParse(s, out n);
        }

    }
}