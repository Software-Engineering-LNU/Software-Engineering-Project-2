namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using Serilog;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository ownerRepository;

    public OwnerService(IOwnerRepository ownerRepository)
    {
        this.ownerRepository = ownerRepository;
    }

    public string? GetUserName(long userId)
    {
        Log.Information("OwnerService GetUserName {@userId}", userId);
        try
        {
            User? user = this.ownerRepository.GetUser(userId);
            if (user != null)
            {
                return user.FullName;
            }

            return null;
        }
        catch (InvalidOperationException)
        {
            Log.Error("OwnerService GetUserName {@userId} InvalidOperationException", userId);
            return null;
        }
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        Log.Information("OwnerService GetProjects {@userId}", userId);
        try
        {
            return this.ownerRepository.GetProjects(userId);
        }
        catch (InvalidOperationException)
        {
            Log.Error("OwnerService GetProjects {@userId} InvalidOperationException", userId);
            return null;
        }
    }
}
