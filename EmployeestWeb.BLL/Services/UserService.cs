namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User? RegisterUser(User user)
    {
        if (!this.userRepository.Exist(user.Email))
        {
            this.userRepository.AddUser(user);
            return user;
        }
        else
        {
            return null;
        }
    }

    public User? AuthorizeUser(string email, string password)
    {
        try
        {
            User? user = this.userRepository.GetUser(email);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            }

            return null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
