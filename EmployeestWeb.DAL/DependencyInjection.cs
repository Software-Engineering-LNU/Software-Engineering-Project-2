namespace EmployeestWeb.DAL
{
    using System.Runtime.CompilerServices;
    using EmployeestWeb.DAL.Repositories.Implementation;
    using EmployeestWeb.DAL.Repositories.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddDAL(this IServiceCollection services)
        {
            // Register services
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
        }
    }
}
