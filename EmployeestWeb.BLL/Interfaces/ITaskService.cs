namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface ITaskService
{
    IEnumerable<Task> GetAllTasks();

    Task? GetTaskById(long id);

    IEnumerable<Task> GetTasksByUserId(long userId);

    void CreateTask(Task task);

    void UpdateTask(long id, Task task);

    void DeleteTask(long id);
}
