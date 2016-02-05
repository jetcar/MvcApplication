using System.Collections.Generic;
using MvcApplication.Models;

namespace MvcApplication.Services
{
    public interface IInvoiceCalculator
    {
        InvoiceModel ClaculateInvoice(Client client);
        InvoiceModel ClaculateInvoice(PremiumClient premiumClient);
    }
}