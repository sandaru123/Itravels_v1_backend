using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class TravelHistory
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; }
        public DateTime? TravelDate { get; set; }

        public virtual User User { get; set; }
    }
}
