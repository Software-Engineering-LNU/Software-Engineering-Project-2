namespace EmployeestWeb.BLL.Services;

using Interfaces;
using EmployeestWeb.DAL.Interfaces;
using DAL.Models;
using System;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public string? GetUserName(long userId)
    {
        try
        {
            return this.employeeRepository.GetUser(userId).FullName;
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
            return this.employeeRepository.GetProjects(userId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public ICollection<Task>? GetTasks(long userId)
    {
        try
        {
            return this.employeeRepository.GetTasks(userId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public ICollection<Team>? GetTeams(long userId)
    {
        try
        {
            return this.employeeRepository.GetTeams(userId);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
