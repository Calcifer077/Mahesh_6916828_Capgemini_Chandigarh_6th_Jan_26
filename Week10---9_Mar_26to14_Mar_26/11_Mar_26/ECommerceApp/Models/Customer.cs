using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}