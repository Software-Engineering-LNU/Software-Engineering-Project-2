namespace EmployeestWeb.DAL
{
    using EmployeestWeb.DAL.Interfaces;
    using EmployeestWeb.DAL.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddDAL(this IServiceCollection services)
        {
            // Register services
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}