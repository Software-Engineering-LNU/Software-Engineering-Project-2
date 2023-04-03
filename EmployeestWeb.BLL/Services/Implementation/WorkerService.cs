namespace EmployeestWeb.BLL.Services.Implementation
{
    using EmployeestWeb.BLL.Models;
    using EmployeestWeb.BLL.Services.Interfaces;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.DAL.Repositories.Interfaces;

    public sealed class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        public async System.Threading.Tasks.Task AddEmployee(User user)
        {
            if (user is not null)
            {
                await this.workerRepository.AddEmployee(user);
            }
        }

        public async System.Threading.Tasks.Task FireEmployeeByFireEmployeeModel(FireEmployeeModel model)
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                await this.workerRepository.RemoveEmployeeByEmail(model.Email);
            }

            if (!string.IsNullOrEmpty(model.PhoneNumber))
            {
                await this.workerRepository.RemoveEmployeeByPhoneNumber(model.PhoneNumber);
            }
        }
    }
}
