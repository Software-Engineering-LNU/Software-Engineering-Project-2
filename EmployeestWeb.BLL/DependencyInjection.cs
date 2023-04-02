namespace EmployeestWeb.BLL;

using Interfaces;
using Services;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddBLL(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddHttpContextAccessor();
    }
}