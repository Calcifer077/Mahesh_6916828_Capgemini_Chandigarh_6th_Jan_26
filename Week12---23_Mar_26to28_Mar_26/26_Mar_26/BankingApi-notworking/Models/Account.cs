public class Account
{
    public int Id { get; set; }
    public string AccountHolderName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; } // Link to logged-in user
}