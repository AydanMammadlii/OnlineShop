namespace OnlineShop.Bussiness.Interfaces;

public interface IWalletService
{
    Task CreateWalletAsync(string cardName, int cardNumber, decimal balance, int userId);
    Task ShowAllActiveAsync();
    Task ShowAllDisactiveAsync();
    Task UpdateBalanceAsync(int userId, decimal newBalance);
    Task DisableWalletAsync(int userId);
}
