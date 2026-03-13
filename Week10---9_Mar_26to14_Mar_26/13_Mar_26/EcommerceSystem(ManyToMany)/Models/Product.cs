using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        // Navigation Property
        public List<Order>? Orders { get; set; }
    }
}