namespace EmployeestWeb.BLL
{
    using EmployeestWeb.BLL.Services.Implementation;
    using EmployeestWeb.BLL.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddTransient<IWorkerService, WorkerService>();
        }
    }
}
