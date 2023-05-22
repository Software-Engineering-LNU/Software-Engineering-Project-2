namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using Serilog;

public class ProjectRepository : IProjectRepository
{
    private readonly EmployeestWebDbContext context;

    public ProjectRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Project> GetAllProjects()
    {
        Log.Information("ProjectRepository GetAllProjects");
        return this.context.Projects?
            .Include(p => p.ProjectMembers!).ThenInclude(p => p.Position)
            .Include(p => p.Teams)
            .Include(p => p.Owner)
            .ToList() ?? Enumerable.Empty<Project>();
    }

    public Project? GetProjectById(long id)
    {
        Log.Information("ProjectRepository GetProjectById {@id}", id);
        return this.context.Projects?
            .Include(p => p.ProjectMembers!).ThenInclude(p => p.Position)
            .Include(p => p.Teams)
            .Include(p => p.Owner)
            .FirstOrDefault(p => p.Id == id);
    }

    public void CreateProject(Project project)
    {
        Log.Information("ProjectRepository CreateProject {@project}", project);
        this.context.Projects!.Add(project);
        this.context.SaveChanges();
    }

    public void UpdateProject(Project project)
    {
        Log.Information("ProjectRepository UpdateProject {@project}", project);
        this.context.Projects!.Update(project);
        this.context.SaveChanges();
    }

    public void DeleteProject(Project project)
    {
        Log.Information("ProjectRepository DeleteProject {@project}", project);
        foreach (var member in project.ProjectMembers!)
        {
            this.context.ProjectMembers!.Remove(member);
        }

        this.context.Projects?.Remove(project);
        this.context.SaveChanges();
    }
}
