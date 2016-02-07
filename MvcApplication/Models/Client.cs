using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    [Serializable]
    public abstract class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParkingHouseId { get; set; }

    }
}