﻿using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Repository
{
    public interface IMemoryDatabase
    {
        IList<Client> GetClientsFromParkingHouse(int id);
        IList<ParkingTimeInfoModel> GetCurrentUserParkingInfo(int i);
        void AddParkingInfo(int clientId, DateTime startdate, DateTime enddate);
    }
}
