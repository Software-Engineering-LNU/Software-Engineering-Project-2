namespace EmployeestWeb.DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;
using Serilog;

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
            .Include(task => task.User)
            .Include(task => task.Team).ThenInclude(t => t.Tasks)
            .ToList() ?? Enumerable.Empty<Task>();
    }

    public Task? GetTaskById(long id)
    {
        var toReturn = this.context.Tasks?
            .Include(task => task.User)
            .Include(task => task.Team).ThenInclude(t => t.Tasks)
            .Single(t => t.Id == id);

        if (toReturn == null)
        {
            Log.Error("Task with specified Id not found: " + Convert.ToString(id));
        }

        return toReturn;
    }

    public void CreateTask(Task task)
    {
        task.User = this.context.Users!.Find(task.UserId);
        task.Team = this.context.Teams!.Find(task.TeamId) !;
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
