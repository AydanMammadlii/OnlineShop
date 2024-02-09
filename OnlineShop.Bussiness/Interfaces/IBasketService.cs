using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Interfaces;

public interface IBasketService
{
    Task CreateProductToBasketAsync(int userId);
    Task DisableProductAsync(int userId);
}

