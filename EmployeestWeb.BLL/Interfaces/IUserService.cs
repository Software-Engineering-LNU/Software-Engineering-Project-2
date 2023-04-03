namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IUserService
{
    void AddUser(User user);

    User? GetUser(long id);

    long? GetUserId(string email, string password);
}
