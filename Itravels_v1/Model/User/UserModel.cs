using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Model.User
{
    public class UserModel
    {
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
    }


    public class UserUpdateModel
    {
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
    }
}
