namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IUserRepository
{
    void AddUser(User user);

    User? GetUser(long id);

    long? GetUserId(string email, string password);
}
