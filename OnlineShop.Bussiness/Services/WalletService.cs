using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;
using System.Diagnostics;

namespace OnlineShop.Bussiness.Services;

public class WalletService : IWalletService
{
    AppDbContext context = new();
    public async Task CreateWalletAsync(string cardName, int cardNumber, decimal balance, int userId)
    {
        if (string.IsNullOrEmpty(cardName)) throw new ArgumentNullException();
        if (balance < 1) throw new InvalidException("enter correct balance");
        if (cardNumber < 1) throw new InvalidException("enter correct number");
        Wallet wallet = new Wallet()
        {
            CardName = cardName,
            CardNumber = cardNumber,
            Balance = balance,
            isActive = true
        };
        await context.Wallets.AddAsync(wallet);
        await context.SaveChangesAsync();
    }

    public async Task DisableWalletAsync(int userId)
    {
        Wallet? wallet = await context.Wallets.FindAsync(userId);
        if (wallet == null) throw new NotFoundException("User is not found");
        wallet.isActive = false;
        await context.SaveChangesAsync();
    }

    public async Task ShowAllActiveAsync()
    {
        var wallets = await context.Wallets.Where(w => w.isActive == true).AsNoTracking().ToListAsync();
        foreach (var wallet in wallets)
        {
            Console.WriteLine($"Id: {wallet.Id}\n" +
                              $"CardName: {wallet.CardName}\n" +
                              $"CardNumber: {wallet.CardNumber}\n" +
                              $"Balance: {wallet.Balance}\n");
        }
    }

    public async Task ShowAllDisactiveAsync()
    {
        var wallets = await context.Wallets.Where(w => w.isActive == false).AsNoTracking().ToListAsync();
        foreach (var wallet in wallets)
        {
            Console.WriteLine($"Id: {wallet.Id}\n" +
                              $"CardName: {wallet.CardName}\n" +
                              $"CardNumber: {wallet.CardNumber}\n" +
                              $"Balance: {wallet.Balance}\n");
        }
    }

    public async Task UpdateBalanceAsync(int userId, decimal newBalance)
    {
        if (newBalance < 1) throw new InvalidException("enter correct balance");
        Wallet? wallet = await context.Wallets.FindAsync(userId);
        if (wallet == null) throw new NotFoundException("Wallet is not found");
        wallet.Balance = newBalance;
        await context.SaveChangesAsync();
    }
}
