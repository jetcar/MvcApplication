using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class ParkingInfo
    {
        public int ClientId { get; set; }
        public DateTime ParkingStartDate { get; set; }
        public DateTime ParkingEndDate { get; set; }
    }
}