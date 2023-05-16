namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User? RegisterUser(User user)
    {
        Log.Information("UserService RegisterUser {@user}", user);
        try
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            this.userRepository.GetUser(user.Email);
            Log.Error("UserService RegisterUser User {@user} already exist", user);
            return null;
        }
        catch (InvalidOperationException)
        {
            this.userRepository.AddUser(user);
            return user;
        }
    }

    public User? AuthorizeUser(string email, string password)
    {
        try
        {
            Log.Information("UserService AuthorizedUser {@email} {@password}", email, password);
            User? user = this.userRepository.GetUser(email);

            if (user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                return user;
            }

            return null;
        }
        catch (InvalidOperationException)
        {
            Log.Information("UserService AuthorizedUser {@email} {@password} InvalidOperationException", email, password);
            return null;
        }
    }

    public User? GetUser(long id)
    {
        try
        {
            return this.userRepository.GetUser(id);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
