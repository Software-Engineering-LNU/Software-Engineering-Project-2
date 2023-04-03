namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;

public class UserRepository : IUserRepository
{
    private readonly EmployeestWebDbContext context;

    public UserRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public void AddUser(User user)
    {
        this.context.Users!.Add(user);
        this.context.SaveChanges();
    }

    public User? GetUser(long id)
    {
        return this.context.Users?.Single(x => x.Id == id);
    }

    public long? GetUserId(string email, string password)
    {
        return this.context.Users?.Single(x => x.Email == email && x.Password.Equals(password)).Id;
    }
}
