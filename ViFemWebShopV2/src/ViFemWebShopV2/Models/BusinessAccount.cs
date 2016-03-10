using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class BusinessAccount
    {
        [Key]
        public int AccountId { get; set; }
        public string BusinessName { get; set; }
        public int CompanyAddressID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
 