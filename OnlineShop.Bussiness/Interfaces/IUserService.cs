namespace OnlineShop.Bussiness.Interfaces;

public interface IUserService
{
    Task LoginUserAsync(string email, string password);
    Task RegisterAsync(string name, string surname, string email, string password);
}
