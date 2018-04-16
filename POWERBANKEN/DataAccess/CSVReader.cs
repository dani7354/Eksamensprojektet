
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
        public List<SalesPeriodInfo> ReadProductsSalesInfoFromCSV(string pFilePath, DateTime periodStart, DateTime periodEnd)
        {
            List<SalesPeriodInfo> salesPeriodInfo = File.ReadAllLines(pFilePath, _readerEncoding)
                .Skip(1)
                .Select(a => a.Split(';'))
                .Select(a => new SalesPeriodInfo()
                {
                    Start = periodStart,
                    End = periodEnd,
                    QuantiySold = int.Parse(a[1]),
                }).ToList();
            return salesPeriodInfo;
        }
    }
}