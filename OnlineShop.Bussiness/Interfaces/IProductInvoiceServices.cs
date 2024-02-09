namespace OnlineShop.Bussiness.Interfaces;

public interface IProductInvoiceServices
{
    Task CreateProductInvoiceAsync(int productCount, decimal productPrice, decimal totalPrice);
    Task UpdateAsync(int productId, int invoiceId);
    Task DisableProductInvoiceAsync(int productId);
}
