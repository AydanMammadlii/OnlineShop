namespace OnlineShop.Bussiness.Interfaces;

public interface IProductServices
{
    Task CreateProductAsync(string name, decimal price, int quantity);
    Task ShowAllActiveAsync();
    Task ShowAllDisactiveAsync();
    Task UpdatePriceAsync(int productId, decimal newPrice);
    Task DisableProductAsync(int productId);
}
