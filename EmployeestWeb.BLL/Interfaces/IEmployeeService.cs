namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IEmployeeService
{
    string GetUserName(long userId);

    ICollection<Project>? GetProjects(long userId);

    ICollection<Task>? GetTasks(long userId);

    ICollection<Team>? GetTeams(long userId);
}
