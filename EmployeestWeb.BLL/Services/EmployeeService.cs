namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;
using Serilog;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public string? GetUserName(long userId)
    {
        Log.Information("EmployeeService GetUserName {@userId}", userId);
        try
        {
            User? user = this.employeeRepository.GetUser(userId);
            if (user != null)
            {
                return user.FullName;
            }

            return null;
        }
        catch (InvalidOperationException)
        {
            Log.Error("EmployeeService GetUserName {@userId} InvalidOperationException", userId);
            return null;
        }
    }

    public ICollection<Project>? GetProjects(long userId)
    {
        Log.Information("EmployeeService GetProjects {@userId}", userId);
        try
        {
            return this.employeeRepository.GetProjects(userId);
        }
        catch (InvalidOperationException)
        {
            Log.Error("EmployeeService GetProjects {@userId} InvalidOperationException", userId);
            return null;
        }
    }

    public ICollection<Task>? GetTasks(long userId)
    {
        Log.Information("EmployeeService GetTasks {@userId}", userId);
        try
        {
            return this.employeeRepository.GetTasks(userId);
        }
        catch (InvalidOperationException)
        {
            Log.Error("EmployeeService GetTasks {@userId} InvalidOperationException", userId);
            return null;
        }
    }

    public ICollection<Team>? GetTeams(long userId)
    {
        Log.Information("EmployeeService GetTeams {@userId}", userId);
        try
        {
            return this.employeeRepository.GetTeams(userId);
        }
        catch (InvalidOperationException)
        {
            Log.Error("EmployeeService GetTeams {@userId} InvalidOperationException", userId);
            return null;
        }
    }
}
