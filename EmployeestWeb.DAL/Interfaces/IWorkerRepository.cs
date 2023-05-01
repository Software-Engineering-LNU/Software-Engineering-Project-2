namespace EmployeestWeb.DAL.Interfaces
{
    using EmployeestWeb.DAL.Models;

    public interface IWorkerRepository
    {
        System.Threading.Tasks.Task AddEmployee(User user);

        System.Threading.Tasks.Task RemoveEmployeeByEmail(string email);

        System.Threading.Tasks.Task RemoveEmployeeByPhoneNumber(string phoneNumber);

        System.Threading.Tasks.Task<User?> GetEmployeeByEmail(string email);
    }
}