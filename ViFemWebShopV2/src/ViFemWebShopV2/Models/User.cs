using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class User
    {
        public int ClientID { get; set; }
        public int BusinessAccount { get; set; }
        public string Password { get; set; }
        public Address DeliveryAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNo { get; set; }
        public string Email { get; set; }

    }
}
