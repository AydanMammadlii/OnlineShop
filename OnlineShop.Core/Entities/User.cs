using System.Security.Principal;

namespace OnlineShop.Core.Entities;

public class User 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; } //unique
    public string? Password { get; set; }
    public bool? IsAdmin { get; set; }
    public Basket Basket { get; set; }
    public DateTime? CreatedDate { get; set; }

    public ICollection<Wallet> Wallets { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
}

