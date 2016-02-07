using System.Collections.Generic;
using MvcApplication.Models;

namespace MvcApplication.Services
{
    public interface IInvoiceCalculator
    {
        Invoice CalculateInvoice(Client client, IList<ParkingTimeInfo> parkingInfo);
    }
}