using System;
using System.Collections.Generic;

namespace Itravels_v1.DAL
{
    public partial class User
    {
        public User()
        {
            Baggage = new HashSet<Baggage>();
            BoardingPass = new HashSet<BoardingPass>();
            ThirdPartyContact = new HashSet<ThirdPartyContact>();
            TravelHistory = new HashSet<TravelHistory>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string UserRegNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Baggage> Baggage { get; set; }
        public virtual ICollection<BoardingPass> BoardingPass { get; set; }
        public virtual ICollection<ThirdPartyContact> ThirdPartyContact { get; set; }
        public virtual ICollection<TravelHistory> TravelHistory { get; set; }
    }
}
