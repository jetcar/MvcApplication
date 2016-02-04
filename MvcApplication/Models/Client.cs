using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Client
    {
        private IList<ParkingTimeInfoModel> _parkingTimeList = new List<ParkingTimeInfoModel>();
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParkingHouseId { get; set; }

        public IList<ParkingTimeInfoModel> ParkingTimeList
        {
            get { return _parkingTimeList; }
            set { _parkingTimeList = value; }
        }
    }

    public class PremiumClient : Client
    {
        
    }
}