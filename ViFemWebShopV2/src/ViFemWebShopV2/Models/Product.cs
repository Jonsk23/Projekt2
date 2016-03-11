using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageURL { get; set; }

    }
}
