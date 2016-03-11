﻿using System.ComponentModel.DataAnnotations;


namespace ViFemWebShopV2.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
