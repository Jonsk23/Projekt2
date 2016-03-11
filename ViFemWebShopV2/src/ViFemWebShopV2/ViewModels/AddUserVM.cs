using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddUserVM
    {
        [Display(Name = "Organisationsnummer ")]
        [Required(ErrorMessage = "Company Number required")]
        public string CompanyNumber { get; set; }

        [Display(Name = "Företagslösenord ")]
        [Required(ErrorMessage = "Company Password required")]
        public string CompanyPassword { get; set; }

        [Display(Name = "Användarnamn ")]
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Display(Name = "E-mail ")]
        [Required(ErrorMessage = "E-mail required")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Förnamn (Valfritt) ")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn (Valfritt) ")]
        public string LastName { get; set; }

        [Display(Name = "Lösenord ")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Display(Name = "Gatuadress ")]
        [Required(ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Display(Name = "Stad")]
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Zip code required")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Five (5) digit zip code required")]
        public string ZipCode { get; set; }
    }
}
