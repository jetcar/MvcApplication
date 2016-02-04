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
        private IList<Client> _clients = new List<Client>() { new Client { Id = 1, Name = "Regular1", ParkingHouseId = 1 }, new Client { Id = 2, Name = "Regular2", ParkingHouseId = 1 }, };

        public IList<Client> GetClientsFromParkingHouse(int id)
        {
            var clients = new List<Client>();
            foreach(var client in _clients.Where(x=>x.ParkingHouseId == id))
            {
                var clientCopy = ObjectCopier.Clone<Client>(client);
                clients.Add(clientCopy);
            }
            return clients;
        }
    }
}