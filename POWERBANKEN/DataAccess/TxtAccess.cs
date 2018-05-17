using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TxtAccess
    {
        private const string FILE_PATH = "growth.txt"; 
        public TxtAccess()
        {
            if (!File.Exists(FILE_PATH))
            {
                File.WriteAllText(FILE_PATH, "0");
            }
        }
       
        public string ReadFile()
        {
           
            if (File.Exists(FILE_PATH))
            {
                return File.ReadAllText(FILE_PATH);
            }
            else
            {
                throw new Exception("Filen kunne ikke findes!");
            }
        }
        public void WriteToFile(string text)
        {
           
            File.WriteAllText(FILE_PATH, text);
        }
    }
}
