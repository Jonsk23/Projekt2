using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class AddProductVM
    {
      //  public string ProductID { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "The product needs a quantity")]
        [Range(1, 100000, ErrorMessage = "Quantity must be over 0")]
        [Display(Name = "Quantity")]
        public int ItemsInStock { get; set; }

        [Required(ErrorMessage = "Enter a price")]
        [Range(1, 100000, ErrorMessage = "Price must be over 0")]
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        //public bool IsActive { get; set; }
    }
}
