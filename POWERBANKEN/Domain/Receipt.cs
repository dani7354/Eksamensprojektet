using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Receipt
    {
        public Receipt(DateTime orderDate, DateTime expectedDeliveryDate,
            DateTime actualDeliveryDate, int amount, double totalOrderPrice)
        {
            OrderDate = orderDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
            ActualDeliveryDate = actualDeliveryDate;
            Amount = amount;
            TotalOrderPrice = totalOrderPrice;
        }
        public DateTime OrderDate { get; set; }
        public Product Product { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public int Amount { get; set; }
        public double TotalOrderPrice { get; set; }


    }
}
