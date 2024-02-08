namespace OnlineShop.Bussiness.Interfaces;

public interface IAdminService
{
    Task loginAdmin(string email, string password);
}
