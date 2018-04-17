using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductType
    {
        public ProductType(string typeName)
        {
            this.TypeName = typeName;
        }

        string TypeName { get; set; }




        public override string ToString() => TypeName;
    }
}
