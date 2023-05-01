namespace EmployeestWeb.BLL.Interfaces
{
    using EmployeestWeb.DAL.Models;

    public interface ITeamService
    {
        System.Threading.Tasks.Task AddEmployee(int teamId, string email);

        System.Threading.Tasks.Task RemoveEmployee(int teamId, string email, int userId);
    }
}
