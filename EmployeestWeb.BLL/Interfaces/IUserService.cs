namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IUserService
{
    long? RegisterUser(User user);

    User? GetUser(long id);

    long? AuthorizeUser(string email, string password);
}
