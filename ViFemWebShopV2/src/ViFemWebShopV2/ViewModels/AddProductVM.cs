using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddProductVM
    {
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity in stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The product must have a price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Display(Name = "URL to image")]
        public string ImageURL { get; set; }

        //public bool IsActive { get; set; }
    }
}
