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
        [Display(Name = "Company Number")]
        [Required(ErrorMessage = "Company Number required")]
        public string CompanyNumber { get; set; }

        [Display(Name = "Company Password")]
        [Required(ErrorMessage = "Company Password required")]
        public string CompanyPassword { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail required")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "First name (optional)")]
        public string FirstName { get; set; }

        [Display(Name = "Last name (optional)")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password need to contain at least 1 number, 1 lowercase letter and 1 uppercase letter. Only letters A-Z are allowed.")]
        public string Password { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Zip code required")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Five (5) digit zip code required")]
        public string ZipCode { get; set; }
    }
}
