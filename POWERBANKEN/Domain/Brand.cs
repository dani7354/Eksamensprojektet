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


        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
