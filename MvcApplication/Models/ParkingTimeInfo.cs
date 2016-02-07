using System;

namespace MvcApplication.Models
{
    [Serializable]
    public class ParkingTimeInfo
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ClientId { get; set; }
        public bool Calculated { get; set; }
    }
}