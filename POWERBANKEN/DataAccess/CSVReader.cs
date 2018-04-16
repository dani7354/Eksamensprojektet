using System;
using System.Text;
using System.Collections.Generic;
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
        public List<string> ReadProductsFromCSV(string pFilePath)
        {
            List<string> productinfo = new List<string>(); //Udskiftes med en liste af en custom type. evt. på.
            using (StreamReader reader = new StreamReader(pFilePath, _readerEncoding))
            {
                while (reader.EndOfStream == false)
                {
                    productinfo.Add(reader.ReadLine());
                }
            }
            return productinfo;
        }
    }
}
