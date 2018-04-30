using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand
    {
        public Brand()
        {
        }

        public Brand(string brandName)
        {
            this.Name = brandName;
        }

        public Brand(int brandID)
        {
            BrandID = brandID;
        }

        public string Name { get; set; }
        public int BrandID { get; set; }
        public override string ToString()
        {
            return string.Format($"{Name}");
        }
    }
}
