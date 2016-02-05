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
        public InvoiceModel ClaculateInvoice(Client client)
        {
            decimal timeRangePriceDay = (decimal)1.5;
            decimal timeRangePriceNight = (decimal)1.0;
            var parkingTimes = client.ParkingTimeList.Where(x => x.Calculated == false);
            var invoice = new InvoiceModel(client.Id);
            
            Calculate(invoice, parkingTimes, timeRangePriceDay, timeRangePriceNight);

            return invoice;

        }

        public InvoiceModel ClaculateInvoice(PremiumClient premiumClient)
        {
            decimal MaxInvoice = 300.0m;
            decimal monthlyFee = 20.0m;
            decimal timeRangePriceDay = 1.0m;
            decimal timeRangePriceNight = 0.75m;
            var parkingTimes = premiumClient.ParkingTimeList.Where(x => x.Calculated == false);
            var invoice = new InvoiceModel(premiumClient.Id);
            Calculate(invoice, parkingTimes, timeRangePriceDay, timeRangePriceNight);

            invoice.Price += monthlyFee;

            if (invoice.Price > MaxInvoice)
                invoice.Price = MaxInvoice;
            return invoice;
        }

        private void Calculate(InvoiceModel invoice, IEnumerable<ParkingTimeInfoModel> parkingTimes, decimal timeRangePriceDay, decimal timeRangePriceNight)
        {
            foreach (var time in parkingTimes)
            {
                var currentTime = time.StartTime;
                var parkingInfo = new InvoiceParkingInfo();
                parkingInfo.StartTime = time.StartTime;
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
                } while (currentTime < time.EndTime);
                parkingInfo.EndTime = time.EndTime;
                invoice.parkingInfo.Add(parkingInfo);
            }
        }
    }
}