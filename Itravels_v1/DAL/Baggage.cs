using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class Baggage
    {
        public Baggage()
        {
            Inquiry = new HashSet<Inquiry>();
            Location = new HashSet<Location>();
        }

        public int BaggageId { get; set; }
        public int UserId { get; set; }
        public double Weight { get; set; }
        public int? InventryId { get; set; }
        public double? Rfid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Inquiry> Inquiry { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
