using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class InvoiceModel
    {
        private IList<InvoiceParkingInfo> _parkingInfo = new List<InvoiceParkingInfo>();

        public IList<InvoiceParkingInfo> parkingInfo
        {
            get { return _parkingInfo; }
            set { _parkingInfo = value; }
        }

        public decimal Price { get; set; }
    }

    public class InvoiceParkingInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BillableAmount { get; set; }
        public decimal Price { get; set; }
    }
}