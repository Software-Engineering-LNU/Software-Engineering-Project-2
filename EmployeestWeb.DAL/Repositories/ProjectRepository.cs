namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;

public class ProjectRepository : IProjectRepository
{
    private readonly EmployeestWebDbContext context;

    public ProjectRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Project> GetAllProjects()
    {
        return this.context.Projects?
            .Include(p => p.ProjectMembers!).ThenInclude(p => p.Position)
            .Include(p => p.Teams)
            .Include(p => p.Owner)
            .ToList() ?? Enumerable.Empty<Project>();
    }

    public Project? GetProjectById(long id)
    {
        return this.context.Projects?
            .Include(p => p.ProjectMembers!).ThenInclude(p => p.Position)
            .Include(p => p.Teams)
            .Include(p => p.Owner)
            .FirstOrDefault(p => p.Id == id);
    }

    public void CreateProject(Project project)
    {
        this.context.Projects!.Add(project);
        this.context.SaveChanges();
    }

    public void UpdateProject(Project project)
    {
        this.context.Projects!.Update(project);
        this.context.SaveChanges();
    }

    public void DeleteProject(Project project)
    {
        foreach (var member in project.ProjectMembers!)
        {
            this.context.ProjectMembers!.Remove(member);
        }

        this.context.Projects?.Remove(project);
        this.context.SaveChanges();
    }
}
