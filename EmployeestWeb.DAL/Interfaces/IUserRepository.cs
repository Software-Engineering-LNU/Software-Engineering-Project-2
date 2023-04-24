namespace EmployeestWeb.DAL.Interfaces;
using Models;

public interface IUserRepository
{
    void AddUser(User user);

    User? GetUser(string email);

    bool Exist(string email);
}
