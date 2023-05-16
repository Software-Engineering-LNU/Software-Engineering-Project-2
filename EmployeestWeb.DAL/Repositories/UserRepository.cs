namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using Serilog;

public class UserRepository : IUserRepository
{
    private readonly EmployeestWebDbContext context;

    public UserRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public void AddUser(User user)
    {
        Log.Information("UserRepository AddUser {@user}", user);
        this.context.Users!.Add(user);
        this.context.SaveChanges();
    }

    public User? GetUser(long id)
    {
        Log.Information("UserRepository GetUser {@id}", id);
        return this.context.Users?
            .Include(u => u.Tasks)
            .ThenInclude(t => t.Team)
            .Include(u => u.TeamMembers)
            .Include(p => p.Projects)
            .ThenInclude(p => p.ProjectMembers)
            .Include(u => u.ProjectMembers)
            .ThenInclude(p => p.Project)
            .ThenInclude(p => p.Owner)
            .Single(u => id == u.Id);
    }

    public User? GetUser(string email)
    {
        Log.Information("UserRepository GetUser {@email}", email);
        return this.context.Users?
            .Include(u => u.Tasks)
            .ThenInclude(t => t.Team)
            .Include(u => u.TeamMembers)
            .Include(p => p.Projects)
            .ThenInclude(p => p.ProjectMembers)
            .Include(u => u.ProjectMembers)
            .ThenInclude(p => p.Project)
            .ThenInclude(p => p.Owner)
            .Single(user => user.Email.Equals(email));
    }

    public bool Exist(string email)
    {
        Log.Information("UserRepository Exist {@email}", email);
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
