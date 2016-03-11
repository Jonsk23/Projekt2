using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddProductVM
    {
        [Display(Name = "Produktnamn: ")]
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Antal i lager: ")]
        public int Stock { get; set; }

        [Display(Name ="Pris: ")]
        [Required(ErrorMessage = "The product must have a price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Produktbeskrivning: ")]
        public string Description { get; set; }

        public SelectListItem[] Categories { get; set; }
        [Display(Name = "Kategori: ")]
        [Required(ErrorMessage = "Välj en kategori")]
        public string Category { get; set; }

        [Display(Name = "URL to image")]
        public string ImageURL { get; set; }

        //public bool IsActive { get; set; }
    }
}
