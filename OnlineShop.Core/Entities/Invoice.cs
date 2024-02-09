namespace OnlineShop.Core.Entities;

public class Invoice
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime CreatedDate { get; set; }
    public string? Status { get; set; }
    public ICollection<ProductInvoice> ProductInvoices { get; set; }
}

