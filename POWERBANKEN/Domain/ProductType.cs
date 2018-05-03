namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductType
    {
        private int productTypeID;

        public ProductType()
        {
        }

        public ProductType(string typeName)
        {
            this.Name = typeName;
        }

        public ProductType(int productTypeID)
        {
            this.productTypeID = productTypeID;
        }

        public string Name { get; set; }
        public int TypeID
        {
            get
            {
                return productTypeID;
            }
            set
            {
                productTypeID = value;
            }
        }

        //public override string ToString()
        //{
        //    return string.Format($"{Name}");
        //}

    }
}
