using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
