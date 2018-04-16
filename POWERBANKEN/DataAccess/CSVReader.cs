using System.Text;
using System.Collections.Generic;
using System;
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
        public List<Product> ReadProductsSalesInfoFromCSV(string pFilePath, DateTime periodStart, DateTime periodEnd)
        {
            List<SalesPeriodInfo> products = new List<SalesPeriodInfo>();
            using (StreamReader reader = new StreamReader(pFilePath, _readerEncoding))
            {
                while (reader.EndOfStream == false)
                {
                    
                }
            }
            return null;
        }
    }
}