using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace ViewModels
{
    public class OrderNotificationViewModel : BaseViewModel
    {
        public OrderNotificationViewModel(MainViewModel viewModel)
        {
            OrderDates = viewModel.OrderDates;
            DaysInAdvance = viewModel.DaysInAdvance;
        }

        public Dictionary<Product, DateTime> OrderDates { get;  private set; }
        public int DaysInAdvance { get; private set; }

    }
}
