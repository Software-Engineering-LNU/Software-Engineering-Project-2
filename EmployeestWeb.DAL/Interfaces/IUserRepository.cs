namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IUserRepository
{
    void AddUser(User user);

    User? GetUser(string email);

    User? GetUser(long id);

    bool Exist(string email);
}
