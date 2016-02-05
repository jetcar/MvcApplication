using MvcApplication.Models;
using MvcApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Repository
{
    public class MemoryDatabase : IMemoryDatabase
    {
        private IList<Client> _clients;
        private IList<InvoiceModel> _invoices;
        private int InvoiceSeq = 1;
        public MemoryDatabase()
        {
            _invoices = new List<InvoiceModel>();
            _clients = new List<Client>()
                {
                    new Client { Id = 1, Name = "Regular1", ParkingHouseId = 1 ,ParkingTimeList =
                    {
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(8).AddMinutes(12),
                            EndTime = DateTime.Today.AddHours(10).AddMinutes(45),
                        },
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                            EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                        }
                    }},
                    new PremiumClient { Id = 2, Name = "Premium1", ParkingHouseId = 1 ,ParkingTimeList =
                    {
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(8).AddMinutes(12),
                            EndTime = DateTime.Today.AddHours(10).AddMinutes(45),
                        },
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(7).AddMinutes(2),
                            EndTime = DateTime.Today.AddHours(11).AddMinutes(56),
                        },
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(22).AddMinutes(10),
                            EndTime = DateTime.Today.AddHours(22).AddMinutes(35),
                        },
                        new ParkingTimeInfoModel()
                        {
                            StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                            EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                        },
                    }},
                };
        }

        public IList<Client> GetClientsFromParkingHouse(int id)
        {
            var clients = new List<Client>();
            foreach (var client in _clients.Where(x => x.ParkingHouseId == id))
            {
                var clientCopy = ObjectCopier.Clone<Client>(client);
                clients.Add(clientCopy);
            }
            return clients;
        }

        public IList<ParkingTimeInfoModel> GetCurrentUserParkingInfo(int id)
        {
            var parkinginfos = new List<ParkingTimeInfoModel>();
            foreach (var parkingTimeInfo in _clients.Where(x => x.Id == id).SelectMany(x => x.ParkingTimeList))
            {
                var clientCopy = ObjectCopier.Clone<ParkingTimeInfoModel>(parkingTimeInfo);
                parkinginfos.Add(clientCopy);
            }
            return parkinginfos;
        }

        public void AddParkingInfo(int clientId, DateTime startdate, DateTime enddate)
        {
            var client = _clients.FirstOrDefault(x => x.Id == clientId);
            if (client == null)
                throw new Exception("user not found");
            client.ParkingTimeList.Add(new ParkingTimeInfoModel() { StartTime = startdate, EndTime = enddate });
        }

        public IList<InvoiceModel> GetClientInvoices(int clientId)
        {
            var invoices = new List<InvoiceModel>();
            foreach (var invoice in _invoices.Where(x => x.ClientId == clientId))
            {
                var invoiceCopy = ObjectCopier.Clone(invoice);
                invoices.Add(invoiceCopy);
            }
            return invoices;
        }

        public Client GetClient(int id)
        {
            var client = _clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
                throw new Exception("Client not found");
            return ObjectCopier.Clone(client);
        }

        public InvoiceModel GetClientInvoice(int id)
        {
            var invoice = _invoices.FirstOrDefault(x => x.Id == id);
            if (invoice == null)
                throw new Exception("Invoice not found");
            return ObjectCopier.Clone(invoice);
        }

        public void Save(InvoiceModel invoice)
        {
            invoice.Id = InvoiceSeq++;
            _invoices.Add(invoice);
        }
    }
}