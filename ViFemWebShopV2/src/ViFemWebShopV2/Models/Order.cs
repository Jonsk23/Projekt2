using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViFemWebShopV2.Models
{
    public class Order
    {
        //public int OrderId { get; set; }
        public int ClientId { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
    }
}
