using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Services;

public class AdminService : IAdminService
{
    AppDbContext context = new();
    public async Task loginAdmin(string email, string password)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();

        User? loginCheck = await context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

        if (loginCheck == null) throw new InvalidException("incorrect email or password");
        if (loginCheck.IsAdmin != true) throw new InvalidException("incorrect email or password");
    }
}
