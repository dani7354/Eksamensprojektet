﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Delivery
    {
        public string DeliveryMethod { get; set; }
        public double DeliveryTime { get; set; }

		public Delivery(string deliveryMethod, double deliveryTime)
        {
            DeliveryMethod = deliveryMethod;
            DeliveryTime = deliveryTime;
        }
    }
}
