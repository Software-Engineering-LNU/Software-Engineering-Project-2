namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

public class OwnerRepository : IOwnerRepository
{
    private readonly EmployeestWebDbContext context;

    public OwnerRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public User GetUser(long userId)
    {
        return this.context.Users.Single(x => x.Id == userId);
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        return this.context.Projects?.Include(x => x.Teams).Where(x => x.OwnerId == userId).ToList();
    }
}
