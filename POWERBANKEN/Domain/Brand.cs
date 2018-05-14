using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand
    {
        public string Name { get; set; }
        public int ID { get; set; }

		public Brand()
		{

		}

        public Brand(string brandName)
        {
            this.Name = brandName;
        }

        public Brand(int brandID)
        {
            ID = brandID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Brand)) return false;
            else
            {
                var b = (Brand)obj;
                return this.Name.Equals(b.Name);
            }
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
