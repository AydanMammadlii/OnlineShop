namespace OnlineShop.Core.Entities;

public class ProductInvoice
{
    public int ProductCount { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductId { get; set; }
    public int InvoiceId { get; set; }
    public Product Product { get; set; } = null!;
    public Invoice Invoice { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
}

