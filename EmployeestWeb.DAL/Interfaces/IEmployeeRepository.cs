namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IEmployeeRepository
{
    User GetUser(long userId);

    ICollection<Project>? GetProjects(long userId);

    ICollection<Task>? GetTasks(long userId);

    ICollection<Team>? GetTeams(long userId);
}
