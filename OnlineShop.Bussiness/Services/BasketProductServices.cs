using DataAccess.Contexts;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;
using System.Diagnostics;

namespace OnlineShop.Bussiness.Services;

public class BasketProductServices : IBasketProductServices
{

    AppDbContext context = new();
    public async Task CreateBasketProductAsync(int productCount)
    {
        if (productCount < 1) throw new InvalidException("enter correct count");
        BasketProduct basketProduct = new BasketProduct()
        {
           ProductCount = productCount
        };
        await context.BasketProducts.AddAsync(basketProduct);
        await context.SaveChangesAsync();
    }

    public async Task DisableBasketProductAsync(int productCount)
    {
        BasketProduct? basketProduct = await context.BasketProducts.FindAsync(productCount);
        if (basketProduct == null) throw new NotFoundException("BasketProduct is empty");
        await context.SaveChangesAsync();
    }
}
