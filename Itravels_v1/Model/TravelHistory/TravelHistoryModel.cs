using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.TravelHistory
{
    public class TravelHistoryModel
    {
        public int UserId { get; set; }
        public string Country { get; set; }
        public DateTime? TravelDate { get; set; }
    }
    public class TravelHistoryUpdateModel
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; }
        public DateTime? TravelDate { get; set; }
    }

}
