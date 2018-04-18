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
        public List<Product> ReadProductsSalesInfoFromCSV(string pFilePath)
        {
<<<<<<< HEAD
            
            File.ReadAllLines(pFilePath, _readerEncoding)
            
=======
            List<Product> products = new List<Product>();
            using (StreamReader reader = new StreamReader(pFilePath, _readerEncoding))
            {

                while (reader.EndOfStream == false)
                {
                    
                }
            }
            return null;
>>>>>>> aca753b13451bf30a26cca8a422c56d9605d3e23
        }
    }
}