namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IUserRepository
{
    void AddUser(User user);

    User? GetUser(long id);

    User? GetUser(string email);
}
