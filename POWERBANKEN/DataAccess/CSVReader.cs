using System;
using System.Text;
namespace DataAccess
{
    public class CSVReader
    {
        private Encoding _readerEncoding;


        public CSVReader()
        {
            _readerEncoding = Encoding.GetEncoding("UTF-8");
        }

        public string GetProductsFromCSV(string pFilePath)
        {
            
            File.ReadAllLines(pFilePath, _readerEncoding)
            
        }
    }
}
