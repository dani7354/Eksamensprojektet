﻿using System;
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
            this.Name = brandName;
        }
        public string Name { get; set; }
    }
}
