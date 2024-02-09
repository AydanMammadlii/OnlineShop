using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;
using System.Diagnostics;

namespace OnlineShop.Bussiness.Services;

public class InvoiceServices : IInvoiceServices
{
    AppDbContext context = new();
    public async Task CreateProductAsync(string status)
    {
        if (string.IsNullOrEmpty(status)) throw new ArgumentNullException();
        Invoice invoice = new Invoice()
        {
            Status = status,
            CreatedDate = DateTime.Now,
            isActive = true
        };
        await context.Invoices.AddAsync(invoice);
        await context.SaveChangesAsync();
    }

    public async Task DisableProductAsync(int userId)
    {
        Wallet? wallet = await context.Wallets.FindAsync(userId);
        if (wallet == null) throw new NotFoundException("Wallet is not found");
        wallet.isActive = false;
        await context.SaveChangesAsync();
    }

    public async Task ShowAllActiveAsync()
    {
        var invoices = await context.Invoices.Where(i => i.isActive == true).AsNoTracking().ToListAsync();
        foreach (var invoice in invoices)
        {
            Console.WriteLine($"Id: {invoice.Id}\n" +
                              $"Status: {invoice.Status}");
        }
    }

    public async Task ShowAllDisactiveAsync()
    {
        var invoices = await context.Invoices.Where(i => i.isActive == false).AsNoTracking().ToListAsync();
        foreach (var invoice in invoices)
        {
            Console.WriteLine($"Id: {invoice.Id}\n" +
                              $"Status: {invoice.Status}");
        }
    }

    public async Task UpdatePriceAsync(int id)
    {
        if (id < 1) throw new InvalidException("enter correct id");
        Wallet? wallet = await context.Wallets.FindAsync(id);
        if (wallet == null) throw new NotFoundException("Wallet is not found");
        wallet.Id = id;
        await context.SaveChangesAsync();
    }
}
