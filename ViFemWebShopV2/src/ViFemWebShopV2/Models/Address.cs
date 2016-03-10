using System.ComponentModel.DataAnnotations;

namespace ViFemWebShopV2.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}