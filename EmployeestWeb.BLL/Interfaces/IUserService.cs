namespace EmployeestWeb.BLL.Interfaces;

using EmployeestWeb.DAL.Models;

public interface IUserService
{
    User? RegisterUser(User user);

    User? AuthorizeUser(string email, string password);
}
