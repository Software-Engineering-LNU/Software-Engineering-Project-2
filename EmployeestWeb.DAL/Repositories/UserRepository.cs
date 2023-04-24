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

    public User? GetUser(string email)
    {
        return this.context.Users?.Include(x => x.ProjectMembers)
            .Include(x => x.Projects)
            .Include(x => x.Tasks)
            .Include(x => x.TeamMembers)
            .Single(x => x.Email == email);
    }

    public bool Exist(string email)
    {
        try
        {
            this.context.Users?.Single(x => x.Email == email);
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
    }
}
