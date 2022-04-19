using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.BoardingPass
{
    public class BoardingPassModel
    {
        public int UserId { get; set; }
        public string Class { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlyingDate { get; set; }
        public TimeSpan? Boardingtime { get; set; }
        public string Gate { get; set; }
        public string SeatNumber { get; set; }
        public string FromCountry { get; set; }
        public string ToCountry { get; set; }
        public string PassportNumber { get; set; }
        public string Zone { get; set; }

    }

    public class BoardingPassUpdateModel
    {
        public int PassId { get; set; }
        public int UserId { get; set; }
        public string Class { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlyingDate { get; set; }
        public TimeSpan? Boardingtime { get; set; }
        public string Gate { get; set; }
        public string SeatNumber { get; set; }
        public string FromCountry { get; set; }
        public string ToCountry { get; set; }
        public string PassportNumber { get; set; }
        public string Zone { get; set; }

    }
}
