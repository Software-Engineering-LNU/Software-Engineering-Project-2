namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeestWebDbContext context;

    public EmployeeRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public User? GetUser(long userId)
    {
        return this.context.Users?.Single(x => x.Id == userId);
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        return this.context.ProjectMembers?.Include(x => x.Project).Where(x => x.UserId == userId).Select(x => x.Project).ToList();
    }

    public ICollection<Task>? GetTasks(long userId)
    {
        return this.context.Tasks?.Include(x => x.Team).Where(x => x.UserId == userId).ToList();
    }

    public ICollection<Team>? GetTeams(long userId)
    {
        return this.context.TeamMembers?.Include(x => x.Team).Where(x => x.UserId == userId).Select(x => x.Team).ToList();
    }
}
