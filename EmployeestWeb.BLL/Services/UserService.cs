namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        if (user == null)
        {
            var errorMessage = $"User cannot be null.";
            throw new ArgumentNullException(nameof(user), errorMessage);
        }

        this.userRepository.AddUser(user);
    }

    public User? GetUser(long id)
    {
        var user = this.userRepository.GetUser(id);
        return user;
    }

    public long? GetUserId(string email, string password)
    {
        return this.userRepository.GetUserId(email, password);
    }
}
