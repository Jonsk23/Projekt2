using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddUserVM
    {
       // public int BusinessAccount { get; internal set; }
       // public int ClientID { get; internal set; }
        //public string DeliveryAddress { get; internal set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Password { get; internal set; }
        public string SocialSecurityNo { get; internal set; }
    }
}
