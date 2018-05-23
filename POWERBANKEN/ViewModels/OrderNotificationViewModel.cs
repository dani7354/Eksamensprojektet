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
            ProductOrderDates = viewModel.ProductNotifications;
            DaysInAdvance = viewModel.DaysInAdvance;
        }

        public List<Product> ProductOrderDates { get; private set; }
        public int DaysInAdvance { get; private set; }

    }
}
