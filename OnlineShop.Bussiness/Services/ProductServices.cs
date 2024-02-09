using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Services;

public class ProductServices : IProductServices
{
    AppDbContext context = new();
    public async Task CreateProductAsync(string name, decimal price, int quantity)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        if(price <1) throw new InvalidException("enter correct price");
        if(quantity <1) throw new InvalidException("enter correct quantity");
        Product product = new Product()
        {
            Name = name,    
            Price = price,
            Quantity = quantity,
            isActive = true
        };
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task DisableProductAsync(int productId)
    {
        Product? product = await context.Products.FindAsync(productId);
        if (product == null) throw new NotFoundException("Product is not found");
        product.isActive = false;
        await context.SaveChangesAsync();
    }

    public async Task ShowAllActiveAsync()
    {
        var products = await context.Products.Where(p => p.isActive == true).AsNoTracking().ToListAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}\n" + 
                              $"Name: {product.Name}\n" + 
                              $"Price: {product.Price}\n" + 
                              $"Quantity: {product.Quantity}");
        }
    }

    public async Task ShowAllDisactiveAsync()
    {
        var products = await context.Products.Where(p => p.isActive == false).AsNoTracking().ToListAsync();
        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Price: {product.Price}\n" +
                              $"Quantity: {product.Quantity}");
        }
    }

    public async Task UpdatePriceAsync(int productId, decimal newPrice)
    {
        if(newPrice <1) throw new InvalidException("enter correct price");
        Product? product = await context.Products.FindAsync(productId);
        if (product == null) throw new NotFoundException("Product is not found");
        product.Price = newPrice;
        await context.SaveChangesAsync();
    }
}
