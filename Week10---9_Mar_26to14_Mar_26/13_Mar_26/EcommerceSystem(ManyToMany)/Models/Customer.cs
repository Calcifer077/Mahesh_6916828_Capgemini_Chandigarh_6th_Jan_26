using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        // Navigation Property
        public List<Order>? Orders { get; set; }
    }
}