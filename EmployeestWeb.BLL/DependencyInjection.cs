namespace EmployeestWeb.BLL
{
    using EmployeestWeb.BLL.Interfaces;
    using EmployeestWeb.BLL.Services;
    using EmployeestWeb.BLL.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddBLL(this IServiceCollection services)
        {
            // Register services
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();
        }
    }
}