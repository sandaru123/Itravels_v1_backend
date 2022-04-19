using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.Location
{
    public class LocationModel
    {
        public int BaggageId { get; set; }
        public string LastCheckPoint { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
    }

    public class LocationUpdateModel
    {
        public int LocationId { get; set; }
        public int BaggageId { get; set; }
        public string LastCheckPoint { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
    }
}
