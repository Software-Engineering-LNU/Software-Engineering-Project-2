namespace EmployeestWeb.DAL
{
    using System.Runtime.CompilerServices;
    using EmployeestWeb.DAL.Repositories.Implementation;
    using EmployeestWeb.DAL.Repositories.Interfaces;
    using EmployeestWeb.DAL.Interfaces;
    using EmployeestWeb.DAL.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddDAL(this IServiceCollection services)
        {
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            // Register services
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}