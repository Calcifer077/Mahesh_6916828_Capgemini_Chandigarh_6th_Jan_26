namespace EcommerceSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        // Foreign Keys
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        // Navigation Properties
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}