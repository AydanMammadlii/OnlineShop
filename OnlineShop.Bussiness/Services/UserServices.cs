using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bussiness.Interfaces;
using OnlineShop.Bussiness.Utilities.Exceptions;
using OnlineShop.Core.Entities;

namespace OnlineShop.Bussiness.Services;

public class UserServices : IUserService
{
    AppDbContext context = new();
    public async Task LoginUserAsync(string email, string password)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();

        User? loginCheck = await context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();

        if (loginCheck == null) throw new InvalidException("incorrect email or password");
    }

    public async Task RegisterAsync(string name, string surname, string email, string password)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(surname)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(email)) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();

        User? userCheck = await context.Users.Where(u => u.Email ==email).FirstOrDefaultAsync();
        if (userCheck != null) throw new AlreadyExistException("this email already exist");

        User user = new()
        {
            Email = email,
            Password = password,
            Name = name,
            Surname = surname,
            CreatedDate = DateTime.Now,
            IsAdmin = false
        };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
}
