using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.Models;

namespace MvcApplication.Services
{
    public class InvoiceCalculator : IInvoiceCalculator
    {
        private const int DAYSTARTHOUR = 7;
        private const int NIGHTSTARTHOUR = 19;
        private const int PARKINGMINTIMERANGE = 30;

        public Invoice CalculateInvoice(Client client, IList<ParkingTimeInfo> parkingTimes)
        {
            if (client is RegularClient)
            {
                return CalculateInvoice(client as RegularClient, parkingTimes);
            }
            if (client is PremiumClient)
            {
                return CalculateInvoice(client as PremiumClient, parkingTimes);
            }
            return null;
        }
        private Invoice CalculateInvoice(RegularClient client, IList<ParkingTimeInfo> parkingTimes)
        {
            decimal timeRangePriceDay = (decimal)1.5;
            decimal timeRangePriceNight = (decimal)1.0;
            var invoice = new Invoice(client.Id);
            
            Calculate(invoice, parkingTimes, timeRangePriceDay, timeRangePriceNight);

            return invoice;

        }

        private Invoice CalculateInvoice(PremiumClient premiumClient, IList<ParkingTimeInfo> parkingTimes)
        {
            decimal MaxInvoice = 300.0m;
            decimal monthlyFee = 20.0m;
            decimal timeRangePriceDay = 1.0m;
            decimal timeRangePriceNight = 0.75m;
            var invoice = new Invoice(premiumClient.Id);
            Calculate(invoice, parkingTimes, timeRangePriceDay, timeRangePriceNight);

            invoice.Price += monthlyFee;

            if (invoice.Price > MaxInvoice)
                invoice.Price = MaxInvoice;
            return invoice;
        }

        private void Calculate(Invoice invoice, IEnumerable<ParkingTimeInfo> parkingTimes, decimal timeRangePriceDay, decimal timeRangePriceNight)
        {
            foreach (var parkingTime in parkingTimes)
            {
                var currentTime = parkingTime.StartTime;
                var parkingInfo = new InvoiceParkingInfo();
                parkingInfo.StartTime = parkingTime.StartTime;
                do
                {
                    if (currentTime.Hour >= DAYSTARTHOUR && currentTime.Hour < NIGHTSTARTHOUR)
                    {
                        invoice.Price += timeRangePriceDay;
                        parkingInfo.BillableAmount++;
                        parkingInfo.Price += timeRangePriceDay;
                    }
                    else
                    {
                        invoice.Price += timeRangePriceNight;
                        parkingInfo.BillableAmount++;
                        parkingInfo.Price += timeRangePriceNight;

                    }
                    currentTime = currentTime.AddMinutes(PARKINGMINTIMERANGE);
                } while (currentTime < parkingTime.EndTime);
                parkingInfo.EndTime = parkingTime.EndTime;
                parkingTime.Calculated = true;
                invoice.parkingInfo.Add(parkingInfo);
                
            }
        }
    }
}