namespace OnlineShop.Core.Entities;

public class Basket
{
    public int Id { get; set; }
    public User? User { get; set; }
    public ICollection<BasketProduct> BasketProducts { get; set; }
}

