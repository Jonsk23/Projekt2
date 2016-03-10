using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "enter password")]
        public string Password { get; set; }
    }
}
