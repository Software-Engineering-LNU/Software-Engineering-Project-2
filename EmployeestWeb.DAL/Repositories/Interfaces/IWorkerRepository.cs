namespace EmployeestWeb.DAL.Repositories.Interfaces
{
    using EmployeestWeb.DAL.Models;
    using Task = System.Threading.Tasks.Task;

    public interface IWorkerRepository
    {
        Task AddEmployee(User user);

        Task RemoveEmployeeByEmail(string email);

        Task RemoveEmployeeByPhoneNumber(string phoneNumber);

        Task<User?> GetEmployeeByEmail(string email);
    }
}