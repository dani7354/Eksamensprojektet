using System;
namespace Udkast_til_algoritme
{
    public class Brand
    {
        private int _productionTimeInDays;
        private int _deliveryTimeInDays;

        public string Name { get; set; }

        public int ProductionTimeInDays 
        {
            get
            {
                return _productionTimeInDays;   
            }
            set
            {
                _productionTimeInDays = value;
                LeadTimeInDays = _productionTimeInDays + _deliveryTimeInDays; 
            }
            
        }



        public int DeliveryTimeInDays 
        {
            get
            {
                return _deliveryTimeInDays; 
            }
            set
            {
                _deliveryTimeInDays = value;
                LeadTimeInDays = _productionTimeInDays + _deliveryTimeInDays;
                
            }
            
        }
        public int LeadTimeInDays { get; private set; }

    }
}
