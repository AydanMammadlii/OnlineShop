using DataAccess.Contexts;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Services;

public class BasketServices : IBasketService
{
    AppDbContext context = new();
    public async Task CreateProductToBasketAsync(int userId)
    {
        Basket basket = new Basket()
        {
            User = userId
        };
        await context.Baskets.AddAsync(basket);
        await context.SaveChangesAsync();
    }

    public async Task DisableProductAsync(int userId)
    {
        Basket? basket = await context.Baskets.FindAsync(userId);
        if (basket == null) throw new NotFoundException("basket is empty");

        await context.SaveChangesAsync();
    }
}
