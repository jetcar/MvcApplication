using System.Collections.Generic;
using MvcApplication.Models;

namespace MvcApplication.Services
{
    public interface IInvoiceCalculator
    {
        InvoiceModel CalculateInvoice(Client client, IList<ParkingTimeInfoModel> parkingInfo);
    }
}