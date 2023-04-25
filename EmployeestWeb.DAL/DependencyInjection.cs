namespace EmployeestWeb.DAL;

using Interfaces;
using Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddDAL(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
    }
}