using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public int BaggageId { get; set; }
        public string LastCheckPoint { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }

        public virtual Baggage Baggage { get; set; }
    }
}
