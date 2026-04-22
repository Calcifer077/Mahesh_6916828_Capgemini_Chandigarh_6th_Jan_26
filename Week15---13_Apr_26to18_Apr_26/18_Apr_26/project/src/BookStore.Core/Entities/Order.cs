namespace BookStore.Core.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public ICollection<OrderItem> Items { get; set; } = [];
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
}

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int Qty { get; set; }
    public decimal Price { get; set; }
}

public class Review
{
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int Rating { get; set; }
    public string? Comment { get; set; }
}

public class Wishlist
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}

public class EmailLog
{
    public int EmailLogId { get; set; }
    public string ToEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public DateTime SentDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
