using System;

namespace Udkast_til_algoritme
{
    class Program
    {
        private DateTime CalculateOrderDate(Product pProduct, SalesPeriodInfo pFuturePeriod)
        {
            int previousPeriodDays = (pProduct.PreviousSalesPeriodInfo.End - pProduct.PreviousSalesPeriodInfo.Start).Days;
            double dailyQuantitySold = pProduct.PreviousSalesPeriodInfo.QuantitySold / previousPeriodDays;

            int futurePeriodDays = (pFuturePeriod.End - pFuturePeriod.Start).Days;
            double expectedDailySales = ((dailyQuantitySold / 100) * pFuturePeriod.GrowthInPercent) + dailyQuantitySold;
            int expectedDailySalesRounded = (int)Math.Ceiling(expectedDailySales); // Vi er interesseret i at have hele tal, og vi runder op for en sikkerhds skyld!

            // Udregnes med udgangspunkt i en lineær sammenhæng 
            double daysBeforeOutOfStock = (pProduct.CurrentQuantity - pProduct.MinQuantity) / expectedDailySalesRounded;
            DateTime OutOfStockDay = pFuturePeriod.Start.AddDays((int)daysBeforeOutOfStock);

            DateTime SuggestedOrderDate = OutOfStockDay.AddDays(-pProduct.Brand.LeadTimeInDays);

            if(SuggestedOrderDate > pFuturePeriod.End)
            {
                throw new Exception("Det bliver ikke nødvendigt at bestille flere af dette produkt! Det ville først være nødvendigt " + SuggestedOrderDate.ToString("dd-MM-yyyy"));
            }

            return SuggestedOrderDate;
        }
        private void Run()
        {
            Brand b1 = new Brand()
            {
                Name = "Anker",
                ProductionTimeInDays = 2,
                DeliveryTimeInDays = 10
            };

            SalesPeriodInfo previous = new SalesPeriodInfo()
            {
                Start = new DateTime(2018, 1, 1),
                End = new DateTime(2018, 4, 1),
                QuantitySold = 345
            };
            SalesPeriodInfo future = new SalesPeriodInfo()
            {
                Start = new DateTime(2018, 5, 1),
                End = new DateTime(2018, 9, 1),
                GrowthInPercent = 191.45
            };


            Product p1 = new Product()
            {
                SKU = "A8111H21",
                Name = "Anker Powerline MFI Lightning, 0.9 m kabel, Hvid",
                Brand = b1,
                StockPrice = 120.45,
                CurrentQuantity = 387,
                MinQuantity = 20,
                PreviousSalesPeriodInfo = previous
            };


            Console.WriteLine("Bestillingsdato for produktet er " + CalculateOrderDate(p1, future).ToString("dd-MM-yyyy"));

        }


        static void Main(string[] args)
        {
            Program program = new Program();

            try
            {

				program.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
