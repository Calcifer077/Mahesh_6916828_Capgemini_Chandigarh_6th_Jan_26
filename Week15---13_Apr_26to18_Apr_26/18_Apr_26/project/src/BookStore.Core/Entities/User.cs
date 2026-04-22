namespace BookStore.Core.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = [];
}

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public UserProfile? Profile { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<Wishlist> Wishlists { get; set; } = [];
}

public class UserProfile
{
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Pincode { get; set; }
}
