
namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductType
    {
        public ProductType(string typeName)
        {
            this.TypeName = typeName;
        }
        public string TypeName { get; set; }
        public int TypeID { get; set; }
      
    }
}
