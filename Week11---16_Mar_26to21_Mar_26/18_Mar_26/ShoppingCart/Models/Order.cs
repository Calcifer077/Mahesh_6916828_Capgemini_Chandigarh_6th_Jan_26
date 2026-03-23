using System.ComponentModel.DataAnnotations;

namespace ShoppingCartMvc.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}