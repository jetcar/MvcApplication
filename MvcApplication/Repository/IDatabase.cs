using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Repository
{
    public interface IDatabase
    {
        IList<Client> GetClientsFromParkingHouse(int id);
        IList<ParkingTimeInfo> GetCurrentUserParkingInfo(int i);
        void AddParkingInfo(int clientId, DateTime startdate, DateTime enddate);
        IList<Invoice> GetClientInvoices(int clientId);
        Invoice GetClientInvoice(int id);
        Client GetClient(int id);
        void Save(Invoice invoice);
        void Save(IList<ParkingTimeInfo> parkingInfo);
    }
}
