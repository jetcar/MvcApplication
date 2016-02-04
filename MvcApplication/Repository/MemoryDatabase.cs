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
        private IList<Client> _clients = new List<Client>()
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
                    StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                    EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                    EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                },
                new ParkingTimeInfoModel()
                {
                    StartTime = DateTime.Today.AddHours(19).AddMinutes(40),
                    EndTime = DateTime.Today.AddHours(20).AddMinutes(35),
                },
            }},
        };

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

        public IList<ParkingTimeInfoModel> GetCurrentUserParkingInfo(int id)
        {
            var parkinginfos = new List<ParkingTimeInfoModel>();
            foreach (var parkingTimeInfo in _clients.Where(x => x.Id == id).SelectMany(x=>x.ParkingTimeList))
            {
                var clientCopy = ObjectCopier.Clone<ParkingTimeInfoModel>(parkingTimeInfo);
                parkinginfos.Add(clientCopy);
            }
            return parkinginfos;
        }
    }
}