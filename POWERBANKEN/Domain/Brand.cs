using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand
    {
        public Brand(string brandName)
        {
            this.BrandName = brandName;
        }
        string BrandName { get; set; }

        public override string ToString() => BrandName;
    }
}
