using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.ThirdPartyContact
{
    public class ThirdPartyContactModel
    {
        public int UserId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string VehicleNumber { get; set; }
        public string Company { get; set; }
    }

    public class ThirdPartyContactUpdateModel
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string VehicleNumber { get; set; }
        public string Company { get; set; }
    }
}
