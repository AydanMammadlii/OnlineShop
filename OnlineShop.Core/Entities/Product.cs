namespace OnlineShop.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool isActive { get; set; } = true;
    public ICollection<BasketProduct?> BasketProducts { get; set; }
    public ICollection<ProductInvoice?> ProductInvoices { get; set; }
}
