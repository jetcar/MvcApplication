using System;

namespace MvcApplication.Models
{
    [Serializable]
    public class InvoiceParkingInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BillableAmount { get; set; }
        public decimal Price { get; set; }
    }
}