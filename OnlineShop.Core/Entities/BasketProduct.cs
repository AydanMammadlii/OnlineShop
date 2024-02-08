namespace OnlineShop.Core.Entities;

public class BasketProduct
{
    public int ProductId { get; set; }
    public int BasketId { get; set; }
    public Product Product { get; set; } = null!;
    public Basket Basket { get; set; } = null!;
    public int ProductCount { get; set; }
}