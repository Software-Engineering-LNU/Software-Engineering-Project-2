namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public long? RegisterUser(User user)
    {
        try
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            this.userRepository.GetUser(user.Email);
            return null;
        }
        catch (InvalidOperationException)
        {
            this.userRepository.AddUser(user);
            return user.Id;
        }
    }

    public long? AuthorizeUser(string email, string password)
    {
        try
        {
            User? user = this.userRepository.GetUser(email);

            if (user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                return user.Id;
            }

            return null;
        }
        catch (InvalidOperationException)
        {
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
