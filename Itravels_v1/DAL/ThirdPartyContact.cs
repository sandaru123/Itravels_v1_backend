using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class ThirdPartyContact
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

        public virtual User User { get; set; }
    }
}
