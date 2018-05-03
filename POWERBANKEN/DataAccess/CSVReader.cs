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

        public List<SalesStatistics> ReadProductsSalesInfoFromCSV(string pFilePath)
        {
            List<SalesStatistics> productSalesStaticstic = new List<SalesStatistics>();
            DateTime periodstart = FindStartDateInFileName(pFilePath);
            DateTime periodEnd = periodstart.AddDays(DateTime.DaysInMonth(periodstart.Year, periodstart.Month) - 1); // Magic number for at f� den nuv�rende dag

			using (StreamReader reader = new StreamReader(pFilePath, _readerEncoding))
            {
                reader.ReadLine(); // Skipping the first line. 
                while (reader.EndOfStream == false)
                {
                    string[] currentTuple = reader.ReadLine().Split(',');
             
                        SalesStatistics prodStat = new SalesStatistics
                        {
                            PeriodStart = periodstart,
                            PeriodEnd = periodEnd
                        };

                        bool quantityFound = false;
                        int counter = 1;
                        while (quantityFound == false || counter < 3)
                        {
                            if (IsNumber(currentTuple[counter])) // den solgte m�ngde vil i alle tilf�lde v�re den f�rste v�rdi i en r�kke, som kun er et tal. Derfor pr�ver vi tryParse p� alle v�rdier i tuplen.
                            {
                                prodStat.QuantitySold = Convert.ToInt32(currentTuple[counter]);
                                quantityFound = true;
                            }
                            counter++;
                        }
                        prodStat.Product = new Product // �ndres til at tjekke database efter matchende produkt. 
                        {
                            Name = currentTuple.First(),
                            SKU = currentTuple.Last()

                        };
                    if(SalesDataObjectIsValid(prodStat))productSalesStaticstic.Add(prodStat);
                }
            }
            return productSalesStaticstic;
        }

        private DateTime FindStartDateInFileName(string pfilePath)
        {
            Dictionary<int, string> Months = new Dictionary<int, string>() // laver en dictionary med 12 KeyValuePairs - en for hver m�ned.
            {
                {1, "jan"},
                {2, "feb"},
                {3, "mar" },
                {4, "apr" },
                {5, "maj" },
                {6, "jun" },
                {7, "jul" },
                {8, "aug" },
                {9, "sep" },
                {10, "okt" },
                {11, "nov" },
                {12, "dec" }
            };
            string fileName = pfilePath.Split('\\').Last(); // finder filnavnet ved at splitte stien op og v�lge det sidste element
            int month = Months.Where(m => fileName.ToLower().Contains(m.Value)).Single().Key; // pr�ver at matche tre af filnavnets bogstaver med en v�rdi i min dictionary og returnerer denne v�rdis tilh�rende n�gle.
            if (month == 0)
            {
                throw new Exception("Der kunne ikke bestemmes en m�ned ud fra filnavnet");
            }
            int yearStartIndex = fileName.Length - 8;
            int year = 0;
            if (IsNumber(fileName.Substring(yearStartIndex, 4)))
            {
                year = Convert.ToInt32(fileName.Substring(yearStartIndex, 4));
            }
            if (year == 0)
            {
                throw new Exception("Der kunne ikke bestemmes et �rstal ud fra filnavnet. S�rg for, at filnavnet indeholder de 3 f�rste bogstaver af m�neden samt, at �rstallet st�r som det sidste i filnavnet, dvs.  ");
            }
            DateTime startdate = new DateTime(year, month, 1);
            return startdate;
        }
        private bool SalesDataObjectIsValid(SalesStatistics salesStat)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(salesStat.Product.Name) && !string.IsNullOrEmpty(salesStat.Product.SKU)) result = true;
            return result;
        }
        private bool IsNumber(string stringToBeChecke)
        {
            return int.TryParse(stringToBeChecke, out int integerOut);
        }

    }
}