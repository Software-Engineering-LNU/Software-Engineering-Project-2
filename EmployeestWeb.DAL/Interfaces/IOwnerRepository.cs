namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IOwnerRepository
{
    User GetUser(long userId);

    ICollection<Project>? GetProjects(long userId);
}
