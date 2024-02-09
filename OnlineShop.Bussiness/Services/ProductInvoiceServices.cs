using DataAccess.Contexts;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;
using System.Diagnostics;

namespace OnlineShop.Bussiness.Services;

public class ProductInvoiceServices : IProductInvoiceServices
{
    AppDbContext context = new();
    public async Task CreateProductInvoiceAsync(int productCount, decimal productPrice, decimal totalPrice)
    {
        if (productCount < 1) throw new InvalidException("enter correct count");
        if (productPrice < 1) throw new InvalidException("enter correct price");
        if (totalPrice < 1) throw new InvalidException("enter correct total price");
        ProductInvoice productInvoice = new ProductInvoice()
        {
            ProductCount = productCount,
            ProductPrice = productPrice,
            TotalPrice = totalPrice
        };
        await context.ProductInvoices.AddAsync(productInvoice);
        await context.SaveChangesAsync();
    }

    public async Task DisableProductInvoiceAsync(int productId)
    {
        ProductInvoice? productInvoice = await context.ProductInvoices.FindAsync(productId);
        if (productInvoice == null) throw new NotFoundException("ProductInvoice is not found");
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int productId, int invoiceId)
    {
        if (productId < 1) throw new InvalidException("enter correct Id");
        if (invoiceId < 1) throw new InvalidException("enter correct Id");
        ProductInvoice? productInvoice = await context.ProductInvoices.FindAsync(productId);
        if (productInvoice == null) throw new NotFoundException("ProductInvoice is not found");
        productInvoice.ProductId = productId;
        productInvoice.InvoiceId = invoiceId;
        await context.SaveChangesAsync();
    }
}
