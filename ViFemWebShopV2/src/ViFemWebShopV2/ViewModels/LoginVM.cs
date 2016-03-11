using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Ange användarnamn")]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ange lösenord")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
