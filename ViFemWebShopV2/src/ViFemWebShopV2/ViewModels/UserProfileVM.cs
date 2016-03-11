using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class UserProfileVM
    {
        // Här ska inloggade kunder se sin medlemsinfo
        // och även sin orderhistorik.

        //Hämta informationen från kakan

        //Kan en lista hämtas och i så fall hur många proppar kommer behövas?


        //public string Email { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string Street { get; set; }

        //public string City { get; set; }

        //public string ZipCode { get; set; }

        public AddUserVM addUser { get; set; }
        public OrderVM[] orders { get; set; }
    }
}
