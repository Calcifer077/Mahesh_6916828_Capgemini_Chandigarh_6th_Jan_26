namespace BookStore.Core.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = [];
}

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = [];
}

public class Publisher
{
    public int PublisherId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = [];
}

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public Category Category { get; set; } = null!;
    public Author Author { get; set; } = null!;
    public Publisher Publisher { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<Wishlist> Wishlists { get; set; } = [];
}
