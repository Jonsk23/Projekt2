using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.ViewModels
{
    public class ListProductsVM
    {
        [Display(Description = "Produktnamn: ")]
        public string Name { get; set; }

        [Display(Description = "Produktkategori: ")]
        public string Category { get; set; }

        [Display(Description = "Pris: ")]
        public int Price { get; set; }

        [Display(Description = "Beskrivning: ")]
        public string Description { get; set; }

    }
}
