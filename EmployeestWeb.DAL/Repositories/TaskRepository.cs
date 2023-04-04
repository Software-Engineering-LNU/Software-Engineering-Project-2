namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;

public class TaskRepository : ITaskRepository
{
    private readonly EmployeestWebDbContext context;

    public TaskRepository(EmployeestWebDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Task> GetAllTasks()
    {
        return this.context.Tasks?
            .Include(t => t.Team).ThenInclude(t => t.Project)
            .Include(t => t.User!)
            .ToList() ?? Enumerable.Empty<Task>();
    }

    public Task? GetTaskById(long id)
    {
        return this.context.Tasks?
            .Include(t => t.Team).ThenInclude(t => t.Project)
            .Include(t => t.User!)
            .FirstOrDefault(t => t.Id == id);
    }

    public void CreateTask(Task task)
    {
        this.context.Tasks!.Add(task);
        this.context.SaveChanges();
    }

    public void UpdateTask(Task task)
    {
        this.context.Tasks!.Update(task);
        this.context.SaveChanges();
    }

    public void DeleteTask(Task task)
    {
        this.context.Tasks?.Remove(task);
        this.context.SaveChanges();
    }
}
