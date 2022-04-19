using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.Baggage
{
    public class BaggageModel
    {
        public int UserId { get; set; }
        public double Weight { get; set; }
        public int? InventryId { get; set; }
        public double? Rfid { get; set; }
    }

    public class BaggageUpdateModel
    {
        public int BaggageId { get; set; }
        public int UserId { get; set; }
        public double Weight { get; set; }
        public int? InventryId { get; set; }
        public double? Rfid { get; set; }
    }
}
