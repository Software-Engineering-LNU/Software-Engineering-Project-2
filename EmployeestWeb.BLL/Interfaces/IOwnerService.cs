namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IOwnerService
{
    string? GetUserName(long userId);

    ICollection<Project>? GetProjects(long userId);
}
