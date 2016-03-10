using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class User
    {
        public int ClientID { get; set; }
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int DeliveryAddressID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
