namespace EmployeestWeb.BLL.Services.Interfaces
{
    using EmployeestWeb.DAL.Models;

    public interface ITeamService
    {
        System.Threading.Tasks.Task AddEmployee(int teamId, string email);
    }
}
