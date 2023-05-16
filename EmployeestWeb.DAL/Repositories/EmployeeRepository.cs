namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Serilog;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeestWebDbContext context;

    public EmployeeRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public User? GetUser(long userId)
    {
        Log.Information("EmployeeRepository GetUser {@id}", userId);
        return this.context.Users?.Single(x => x.Id == userId);
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        Log.Information("EmployeeRepository GetProjects {@userId}", userId);
        return this.context.ProjectMembers?.Include(x => x.Project).Where(x => x.UserId == userId).Select(x => x.Project).ToList();
    }

    public ICollection<Task>? GetTasks(long userId)
    {
        Log.Information("EmployeeRepository GetTasks {@userId}", userId);
        return this.context.Tasks?.Include(x => x.Team).Where(x => x.UserId == userId).ToList();
    }

    public ICollection<Team>? GetTeams(long userId)
    {
        Log.Information("EmployeeRepository GeTeams {@userId}", userId);
        return this.context.TeamMembers?.Include(x => x.Team).Where(x => x.UserId == userId).Select(x => x.Team).ToList();
    }
}
