using System;

namespace MvcApplication.Models
{
    public class ParkingTimeInfoModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Calculated { get; set; }
    }
}