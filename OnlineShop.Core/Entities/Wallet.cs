namespace OnlineShop.Core.Entities;

public class Wallet
{
    public int Id { get; set; }
    public string? CardName { get; set; }
    public int CardNumber { get; set; } //unique
    public decimal Balance { get; set; }
    public int UserId { get; set; }
    public bool isActive { get; set; } = true;
    public User? User { get; set; }
    public DateTime? CreatedData { get; set; }
}

