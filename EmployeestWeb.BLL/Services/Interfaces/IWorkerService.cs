namespace EmployeestWeb.BLL.Services.Interfaces
{
    using EmployeestWeb.BLL.Models;
    using EmployeestWeb.DAL.Models;
    using Task = System.Threading.Tasks.Task;

    public interface IWorkerService
    {
        Task AddEmployee(User user);

        Task FireEmployeeByFireEmployeeModel(FireEmployeeModel model);
    }
}
