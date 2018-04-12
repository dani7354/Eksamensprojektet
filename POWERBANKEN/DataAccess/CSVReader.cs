using System;
using System.Text;
namespace DataAccess
{
    public class CSVReader
    {
        private Encoding _readerEncoding;


        public CSVReader()
        {
            _readerEncoding = Encoding.GetEncoding("iso-8859-1");
        }

        public string GetProductsFromCSV(string pFilePath)
        {
            
            return string.Empty;
            
        }
    }
}
