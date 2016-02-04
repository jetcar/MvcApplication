using MvcApplication.Models;
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
    }
}
