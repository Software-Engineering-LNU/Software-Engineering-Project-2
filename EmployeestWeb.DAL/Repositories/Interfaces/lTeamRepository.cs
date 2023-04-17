namespace EmployeestWeb.DAL.Repositories.Interfaces
{
    using EmployeestWeb.DAL.Models;
    using Task = System.Threading.Tasks.Task;

    public interface ITeamRepository
    {
        Task AddEmployee(TeamMember teamMember);

        Task RemoveEmployee(TeamMember teamMember);
    }
}
