namespace OnlineShop.Bussiness.Interfaces;

public interface IInvoiceServices
{
    Task CreateProductAsync(string status);
    Task ShowAllActiveAsync();
    Task ShowAllDisactiveAsync();
    Task UpdatePriceAsync(int id);
    Task DisableProductAsync(int userId);
}
