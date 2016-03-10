using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddUserVM
    {
        // public int BusinessAccount { get; internal set; }
        // public int ClientID { get; internal set; }
        //public string DeliveryAddress { get; internal set; }

        [Required(ErrorMessage = "E-mail required")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; internal set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; internal set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; internal set; }

        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password need to contain at least 1 number, 1 lowercase letter and 1 uppercase letter. Only letters A-Z are allowed.")]
        public string Password { get; internal set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }

        [Display(Name = "Zip code")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Five (5) digit zip code required")]
        public string ZipCode { get; set; }
    }
}
