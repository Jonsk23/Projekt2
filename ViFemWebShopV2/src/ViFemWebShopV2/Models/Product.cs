using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int ItemsInStock { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }

    }
}
