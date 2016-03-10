using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class BusinessAccount
    {
        public int AccountId { get; set; }
        public string BusinessName { get; set; }
        public Address CompanyAddress { get; set; }
        public string RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
