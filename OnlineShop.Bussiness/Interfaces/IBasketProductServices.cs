using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Interfaces;

public interface IBasketProductServices
{
    Task CreateBasketProductAsync(int productCount);
    Task DisableBasketProductAsync(int productCount);
}
