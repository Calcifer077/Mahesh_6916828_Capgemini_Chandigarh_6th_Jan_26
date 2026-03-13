namespace ECommerceApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    }
}