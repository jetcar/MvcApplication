using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    [Serializable]
    public class InvoiceModel
    {
        public InvoiceModel(int clientId)
        {
            ClientId = clientId;
        }
        private IList<InvoiceParkingInfo> _parkingInfo = new List<InvoiceParkingInfo>();
        public int Id { get; set; }
        public int ClientId { get; internal set; }

        public IList<InvoiceParkingInfo> parkingInfo
        {
            get { return _parkingInfo; }
            set { _parkingInfo = value; }
        }

        public decimal Price { get; set; }
    }
}