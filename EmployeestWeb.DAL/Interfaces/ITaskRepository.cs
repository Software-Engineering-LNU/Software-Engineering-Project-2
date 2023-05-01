namespace EmployeestWeb.DAL.Interfaces;

using Models;

public interface ITaskRepository
{
    IEnumerable<Task> GetAllTasks();

    Task? GetTaskById(long id);

    void CreateTask(Task task);

    void UpdateTask(Task task);

    void DeleteTask(Task task);
}