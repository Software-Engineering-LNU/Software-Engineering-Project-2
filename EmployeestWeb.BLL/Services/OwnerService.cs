namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository ownerRepository;

    public OwnerService(IOwnerRepository ownerRepository)
    {
        this.ownerRepository = ownerRepository;
    }

    public string? GetUserName(long userId)
    {
        try
        {
            return this.ownerRepository.GetUser(userId).FullName;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        try
        {
            return this.ownerRepository.GetProjects(userId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
